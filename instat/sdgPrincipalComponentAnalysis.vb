﻿' Instat-R
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
Public Class sdgPrincipalComponentAnalysis
    Private bControlsInitialised As Boolean = False
    Private clsREigenValues, clsREigenVectors, clsRRotation As New RFunction
    Public bFirstLoad As Boolean = True

    ' to do:
    Public clsRScores, clsPCAModel, clsRVariablesPlotFunction, clsRVariablesPlotTheme, clsRCoord, clsRContrib, clsREig, clsRFactor, clsRMelt As New RFunction
    Public clsRScreePlotFunction, clsRScreePlotTheme, clsRIndividualsPlotFunction, clsRIndividualsPlotTheme, clsRBiplotFunction, clsRBiplotTheme, clsRBarPlotFunction, clsRBarPlotGeom, clsRBarPlotFacet, clsRBarPlotAes As New RFunction
    Public clsRScreePlot, clsRVariablesPlot, clsRIndividualsPlot, clsRBiplot As New RSyntax

    Dim clsRBarPlot, clsRBarPlot0 As New ROperator

    Private Sub sdgPrincipalComponentAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bFirstLoad Then
            InitialiseDialog()
            SetDefaults()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitialiseControls()
        ucrChkEigenvalues.SetParameter(New RParameter("value1", 2))
        ucrChkEigenvalues.SetText("Eigenvalues")
        ucrChkEigenvalues.SetValueIfChecked(Chr(34) & "eig" & Chr(34))

        ucrChkEigenvectors.SetParameter(New RParameter("value1", 2))
        ucrChkEigenvectors.SetText("Eigenvectors")
        ucrChkEigenvectors.SetValueIfChecked(Chr(34) & "ind" & Chr(34))

        ucrChkRotation.SetParameter(New RParameter("MARGIN", 1))
        ucrChkRotation.SetText("Rotation")
        ucrChkRotation.SetValueIfChecked(2)

        ucrPnlGraphics.AddRadioButton(rdoScreePlot)
        ucrPnlGraphics.AddRadioButton(rdoVariablesPlot)
        ucrPnlGraphics.AddRadioButton(rdoIndividualsPlot)
        ucrPnlGraphics.AddRadioButton(rdoBiplot)
        ucrPnlGraphics.AddRadioButton(rdoBarPlot)

        ucrPnlGeom.AddRadioButton(rdoOne)
        ucrPnlGeom.AddRadioButton(rdoTwo)
        ucrPnlGeom.AddRadioButton(rdoBoth)

        ucrPnlGraphics.AddToLinkedControls(ucrPnlGeom, {rdoScreePlot, rdoVariablesPlot, rdoIndividualsPlot, rdoBiplot}, bNewLinkedHideIfParameterMissing:=True, bNewLinkedAddRemoveParameter:=True)
        ucrPnlGeom.SetLinkedDisplayControl(grpGeom)

        ucrPnlGraphics.AddToLinkedControls(ucrLabel, {rdoScreePlot, rdoVariablesPlot, rdoIndividualsPlot, rdoBiplot}, bNewLinkedHideIfParameterMissing:=True, bNewLinkedAddRemoveParameter:=True)
        ucrLabel.SetLinkedDisplayControl(lblChoiceScree)

        ucrPnlGraphics.AddToLinkedControls(ucrChkIncludePercentage, {rdoScreePlot}, bNewLinkedHideIfParameterMissing:=True, bNewLinkedAddRemoveParameter:=True)

        ucrPnlGraphics.AddToLinkedControls(ucrNudDim, {rdoVariablesPlot, rdoIndividualsPlot, rdoBiplot}, bNewLinkedHideIfParameterMissing:=True, bNewLinkedAddRemoveParameter:=True)
        ucrPnlGraphics.AddToLinkedControls(ucrNudDim2, {rdoVariablesPlot, rdoIndividualsPlot, rdoBiplot}, bNewLinkedHideIfParameterMissing:=True, bNewLinkedAddRemoveParameter:=True)
        ucrNudDim.SetLinkedDisplayControl(lblDim)

        ucrPnlGraphics.AddToLinkedControls(ucrSelectorFactor, {rdoBarPlot}, bNewLinkedHideIfParameterMissing:=True, bNewLinkedAddRemoveParameter:=True)
        ucrPnlGraphics.AddToLinkedControls(ucrReceiverFactor, {rdoBarPlot}, bNewLinkedHideIfParameterMissing:=True, bNewLinkedAddRemoveParameter:=True)
        ucrReceiverFactor.SetLinkedDisplayControl(lblFactorVariable)
    End Sub

    Private Sub InitialiseDialog()
        ucrNudDim.Minimum = 1
        ucrNudDim2.Minimum = 1
    End Sub

    Public Sub SetDefaults()
        ucrReceiverFactor.Selector = ucrSelectorFactor
        ucrReceiverFactor.SetDataType("factor")
        ucrSelectorFactor.Reset()
        ucrReceiverFactor.SetMeAsReceiver()
        ucrSelectorFactor.Focus()
        ucrChkIncludePercentage.Checked = False
        rdoScreePlot.Checked = True
        rdoScreePlot.Checked = True
        ucrNudDim.Value = 1
        ucrNudDim2.Value = 2
        rdoBoth.Checked = True
        Dimensions()
        DisplayOptions()
    End Sub

    'Code for running Screeplot if it is selected in the "Graphics" tab
    Private Sub ScreePlot()
        clsRScreePlot.SetOperation("+")
        clsRScreePlotFunction.SetRCommand("fviz_screeplot")
        clsRScreePlotFunction.AddParameter("X", clsRFunctionParameter:=dlgPrincipalComponentAnalysis.ucrBase.clsRsyntax.clsBaseFunction)
        clsRScreePlotTheme.SetRCommand("theme_minimal")
        clsRScreePlot.SetOperatorParameter(True, clsRFunc:=clsRScreePlotFunction)
        clsRScreePlot.SetOperatorParameter(False, clsRFunc:=clsRScreePlotTheme)
        If ucrChkIncludePercentage.Checked Then
            clsRScreePlotFunction.AddParameter("addlabels", "TRUE")
        Else
            clsRScreePlotFunction.RemoveParameterByName("addlabels")
        End If
        frmMain.clsRLink.RunScript(clsRScreePlot.GetScript(), 3)
    End Sub

    'Code for running Variables Plot if it is selected in the "Graphics" tab
    Private Sub VariablesPlot()
        clsRVariablesPlot.SetOperation("+")
        clsRVariablesPlotFunction.SetRCommand("fviz_pca_var")
        clsRVariablesPlotFunction.AddParameter("X", clsRFunctionParameter:=dlgPrincipalComponentAnalysis.ucrBase.clsRsyntax.clsBaseFunction)
        clsRVariablesPlotTheme.SetRCommand("theme_minimal")
        clsRVariablesPlot.SetOperatorParameter(True, clsRFunc:=clsRVariablesPlotFunction)
        clsRVariablesPlot.SetOperatorParameter(False, clsRFunc:=clsRVariablesPlotTheme)
        clsRVariablesPlotFunction.AddParameter("axes", "c(" & ucrNudDim.Value & "," & ucrNudDim2.Value & ")")
        frmMain.clsRLink.RunScript(clsRVariablesPlot.GetScript(), 3)
    End Sub

    'Code for running Individuals Plot if it is selected in the "Graphics" tab
    Private Sub IndividualsPlot()
        clsRIndividualsPlot.SetOperation("+")
        clsRIndividualsPlotFunction.SetRCommand("fviz_pca_ind")
        clsRIndividualsPlotFunction.AddParameter("X", clsRFunctionParameter:=dlgPrincipalComponentAnalysis.ucrBase.clsRsyntax.clsBaseFunction)
        clsRIndividualsPlotTheme.SetRCommand("theme_minimal")
        clsRIndividualsPlot.SetOperatorParameter(True, clsRFunc:=clsRIndividualsPlotFunction)
        clsRIndividualsPlot.SetOperatorParameter(False, clsRFunc:=clsRIndividualsPlotTheme)
        clsRIndividualsPlotFunction.AddParameter("axes", "c(" & ucrNudDim.Value & "," & ucrNudDim2.Value & ")")
        frmMain.clsRLink.RunScript(clsRIndividualsPlot.GetScript(), 3)
    End Sub

    'Code for running Biplot if it is selected in the "Graphics" tab
    Private Sub Biplot()
        clsRBiplot.SetOperation("+")
        clsRBiplotFunction.SetRCommand("fviz_pca_biplot")
        clsRBiplotFunction.AddParameter("X", clsRFunctionParameter:=dlgPrincipalComponentAnalysis.ucrBase.clsRsyntax.clsBaseFunction)
        clsRBiplotTheme.SetRCommand("theme_minimal")
        clsRBiplot.SetOperatorParameter(True, clsRFunc:=clsRBiplotFunction)
        clsRBiplot.SetOperatorParameter(False, clsRFunc:=clsRBiplotTheme)
        clsRBiplotFunction.AddParameter("axes", "c(" & ucrNudDim.Value & "," & ucrNudDim2.Value & ")")
        frmMain.clsRLink.RunScript(clsRBiplot.GetScript(), 3)
    End Sub

    'Code for running Barplot if it is selected in the "Graphics" tab
    Private Sub Barplot()
        clsRBarPlot0.SetOperation("+")
        clsRBarPlot.SetOperation("+")
        clsRFactor.SetRCommand("cbind")
        clsRMelt.SetRCommand("melt")
        clsRMelt.AddParameter("", clsRFunctionParameter:=clsREigenVectors)
        clsRFactor.AddParameter("factor_col", ucrReceiverFactor.GetVariableNames)
        clsRFactor.AddParameter("", clsRFunctionParameter:=clsRMelt)
        clsRBarPlotFunction.SetRCommand("ggplot")
        clsRBarPlotFunction.AddParameter("data", clsRFunctionParameter:=clsRFactor)
        clsRBarPlotGeom.SetRCommand("geom_bar")
        clsRBarPlotAes.SetRCommand("aes")
        clsRBarPlotAes.AddParameter("x", "Var1")
        clsRBarPlotAes.AddParameter("y", "value")
        clsRBarPlotAes.AddParameter("fill", "factor_col")
        clsRBarPlotGeom.AddParameter("", clsRFunctionParameter:=clsRBarPlotAes)
        clsRBarPlotGeom.AddParameter("stat", Chr(34) & "identity" & Chr(34))
        clsRBarPlotFacet.SetRCommand("facet_wrap")
        clsRBarPlotFacet.AddParameter("", "~Var2")
        clsRBarPlot0.AddParameter(iPosition:=0, clsRFunctionParameter:=clsRBarPlotFunction)
        clsRBarPlot0.AddParameter(clsRFunctionParameter:=clsRBarPlotGeom)
        clsRBarPlot.AddParameter(iPosition:=0, clsROperatorParameter:=clsRBarPlot0)
        clsRBarPlot.AddParameter(clsRFunctionParameter:=clsRBarPlotFacet)
    End Sub

    'When to run the various options in the "Display" tab and "Graphics" tab

    Public Sub PCAOptions()
        If rdoScreePlot.Checked Then
            ScreePlot()
        End If
        If rdoIndividualsPlot.Checked Then
            IndividualsPlot()
        End If
        If rdoVariablesPlot.Checked Then
            VariablesPlot()
        End If
        If rdoBiplot.Checked Then
            Biplot()
        End If
        If rdoBarPlot.Checked Then
            Barplot()
            frmMain.clsRLink.RunScript(clsRBarPlot.ToScript, 3)
        End If
    End Sub

    ' Here, the minimum and maximum dimensions selected rely on a few things
    Public Sub Dimensions()
        ' Now, if the receiver is empty or has one variable in it then the value for the second dimension is two
        If dlgPrincipalComponentAnalysis.ucrReceiverMultiplePCA.IsEmpty OrElse dlgPrincipalComponentAnalysis.ucrReceiverMultiplePCA.lstSelectedVariables.Items.Count = 1 Then
            ucrNudDim2.Value = 2
            ' If the receiver is has more than two variables, then the maximum dimension allowed depends on a few things
        ElseIf dlgPrincipalComponentAnalysis.ucrReceiverMultiplePCA.lstSelectedVariables.Items.Count > 1 Then
            ' Firstly, if the row length is shorter than the number of columns, and then if the row length is shorter than the components value selected in the main dialog, the data frame length maximum can only be as much as the row length minus one
            ' otherwise, if the row length is larger than the number of components, then the maximum dimensions can only be as much as the component value selected in the main dialog.
            If dlgPrincipalComponentAnalysis.ucrSelectorPCA.ucrAvailableDataFrames.iDataFrameLength <= dlgPrincipalComponentAnalysis.ucrReceiverMultiplePCA.lstSelectedVariables.Items.Count Then
                If dlgPrincipalComponentAnalysis.ucrSelectorPCA.ucrAvailableDataFrames.iDataFrameLength <= dlgPrincipalComponentAnalysis.ucrNudNumberOfComp.Value Then
                    ucrNudDim.Maximum = dlgPrincipalComponentAnalysis.ucrSelectorPCA.ucrAvailableDataFrames.iDataFrameLength - 1
                    ucrNudDim2.Maximum = dlgPrincipalComponentAnalysis.ucrSelectorPCA.ucrAvailableDataFrames.iDataFrameLength - 1
                Else
                    ucrNudDim.Maximum = dlgPrincipalComponentAnalysis.ucrNudNumberOfComp.Value
                    ucrNudDim2.Maximum = dlgPrincipalComponentAnalysis.ucrNudNumberOfComp.Value
                End If
            Else
                ' Firstly, if the column length is shorter than the number of rows, and then if the column length is shorter than the components value selected in the main dialog, the data frame length maximum can only be as much as the column length
                ' otherwise, if the column length is larger than the number of components, then the maximum dimensions selected can only be as much as the component value selected in the main dialog.
                If dlgPrincipalComponentAnalysis.ucrReceiverMultiplePCA.lstSelectedVariables.Items.Count <= dlgPrincipalComponentAnalysis.ucrNudNumberOfComp.Value Then
                    ucrNudDim.Maximum = dlgPrincipalComponentAnalysis.ucrReceiverMultiplePCA.lstSelectedVariables.Items.Count
                    ucrNudDim2.Maximum = dlgPrincipalComponentAnalysis.ucrReceiverMultiplePCA.lstSelectedVariables.Items.Count
                Else
                    ucrNudDim.Maximum = dlgPrincipalComponentAnalysis.ucrNudNumberOfComp.Value
                    ucrNudDim2.Maximum = dlgPrincipalComponentAnalysis.ucrNudNumberOfComp.Value
                End If
            End If
        End If
    End Sub

    ' In the "Graphics" tab, the groupbox regarding plot options changes depending what graph is chosen.
    ' Additionally, some label names change depending which is selected. This sub is about these changes.
    Private Sub DisplayOptions()
        If rdoBarPlot.Checked Then

        Else
            If rdoScreePlot.Checked Then
                lblChoiceScree.Text = "Choice:"
                rdoOne.Text = "Bar"
                rdoTwo.Text = "Line"
                ucrLabel.SetItems({"variance", "eigenvalue"})
                ucrLabel.SetName("variance")
            Else
                ucrLabel.SetName("all")
                ucrLabel.SetItems({"all", "ind.sup", "quali", "quanti.sup", "var", "ind", "none"})
                lblDim.Visible = True
                lblChoiceScree.Text = "Label:"
                rdoTwo.Text = "Text"
                If rdoVariablesPlot.Checked Then
                    rdoOne.Text = "Arrow"
                Else
                    rdoOne.Text = "Point"
                End If
            End If
        End If
    End Sub

    Private Sub rdoPlotItems_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBoth.CheckedChanged, rdoOne.CheckedChanged, rdoTwo.CheckedChanged
        GeomChecked()
    End Sub

    Public Sub ucrReceiverFactor_SelectionChanged() Handles ucrReceiverFactor.SelectionChanged
        Barplot()
    End Sub

    ' One of the options in the "Graphics" tab is what should be plotted on the graph. These options can change depending on which radio button is selected. This sub is about running the correct code for each graphic options
    Private Sub GeomChecked()
        If rdoScreePlot.Checked Then
            If rdoBoth.Checked Then
                clsRScreePlotFunction.AddParameter("geom", "c(" & Chr(34) & "bar" & Chr(34) & "," & Chr(34) & "line" & Chr(34) & ")")
            ElseIf rdoOne.Checked Then
                clsRScreePlotFunction.AddParameter("geom", Chr(34) & "bar" & Chr(34))
            ElseIf rdoTwo.Checked Then
                clsRScreePlotFunction.AddParameter("geom", Chr(34) & "line" & Chr(34))
            End If
        ElseIf rdoVariablesPlot.Checked Then
            If rdoBoth.Checked Then
                clsRVariablesPlotFunction.AddParameter("geom", "c(" & Chr(34) & "arrow" & Chr(34) & "," & Chr(34) & "text" & Chr(34) & ")")
            ElseIf rdoOne.Checked Then
                clsRVariablesPlotFunction.AddParameter("geom", Chr(34) & "arrow" & Chr(34))
            ElseIf rdoTwo.Checked Then
                clsRVariablesPlotFunction.AddParameter("geom", Chr(34) & "text" & Chr(34))
            End If
        ElseIf rdoIndividualsPlot.Checked Then
            If rdoBoth.Checked Then
                clsRIndividualsPlotFunction.AddParameter("geom", "c(" & Chr(34) & "point" & Chr(34) & "," & Chr(34) & "text" & Chr(34) & ")")
            ElseIf rdoOne.Checked Then
                clsRIndividualsPlotFunction.AddParameter("geom", Chr(34) & "point" & Chr(34))
            ElseIf rdoTwo.Checked Then
                clsRIndividualsPlotFunction.AddParameter("geom", Chr(34) & "text" & Chr(34))
            End If
        ElseIf rdoBiplot.Checked Then
            If rdoBoth.Checked Then
                clsRBiplotFunction.AddParameter("geom", "c(" & Chr(34) & "point" & Chr(34) & "," & Chr(34) & "text" & Chr(34) & ")")
            ElseIf rdoOne.Checked Then
                clsRBiplotFunction.AddParameter("geom", Chr(34) & "point" & Chr(34))
            ElseIf rdoTwo.Checked Then
                clsRBiplotFunction.AddParameter("geom", Chr(34) & "text" & Chr(34))
            Else
                clsRBiplotFunction.RemoveParameterByName("geom")
            End If
        Else
            clsRScreePlotFunction.RemoveParameterByName("geom")
        End If
    End Sub

    Private Sub cboLabelVar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ucrLabel.TextChanged
        ComboBoxOptions()
    End Sub

    Private Sub ComboBoxOptions()
        If rdoScreePlot.Checked Then
            clsRScreePlotFunction.AddParameter("choice", Chr(34) & ucrLabel.GetText & Chr(34))
        End If
        If rdoVariablesPlot.Checked Then
            clsRVariablesPlotFunction.AddParameter("label", Chr(34) & ucrLabel.GetText & Chr(34))
        End If
        If rdoIndividualsPlot.Checked Then
            clsRIndividualsPlotFunction.AddParameter("label", Chr(34) & ucrLabel.GetText & Chr(34))
        End If
        If rdoBiplot.Checked Then
            clsRBiplotFunction.AddParameter("label", Chr(34) & ucrLabel.GetText & Chr(34))
        End If
    End Sub

    Private Sub rdoPlots_CheckedChanged(sender As Object, e As EventArgs) Handles rdoScreePlot.CheckedChanged, rdoBarPlot.CheckedChanged, rdoBiplot.CheckedChanged, rdoVariablesPlot.CheckedChanged, rdoIndividualsPlot.CheckedChanged
        DisplayOptions()
        GeomChecked()
        ComboBoxOptions()
    End Sub

    Public Sub SetRFunction(clsNewREigenValues As RFunction, clsNewREigenVectors As RFunction, clsNewRRotation As RFunction, Optional bReset As Boolean = False)
        If Not bControlsInitialised Then
            InitialiseControls()
        End If
        clsREigenValues = clsNewREigenValues
        clsREigenVectors = clsNewREigenVectors
        clsRRotation = clsNewRRotation

        ucrChkEigenvalues.SetRCode(clsREigenValues, bReset)
        ucrChkEigenvectors.SetRCode(clsREigenVectors, bReset)
        ucrChkRotation.SetRCode(clsRRotation, bReset)


    End Sub

    'Private Sub Rotation()
    '    clsRRotation.SetRCommand("sweep")
    '    clsRCoord.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_from_model")
    '    clsRCoord.AddParameter("data_name", Chr(34) & dlgPrincipalComponentAnalysis.ucrSelectorPCA.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem & Chr(34))
    '    clsRCoord.AddParameter("model_name", Chr(34) & dlgPrincipalComponentAnalysis.strModelName & Chr(34))
    '    clsRCoord.AddParameter("value1", Chr(34) & "var" & Chr(34))
    '    clsRCoord.AddParameter("value2", Chr(34) & "coord" & Chr(34))
    '    clsREig.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_from_model")
    '    clsREig.AddParameter("data_name", Chr(34) & dlgPrincipalComponentAnalysis.ucrSelectorPCA.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem & Chr(34))
    '    clsREig.AddParameter("model_name", Chr(34) & dlgPrincipalComponentAnalysis.strModelName & Chr(34))
    '    clsREig.AddParameter("value1", Chr(34) & "eig" & Chr(34))
    '    clsRRotation.AddParameter("x", clsRFunctionParameter:=clsRCoord)
    '    clsRRotation.AddParameter("MARGIN", 2)
    '    clsRRotation.AddParameter("STATS", "sqrt(" & clsREig.ToScript.ToString & "[,1])")
    '    clsRRotation.AddParameter("FUN", " '/'")
    '    frmMain.clsRLink.RunScript(clsRRotation.ToScript(), 2)
    'End Sub
End Class