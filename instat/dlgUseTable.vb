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
Imports RDotNet
Public Class dlgUseTable
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsRFunctionAsHTML, clsRFunctionAsRTF, clsRFunctionAsWord, clsRFunctionAsLaTex, clsUseTableFunction As New RFunction

    Private clsTableTitleFunction, clsTabFootnoteTitleFunction, clsTableSourcenoteFunction, clsDummyFunction,
                                        clsThemesTabOptionsFunction, clsFootnoteCellFunction, clsSecondFootnoteCellBodyFunction,
                                       clsFootnoteTitleLocationFunction, clsFootnoteCellBodyFunction,
                                       clsFootnoteSubtitleLocationFunction, clsTabFootnoteSubtitleFunction,
                                        clsSecondFootnoteCellFunction, clsTabStyleCellTitleFunction,
                                       clsTabStyleCellTextFunction, clsTabStyleFunction, clsTabStylePxFunction, clsGtFunction,
                                       clsgtExtraThemesFunction, clsGtColsLabelFunction, clsgtAlignColsFunction As New RFunction

    Private clsPipeOperator, clsSummaryOperator, clsJoiningPipeOperator, clsColumnRenameOperator As New ROperator

    Private Sub dlgUseTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        SetBaseFunction()
        bReset = False
        TestOKEnabled()
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False

        ucrTablesSelector.SetParameter(New RParameter("data_name", 0))
        ucrTablesSelector.SetParameterIsString()

        ucrTablesReceiver.SetParameter(New RParameter("object_name", 1))
        ucrTablesReceiver.Selector = ucrTablesSelector
        ucrTablesReceiver.SetParameterIsString()
        ucrTablesReceiver.strSelectorHeading = "Tables"
        ucrTablesReceiver.SetItemType(RObjectTypeLabel.Table)

        ''To Be enabled later when the formats are supported.
        rdoAsHTML.Enabled = False
        rdoAsLaTex.Enabled = False
        rdoAsRTF.Enabled = False
        rdoAsWord.Enabled = False
        'ucrPnlExportOptions.AddRadioButton(rdoAsHTML)
        'ucrPnlExportOptions.AddRadioButton(rdoAsRTF)
        'ucrPnlExportOptions.AddRadioButton(rdoAsWord)
        'ucrPnlExportOptions.AddRadioButton(rdoAsLaTex)
        'ucrPnlExportOptions.AddFunctionNamesCondition(rdoAsHTML, "as_raw_html")
        'ucrPnlExportOptions.AddFunctionNamesCondition(rdoAsRTF, "as_rtf")
        'ucrPnlExportOptions.AddFunctionNamesCondition(rdoAsWord, "as_word")
        'ucrPnlExportOptions.AddFunctionNamesCondition(rdoAsLaTex, "as_word")

        ucrSaveTable.SetPrefix("use_table")
        ucrSaveTable.SetDataFrameSelector(ucrTablesSelector.ucrAvailableDataFrames)
        ucrSaveTable.SetCheckBoxText("Save New Table")
        ucrSaveTable.SetIsComboBox()
    End Sub

    Private Sub SetDefaults()
        clsRFunctionAsHTML = New RFunction
        clsRFunctionAsRTF = New RFunction
        clsRFunctionAsWord = New RFunction
        clsRFunctionAsLaTex = New RFunction
        clsUseTableFunction = New RFunction
        clsPipeOperator = New ROperator

        clsTableTitleFunction = New RFunction
        clsTabFootnoteTitleFunction = New RFunction
        clsTableSourcenoteFunction = New RFunction
        clsDummyFunction = New RFunction
        clsThemesTabOptionsFunction = New RFunction
        clsFootnoteCellFunction = New RFunction
        clsSecondFootnoteCellBodyFunction = New RFunction
        clsFootnoteTitleLocationFunction = New RFunction
        clsFootnoteCellBodyFunction = New RFunction
        clsFootnoteSubtitleLocationFunction = New RFunction
        clsTabFootnoteSubtitleFunction = New RFunction
        clsSecondFootnoteCellFunction = New RFunction
        clsTabStyleCellTextFunction = New RFunction
        clsTabStyleFunction = New RFunction
        clsTabStylePxFunction = New RFunction
        clsTabStyleCellTitleFunction = New RFunction
        clsSummaryOperator = New ROperator
        clsJoiningPipeOperator = New ROperator
        clsgtExtraThemesFunction = New RFunction
        clsColumnRenameOperator = New ROperator
        clsGtColsLabelFunction = New RFunction
        clsGtFunction = New RFunction
        clsgtAlignColsFunction = New RFunction

        'rdoAsHTML.Checked = True
        ucrTablesReceiver.SetMeAsReceiver()
        ucrTablesSelector.Reset()
        ucrSaveTable.Reset()

        clsDummyFunction.AddParameter("theme", "select", iPosition:=11)

        clsgtExtraThemesFunction.SetPackageName("gtExtras")

        clsSummaryOperator.SetOperation("+")

        clsTabStyleFunction.SetRCommand("tab_style")
        clsTabStyleFunction.SetPackageName("gt")
        clsTabStyleFunction.AddParameter("style", clsRFunctionParameter:=clsTabStyleCellTextFunction, iPosition:=0)
        clsTabStyleFunction.AddParameter("location", clsRFunctionParameter:=clsTabStyleCellTitleFunction, iPosition:=1)

        clsTabStyleCellTitleFunction.SetPackageName("gt")
        clsTabStyleCellTitleFunction.SetRCommand("cells_title")
        clsTabStyleCellTitleFunction.AddParameter("groups", Chr(34) & "title" & Chr(34), iPosition:=0)

        clsTabStyleCellTextFunction.SetPackageName("gt")
        clsTabStyleCellTextFunction.SetRCommand("cell_text")
        clsTabStyleCellTextFunction.AddParameter("size", clsRFunctionParameter:=clsTabStylePxFunction, iPosition:=0)

        clsTabStylePxFunction.SetPackageName("gt")
        clsTabStylePxFunction.SetRCommand("px")
        clsTabStylePxFunction.AddParameter("size", "18", bIncludeArgumentName:=False, iPosition:=0)

        clsTableTitleFunction.SetPackageName("gt")
        clsTableTitleFunction.SetRCommand("tab_header")

        clsTabFootnoteTitleFunction.SetPackageName("gt")
        clsTabFootnoteTitleFunction.SetRCommand("tab_footnote")

        clsTabFootnoteSubtitleFunction.SetPackageName("gt")
        clsTabFootnoteSubtitleFunction.SetRCommand("tab_footnote")

        clsFootnoteCellFunction.SetPackageName("gt")
        clsFootnoteCellFunction.SetRCommand("tab_footnote")

        clsSecondFootnoteCellFunction.SetPackageName("gt")
        clsSecondFootnoteCellFunction.SetRCommand("tab_footnote")

        clsFootnoteTitleLocationFunction.SetPackageName("gt")
        clsFootnoteTitleLocationFunction.SetRCommand("cells_title")

        clsFootnoteSubtitleLocationFunction.SetPackageName("gt")
        clsFootnoteSubtitleLocationFunction.SetRCommand("cells_title")

        clsTableSourcenoteFunction.SetPackageName("gt")
        clsTableSourcenoteFunction.SetRCommand("tab_source_note")

        clsFootnoteCellBodyFunction.SetPackageName("gt")
        clsFootnoteCellBodyFunction.SetRCommand("cells_body")

        clsSecondFootnoteCellBodyFunction.SetPackageName("gt")
        clsSecondFootnoteCellBodyFunction.SetRCommand("cells_body")

        clsThemesTabOptionsFunction.SetPackageName("gt")
        clsThemesTabOptionsFunction.SetRCommand("tab_options")

        clsRFunctionAsHTML.SetPackageName("gt")
        clsRFunctionAsHTML.SetRCommand("as_raw_html")

        clsRFunctionAsRTF.SetPackageName("gt")
        clsRFunctionAsRTF.SetRCommand("as_rtf")

        clsRFunctionAsWord.SetPackageName("gt")
        clsRFunctionAsWord.SetRCommand("as_word")

        clsRFunctionAsLaTex.SetPackageName("gt")
        clsRFunctionAsLaTex.SetRCommand("as_word")

        clsUseTableFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_object_data")

        clsPipeOperator.SetOperation("%>%")

        clsGtFunction.SetPackageName("gt")
        clsGtFunction.SetRCommand("gt")

        clsJoiningPipeOperator.SetOperation("%>%")
        clsJoiningPipeOperator.AddParameter("object", clsRFunctionParameter:=clsUseTableFunction, iPosition:=0)

        clsGtColsLabelFunction.SetPackageName("gt")
        clsGtColsLabelFunction.SetRCommand("cols_label")

        clsgtAlignColsFunction.SetPackageName("gt")
        clsgtAlignColsFunction.SetRCommand("cols_align")
        clsgtAlignColsFunction.AddParameter("align", Chr(34) & "auto" & Chr(34), iPosition:=0)
        clsgtAlignColsFunction.AddParameter("columns", "everything()", iPosition:=1)

        clsColumnRenameOperator.SetOperation("%>%")

        ucrBase.clsRsyntax.SetBaseROperator(clsJoiningPipeOperator)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrTablesSelector.SetRCode(clsUseTableFunction, bReset)
        ucrTablesReceiver.SetRCode(clsUseTableFunction, bReset)
        ucrSaveTable.SetRCode(ucrBase.clsRsyntax.clsBaseOperator, bReset)
    End Sub

    Private Sub TestOKEnabled()
        If Not ucrTablesReceiver.IsEmpty Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub cmdFormatOptions_Click(sender As Object, e As EventArgs) Handles cmdFormatOptions.Click
        sdgFormatSummaryTables.SetRCode(clsNewTableTitleFunction:=clsTableTitleFunction, clsNewTabFootnoteTitleFunction:=clsTabFootnoteTitleFunction, clsNewTableSourcenoteFunction:=clsTableSourcenoteFunction, clsNewDummyFunction:=clsDummyFunction,
                                        clsNewFootnoteCellFunction:=clsFootnoteCellFunction, clsNewSecondFootnoteCellBodyFunction:=clsSecondFootnoteCellBodyFunction,
                                        clsNewPipeOperator:=clsPipeOperator, clsNewFootnoteTitleLocationFunction:=clsFootnoteTitleLocationFunction, clsNewFootnoteCellBodyFunction:=clsFootnoteCellBodyFunction,
                                        clsNewFootnoteSubtitleLocationFunction:=clsFootnoteSubtitleLocationFunction, clsNewTabFootnoteSubtitleFunction:=clsTabFootnoteSubtitleFunction, clsNewJoiningOperator:=clsJoiningPipeOperator,
                                        clsNewMutableOPerator:=clsSummaryOperator, clsNewSecondFootnoteCellFunction:=clsSecondFootnoteCellFunction,
                                        clsNewTabStyleCellTextFunction:=clsTabStyleCellTextFunction, clsNewTabStyleFunction:=clsTabStyleFunction, clsNewTabStylePxFunction:=clsTabStylePxFunction,
                                        clsNewgtExtraThemesFunction:=clsgtExtraThemesFunction, clsNewThemesTabOptionFunction:=clsThemesTabOptionsFunction, clsNewgtAlignColsFunction:=clsgtAlignColsFunction,
                                        clsNewGtColsLabelFunction:=clsGtColsLabelFunction, dfEditData:=GetSelectedDataFrame, strDataFrameName:=ucrTablesSelector.strCurrentDataFrame,
                                        bUseTable:=True, bReset:=bReset)
        sdgFormatSummaryTables.ShowDialog()
        SetBaseFunction()
    End Sub

    Public Function GetSelectedDataFrame() As CharacterMatrix
        Dim dfTemp As CharacterMatrix = Nothing
        Dim expTemp As SymbolicExpression
        Dim clsDataFrameFunction As New RFunction
        Dim clsNamesFunction As New RFunction

        clsDataFrameFunction.SetRCommand("as.data.frame")
        clsDataFrameFunction.AddParameter("data", clsRFunctionParameter:=clsUseTableFunction, bIncludeArgumentName:=False)

        clsNamesFunction.SetRCommand("names")
        clsNamesFunction.AddParameter("name", clsRFunctionParameter:=clsDataFrameFunction, bIncludeArgumentName:=False)

        expTemp = frmMain.clsRLink.RunInternalScriptGetValue(clsNamesFunction.ToScript(), bSilent:=True)
        If expTemp IsNot Nothing Then
            dfTemp = expTemp.AsCharacterMatrix
        End If
        Return dfTemp
    End Function

    Private Sub SetBaseFunction()
        If clsGtColsLabelFunction.ContainsParameter(".list") Then
            clsJoiningPipeOperator.RemoveAssignTo()
            clsJoiningPipeOperator.SetAssignTo("format_table")
            clsColumnRenameOperator.AddParameter("x", clsROperatorParameter:=clsJoiningPipeOperator, iPosition:=0)
            clsColumnRenameOperator.AddParameter("y", clsRFunctionParameter:=clsGtColsLabelFunction, iPosition:=1)
            clsColumnRenameOperator.SetAssignToOutputObject(strRObjectToAssignTo:="last_table_renamed",
                                                  strRObjectTypeLabelToAssignTo:=RObjectTypeLabel.Table,
                                                  strRObjectFormatToAssignTo:=RObjectFormat.Html,
                                                  strRDataFrameNameToAddObjectTo:=ucrTablesSelector.strCurrentDataFrame,
                                                  strObjectName:="last_table_renamed")
            ucrBase.clsRsyntax.SetBaseROperator(clsColumnRenameOperator)

        Else

            clsJoiningPipeOperator.SetAssignToOutputObject(strRObjectToAssignTo:="last_table",
                                                  strRObjectTypeLabelToAssignTo:=RObjectTypeLabel.Table,
                                                  strRObjectFormatToAssignTo:=RObjectFormat.Html,
                                                  strRDataFrameNameToAddObjectTo:=ucrTablesSelector.strCurrentDataFrame,
                                                  strObjectName:="last_table")
            ucrBase.clsRsyntax.SetBaseROperator(clsJoiningPipeOperator)
        End If
    End Sub

    Private Sub ucrCoreControls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrTablesReceiver.ControlContentsChanged, ucrSaveTable.ControlContentsChanged
        TestOKEnabled()
    End Sub

    Private Sub ucrPnlExportOptions_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrPnlExportOptions.ControlValueChanged
        If rdoAsHTML.Checked Then
            clsJoiningPipeOperator.AddParameter("y", clsRFunctionParameter:=clsRFunctionAsHTML)
        ElseIf rdoAsRTF.Checked Then
            clsJoiningPipeOperator.AddParameter("y", clsRFunctionParameter:=clsRFunctionAsRTF)
        ElseIf rdoAsWord.Checked Then
            clsJoiningPipeOperator.AddParameter("y", clsRFunctionParameter:=clsRFunctionAsWord)
        Else
            clsJoiningPipeOperator.AddParameter("y", clsRFunctionParameter:=clsRFunctionAsLaTex)
        End If
    End Sub
End Class