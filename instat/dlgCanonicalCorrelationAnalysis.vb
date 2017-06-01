' Instat-R
' Copyright (C) 2015
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
' You should have received a copy of the GNU General Public License k
' along with this program.  If not, see <http://www.gnu.org/licenses/>.
Imports instat.Translations
Public Class dlgCanonicalCorrelationAnalysis
    Public strModelName As String = ""
    Public bFirstLoad As Boolean = True
    Private bResetSubdialog As Boolean = False
    Private bReset As Boolean = True
    Public clsRCanCor, clsRCoef, clsRGraphics, clsTempFunc As New RFunction
    Private clsDefaultFunction As New RFunction

    Private Sub dlgCanonicalCorrelationAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeforControls(bReset)
        bReset = False
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.iHelpTopicID = 423
        ucrBase.clsRsyntax.iCallType = 3
        ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False

        'cmdCCAOptions.Enabled = False

        ' note: canne have the same variables in both receivers.

        ' Y Variable Selector
        ucrReceiverYvariables.SetParameter(New RParameter("y", 0))
        ucrReceiverYvariables.SetParameterIsRFunction()
        ucrReceiverYvariables.Selector = ucrSelectorCCA
        ucrReceiverYvariables.SetDataType("numeric")
        ucrReceiverYvariables.bExcludeFromSelector = True

        ' X Variable Selector
        ucrReceiverXvariables.SetParameter(New RParameter("x", 1))
        ucrReceiverXvariables.SetParameterIsRFunction()
        ucrReceiverXvariables.Selector = ucrSelectorCCA
        ucrReceiverXvariables.SetDataType("numeric")
        ucrReceiverXvariables.bExcludeFromSelector = True

        'ucrSaveResult
        ucrSaveResult.SetCheckBoxText("Save Result")
        ucrSaveResult.SetSaveTypeAsModel()
        ucrSaveResult.SetPrefix("CCA")
        ucrSaveResult.SetIsComboBox()
        ucrSaveResult.SetDataFrameSelector(ucrSelectorCCA.ucrAvailableDataFrames)
        ucrSaveResult.SetAssignToIfUncheckedValue("last_CCA")

    End Sub

    Private Sub SetDefaults()
        clsDefaultFunction = New RFunction
        clsRCanCor = New RFunction
        clsRGraphics = New RFunction

        ucrSelectorCCA.Reset()
        ucrSaveResult.Reset()
        ucrReceiverXvariables.SetMeAsReceiver()

        'Define the default RFunction
        clsDefaultFunction.SetRCommand("cancor")
        clsDefaultFunction.SetAssignTo("last_CCA", strTempModel:="last_CCA", strTempDataframe:=ucrSelectorCCA.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem)

        ' sub dialog options
        clsRCanCor.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_from_model")
        clsRCanCor.AddParameter("value1", Chr(34) & "cancor" & Chr(34))

        clsRCoef.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_from_model")
        clsRCoef.AddParameter("value1", Chr(34) & "coef" & Chr(34))

        clsRGraphics.SetPackageName("GGally")
        clsRGraphics.SetRCommand("ggpairs")
        clsRGraphics.AddParameter("data", clsRFunctionParameter:=clsTempFunc)

        ' Set default RFunction as the base function
        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultFunction)
        bResetSubdialog = True
    End Sub

    Private Sub SetRCodeforControls(bReset As Boolean)
        ucrReceiverXvariables.AddAdditionalCodeParameterPair(clsRGraphics, New RParameter("columns"), iAdditionalPairNo:=1)
        ucrReceiverYvariables.AddAdditionalCodeParameterPair(clsRGraphics, New RParameter("columns"), iAdditionalPairNo:=2)

        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub TestOKEnabled()
        If ucrSaveResult.IsComplete() AndAlso ucrReceiverYvariables.lstSelectedVariables.Items.Count > 1 AndAlso ucrReceiverXvariables.lstSelectedVariables.Items.Count > 1 Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrBaseCCA_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeforControls(True)
        TestOKEnabled()
    End Sub

    Private Sub cmdCCAOptions_Click(sender As Object, e As EventArgs) Handles cmdCCAOptions.Click
        sdgCanonicalCorrelation.SetRFunction(clsRCanCor, clsRCoef, bResetSubdialog)
        bResetSubdialog = False
        sdgCanonicalCorrelation.ShowDialog()
    End Sub

    Private Sub ucrBaseCCA_clickok(sender As Object, e As EventArgs) Handles ucrBase.ClickOk
        sdgCanonicalCorrelation.CreatePlots()
    End Sub

    Private Sub ucrSaveResult_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrSaveResult.ControlContentsChanged, ucrReceiverXvariables.ControlContentsChanged, ucrReceiverYvariables.ControlContentsChanged
        TestOKEnabled()
    End Sub

    Public Sub AssignName()
        If ucrSaveResult.IsComplete Then
            ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False
            strModelName = ucrSaveResult.GetText()
        Else
            ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False
            strModelName = "last_CCA"
        End If
    End Sub

    Private Sub Test()
        AssignName()
        clsRCanCor.AddParameter("data_name", Chr(34) & ucrSelectorCCA.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem & Chr(34))
        clsRCanCor.AddParameter("model_name", Chr(34) & strModelName & Chr(34))
        clsRCoef.AddParameter("data_name", Chr(34) & ucrSelectorCCA.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem & Chr(34))
        clsRCoef.AddParameter("model_name", Chr(34) & strModelName & Chr(34))
    End Sub

    Private Sub ucrSaveResult_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrSaveResult.ControlValueChanged, ucrSelectorCCA.ControlValueChanged
        Test()

        'temp solution to fix bug in ggpairs function
        clsTempFunc = ucrSelectorCCA.ucrAvailableDataFrames.clsCurrDataFrame.Clone()
        clsTempFunc.AddParameter("remove_attr", "TRUE")
    End Sub
End Class