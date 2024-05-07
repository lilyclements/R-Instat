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

Public Class dlgClimograph
    Private bFirstload As Boolean = True
    Private bReset As Boolean = True
    Private clsGgwalterliethFunction, clsDummyFunction As RFunction
    Private clsBaseOperator As New ROperator
    Private ReadOnly strFacetWrap As String = "Facet Wrap"
    Private ReadOnly strFacetRow As String = "Facet Row"
    Private ReadOnly strFacetCol As String = "Facet Column"
    Private ReadOnly strNone As String = "None"
    Private ReadOnly strFacetWrap1 As String = "Facet Wrap"
    Private ReadOnly strFacetRow1 As String = "Facet Row"
    Private ReadOnly strFacetCol1 As String = "Facet Column"
    Private ReadOnly strNone1 As String = "None"
    Private clsFacetFunction As New RFunction
    Private clsGroupByFunction As New RFunction
    Private clsGeomBarFunction As New RFunction
    Private clsGeomLineFunction As New RFunction
    Private clsGeomLineFunction1 As New RFunction
    Private clsRggplotFunction As New RFunction
    Private clsBarAesFunction As New RFunction
    Private clsAesLineFunction As New RFunction
    Private clsAesLine1Function As New RFunction
    Private clsFacetFunction1 As New RFunction
    Private clsGroupByFunction1 As New RFunction
    Private bResetSubdialog As Boolean = True
    Private clsCoordPolarFunction As New RFunction
    Private clsRFacetFunction As New RFunction
    Private clsAnnotateFunction As New RFunction
    Private clsCoordPolarStartOperator As New ROperator
    Private clsXScaleDateFunction As New RFunction
    Private clsYScaleDateFunction As New RFunction
    Private clsScaleFillViridisFunction As New RFunction
    Private clsScaleColourViridisFunction As New RFunction
    Private clsScalecolouridentityFunction As New RFunction
    Private clsLabsFunction As New RFunction
    Private clsXlabFunction As New RFunction
    Private clsYlabFunction As New RFunction
    Private dctThemeFunctions As New Dictionary(Of String, RFunction)
    Private clsXScalecontinuousFunction As New RFunction
    Private clsYScalecontinuousFunction As New RFunction
    Private clsThemeFunction As New RFunction
    Private clsFacetVariablesOperator As New ROperator
    Private clsFacetRowOp1 As New ROperator
    Private clsFacetColOp1 As New ROperator
    Private clsPipeOperator1 As New ROperator
    Private clsFacetOperator As New ROperator
    Private clsFacetRowOp As New ROperator
    Private clsFacetColOp As New ROperator
    Private clsPipeOperator As New ROperator
    Private bUpdateComboOptions As Boolean = True
    Private bUpdatingParameters As Boolean = False
    Private bUpdateComboOptions1 As Boolean = True
    Private bUpdatingParameters1 As Boolean = False

    Private Sub dlgClimograph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstload Then
            InitialiseDialog()
            bFirstload = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        TestOKEnabled()
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        Dim dctLegendPosition As New Dictionary(Of String, String)

        ucrBase.iHelpTopicID = 432

        ucrSelectorClimograph.SetParameter(New RParameter("data", 0, bNewIncludeArgumentName:=False))
        ucrSelectorClimograph.SetParameterIsrfunction()

        ucrPnlClimograph.AddRadioButton(rdoClimograph)
        ucrPnlClimograph.AddRadioButton(rdoWalterLieth)
        ucrPnlClimograph.AddParameterValuesCondition(rdoWalterLieth, "checked", "WalterLieth")
        ucrPnlClimograph.AddParameterValuesCondition(rdoClimograph, "checked", "Climograph")

        ucrReceiverMonth.SetParameter(New RParameter("month", 1))
        ucrReceiverMonth.SetParameterIsString()
        ucrReceiverMonth.Selector = ucrSelectorClimograph
        ucrReceiverMonth.SetClimaticType("month")
        ucrReceiverMonth.bAutoFill = True
        ucrReceiverMonth.strSelectorHeading = "Month Variables"
        ucrReceiverMonth.SetLinkedDisplayControl(lblMonth)

        ucrReceiverMonthC.SetParameter(New RParameter("x", 2))
        ucrReceiverMonthC.SetParameterIsString()
        ucrReceiverMonthC.Selector = ucrSelectorClimograph
        ucrReceiverMonthC.bWithQuotes = False
        ucrReceiverMonthC.SetClimaticType("month")
        ucrReceiverMonthC.bAutoFill = True
        ucrReceiverMonthC.strSelectorHeading = "Month Variables"
        ucrReceiverMonthC.SetLinkedDisplayControl(lblMonthC)

        ucrReceiverRain.SetParameter(New RParameter("p_mes", 3))
        ucrReceiverRain.SetParameterIsString()
        ucrReceiverRain.Selector = ucrSelectorClimograph
        ucrReceiverRain.SetClimaticType("rain")
        ucrReceiverRain.bAutoFill = True
        ucrReceiverRain.strSelectorHeading = "Rain Variables"
        ucrReceiverRain.SetLinkedDisplayControl(lblRain)

        ucrReceiverRainC.SetParameter(New RParameter("y", 1))
        ucrReceiverRainC.SetParameterIsString()
        ucrReceiverRainC.Selector = ucrSelectorClimograph
        ucrReceiverRainC.bWithQuotes = False
        ucrReceiverRainC.SetClimaticType("rain")
        ucrReceiverRainC.bAutoFill = True
        ucrReceiverRainC.strSelectorHeading = "Rain Variables"
        ucrReceiverRainC.SetLinkedDisplayControl(lblRainC)

        ucrReceiverMaxtem.SetParameter(New RParameter("tm_max", 4))
        ucrReceiverMaxtem.SetParameterIsString()
        ucrReceiverMaxtem.Selector = ucrSelectorClimograph
        ucrReceiverMaxtem.SetClimaticType("temp_max")
        ucrReceiverMaxtem.bAutoFill = True
        ucrReceiverMaxtem.strSelectorHeading = "Variables"
        ucrReceiverMaxtem.SetLinkedDisplayControl(lblMaxtem)

        ucrReceiverMintemp.SetParameter(New RParameter("tm_min", 5))
        ucrReceiverMintemp.SetParameterIsString()
        ucrReceiverMintemp.Selector = ucrSelectorClimograph
        ucrReceiverMintemp.SetClimaticType("temp_min")
        ucrReceiverMintemp.bAutoFill = True
        ucrReceiverMintemp.strSelectorHeading = "Variables"
        ucrReceiverMintemp.SetLinkedDisplayControl(lblMintem)

        ucrReceiverElement1.SetParameter(New RParameter("y", 4))
        ucrReceiverElement1.SetParameterIsString()
        ucrReceiverElement1.Selector = ucrSelectorClimograph
        ucrReceiverElement1.bWithQuotes = False
        ucrReceiverElement1.SetClimaticType("temp_max")
        ucrReceiverElement1.bAutoFill = True
        ucrReceiverElement1.strSelectorHeading = "Variables"
        ucrReceiverElement1.SetLinkedDisplayControl(lblElement1)

        ucrReceiverElement2.SetParameter(New RParameter("y", 5))
        ucrReceiverElement2.SetParameterIsString()
        ucrReceiverElement2.Selector = ucrSelectorClimograph
        ucrReceiverElement2.bWithQuotes = False
        ucrReceiverElement2.SetClimaticType("temp_min")
        ucrReceiverElement2.bAutoFill = True
        ucrReceiverElement2.strSelectorHeading = "Variables"
        ucrReceiverElement2.SetLinkedDisplayControl(lblElement2)

        ucr1stFactorReceiver.SetParameter(New RParameter("var1"))
        ucr1stFactorReceiver.Selector = ucrSelectorClimograph
        ucr1stFactorReceiver.SetIncludedDataTypes({"factor"})
        ucr1stFactorReceiver.strSelectorHeading = "Factors"
        ucr1stFactorReceiver.bWithQuotes = False
        ucr1stFactorReceiver.SetParameterIsString()
        ucr1stFactorReceiver.SetValuesToIgnore({"."})

        ucrInputStation.SetItems({strFacetWrap, strFacetRow, strFacetCol, strNone})
        ucrInputStation.SetDropDownStyleAsNonEditable()

        ucrReceiverFacet.SetParameter(New RParameter("var1"))
        ucrReceiverFacet.Selector = ucrSelectorClimograph
        ucrReceiverFacet.SetClimaticType("year")
        ucrReceiverFacet.bAutoFill = True
        ucrReceiverFacet.bWithQuotes = False
        ucrReceiverFacet.SetParameterIsString()
        ucrReceiverFacet.SetValuesToIgnore({"."})

        ucrInputFacet.SetItems({strFacetWrap, strFacetRow, strFacetCol, strNone})
        ucrInputFacet.SetDropDownStyleAsNonEditable()

        ucrReceiverAbsolute.SetParameter(New RParameter("ta_min", 6))
        ucrReceiverAbsolute.SetParameterIsString()
        ucrReceiverAbsolute.Selector = ucrSelectorClimograph
        ucrReceiverAbsolute.strSelectorHeading = "Variables"
        ucrReceiverAbsolute.SetLinkedDisplayControl(lblAbsolute)

        ucrPnlClimograph.AddToLinkedControls({ucr1stFactorReceiver, ucrReceiverAbsolute, ucrReceiverMintemp, ucrReceiverMonth, ucrReceiverMaxtem, ucrReceiverRain, ucrInputStation}, {rdoWalterLieth}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlClimograph.AddToLinkedControls({ucrReceiverFacet, ucrChkLegend, ucrReceiverElement2, ucrReceiverElement1, ucrReceiverMonthC, ucrReceiverRainC, ucrInputFacet, ucrChkColourIdntity}, {rdoClimograph}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrChkColourIdntity.SetText("Colour Identity")
        ucrChkColourIdntity.AddParameterValuesCondition(True, "checked", "True")
        ucrChkColourIdntity.AddParameterValuesCondition(False, "checked", "False")
        ucrChkColourIdntity.AddToLinkedControls({ucrInputName, ucrInputLabels}, {True}, bNewLinkedHideIfParameterMissing:=True)
        ucrInputName.SetValidationTypeAsList()
        ucrInputName.SetLinkedDisplayControl(lblName)
        ucrInputLabels.SetValidationTypeAsList()
        ucrInputLabels.SetLinkedDisplayControl(lblLabel)

        ucrChkLegend.SetText("Legend:")
        ucrChkLegend.AddToLinkedControls({ucrInputLegendPosition}, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:="None")
        ucrInputLegendPosition.SetDropDownStyleAsNonEditable()
        ucrInputLegendPosition.SetParameter(New RParameter("legend.position"))
        dctLegendPosition.Add("None", Chr(34) & "none" & Chr(34))
        dctLegendPosition.Add("Left", Chr(34) & "left" & Chr(34))
        dctLegendPosition.Add("Right", Chr(34) & "right" & Chr(34))
        dctLegendPosition.Add("Top", Chr(34) & "top" & Chr(34))
        dctLegendPosition.Add("Bottom", Chr(34) & "bottom" & Chr(34))
        ucrInputLegendPosition.SetItems(dctLegendPosition)
        ucrChkLegend.AddParameterPresentCondition(True, "legend.position")
        ucrChkLegend.AddParameterPresentCondition(False, "legend.position", False)

        ucrSave.SetPrefix("wl_graph")
        ucrSave.SetIsComboBox()
        ucrSave.SetSaveTypeAsGraph()
        ucrSave.SetCheckBoxText("Save")
        ucrSave.SetDataFrameSelector(ucrSelectorClimograph.ucrAvailableDataFrames)
        ucrSave.SetAssignToIfUncheckedValue("last_graph")
    End Sub

    Private Sub SetDefaults()
        clsGgwalterliethFunction = New RFunction
        clsBaseOperator = New ROperator
        clsDummyFunction = New RFunction
        clsGroupByFunction = New RFunction
        clsPipeOperator = New ROperator

        clsFacetFunction = New RFunction
        clsFacetOperator = New ROperator
        clsFacetRowOp = New ROperator
        clsFacetColOp = New ROperator

        clsGeomBarFunction = New RFunction
        clsGeomLineFunction = New RFunction
        clsGeomLineFunction1 = New RFunction
        clsAesLineFunction = New RFunction
        clsAesLine1Function = New RFunction
        clsRggplotFunction = New RFunction
        clsBarAesFunction = New RFunction
        clsFacetFunction1 = New RFunction
        clsScalecolouridentityFunction = New RFunction
        clsFacetVariablesOperator = New ROperator
        clsFacetRowOp1 = New ROperator
        clsFacetColOp1 = New ROperator
        clsPipeOperator1 = New ROperator
        clsGroupByFunction1 = New RFunction

        ucrSelectorClimograph.Reset()
        ucrSelectorClimograph.SetGgplotFunction(clsBaseOperator)
        ucrSave.Reset()

        ucrInputStation.SetName(strFacetWrap)
        ucrInputStation.bUpdateRCodeFromControl = True

        ucrInputFacet.SetName(strFacetWrap)
        ucrInputFacet.bUpdateRCodeFromControl = True

        clsDummyFunction.AddParameter("checked", "Climograph", iPosition:=0)

        clsFacetFunction1.SetPackageName("ggplot2")
        clsFacetRowOp1.SetOperation("+")
        clsFacetRowOp1.bBrackets = False
        clsFacetColOp1.SetOperation("+")
        clsFacetColOp1.bBrackets = False
        clsFacetVariablesOperator.SetOperation("~")
        clsFacetVariablesOperator.bForceIncludeOperation = True
        clsFacetVariablesOperator.bBrackets = False
        clsFacetFunction1.AddParameter("facets", clsROperatorParameter:=clsFacetVariablesOperator, iPosition:=0)

        clsPipeOperator1.SetOperation("%>%")
        SetPipeAssignTo1()

        clsGroupByFunction1.SetPackageName("dplyr")
        clsGroupByFunction1.SetRCommand("group_by")

        clsPipeOperator.SetOperation("%>%")
        SetPipeAssignTo()

        clsGgwalterliethFunction.SetRCommand("ggwalter_lieth")

        clsFacetFunction.SetPackageName("ggplot2")
        clsFacetRowOp.SetOperation("+")
        clsFacetRowOp.bBrackets = False
        clsFacetColOp.SetOperation("+")
        clsFacetColOp.bBrackets = False
        clsFacetOperator.SetOperation("~")
        clsFacetOperator.bForceIncludeOperation = True
        clsFacetOperator.bBrackets = False
        clsFacetFunction.AddParameter("facets", clsROperatorParameter:=clsFacetOperator, iPosition:=0)

        clsGroupByFunction.SetPackageName("dplyr")
        clsGroupByFunction.SetRCommand("group_by")

        clsRggplotFunction.SetPackageName("ggplot2")
        clsRggplotFunction.SetRCommand("ggplot")
        clsRggplotFunction.AddParameter("mapping", clsRFunctionParameter:=clsBarAesFunction, iPosition:=1)

        clsBarAesFunction.SetRCommand("aes")
        clsBarAesFunction.AddParameter("fill", ucrReceiverMonthC.GetVariableNames(False), iPosition:=3)

        clsGeomBarFunction.SetRCommand("geom_bar")
        clsGeomBarFunction.AddParameter("stat", Chr(34) & "identity" & Chr(34), iPosition:=0)
        clsGeomBarFunction.AddParameter("alpha", "0.5", iPosition:=1)

        clsAesLineFunction.SetRCommand("aes")
        clsAesLineFunction.AddParameter("group", "1", iPosition:=1)
        clsAesLineFunction.AddParameter("colour", Chr(34) & "blue" & Chr(34), iPosition:=3)

        clsAesLine1Function.SetRCommand("aes")
        clsAesLine1Function.AddParameter("group", "1", iPosition:=1)
        clsAesLine1Function.AddParameter("colour", Chr(34) & "red" & Chr(34), iPosition:=3)

        clsGeomLineFunction.SetRCommand("geom_line")
        clsGeomLineFunction.AddParameter("mapping", clsRFunctionParameter:=clsAesLineFunction, iPosition:=0)

        clsGeomLineFunction1.SetRCommand("geom_line")
        clsGeomLineFunction1.AddParameter("mapping", clsRFunctionParameter:=clsAesLine1Function, iPosition:=0)

        clsScalecolouridentityFunction.SetRCommand("scale_colour_identity")
        clsScalecolouridentityFunction.AddParameter("guide", Chr(34) & "legend" & Chr(34), iPosition:=1)

        clsBaseOperator.SetOperation("+")
        clsBaseOperator.AddParameter("ggplot", clsRFunctionParameter:=clsRggplotFunction, iPosition:=0)
        clsBaseOperator.AddParameter("geom_bar", clsRFunctionParameter:=clsGeomBarFunction, iPosition:=2)

        clsLabsFunction = GgplotDefaults.clsDefaultLabs.Clone()
        clsXlabFunction = GgplotDefaults.clsXlabTitleFunction.Clone()
        clsYlabFunction = GgplotDefaults.clsYlabTitleFunction.Clone()
        clsXScalecontinuousFunction = GgplotDefaults.clsXScalecontinuousFunction.Clone()
        clsYScalecontinuousFunction = GgplotDefaults.clsYScalecontinuousFunction.Clone
        clsRFacetFunction = GgplotDefaults.clsFacetFunction.Clone()
        clsBaseOperator.AddParameter(GgplotDefaults.clsDefaultThemeParameter.Clone())
        clsCoordPolarStartOperator = GgplotDefaults.clsCoordPolarStartOperator.Clone()
        clsCoordPolarFunction = GgplotDefaults.clsCoordPolarFunction.Clone()
        clsXScaleDateFunction = GgplotDefaults.clsXScaleDateFunction.Clone()
        clsYScaleDateFunction = GgplotDefaults.clsYScaleDateFunction.Clone()
        clsThemeFunction = GgplotDefaults.clsDefaultThemeFunction.Clone()
        dctThemeFunctions = New Dictionary(Of String, RFunction)(GgplotDefaults.dctThemeFunctions)
        clsScaleFillViridisFunction = GgplotDefaults.clsScaleFillViridisFunction
        clsScaleColourViridisFunction = GgplotDefaults.clsScaleColorViridisFunction
        clsAnnotateFunction = GgplotDefaults.clsAnnotateFunction

        ucrBase.clsRsyntax.SetBaseROperator(clsBaseOperator)
    End Sub

    Private Sub SetRCodeForControls(bReset)
        ucrSelectorClimograph.AddAdditionalCodeParameterPair(clsGgwalterliethFunction, New RParameter("data", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=1)

        ucrSelectorClimograph.SetRCode(clsRggplotFunction, bReset)
        ucrReceiverRainC.SetRCode(clsBarAesFunction, bReset)
        ucrReceiverMonthC.SetRCode(clsBarAesFunction, bReset)
        ucrReceiverElement2.SetRCode(clsAesLine1Function, bReset)
        ucrReceiverElement1.SetRCode(clsAesLineFunction, bReset)
        ucrReceiverMonth.SetRCode(clsGgwalterliethFunction, bReset)
        ucrReceiverRain.SetRCode(clsGgwalterliethFunction, bReset)
        ucrReceiverMintemp.SetRCode(clsGgwalterliethFunction, bReset)
        ucrReceiverMaxtem.SetRCode(clsGgwalterliethFunction, bReset)
        ucrReceiverAbsolute.SetRCode(clsGgwalterliethFunction, bReset)
        ucrSave.SetRCode(clsBaseOperator, bReset)
        ucrChkLegend.SetRCode(clsThemeFunction, bReset, bCloneIfNeeded:=True)
        ucrInputLegendPosition.SetRCode(clsThemeFunction, bReset, bCloneIfNeeded:=True)
        If bReset Then
            ucrPnlClimograph.SetRCode(clsDummyFunction, bReset)
            ucrChkColourIdntity.SetRCode(clsScalecolouridentityFunction, bReset)
            ucrInputName.SetRCode(clsScalecolouridentityFunction, bReset)
            ucrInputLabels.SetRCode(clsScalecolouridentityFunction, bReset)
        End If
    End Sub

    Private Sub TestOKEnabled()
        If rdoClimograph.Checked AndAlso ((Not ucrReceiverElement1.IsEmpty AndAlso Not ucrReceiverElement2.IsEmpty AndAlso Not ucrReceiverMonthC.IsEmpty AndAlso Not ucrReceiverRainC.IsEmpty) OrElse Not ucrSave.IsComplete) Then
            ucrBase.OKEnabled(True)
        ElseIf rdoWalterLieth.Checked AndAlso ((Not ucrReceiverAbsolute.IsEmpty AndAlso Not ucrReceiverMaxtem.IsEmpty AndAlso Not ucrReceiverMintemp.IsEmpty AndAlso Not ucrReceiverMonth.IsEmpty AndAlso Not ucrReceiverRain.IsEmpty) OrElse Not ucrSave.IsComplete) Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrPnlClimograph_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrPnlClimograph.ControlValueChanged
        If rdoClimograph.Checked Then
            clsBaseOperator.RemoveParameterByName("ggwalter_lieth")
            ucrReceiverMonthC.SetMeAsReceiver()
            clsBaseOperator.AddParameter("ggplot", clsRFunctionParameter:=clsRggplotFunction, iPosition:=0)
            clsBaseOperator.AddParameter("geom_bar", clsRFunctionParameter:=clsGeomBarFunction, iPosition:=2)
        Else
            clsBaseOperator.RemoveParameterByName("ggplot")
            clsBaseOperator.RemoveParameterByName("geom_bar")
            ucrReceiverMonth.SetMeAsReceiver()
            clsBaseOperator.AddParameter("ggwalter_lieth", clsRFunctionParameter:=clsGgwalterliethFunction, iPosition:=0)
        End If
        AddGeomLine()
        Identity()
        AutoFacetStation()
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        UpdateParameters()
        TestOKEnabled()
    End Sub

    Private Sub cmdOptions_Click(sender As Object, e As EventArgs) Handles cmdOptions.Click
        sdgPlots.SetRCode(clsNewOperator:=ucrBase.clsRsyntax.clsBaseOperator, clsNewYScalecontinuousFunction:=clsYScalecontinuousFunction, clsNewXScalecontinuousFunction:=clsXScalecontinuousFunction,
                                clsNewXLabsTitleFunction:=clsXlabFunction, clsNewYLabTitleFunction:=clsYlabFunction, clsNewLabsFunction:=clsLabsFunction, clsNewFacetFunction:=clsRFacetFunction,
                                dctNewThemeFunctions:=dctThemeFunctions, ucrNewBaseSelector:=ucrSelectorClimograph, clsNewThemeFunction:=clsThemeFunction,
                                clsNewCoordPolarFunction:=clsCoordPolarFunction, clsNewCoordPolarStartOperator:=clsCoordPolarStartOperator, clsNewXScaleDateFunction:=clsXScaleDateFunction, clsNewAnnotateFunction:=clsAnnotateFunction,
                                clsNewScaleFillViridisFunction:=clsScaleFillViridisFunction, clsNewScaleColourViridisFunction:=clsScaleColourViridisFunction, clsNewYScaleDateFunction:=clsYScaleDateFunction, clsNewFacetVariablesOperator:=clsFacetVariablesOperator, bReset:=bResetSubdialog)
        sdgPlots.ShowDialog()
        bResetSubdialog = False
    End Sub

    Private Sub ucrInputFacet_ControlValueChanged(ucrChangedControl As ucrInputComboBox) Handles ucrInputFacet.ControlValueChanged
        If Not bUpdateComboOptions1 Then
            Exit Sub
        End If
        Dim strChangedText As String = ucrChangedControl.GetText()
        If strChangedText <> strNone Then
            If Not strChangedText = strFacetCol1 AndAlso Not strChangedText = strFacetRow1 AndAlso
                    Not ucrInputFacet.Equals(ucrChangedControl) AndAlso ucrInputFacet.GetText() = strChangedText Then
                bUpdateComboOptions1 = False
                ucrInputFacet.SetName(strNone1)
                bUpdateComboOptions1 = True
            End If
            If (strChangedText = strFacetWrap1 AndAlso ucrInputFacet.GetText = strFacetRow1) OrElse (strChangedText = strFacetRow1 AndAlso
                    ucrInputFacet.GetText = strFacetWrap1) OrElse (strChangedText = strFacetWrap1 AndAlso
                    ucrInputFacet.GetText = strFacetCol1) OrElse (strChangedText = strFacetCol1 AndAlso ucrInputFacet.GetText = strFacetWrap1) Then
                ucrInputFacet.SetName(strNone1)
            End If
        End If
        UpdateParameters1()
        AddRemoveFacets1()
        AddRemoveGroupBy1()
    End Sub

    Private Sub UpdateParameters1()
        clsFacetVariablesOperator.RemoveParameterByName("var1")
        clsFacetColOp1.RemoveParameterByName("col" & ucrInputFacet.Name)
        clsFacetRowOp1.RemoveParameterByName("row" & ucrInputFacet.Name)

        clsBaseOperator.RemoveParameterByName("facets")
        bUpdatingParameters1 = True
        ucrReceiverFacet.SetRCode(Nothing)
        Select Case ucrInputFacet.GetText()
            Case strFacetWrap1
                ucrReceiverFacet.ChangeParameterName("var1")
                ucrReceiverFacet.SetRCode(clsFacetVariablesOperator)
            Case strFacetCol1
                ucrReceiverFacet.ChangeParameterName("col" & ucrInputFacet.Name)
                ucrReceiverFacet.SetRCode(clsFacetColOp1)
            Case strFacetRow1
                ucrReceiverFacet.ChangeParameterName("row" & ucrInputFacet.Name)
                ucrReceiverFacet.SetRCode(clsFacetRowOp1)
        End Select
        If Not clsRFacetFunction.ContainsParameter("x") Then
            clsRFacetFunction.AddParameter("x", Chr(34) & Chr(34))
        End If
        bUpdatingParameters1 = False
    End Sub

    Private Sub AddRemoveFacets1()
        Dim bWrap As Boolean = False
        Dim bCol As Boolean = False
        Dim bRow As Boolean = False

        If bUpdatingParameters1 Then
            Exit Sub
        End If

        clsBaseOperator.RemoveParameterByName("facets")
        If Not ucrReceiverFacet.IsEmpty Then
            Select Case ucrInputFacet.GetText()
                Case strFacetWrap1
                    bWrap = True
                Case strFacetCol1
                    bCol = True
                Case strFacetRow1
                    bRow = True
            End Select
        End If

        If bWrap OrElse bRow OrElse bCol Then
            clsBaseOperator.AddParameter("facets", clsRFunctionParameter:=clsFacetFunction1)
        End If
        If bWrap Then
            clsFacetFunction1.SetRCommand("facet_wrap")
        End If
        If bRow OrElse bCol Then
            clsFacetFunction1.SetRCommand("facet_grid")
        End If
        If bRow Then
            clsFacetVariablesOperator.AddParameter("left", clsROperatorParameter:=clsFacetRowOp1, iPosition:=0)
        ElseIf bCol AndAlso bWrap = False Then
            clsFacetVariablesOperator.AddParameter("left", ".", iPosition:=0)
        Else
            clsFacetVariablesOperator.RemoveParameterByName("left")
        End If
        If bCol Then
            clsFacetVariablesOperator.AddParameter("right", clsROperatorParameter:=clsFacetColOp1, iPosition:=1)
        ElseIf bRow AndAlso bWrap = False Then
            clsFacetVariablesOperator.AddParameter("right", ".", iPosition:=1)
        Else
            clsFacetVariablesOperator.RemoveParameterByName("right")
        End If
    End Sub

    Private Sub ucrReceiverFacet_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverFacet.ControlValueChanged
        If Not ucrReceiverFacet.IsEmpty Then
            clsBaseOperator.AddParameter("facets", clsRFunctionParameter:=clsFacetFunction1)
        Else
            clsBaseOperator.RemoveParameterByName("facets")
        End If
        AddRemoveFacets1()
        AddRemoveGroupBy1()
    End Sub

    Private Sub GetParameterValue1(clsOperator As ROperator)
        Dim i As Integer = 0
        For Each clsTempParam As RParameter In clsOperator.clsParameters
            If clsTempParam.strArgumentValue <> "" AndAlso clsTempParam.strArgumentValue <> "." Then
                clsGroupByFunction1.AddParameter(i, clsTempParam.strArgumentValue, bIncludeArgumentName:=False, iPosition:=i)
                i = i + 1
            End If
        Next
    End Sub

    Private Sub AddRemoveGroupBy1()
        If clsPipeOperator1.ContainsParameter("mutate") Then
            clsGroupByFunction1.ClearParameters()
            If clsBaseOperator.ContainsParameter("facets") Then
                Select Case ucrInputFacet.GetText()
                    Case strFacetWrap1
                        GetParameterValue1(clsFacetVariablesOperator)
                    Case strFacetCol1
                        GetParameterValue1(clsFacetColOp1)
                    Case strFacetRow1
                        GetParameterValue1(clsFacetRowOp1)
                End Select
            End If

            If clsGroupByFunction1.iParameterCount > 0 Then
                clsPipeOperator1.AddParameter("group_by", clsRFunctionParameter:=clsGroupByFunction1, iPosition:=1)
            Else
                clsPipeOperator1.RemoveParameterByName("group_by")
            End If
        Else
            clsPipeOperator1.RemoveParameterByName("group_by")
        End If

        SetPipeAssignTo1()
    End Sub

    Private Sub SetPipeAssignTo1()
        If ucrSelectorClimograph.ucrAvailableDataFrames.cboAvailableDataFrames.Text <> "" AndAlso clsPipeOperator1.clsParameters.Count > 1 Then
            clsPipeOperator1.SetAssignTo(ucrSelectorClimograph.ucrAvailableDataFrames.cboAvailableDataFrames.Text)
        Else
            clsPipeOperator1.RemoveAssignTo()
        End If
    End Sub

    Private Sub ucrInput_ControlValueChanged(ucrChangedControl As ucrInputComboBox) Handles ucrInputStation.ControlValueChanged
        If Not bUpdateComboOptions Then
            Exit Sub
        End If
        Dim strChangedText As String = ucrChangedControl.GetText()
        If strChangedText <> strNone Then
            If Not strChangedText = strFacetCol AndAlso Not strChangedText = strFacetRow AndAlso
                    Not ucrInputStation.Equals(ucrChangedControl) AndAlso ucrInputStation.GetText() = strChangedText Then
                bUpdateComboOptions = False
                ucrInputStation.SetName(strNone)
                bUpdateComboOptions = True
            End If
            If (strChangedText = strFacetWrap AndAlso ucrInputStation.GetText = strFacetRow) OrElse (strChangedText = strFacetRow AndAlso
                    ucrInputStation.GetText = strFacetWrap) OrElse (strChangedText = strFacetWrap AndAlso
                    ucrInputStation.GetText = strFacetCol) OrElse (strChangedText = strFacetCol AndAlso ucrInputStation.GetText = strFacetWrap) Then
                ucrInputStation.SetName(strNone)
            End If
        End If
        UpdateParameters()
        AddRemoveFacets()
        AddRemoveGroupBy()
    End Sub

    Private Sub UpdateParameters()
        clsFacetOperator.RemoveParameterByName("var1")
        clsFacetColOp.RemoveParameterByName("col" & ucrInputStation.Name)
        clsFacetRowOp.RemoveParameterByName("row" & ucrInputStation.Name)

        clsBaseOperator.RemoveParameterByName("facets")
        bUpdatingParameters = True
        ucr1stFactorReceiver.SetRCode(Nothing)
        Select Case ucrInputStation.GetText()
            Case strFacetWrap
                ucr1stFactorReceiver.ChangeParameterName("var1")
                ucr1stFactorReceiver.SetRCode(clsFacetOperator)
            Case strFacetCol
                ucr1stFactorReceiver.ChangeParameterName("col" & ucrInputStation.Name)
                ucr1stFactorReceiver.SetRCode(clsFacetColOp)
            Case strFacetRow
                ucr1stFactorReceiver.ChangeParameterName("row" & ucrInputStation.Name)
                ucr1stFactorReceiver.SetRCode(clsFacetRowOp)
        End Select
        bUpdatingParameters = False
    End Sub

    Private Sub AddRemoveFacets()
        Dim bWrap As Boolean = False
        Dim bCol As Boolean = False
        Dim bRow As Boolean = False

        If bUpdatingParameters Then
            Exit Sub
        End If

        clsBaseOperator.RemoveParameterByName("facets")
        If Not ucr1stFactorReceiver.IsEmpty Then
            Select Case ucrInputStation.GetText()
                Case strFacetWrap
                    bWrap = True
                Case strFacetCol
                    bCol = True
                Case strFacetRow
                    bRow = True
            End Select
        End If

        If bWrap OrElse bRow OrElse bCol Then
            clsBaseOperator.AddParameter("facets", clsRFunctionParameter:=clsFacetFunction)
        End If
        If bWrap Then
            clsFacetFunction.SetRCommand("facet_wrap")
        End If
        If bRow OrElse bCol Then
            clsFacetFunction.SetRCommand("facet_grid")
        End If
        If bRow Then
            clsFacetOperator.AddParameter("left", clsROperatorParameter:=clsFacetRowOp, iPosition:=0)
        ElseIf bCol AndAlso Not bWrap Then
            clsFacetOperator.AddParameter("left", ".", iPosition:=0)
        Else
            clsFacetOperator.RemoveParameterByName("left")
        End If
        If bCol Then
            clsFacetOperator.AddParameter("right", clsROperatorParameter:=clsFacetColOp, iPosition:=1)
        ElseIf bRow AndAlso Not bWrap Then
            clsFacetOperator.AddParameter("right", ".", iPosition:=1)
        Else
            clsFacetOperator.RemoveParameterByName("right")
        End If
    End Sub

    Private Sub ucr1stFactorReceiver_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucr1stFactorReceiver.ControlValueChanged
        If Not ucr1stFactorReceiver.IsEmpty Then
            clsGgwalterliethFunction.AddParameter("station", ucr1stFactorReceiver.GetVariableNames(), iPosition:=1)
        Else
            clsGgwalterliethFunction.RemoveParameterByName("station")
            clsBaseOperator.RemoveParameterByName("facets")
        End If
        AddRemoveFacets()
        AddRemoveGroupBy()
    End Sub

    Private Sub AutoFacetStation()
        If rdoClimograph.Checked Then
            Dim currentReceiver As ucrReceiver = ucrSelectorClimograph.CurrentReceiver

            If currentReceiver IsNot Nothing Then
                ucrReceiverFacet.AddItemsWithMetadataProperty(ucrSelectorClimograph.ucrAvailableDataFrames.cboAvailableDataFrames.Text, "Climatic_Type", {"year_label"})
                currentReceiver.SetMeAsReceiver()
                AddRemoveGroupBy1()
            End If
        Else
            Dim ucrCurrentReceiver As ucrReceiver = ucrSelectorClimograph.CurrentReceiver

            If ucrCurrentReceiver IsNot Nothing Then
                ucr1stFactorReceiver.AddItemsWithMetadataProperty(ucrSelectorClimograph.ucrAvailableDataFrames.cboAvailableDataFrames.Text, "Climatic_Type", {"station_label"})
                ucrCurrentReceiver.SetMeAsReceiver()
                AddRemoveGroupBy()
            End If
        End If
    End Sub

    Private Sub ucrSelectorClimograph_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrSelectorClimograph.ControlValueChanged
        AutoFacetStation()
        SetPipeAssignTo()
        SetPipeAssignTo1()
    End Sub

    Private Sub GetParameterValue(clsOperator As ROperator)
        Dim i As Integer = 0
        For Each clsTempParam As RParameter In clsOperator.clsParameters
            If clsTempParam.strArgumentValue <> "" AndAlso clsTempParam.strArgumentValue <> "." Then
                clsGroupByFunction.AddParameter(i, clsTempParam.strArgumentValue, bIncludeArgumentName:=False, iPosition:=i)
                i = i + 1
            End If
        Next
    End Sub

    Private Sub AddRemoveGroupBy()

        If clsPipeOperator.ContainsParameter("mutate") Then
            clsGroupByFunction.ClearParameters()
            If clsBaseOperator.ContainsParameter("facets") Then
                Select Case ucrInputStation.GetText()
                    Case strFacetWrap
                        GetParameterValue(clsFacetOperator)
                    Case strFacetCol
                        GetParameterValue(clsFacetColOp)
                    Case strFacetRow
                        GetParameterValue(clsFacetRowOp)
                End Select
            End If

            If clsGroupByFunction.iParameterCount > 0 Then
                clsPipeOperator.AddParameter("group_by", clsRFunctionParameter:=clsGroupByFunction, iPosition:=1)
            Else
                clsPipeOperator.RemoveParameterByName("group_by")
            End If
        Else
            clsPipeOperator.RemoveParameterByName("group_by")
        End If

        SetPipeAssignTo()
    End Sub

    Private Sub SetPipeAssignTo()
        If ucrSelectorClimograph.ucrAvailableDataFrames.cboAvailableDataFrames.Text <> "" AndAlso clsPipeOperator.clsParameters.Count > 1 Then
            clsPipeOperator.SetAssignTo(ucrSelectorClimograph.ucrAvailableDataFrames.cboAvailableDataFrames.Text)
        Else
            clsPipeOperator.RemoveAssignTo()
        End If
    End Sub

    Private Sub AddGeomLine()
        If rdoClimograph.Checked Then
            If Not ucrReceiverElement1.IsEmpty Then
                clsBaseOperator.AddParameter("geom_line", clsRFunctionParameter:=clsGeomLineFunction, iPosition:=2)
            Else
                clsBaseOperator.RemoveParameterByName("geom_line")
            End If
            If Not ucrReceiverElement1.IsEmpty Then
                clsBaseOperator.AddParameter("geom_line1", clsRFunctionParameter:=clsGeomLineFunction1, iPosition:=3)
            Else
                clsBaseOperator.RemoveParameterByName("geom_line1")
            End If
        Else
            clsBaseOperator.RemoveParameterByName("geom_line")
            clsBaseOperator.RemoveParameterByName("geom_line1")
        End If
    End Sub

    Private Sub ucrReceiverElement1_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverElement1.ControlValueChanged
        AddGeomLine()
    End Sub

    Private Sub AddRemoveTheme()
        If clsThemeFunction.iParameterCount > 0 Then
            clsBaseOperator.AddParameter("theme", clsRFunctionParameter:=clsThemeFunction, iPosition:=15)
        Else
            clsBaseOperator.RemoveParameterByName("theme")
        End If
    End Sub

    Private Sub ucrChkLegend_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkLegend.ControlValueChanged, ucrInputLegendPosition.ControlValueChanged
        AddRemoveTheme()
    End Sub

    Private Sub Identity()
        If rdoClimograph.Checked Then
            If ucrChkColourIdntity.Checked Then
                clsBaseOperator.AddParameter("scale_colour_identity", clsRFunctionParameter:=clsScalecolouridentityFunction, iPosition:=13)
                If Not ucrInputLabels.IsEmpty Then
                    clsScalecolouridentityFunction.AddParameter("labels", ucrInputLabels.clsRList.ToScript(), iPosition:=2)
                Else
                    clsScalecolouridentityFunction.RemoveParameterByName("labels")
                End If
                If Not ucrInputName.IsEmpty Then
                    clsScalecolouridentityFunction.AddParameter("name", Chr(34) & ucrInputName.GetText() & Chr(34), iPosition:=0)
                Else
                    clsScalecolouridentityFunction.RemoveParameterByName("name")
                End If
            Else
                clsBaseOperator.RemoveParameterByName("scale_colour_identity")
            End If
        Else
            clsBaseOperator.RemoveParameterByName("scale_colour_identity")
        End If
    End Sub

    Private Sub ucrChkColourIdntity_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkColourIdntity.ControlValueChanged, ucrInputName.ControlValueChanged, ucrInputLabels.ControlValueChanged
        Identity()
    End Sub

    Private Sub AllControls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrPnlClimograph.ControlContentsChanged, ucrReceiverRain.ControlContentsChanged, ucrReceiverAbsolute.ControlContentsChanged, ucrReceiverMonth.ControlContentsChanged, ucrReceiverMaxtem.ControlContentsChanged, ucrReceiverMintemp.ControlContentsChanged, ucrSave.ControlContentsChanged, ucrReceiverElement1.ControlContentsChanged, ucrReceiverElement2.ControlContentsChanged, ucrReceiverMonthC.ControlContentsChanged, ucrReceiverRainC.ControlContentsChanged
        TestOKEnabled()
    End Sub
End Class