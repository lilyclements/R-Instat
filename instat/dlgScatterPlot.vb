
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
Public Class dlgScatterPlot
    Private clsRgeom_scatterplotFunction As New RFunction
    Private clsRaesFunction As New RFunction
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True

    Private Sub dlgScatterPlot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If

        If bReset Then
            SetDefaults()
        End If

        bReset = False
        SetRCodeForControls(bReset)

        autoTranslate(Me)
        TestOkEnabled()

    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False
        ucrBase.iHelpTopicID = 433
        ucrBase.clsRsyntax.iCallType = 3


        ucrVariablesAsFactorForScatter.SetFactorReceiver(ucrFactorOptionalReceiver)
        ucrVariablesAsFactorForScatter.SetSelector(ucrSelectorForScatter)
        ucrVariablesAsFactorForScatter.SetIncludedDataType({"factor", "numeric"})
        ucrReceiverX.SetParameter(New RParameter("y"))

        ucrReceiverX.Selector = ucrSelectorForScatter
        ucrReceiverX.SetIncludedDataTypes({"factor", "numeric"})
        ucrReceiverX.SetParameter(New RParameter("x"))

        ucrFactorOptionalReceiver.Selector = ucrSelectorForScatter
        ucrFactorOptionalReceiver.SetIncludedDataTypes({"factor", "numeric"})
        ucrFactorOptionalReceiver.SetParameter(New RParameter("colour"))

        ucrSelectorForScatter.SetParameter(New RParameter("data", 0))
        ' sdgPlots.SetRSyntax(ucrBase.clsRsyntax)

        ucrSave.SetPrefix("Scatter")
        ucrSave.SetSaveTypeAsGraph()
        ucrSave.SetDataFrameSelector(ucrSelectorForScatter.ucrAvailableDataFrames)
        ucrSave.SetIsComboBox()
        ucrSave.SetCheckBoxText("Save Graph")
        ucrSave.SetAssignToIfUncheckedValue("last_graph")
    End Sub

    Private Sub SetDefaults()
        Dim clsDefaultFunction As New RFunction
        Dim clsRaesFunc As New RFunction
        Dim clsRgeom As New RFunction

        'setDefaults
        clsRaesFunc.ClearParameters()
        clsRgeom.ClearParameters()
        ucrSelectorForScatter.Reset()
        ucrSelectorForScatter.Focus()
        ucrVariablesAsFactorForScatter.ResetControl()
        ucrSave.Reset()
        'sdgPlots.Reset()

        ucrBase.clsRsyntax.SetOperation("+")
        clsDefaultFunction.SetRCommand("ggplot")
        clsRgeom.SetRCommand("geom_point")
        clsRaesFunc.SetRCommand("aes")
        clsDefaultFunction.AddParameter("mapping", clsRFunctionParameter:=clsRaesFunc)

        ucrBase.clsRsyntax.SetOperatorParameter(True, clsRFunc:=clsDefaultFunction)
        ucrBase.clsRsyntax.SetOperatorParameter(False, clsRFunc:=clsRgeom)

        clsRaesFunction = clsRaesFunc.Clone
        clsRgeom_scatterplotFunction = clsRgeom.Clone
        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultFunction.Clone())

    End Sub
    Private Sub SetXParameter()
        If Not ucrReceiverX.IsEmpty Then
            clsRaesFunction.AddParameter("x", ucrReceiverX.GetVariableNames(False))
        Else
            clsRaesFunction.AddParameter("x", Chr(34) & Chr(34))
        End If
    End Sub

    Private Sub SetYParameter()
        If Not ucrVariablesAsFactorForScatter.IsEmpty Then
            clsRaesFunction.AddParameter("y", ucrVariablesAsFactorForScatter.GetVariableNames(False))
        Else
            clsRaesFunction.AddParameter("y", Chr(34) & Chr(34))
        End If
    End Sub
    Private Sub ucrReceiverX_SelectionChanged() Handles ucrReceiverX.ControlValueChanged
        SetXParameter()
        TestOkEnabled()
    End Sub

    Private Sub ucrFactorOptionalReceiver_SelectionChanged() Handles ucrFactorOptionalReceiver.ControlValueChanged
        If Not ucrFactorOptionalReceiver.IsEmpty Then
            clsRaesFunction.AddParameter("colour", ucrFactorOptionalReceiver.GetVariableNames(False))
        Else
            clsRaesFunction.RemoveParameterByName("colour")
        End If
    End Sub

    Private Sub TestOkEnabled()
        'tests when okay Is enable. Both x and y aesthetics are mandatory but can be set to x="" or(exclusive) y="" in case the other one is filled. 
        'If (ucrReceiverX.IsEmpty() AndAlso ucrVariablesAsFactorForScatter.IsEmpty) OrElse Not (ucrSave.IsComplete) Then
        '    ucrBase.OKEnabled(False)
        'Else
        '    ucrBase.OKEnabled(True)
        'End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
    End Sub

    Private Sub cmdOptions_Click(sender As Object, e As EventArgs) Handles cmdOptions.Click
        sdgPlots.SetDataFrame(strNewDataFrame:=ucrSelectorForScatter.ucrAvailableDataFrames.cboAvailableDataFrames.Text)
        sdgPlots.ShowDialog()
    End Sub

    Private Sub ucrVariablesAsFactor_SelectionChanged() Handles ucrVariablesAsFactorForScatter.ControlValueChanged
        SetYParameter()
        TestOkEnabled()
    End Sub

    ' Private Sub cmdScatterPlotOptions_Click(sender As Object, e As EventArgs) Handles cmdScatterPlotOptions.Click
    '    'SetupLayer sends the components storing the plot info (clsRaesFunction, clsRggplotFunction, ...) of dlgScatteredPlot through to sdgLayerOptions where these will be edited.
    '    sdgLayerOptions.SetupLayer(clsTempGgPlot:=clsRggplotFunction, clsTempGeomFunc:=clsRgeom_scatterplotFunction, clsTempAesFunc:=clsRaesFunction, bFixAes:=True, bFixGeom:=True, strDataframe:=ucrSelectorForScatter.ucrAvailableDataFrames.cboAvailableDataFrames.Text, bApplyAesGlobally:=True, bIgnoreGlobalAes:=False)
    '    sdgLayerOptions.ShowDialog()
    '    'Coming from the sdgLayerOptions, clsRaesFunction and others has been modified. One then needs to display these modifications on the dlgScatteredPlot.

    '    'The aesthetics parameters on the main dialog are repopulated as required. 
    '    For Each clsParam In clsRaesFunction.clsParameters
    '        If clsParam.strArgumentName = "x" Then
    '            If clsParam.strArgumentValue = Chr(34) & Chr(34) Then
    '                ucrReceiverX.Clear()
    '            Else
    '                ucrReceiverX.Add(clsParam.strArgumentValue)
    '            End If
    '            'In the y case, the vlue stored in the clsReasFunction in the multiplevariables case is "value", however that one shouldn't be written in the multiple variables receiver (otherwise it would stack all variables and the stack ("value") itself!).
    '            'Warning: what if someone used the name value for one of it's variables independently from the multiple variables method ? Here if the receiver is actually in single mode, the variable "value" will still be given back, which throws the problem back to the creation of "value" in the multiple receiver case.
    '        ElseIf clsParam.strArgumentName = "y" AndAlso (clsParam.strArgumentValue <> "value" OrElse ucrVariablesAsFactorForScatter.bSingleVariable) Then
    '            'Still might be in the case of bSingleVariable with mapping y="".
    '            If clsParam.strArgumentValue = (Chr(34) & Chr(34)) Then
    '                ucrVariablesAsFactorForScatter.Clear()
    '            Else ucrVariablesAsFactorForScatter.Add(clsParam.strArgumentValue)
    '            End If
    '        ElseIf clsParam.strArgumentName = "colour" Then
    '            ucrFactorOptionalReceiver.Add(clsParam.strArgumentValue)
    '        End If
    '    Next
    'End Sub

End Class