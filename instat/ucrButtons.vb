﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat.Translations

Public Class ucrButtons
    Public clsRsyntax As RSyntax
    Public iHelpTopicID As Integer
    Public bFirstLoad As Boolean
    Public Event BeforeClickOk(sender As Object, e As EventArgs)
    Public Event ClickOk(sender As Object, e As EventArgs)
    Public Event ClickReset(sender As Object, e As EventArgs)
    Public Event ClickClose(sender As Object, e As EventArgs)
    Private strCurrLang As String
    Private bCommentChangedInThisDialog, bLoadInProgress As Boolean

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        clsRsyntax = New RSyntax
        iHelpTopicID = -1
        bFirstLoad = True
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.ParentForm.Close()
        RaiseEvent ClickClose(sender, e)
    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        SetDefaults()
        RaiseEvent ClickReset(sender, e)
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        RunFormScripts(sender, e, True)
    End Sub

    Private Sub cmdPaste_Click(sender As Object, e As EventArgs) Handles cmdPaste.Click
        Scripts(bRun:=False)
        ParentForm.Close()
    End Sub

    Private Sub toolStripMenuItemOkClose_Click(sender As Object, e As EventArgs) Handles toolStripMenuItemOkClose.Click
        RunFormScripts(sender, e, True)
    End Sub

    Private Sub toolStripMenuItemOkKeep_Click(sender As Object, e As EventArgs) Handles toolStripMenuItemOkKeep.Click
        RunFormScripts(sender, e, False)
    End Sub

    Private Sub toolStripMenuItemToScriptClose_Click(sender As Object, e As EventArgs) Handles toolStripMenuItemToScriptClose.Click
        Scripts(bRun:=False)
        ParentForm.Close()
    End Sub

    Private Sub toolStripMenuItemToScriptKeep_Click(sender As Object, e As EventArgs) Handles toolStripMenuItemToScriptKeep.Click
        Scripts(bRun:=False)
    End Sub

    Private Sub txtComment_TextChanged(sender As Object, e As EventArgs) Handles txtComment.TextChanged
        ' only set the flag if the user changes the text (not when the dialog is loading)
        If Not bLoadInProgress Then
            bCommentChangedInThisDialog = True
        End If
    End Sub

    Private Sub RunFormScripts(sender As Object, e As EventArgs, bCloseForm As Boolean)
        Dim lstCurrentEnabled As New List(Of Boolean)
        Dim ctrTempControl As Control
        Dim j As Integer

        'this is getting the current controls on the form and disables then to prevent user to interract with form when its running
        For Each ctrTempControl In ParentForm.Controls
            lstCurrentEnabled.Add(ctrTempControl.Enabled)
            ctrTempControl.Enabled = False
        Next
        ParentForm.Cursor = Cursors.WaitCursor

        RaiseEvent BeforeClickOk(sender, e)
        Scripts(bRun:=True)
        RaiseEvent ClickOk(sender, e)

        'Need to be resetting other AssignTo values as well, maybe through single method

        'Warning: these reinitializing processes of the RSyntax parameters should probably be integrated at the end of GetScript. 
        'However, for the moment, RSyntax is not playing it's role of capturing the whole set of R-commands that the user wants to run when OK is Cklicked. 
        'Indeed, the events BeforeClickOk and ClickOk enables for the moment to insert R-commands before and after the Base R-command handle. 
        'In the process, we want the RSyntax parameters to be set as at the end of GetScript. Hence the reset needs to come after.
        'Eventually, all this should be more neatly incorporated in the RSyntax machinery...

        If bCloseForm Then
            ParentForm.Close()
        End If

        j = 0
        For Each ctrTempControl In ParentForm.Controls
            ctrTempControl.Enabled = lstCurrentEnabled(j)
            j = j + 1
        Next
        ParentForm.Cursor = Cursors.Default
    End Sub

    Private Sub Scripts(bRun As Boolean)
        Dim strComment, strComments As String
        Dim lstBeforeScripts As List(Of String)
        Dim lstAfterScripts As List(Of String)
        Dim lstBeforeCodes As List(Of RCodeStructure)
        Dim lstAfterCodes As List(Of RCodeStructure)
        Dim bFirstCode As Boolean = True
        Dim clsRemoveFunc As New RFunction
        Dim clsRemoveListFun As New RFunction
        Dim lstAssignToCodes As New List(Of RCodeStructure) 'todo. remove after refactoring GetAllAssignTo
        Dim lstAssignToStrings As New List(Of String)

        'rm is the R function to remove the created objects from the memory at the end of the script and c is the function that puts them together in a list
        clsRemoveFunc.SetRCommand("rm")
        clsRemoveListFun.SetRCommand("c")

        'this sets the comment for the script
        If chkComment.Checked Then
            strComments = txtComment.Text
        Else
            strComments = ""
        End If
        If Not bRun AndAlso strComments <> "" Then
            frmMain.AddToScriptWindow(frmMain.clsRLink.GetFormattedComment(strComments) & Environment.NewLine)
        End If

        'Get this list before doing ToScript then no need for global variable name
        clsRsyntax.GetAllAssignTo(lstAssignToCodes, lstAssignToStrings)

        'Run additional before codes
        lstBeforeScripts = clsRsyntax.GetBeforeCodesScripts()
        lstBeforeCodes = clsRsyntax.GetBeforeCodes()
        For i As Integer = 0 To clsRsyntax.lstBeforeCodes.Count - 1
            If bFirstCode Then
                strComment = strComments
                bFirstCode = False
            Else
                strComment = ""
            End If
            If bRun Then
                frmMain.clsRLink.RunScript(lstBeforeScripts(i), iCallType:=lstBeforeCodes(i).iCallType, strComment:=strComment, bSeparateThread:=clsRsyntax.bSeparateThread)
            Else
                frmMain.AddToScriptWindow(lstBeforeScripts(i))
            End If
        Next

        'Run base code from RSyntax
        If bRun Then
            If bFirstCode Then
                strComment = strComments
                bFirstCode = False
            Else
                strComment = ""
            End If
            frmMain.clsRLink.RunScript(clsRsyntax.GetScript(), clsRsyntax.iCallType, strComment:=strComment, bSeparateThread:=clsRsyntax.bSeparateThread)
        Else
            frmMain.AddToScriptWindow(clsRsyntax.GetScript())
        End If

        'This clears the script after it has been run, but leave the function and parameters in the base function
        'so that it can be run exactly the same when reopened.
        clsRsyntax.strScript = ""

        'Run additional after codes
        lstAfterScripts = clsRsyntax.GetAfterCodesScripts()
        lstAfterCodes = clsRsyntax.GetAfterCodes()
        For i As Integer = 0 To lstAfterCodes.Count - 1
            If bRun Then
                If bFirstCode Then
                    strComment = strComments
                    bFirstCode = False
                Else
                    strComment = ""
                End If
                frmMain.clsRLink.RunScript(lstAfterScripts(i), iCallType:=lstAfterCodes(i).iCallType, strComment:=strComment, bSeparateThread:=clsRsyntax.bSeparateThread, bShowWaitDialogOverride:=clsRsyntax.bShowWaitDialogOverride)
            Else
                frmMain.AddToScriptWindow(lstAfterScripts(i))
            End If
        Next

        'Clear variables from global environment
        'TODO check that this line could be removed
        clsRemoveFunc.ClearParameters()
        'TODO remove assign to instat object
        'lstAssignToStrings.RemoveAll(Function(x) x = frmMain.clsRLink.strInstatDataObject)
        If lstAssignToStrings.Count = 1 Then
            'Don't want to remove the Instat Object if it's been assigned
            clsRemoveFunc.AddParameter("x1", lstAssignToStrings(0), bIncludeArgumentName:=False)
        ElseIf lstAssignToStrings.Count > 1 Then
            For i As Integer = 0 To lstAssignToStrings.Count - 1
                clsRemoveListFun.AddParameter(i, Chr(34) & lstAssignToStrings(i) & Chr(34), bIncludeArgumentName:=False)
            Next
            clsRemoveFunc.AddParameter("list", clsRFunctionParameter:=clsRemoveListFun)
        End If
        If bRun Then
            If clsRemoveFunc.clsParameters.Count > 0 Then
                frmMain.clsRLink.RunScript(clsRemoveFunc.ToScript(), iCallType:=0)
            End If
        Else
            frmMain.AddToScriptWindow(clsRemoveFunc.ToScript())
        End If
    End Sub

    Public Sub OKEnabled(bEnabled As Boolean)
        cmdOk.Enabled = bEnabled
        cmdPaste.Enabled = bEnabled
    End Sub

    Private Sub ucrButtons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bLoadInProgress = True
        If frmMain.clsRecentItems IsNot Nothing Then
            frmMain.clsRecentItems.addToMenu(Me.Parent)
        End If
        If bFirstLoad Then
            'TODO. Temp this could be done on the designer
            txtComment.Multiline = True
            AddButtonInCommentTextbox()
            SetDefaults()
            bFirstLoad = False
        ElseIf Not bCommentChangedInThisDialog Then
            ' If the comment was not set specifically for this dialog, then reset to the Instat 
            ' option comment. We need to do this in case the instat option comment changed since 
            ' we last opened this dialog, e.g. by switching from English to French.
            ResetCommentToInstatOptionComment()
        End If
        If frmMain.clsInstatOptions IsNot Nothing Then
            If frmMain.clsInstatOptions.strLanguageCultureCode <> "en-GB" Then
                cmdHelp.Width = cmdOk.Width / 2
                cmdLanguage.Visible = True
            Else
                cmdHelp.Width = cmdOk.Width
                cmdLanguage.Visible = False
            End If
            strCurrLang = frmMain.clsInstatOptions.strLanguageCultureCode
        End If
        bLoadInProgress = False
    End Sub

    Private Sub SetDefaults()
        If frmMain.clsInstatOptions IsNot Nothing Then
            chkComment.Checked = frmMain.clsInstatOptions.bIncludeCommentDefault
        Else
            chkComment.Checked = True
        End If
        SetCommentEditable()
        ResetCommentToInstatOptionComment()
    End Sub

    Private Sub ResetCommentToInstatOptionComment()
        If frmMain.clsInstatOptions IsNot Nothing Then
            txtComment.Text = Translations.GetTranslation(frmMain.clsInstatOptions.strComment) _
                              & " " & Translations.GetTranslation(ParentForm.Text)
        Else
            txtComment.Text = Translations.GetTranslation(ParentForm.Text)
        End If
        bCommentChangedInThisDialog = False
    End Sub

    Private Sub chkComment_CheckedChanged(sender As Object, e As EventArgs) Handles chkComment.CheckedChanged
        SetCommentEditable()
    End Sub

    Private Sub SetCommentEditable()
        txtComment.Enabled = chkComment.Checked
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        HelpContent()
    End Sub

    Private Sub HelpContent()
        If iHelpTopicID > 0 Then
            Help.ShowHelp(Me.Parent, frmMain.strStaticPath & "\" & frmMain.strHelpFilePath, HelpNavigator.TopicId, iHelpTopicID.ToString())
        Else
            Help.ShowHelp(Me.Parent, frmMain.strStaticPath & "\" & frmMain.strHelpFilePath, HelpNavigator.TableOfContents)
        End If
    End Sub

    Private Sub cmdLanguage_Click(sender As Object, e As EventArgs) Handles cmdLanguage.Click

        If strCurrLang <> "en-GB" Then
            strCurrLang = "en-GB"
        Else
            strCurrLang = frmMain.clsInstatOptions.strLanguageCultureCode
        End If

        Dim strConfiguredLanguage As String = frmMain.clsInstatOptions.strLanguageCultureCode
        frmMain.clsInstatOptions.strLanguageCultureCode = strCurrLang
        autoTranslate(Me.ParentForm)
        ' If the comment was not set specifically for this dialog, then translate to toggled language
        If Not bCommentChangedInThisDialog Then
            ResetCommentToInstatOptionComment()
        End If
        frmMain.clsInstatOptions.strLanguageCultureCode = strConfiguredLanguage

        If cmdLanguage.FlatStyle = FlatStyle.Popup Then
            cmdLanguage.FlatStyle = FlatStyle.Flat
        Else
            cmdLanguage.FlatStyle = FlatStyle.Popup
        End If
    End Sub

    Private Sub AddButtonInCommentTextbox()
        Dim btnMoreComment As New Button
        'add the button to the comment textbox first
        txtComment.Controls.Clear()
        txtComment.Controls.Add(btnMoreComment)

        'then set the  button properties
        btnMoreComment.Text = ":::" 'temp. This will be shown as centered ... An image as below commended code is preferred
        'btn.Image = Image.FromFile("C:\patowhiz\3dots.png")
        btnMoreComment.Size = New Size(25, txtComment.ClientSize.Height + 2)
        btnMoreComment.TextAlign = ContentAlignment.TopCenter
        btnMoreComment.FlatStyle = FlatStyle.Standard
        btnMoreComment.FlatAppearance.BorderSize = 0
        btnMoreComment.Cursor = Cursors.Default
        btnMoreComment.Dock = DockStyle.Right
        btnMoreComment.BackColor = cmdOk.BackColor
        btnMoreComment.UseVisualStyleBackColor = True

        'set the btn event handler
        AddHandler btnMoreComment.Click, Sub()
                                             'shows a popup that displays the additional comments
                                             Dim frmPopup As New Form
                                             Dim txtPopupComment As New TextBox
                                             frmPopup.ShowInTaskbar = False
                                             frmPopup.FormBorderStyle = FormBorderStyle.None
                                             frmPopup.Size = New Size(txtComment.Width, 120)
                                             frmPopup.Controls.Add(txtPopupComment)
                                             'Set the text properties
                                             txtPopupComment.Dock = DockStyle.Fill
                                             txtPopupComment.Multiline = True
                                             txtPopupComment.ScrollBars = ScrollBars.Vertical
                                             txtPopupComment.WordWrap = False

                                             AddHandler txtPopupComment.LostFocus, Sub()
                                                                                       txtComment.Text = txtPopupComment.Text
                                                                                       frmPopup.Close()
                                                                                   End Sub
                                             AddHandler txtPopupComment.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                                                     If e.Control AndAlso e.KeyCode = Keys.Enter Then
                                                                                         txtComment.Text = txtPopupComment.Text
                                                                                         frmPopup.Close()
                                                                                     End If
                                                                                 End Sub

                                             Dim ctlpos As Point = txtComment.PointToScreen(New Point(0, 0)) 'Point.Empty is not function so use Point(0, 0)
                                             frmPopup.StartPosition = FormStartPosition.Manual 'set it to manual
                                             'if user wanted below the control. Left here for future reference
                                             'sdgComment.Location = New Point(ctlpos.X - 2, ctlpos.Y + txtComment.Height - 2) 'then locate its position
                                             frmPopup.Location = New Point(ctlpos.X - 2, ctlpos.Y - frmPopup.Height - 2) 'set location to show the form just above the examples button
                                             frmPopup.Show()
                                             txtPopupComment.Text = txtComment.Text
                                             txtPopupComment.SelectionStart = txtPopupComment.TextLength
                                         End Sub

    End Sub
End Class
