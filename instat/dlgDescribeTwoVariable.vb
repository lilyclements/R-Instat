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
Public Class dlgDescribeTwoVariable
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private bResetSubdialog As Boolean = False
    Public strFirstVariablesType, strSecondVariableType As String
    Public clsGetDataTypeFunction, clsGetSecondDataTypeFunction, clsRCorrelationFunction, clsRCustomSummaryFunction,
           clsCombineFunction, clsRAnovaFunction, clsFrequencyTablesFunction, clsSkimrFunction, clsSummariesListFunction,
           clsGroupByFunction, clsDummyFunction, clsMmtableFunction, clsHeaderTopLeftFunction,
           clsHeaderLeftTopFunction, clsHeaderLeftTopFuncion, clsCombineFrequencyParametersFunction,
           clsSummaryMapFunction, clsCombineMultipleColumnsFunction, clsCombineFactorsFunction,
           clsMmtableMapFunction, clsHeaderTopLeftSummaryVariableFunction, clsSecondHeaderTopLeftFunction,
           clsCombineFrequencyFactorParameterFunction, clsSelectFunction, clsRenameCombineFunction,
           clsSecondHeaderLeftTopFunction, clsThreeVariableCombineFrequencyParametersFunction As New RFunction
    Private clsGroupByPipeOperator, clsMmtablePlusOperator, clsMapFrequencyPipeOperator,
             clsMmtableTildeOperator, clsDataSelectTildeOperator, clsEmptyOperator, clsSecondEmptyOperator As New ROperator
    Private lstFrequencyParameters As New List(Of String)({"percentage_type", "margin_name",
                                                          "perc_total_factors", "perc_decimal",
                                                          "signif_fig", "include_margins"})
    Private iUcrBaseXLocation, iDialogueXsize As Integer

    Private Sub dlgDescribeTwoVariable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
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
        ucrBase.iHelpTopicID = 414
        ucrBase.clsRsyntax.iCallType = 2

        iUcrBaseXLocation = ucrBase.Location.X
        iDialogueXsize = Me.Size.Width

        ucrSelectorDescribeTwoVar.SetParameter(New RParameter("data_name", 0))
        ucrSelectorDescribeTwoVar.SetParameterIsString()

        ucrReceiverFirstVars.SetParameter(New RParameter("columns_to_summarise", 1))
        ucrReceiverFirstVars.SetParameterIsString()
        ucrReceiverFirstVars.Selector = ucrSelectorDescribeTwoVar
        ucrReceiverFirstVars.SetSingleTypeStatus(True, bIsCategoricalNumeric:=True)

        ucrReceiverSecondTwoVariableFactor.SetParameter(New RParameter("factors", 2))
        ucrReceiverSecondTwoVariableFactor.SetParameterIsString()
        ucrReceiverSecondTwoVariableFactor.Selector = ucrSelectorDescribeTwoVar
        ucrReceiverSecondTwoVariableFactor.SetLinkedDisplayControl(lbSecondVariable)

        ucrReceiverSkimrGroupByFactor.SetParameter(New RParameter("factors", 2, bNewIncludeArgumentName:=False))
        ucrReceiverSkimrGroupByFactor.bWithQuotes = False
        ucrReceiverSkimrGroupByFactor.SetParameterIsString()
        ucrReceiverSkimrGroupByFactor.Selector = ucrSelectorDescribeTwoVar
        ucrReceiverSkimrGroupByFactor.SetLinkedDisplayControl(lblFirstGroupByFactor)
        ucrReceiverSkimrGroupByFactor.SetDataType("factor")

        ucrReceiverSecondSkimrGroupByFactor.SetParameter(New RParameter("second_factor", 3, bNewIncludeArgumentName:=False))
        ucrReceiverSecondSkimrGroupByFactor.bWithQuotes = False
        ucrReceiverSecondSkimrGroupByFactor.SetParameterIsString()
        ucrReceiverSecondSkimrGroupByFactor.Selector = ucrSelectorDescribeTwoVar
        ucrReceiverSecondSkimrGroupByFactor.SetLinkedDisplayControl(lblSecondGroupByFactor)
        ucrReceiverSecondSkimrGroupByFactor.SetDataType("factor")

        ucrReceiverNumericVariable.SetParameterIsString()
        ucrReceiverNumericVariable.Selector = ucrSelectorDescribeTwoVar
        ucrReceiverNumericVariable.SetLinkedDisplayControl(lblNumericVariable)

        ucrChkOmitMissing.SetParameter(New RParameter("na.rm", 6))
        ucrChkOmitMissing.SetText("Omit Missing Values")
        ucrChkOmitMissing.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkOmitMissing.bUpdateRCodeFromControl = True

        ucrChkDisplayMargins.SetParameter(New RParameter("include_margins", 5))
        ucrChkDisplayMargins.SetText("Display Margins")
        ucrChkDisplayMargins.SetRDefault("FALSE")

        ucrInputMarginName.SetLinkedDisplayControl(lblMarginName)

        ucrPnlDescribe.AddRadioButton(rdoTwoVariable)
        ucrPnlDescribe.AddRadioButton(rdoSkim)
        ucrPnlDescribe.AddRadioButton(rdoThreeVariable)
        ucrPnlDescribe.AddParameterValuesCondition(rdoTwoVariable, "checked", "customize")
        ucrPnlDescribe.AddParameterValuesCondition(rdoSkim, "checked", "skim")
        ucrPnlDescribe.AddParameterValuesCondition(rdoThreeVariable, "checked", "three_variable")

        ucrPnlDescribe.AddToLinkedControls({ucrReceiverFirstVars}, {rdoTwoVariable, rdoSkim}, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlDescribe.AddToLinkedControls({ucrReceiverThreeVariableFirstFactor}, {rdoThreeVariable}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlDescribe.AddToLinkedControls({ucrReceiverSkimrGroupByFactor, ucrReceiverSecondSkimrGroupByFactor}, {rdoSkim}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlDescribe.AddToLinkedControls({ucrReceiverNumericVariable}, {rdoThreeVariable}, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlDescribe.AddToLinkedControls({ucrReceiverSecondTwoVariableFactor}, {rdoTwoVariable}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlDescribe.AddToLinkedControls({ucrReceiverThreeVariableSecondFactor}, {rdoThreeVariable}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrChkDisplayAsPercentage.SetParameter(New RParameter("percentage_type", 1))
        ucrChkDisplayAsPercentage.SetText("As Percentages")
        ucrChkDisplayAsPercentage.SetValuesCheckedAndUnchecked(Chr(34) & "factors" & Chr(34), Chr(34) & "none" & Chr(34))
        ucrChkDisplayAsPercentage.SetRDefault(Chr(34) & "none" & Chr(34))

        ucrChkDisplayAsPercentage.AddToLinkedControls(ucrReceiverPercentages, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrChkDisplayAsPercentage.AddToLinkedControls(ucrChkPercentageProportion, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrReceiverThreeVariableFirstFactor.SetParameterIsString()
        ucrReceiverThreeVariableFirstFactor.Selector = ucrSelectorDescribeTwoVar
        ucrReceiverThreeVariableFirstFactor.SetIncludedDataTypes({"factor"})

        ucrReceiverThreeVariableSecondFactor.SetParameter(New RParameter("second_three_varible_factor", 0, bNewIncludeArgumentName:=False))
        ucrReceiverThreeVariableSecondFactor.SetParameterIsString()
        ucrReceiverThreeVariableSecondFactor.Selector = ucrSelectorDescribeTwoVar
        ucrReceiverThreeVariableSecondFactor.SetIncludedDataTypes({"factor"})
        ucrReceiverThreeVariableSecondFactor.SetLinkedDisplayControl(lblThreeVariableSecondFactor)

        ucrReceiverPercentages.SetParameter(New RParameter("perc_total_factors", 2))
        ucrReceiverPercentages.SetParameterIsString()
        ucrReceiverPercentages.Selector = ucrSelectorDescribeTwoVar
        ucrReceiverPercentages.SetDataType("factor")
        ucrReceiverPercentages.SetLinkedDisplayControl(lblFactorsAsPercentage)

        ucrChkThreeVariableDisplayAsPercentage.SetParameter(New RParameter("percentage_type", 1))
        ucrChkThreeVariableDisplayAsPercentage.SetText("As Percentages")
        ucrChkThreeVariableDisplayAsPercentage.SetValuesCheckedAndUnchecked(Chr(34) & "factors" & Chr(34), Chr(34) & "none" & Chr(34))
        ucrChkThreeVariableDisplayAsPercentage.SetRDefault(Chr(34) & "none" & Chr(34))

        ucrChkThreeVariableDisplayAsPercentage.AddToLinkedControls(ucrReceiverThreeVariableMultiplePercentages, {True}, bNewLinkedHideIfParameterMissing:=True,
                                                      bNewLinkedAddRemoveParameter:=True)
        ucrChkThreeVariableDisplayAsPercentage.AddToLinkedControls(ucrChkThreeVariablePercentageProportion, {True}, bNewLinkedAddRemoveParameter:=True,
                                                      bNewLinkedHideIfParameterMissing:=True)

        ucrReceiverThreeVariableMultiplePercentages.SetParameter(New RParameter("perc_total_factors", 2))
        ucrReceiverThreeVariableMultiplePercentages.SetParameterIsString()
        ucrReceiverThreeVariableMultiplePercentages.Selector = ucrSelectorDescribeTwoVar
        ucrReceiverThreeVariableMultiplePercentages.SetDataType("factor")
        ucrReceiverThreeVariableMultiplePercentages.SetLinkedDisplayControl(lblThreeVariableFactorAsPercentages)

        ucrChkThreeVariablePercentageProportion.SetParameter(New RParameter("perc_decimal", 3))
        ucrChkThreeVariablePercentageProportion.SetText("Display as Decimal")
        ucrChkThreeVariablePercentageProportion.SetRDefault("FALSE")

        ucrChkPercentageProportion.SetParameter(New RParameter("perc_decimal", 3))
        ucrChkPercentageProportion.SetText("Display as Decimal")
        ucrChkPercentageProportion.SetRDefault("FALSE")

        ucrNudSigFigs.SetParameter(New RParameter("signif_fig", 6))
        ucrNudSigFigs.SetMinMax(0, 22)
        ucrNudSigFigs.SetRDefault(2)

        ucrNudColumnFactors.SetMinMax(1, 2)

        clsGetDataTypeFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_variables_metadata")
        clsGetDataTypeFunction.AddParameter("property", "data_type_label")

        clsGetSecondDataTypeFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_variables_metadata")
        clsGetSecondDataTypeFunction.AddParameter("property", "data_type_label")
    End Sub

    Private Sub SetDefaults()
        clsFrequencyTablesFunction = New RFunction
        clsRAnovaFunction = New RFunction
        clsRCorrelationFunction = New RFunction
        clsSummariesListFunction = New RFunction
        clsRCustomSummaryFunction = New RFunction
        clsCombineFunction = New RFunction
        clsSkimrFunction = New RFunction
        clsGroupByPipeOperator = New ROperator
        clsGroupByFunction = New RFunction
        clsMmtableFunction = New RFunction
        clsHeaderTopLeftFunction = New RFunction
        clsHeaderLeftTopFunction = New RFunction
        clsHeaderLeftTopFuncion = New RFunction
        clsDummyFunction = New RFunction
        clsCombineFrequencyParametersFunction = New RFunction
        clsSummaryMapFunction = New RFunction
        clsCombineMultipleColumnsFunction = New RFunction
        clsMmtableMapFunction = New RFunction
        clsHeaderTopLeftSummaryVariableFunction = New RFunction
        clsCombineFactorsFunction = New RFunction
        clsCombineFrequencyFactorParameterFunction = New RFunction
        clsSelectFunction = New RFunction
        clsRenameCombineFunction = New RFunction
        clsSecondHeaderTopLeftFunction = New RFunction
        clsSecondHeaderLeftTopFunction = New RFunction
        clsThreeVariableCombineFrequencyParametersFunction = New RFunction
        clsDataSelectTildeOperator = New ROperator
        clsMmtableTildeOperator = New ROperator
        clsMapFrequencyPipeOperator = New ROperator
        clsMmtablePlusOperator = New ROperator
        clsEmptyOperator = New ROperator
        clsSecondEmptyOperator = New ROperator

        ucrSelectorDescribeTwoVar.Reset()
        ucrReceiverFirstVars.SetMeAsReceiver()
        ucrInputMarginName.SetText("All")
        ucrNudColumnFactors.SetText("2")
        ucrInputMarginName.Visible = False
        grpThreeVariablePercentages.Visible = False

        ucrBase.clsRsyntax.ClearCodes()

        clsCombineFrequencyParametersFunction.SetRCommand("c")

        clsThreeVariableCombineFrequencyParametersFunction.SetRCommand("c")

        clsCombineFactorsFunction.SetRCommand("c")

        clsRenameCombineFunction.SetRCommand("c")
        clsRenameCombineFunction.AddParameter("first", "1", iPosition:=0, bIncludeArgumentName:=False)
        clsRenameCombineFunction.AddParameter("fourth", "4", iPosition:=3, bIncludeArgumentName:=False)

        clsSelectFunction.SetPackageName("dplyr")
        clsSelectFunction.SetRCommand("select")
        clsSelectFunction.AddParameter(".data", clsRFunctionParameter:=clsFrequencyTablesFunction, iPosition:=0)
        clsSelectFunction.AddParameter("rename_function", bIncludeArgumentName:=False, clsRFunctionParameter:=clsRenameCombineFunction, iPosition:=1)

        clsCombineFrequencyFactorParameterFunction.SetRCommand("c")
        clsCombineFrequencyFactorParameterFunction.AddParameter("factor_by", ".x",
                                                                iPosition:=3, bIncludeArgumentName:=False)

        clsEmptyOperator.SetOperation("")
        clsEmptyOperator.AddParameter("multiple_receiver_cols", "multiple_receiver_cols", iPosition:=0)
        clsEmptyOperator.SetAssignTo("names(list_of_tables)")

        clsSecondEmptyOperator.SetOperation("")
        clsSecondEmptyOperator.iCallType = 2
        clsSecondEmptyOperator.AddParameter("list_of_tables", "list_of_tables", iPosition:=0)

        clsDataSelectTildeOperator.SetOperation("~")
        clsDataSelectTildeOperator.AddParameter("empty_parameter", "", iPosition:=0)
        clsDataSelectTildeOperator.AddParameter("select_function", clsRFunctionParameter:=clsSelectFunction, iPosition:=1)

        clsMmtableTildeOperator.SetOperation("~")
        clsMmtableTildeOperator.AddParameter("empty_parameter", "", iPosition:=0)
        clsMmtableTildeOperator.AddParameter("mmtable", clsRFunctionParameter:=clsMmtableFunction, iPosition:=1)

        clsCombineMultipleColumnsFunction.SetRCommand("c")
        clsCombineMultipleColumnsFunction.SetAssignTo("multiple_receiver_cols")

        clsSummaryMapFunction.SetPackageName("purrr")
        clsSummaryMapFunction.SetRCommand("map")
        clsSummaryMapFunction.AddParameter(".x", clsRFunctionParameter:=clsCombineMultipleColumnsFunction, iPosition:=0)
        clsSummaryMapFunction.AddParameter(".f", clsROperatorParameter:=clsDataSelectTildeOperator, iPosition:=1)

        clsMmtableMapFunction.SetPackageName("purrr")
        clsMmtableMapFunction.SetRCommand("map")
        clsMmtableMapFunction.AddParameter(".x", ".", iPosition:=0)
        clsMmtableMapFunction.AddParameter(".f", clsROperatorParameter:=clsMmtablePlusOperator, iPosition:=1)

        clsMapFrequencyPipeOperator.SetOperation("%>%")
        clsMapFrequencyPipeOperator.AddParameter("map_summary_table", clsRFunctionParameter:=clsSummaryMapFunction, iPosition:=1)
        clsMapFrequencyPipeOperator.AddParameter("map_mmtable", clsRFunctionParameter:=clsMmtableMapFunction, iPosition:=2)
        clsMapFrequencyPipeOperator.AddParameter("data", clsRFunctionParameter:=ucrSelectorDescribeTwoVar.ucrAvailableDataFrames.clsCurrDataFrame, iPosition:=0)
        clsMapFrequencyPipeOperator.SetAssignTo("list_of_tables ")

        clsHeaderTopLeftFunction.SetPackageName("mmtable2")
        clsHeaderTopLeftFunction.SetRCommand("header_top_left")

        clsHeaderLeftTopFunction.SetPackageName("mmtable2")
        clsHeaderLeftTopFunction.SetRCommand("header_left_top")

        clsSecondHeaderTopLeftFunction.SetPackageName("mmtable2")
        clsSecondHeaderTopLeftFunction.SetRCommand("header_top_left")

        clsSecondHeaderLeftTopFunction.SetPackageName("mmtable2")
        clsSecondHeaderLeftTopFunction.SetRCommand("header_left_top")

        clsHeaderTopLeftSummaryVariableFunction.SetPackageName("mmtable2")
        clsHeaderTopLeftSummaryVariableFunction.SetRCommand("header_top_left")
        clsHeaderTopLeftSummaryVariableFunction.AddParameter("variable", Chr(39) & "summary-variable" & Chr(39), iPosition:=0)

        clsMmtableFunction.SetPackageName("mmtable2")
        clsMmtableFunction.SetRCommand("mmtable")
        clsMmtableFunction.AddParameter("data", ".x", iPosition:=0)
        clsMmtableFunction.AddParameter("cells", "value", iPosition:=1)

        clsDummyFunction.AddParameter("checked", "skim", iPosition:=0)

        clsMmtablePlusOperator.SetOperation("+")
        clsMmtablePlusOperator.bBrackets = False
        clsMmtablePlusOperator.AddParameter("mmtable2", clsROperatorParameter:=clsMmtableTildeOperator, iPosition:=0)
        clsMmtablePlusOperator.AddParameter("header_top_left", clsRFunctionParameter:=clsHeaderTopLeftFunction, iPosition:=1)
        clsMmtablePlusOperator.AddParameter("header_left_top", clsRFunctionParameter:=clsHeaderLeftTopFunction, iPosition:=2)

        clsGroupByPipeOperator.SetOperation("%>%")
        clsGroupByPipeOperator.AddParameter("skim", clsRFunctionParameter:=clsSkimrFunction, iPosition:=2, bIncludeArgumentName:=False)
        clsGroupByPipeOperator.AddParameter("data", clsRFunctionParameter:=ucrSelectorDescribeTwoVar.ucrAvailableDataFrames.clsCurrDataFrame, iPosition:=0)

        clsGroupByFunction.SetPackageName("dplyr")
        clsGroupByFunction.SetRCommand("group_by")

        clsSkimrFunction.SetPackageName("skimr")
        clsSkimrFunction.SetRCommand("skim_without_charts")

        clsCombineFunction.SetRCommand("c")

        clsFrequencyTablesFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$summary_table")
        clsFrequencyTablesFunction.AddParameter("data_name", Chr(34) & ucrSelectorDescribeTwoVar.ucrAvailableDataFrames.cboAvailableDataFrames.Text & Chr(34), iPosition:=0)
        clsFrequencyTablesFunction.AddParameter("summaries", Chr(34) & "summary_count" & Chr(34), iPosition:=1)
        clsFrequencyTablesFunction.AddParameter("factors", clsRFunctionParameter:=clsCombineFrequencyFactorParameterFunction, iPosition:=2)

        clsRAnovaFunction.AddParameter("signif.stars", "FALSE", iPosition:=2)
        clsRAnovaFunction.AddParameter("sign_level", "FALSE", iPosition:=3)
        clsRAnovaFunction.AddParameter("means", "FALSE", iPosition:=4)

        clsSummariesListFunction.SetRCommand("c")
        clsSummariesListFunction.AddParameter("summary_count_missing", Chr(34) & "summary_count_missing" & Chr(34), bIncludeArgumentName:=False, iPosition:=0)
        clsSummariesListFunction.AddParameter("summary_min", Chr(34) & "summary_min" & Chr(34), bIncludeArgumentName:=False, iPosition:=1)
        clsSummariesListFunction.AddParameter("p25", Chr(34) & "p25" & Chr(34), bIncludeArgumentName:=False, iPosition:=2)
        clsSummariesListFunction.AddParameter("summary_median", Chr(34) & "summary_median" & Chr(34), bIncludeArgumentName:=False, iPosition:=3)
        clsSummariesListFunction.AddParameter("summary_mean", Chr(34) & "summary_mean" & Chr(34), bIncludeArgumentName:=False, iPosition:=4)
        clsSummariesListFunction.AddParameter("p75", Chr(34) & "p75" & Chr(34), bIncludeArgumentName:=False, iPosition:=5)
        clsSummariesListFunction.AddParameter("summary_max", Chr(34) & "summary_max" & Chr(34), bIncludeArgumentName:=False, iPosition:=6)

        clsRCustomSummaryFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$summary")
        clsRCustomSummaryFunction.AddParameter("summaries", clsRFunctionParameter:=clsSummariesListFunction)

        clsRCustomSummaryFunction.AddParameter("store_results", "FALSE", iPosition:=4)
        clsRCustomSummaryFunction.AddParameter("drop", "TRUE", iPosition:=5)
        clsRCustomSummaryFunction.AddParameter("na.rm", "FALSE", iPosition:=6)
        clsRCustomSummaryFunction.AddParameter("return_output", "TRUE", iPosition:=7)

        clsRCorrelationFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$cor")

        clsRAnovaFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$anova_tables")

        ucrBase.clsRsyntax.SetBaseROperator(clsGroupByPipeOperator)
        bResetSubdialog = True
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrReceiverSecondTwoVariableFactor.AddAdditionalCodeParameterPair(clsRAnovaFunction, New RParameter("y_col_name", 2), iAdditionalPairNo:=1)
        ucrReceiverSecondTwoVariableFactor.AddAdditionalCodeParameterPair(clsRCorrelationFunction, New RParameter("y_col_name", 2), iAdditionalPairNo:=2)
        ucrReceiverSecondTwoVariableFactor.AddAdditionalCodeParameterPair(clsCombineFrequencyFactorParameterFunction, New RParameter("factor_one", 2, bNewIncludeArgumentName:=False), iAdditionalPairNo:=3)

        ucrReceiverFirstVars.AddAdditionalCodeParameterPair(clsRAnovaFunction, New RParameter("x_col_names", 1), iAdditionalPairNo:=1)
        ucrReceiverFirstVars.AddAdditionalCodeParameterPair(clsRCorrelationFunction, New RParameter("x_col_names", 1), iAdditionalPairNo:=2)
        ucrReceiverFirstVars.AddAdditionalCodeParameterPair(clsSkimrFunction, New RParameter("col_names", 1, bNewIncludeArgumentName:=False), iAdditionalPairNo:=3)

        ucrSelectorDescribeTwoVar.AddAdditionalCodeParameterPair(clsRAnovaFunction, ucrSelectorDescribeTwoVar.GetParameter(), iAdditionalPairNo:=1)
        ucrSelectorDescribeTwoVar.AddAdditionalCodeParameterPair(clsRCustomSummaryFunction, ucrSelectorDescribeTwoVar.GetParameter(), iAdditionalPairNo:=2)

        ucrChkDisplayMargins.AddAdditionalCodeParameterPair(clsThreeVariableCombineFrequencyParametersFunction, ucrChkDisplayMargins.GetParameter, iAdditionalPairNo:=1)

        ucrNudSigFigs.AddAdditionalCodeParameterPair(clsThreeVariableCombineFrequencyParametersFunction, ucrNudSigFigs.GetParameter, iAdditionalPairNo:=1)

        ucrChkOmitMissing.SetRCode(clsRCustomSummaryFunction, bReset)
        ucrReceiverFirstVars.SetRCode(clsRCustomSummaryFunction, bReset)
        ucrReceiverSecondTwoVariableFactor.SetRCode(clsRCustomSummaryFunction, bReset)
        ucrSelectorDescribeTwoVar.SetRCode(clsRCorrelationFunction, bReset)
        ucrReceiverSkimrGroupByFactor.SetRCode(clsGroupByFunction, bReset)
        ucrReceiverSecondSkimrGroupByFactor.SetRCode(clsGroupByFunction, bReset)
        ucrChkDisplayMargins.SetRCode(clsCombineFrequencyParametersFunction, bReset)
        ucrChkDisplayAsPercentage.SetRCode(clsCombineFrequencyParametersFunction, bReset)
        ucrReceiverPercentages.SetRCode(clsCombineFrequencyParametersFunction, bReset)
        ucrChkPercentageProportion.SetRCode(clsCombineFrequencyParametersFunction, bReset)
        ucrChkThreeVariableDisplayAsPercentage.SetRCode(clsThreeVariableCombineFrequencyParametersFunction, bReset)
        ucrReceiverThreeVariableMultiplePercentages.SetRCode(clsThreeVariableCombineFrequencyParametersFunction, bReset)
        ucrChkThreeVariablePercentageProportion.SetRCode(clsThreeVariableCombineFrequencyParametersFunction, bReset)
        ucrReceiverThreeVariableSecondFactor.SetRCode(clsCombineFrequencyFactorParameterFunction, bReset)
        ucrPnlDescribe.SetRCode(clsDummyFunction, bReset)
        ucrNudSigFigs.SetRCode(clsCombineFrequencyParametersFunction, bReset)
        Results()
    End Sub

    Public Sub TestOKEnabled()
        If rdoTwoVariable.Checked Then
            If ((Not ucrReceiverSecondTwoVariableFactor.IsEmpty()) AndAlso (Not ucrReceiverFirstVars.IsEmpty())) Then
                If ((strFirstVariablesType = "numeric" OrElse strFirstVariablesType = "integer") AndAlso (strSecondVariableType = "factor")) AndAlso clsSummariesListFunction.clsParameters.Count = 0 Then
                    ucrBase.OKEnabled(False)
                Else
                    ucrBase.OKEnabled(True)
                End If
            Else
                ucrBase.OKEnabled(False)
            End If
        ElseIf rdoSkim.checked Then
            If ucrReceiverFirstVars.IsEmpty Then
                ucrBase.OKEnabled(False)
            Else
                ucrBase.OKEnabled(True)
            End If
        Else
            ucrBase.OKEnabled(True)
        End If
    End Sub

    Private Sub ucrBaseDescribeTwoVar_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub cmdSummaries_Click(sender As Object, e As EventArgs) Handles cmdSummaries.Click
        sdgSummaries.SetRFunction(clsSummariesListFunction, clsRCustomSummaryFunction, clsCombineFunction, ucrSelectorDescribeTwoVar, bResetSubdialog)
        bResetSubdialog = False
        sdgSummaries.ShowDialog()
        TestOKEnabled()
    End Sub

    Private Sub cmdDisplayOptions_Click(sender As Object, e As EventArgs)
        sdgDescribeDisplay.SetRFunction(clsFrequencyTablesFunction, clsRAnovaFunction, bResetSubdialog)
        bResetSubdialog = False
        sdgDescribeDisplay.ShowDialog()
        TestOKEnabled()
    End Sub

    Public Sub Results()
        Dim lstFirstItemTypes As List(Of String)
        ucrBase.clsRsyntax.RemoveFromAfterCodes(clsEmptyOperator)
        ucrBase.clsRsyntax.RemoveFromAfterCodes(clsSecondEmptyOperator)
        If rdoTwoVariable.Checked Then
            grpSummaries.Visible = True
            If Not ucrReceiverFirstVars.IsEmpty() Then
                lstFirstItemTypes = ucrReceiverFirstVars.GetCurrentItemTypes(True, bIsCategoricalNumeric:=True)
                If lstFirstItemTypes.Count = 1 AndAlso lstFirstItemTypes.Contains("logical") Then
                    lstFirstItemTypes(0) = "categorical"
                Else
                    lstFirstItemTypes.RemoveAll(Function(x) x.Contains("logical"))
                End If
                If (lstFirstItemTypes.Count > 0) Then
                    strFirstVariablesType = lstFirstItemTypes(0)
                Else
                    strFirstVariablesType = ""
                End If
                lblFirstType.Text = strFirstVariablesType
                lblFirstType.ForeColor = SystemColors.Highlight
            Else
                strFirstVariablesType = ""
                lblFirstType.Text = "________"
                lblFirstType.ForeColor = SystemColors.ControlText
            End If
            If Not ucrReceiverSecondTwoVariableFactor.IsEmpty() Then
                strSecondVariableType = ucrReceiverSecondTwoVariableFactor.strCurrDataType
                If strSecondVariableType.Contains("factor") OrElse strSecondVariableType.Contains("character") OrElse strSecondVariableType.Contains("logical") Then
                    strSecondVariableType = "categorical"
                Else
                    strSecondVariableType = "numeric"
                End If
                lblSecondType.Text = strSecondVariableType
                lblSecondType.ForeColor = SystemColors.Highlight
            Else
                strSecondVariableType = ""
                lblSecondType.Text = "________"
                lblSecondType.ForeColor = SystemColors.ControlText
            End If

            If strFirstVariablesType = "numeric" AndAlso strSecondVariableType = "numeric" Then
                grpOptions.Visible = True
                cmdSummaries.Visible = False
                ucrChkOmitMissing.Visible = True
                ucrBase.clsRsyntax.SetBaseRFunction(clsRCorrelationFunction)
                lblSummaryName.Text = "Correlations"
                lblSummaryName.ForeColor = SystemColors.Highlight
            ElseIf strFirstVariablesType = "categorical" AndAlso strSecondVariableType = "numeric" Then
                grpOptions.Visible = False
                ucrBase.clsRsyntax.SetBaseRFunction(clsRAnovaFunction)
                lblSummaryName.Text = "ANOVA tables"
                lblSummaryName.ForeColor = SystemColors.Highlight
            ElseIf strFirstVariablesType = "numeric" AndAlso strSecondVariableType = "categorical" Then
                grpOptions.Visible = True
                cmdSummaries.Visible = True
                ucrChkOmitMissing.Visible = True
                ucrBase.clsRsyntax.SetBaseRFunction(clsRCustomSummaryFunction)
                ucrReceiverFirstVars.SetParameterIsString()
                lblSummaryName.Text = "Numerical summaries"
                lblSummaryName.ForeColor = SystemColors.Highlight
            ElseIf strFirstVariablesType = "categorical" AndAlso strSecondVariableType = "categorical" Then
                grpOptions.Visible = False
                ucrBase.clsRsyntax.SetBaseROperator(clsMapFrequencyPipeOperator)
                ucrBase.clsRsyntax.AddToAfterCodes(clsEmptyOperator, 1)
                ucrBase.clsRsyntax.AddToAfterCodes(clsSecondEmptyOperator, 2)
                lblSummaryName.Text = "Frequency tables"
                lblSummaryName.ForeColor = SystemColors.Highlight
            Else
                grpOptions.Visible = False
                lblSummaryName.Text = "__________"
                lblSummaryName.ForeColor = SystemColors.ControlText
            End If
        Else
            grpOptions.Visible = False
            grpSummaries.Visible = False
            If rdoThreeVariable.Checked Then
                ucrBase.clsRsyntax.SetBaseROperator(clsMapFrequencyPipeOperator)
                ucrBase.clsRsyntax.AddToAfterCodes(clsEmptyOperator, 1)
                ucrBase.clsRsyntax.AddToAfterCodes(clsSecondEmptyOperator, 2)
            End If
        End If
        autoTranslate(Me)
    End Sub

    Private Sub Controls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverFirstVars.ControlContentsChanged,
                ucrReceiverSecondTwoVariableFactor.ControlContentsChanged, ucrPnlDescribe.ControlContentsChanged,
                ucrReceiverThreeVariableFirstFactor.ControlValueChanged, ucrReceiverThreeVariableSecondFactor.ControlValueChanged
        If rdoTwoVariable.Checked Then
            If Not ucrReceiverFirstVars.IsEmpty AndAlso (ucrChangedControl Is ucrReceiverFirstVars OrElse ucrChangedControl Is ucrReceiverSecondTwoVariableFactor) Then
                Dim iPosition As Integer = 0
                clsCombineMultipleColumnsFunction.ClearParameters()
                clsCombineFactorsFunction.ClearParameters()

                For Each strColumn In ucrReceiverFirstVars.GetVariableNamesList()
                    clsCombineMultipleColumnsFunction.AddParameter(strColumn, strColumn, bIncludeArgumentName:=False, iPosition:=iPosition)
                    If ucrReceiverSecondTwoVariableFactor.GetVariableNames <> strColumn Then
                        clsCombineFactorsFunction.AddParameter(strColumn, strColumn, bIncludeArgumentName:=False, iPosition:=iPosition)
                    End If
                    iPosition += 1
                Next
                clsCombineFactorsFunction.AddParameter(ucrReceiverSecondTwoVariableFactor.GetVariableNames, ucrReceiverSecondTwoVariableFactor.GetVariableNames,
                                                       bIncludeArgumentName:=False, iPosition:=iPosition)
            End If
        ElseIf rdoThreeVariable.Checked Then
            If Not ucrReceiverThreeVariableFirstFactor.IsEmpty AndAlso (ucrChangedControl Is ucrReceiverThreeVariableFirstFactor OrElse ucrChangedControl Is ucrReceiverThreeVariableSecondFactor) Then
                Dim iPosition As Integer = 0
                clsCombineMultipleColumnsFunction.ClearParameters()
                clsCombineFactorsFunction.ClearParameters()

                For Each strColumn In ucrReceiverThreeVariableFirstFactor.GetVariableNamesList()
                    clsCombineMultipleColumnsFunction.AddParameter(strColumn, strColumn, bIncludeArgumentName:=False, iPosition:=iPosition)
                    If ucrReceiverThreeVariableSecondFactor.GetVariableNames <> strColumn Then
                        clsCombineFactorsFunction.AddParameter(strColumn, strColumn, bIncludeArgumentName:=False, iPosition:=iPosition)
                    End If
                    iPosition += 1
                Next
                clsCombineFactorsFunction.AddParameter(ucrReceiverThreeVariableSecondFactor.GetVariableNames, ucrReceiverSecondTwoVariableFactor.GetVariableNames,
                                                       bIncludeArgumentName:=False, iPosition:=iPosition)
            End If
        End If
        SwapMmtableHeaderFunctions()
        Results()
        EnableDisableFrequencyControls()
        AddRemoveFrequencyParameters()
        ChangeLocations()
        TestOKEnabled()
    End Sub

    Private Sub ucrChkOmitMissing_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkOmitMissing.ControlValueChanged
        If ucrChkOmitMissing.Checked Then
            clsRCorrelationFunction.AddParameter("use", Chr(34) & "pairwise.complete.obs" & Chr(34), iPosition:=2)
        Else
            clsRCorrelationFunction.RemoveParameterByName("use")
        End If
    End Sub

    Private Sub ucrPnlDescribe_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrPnlDescribe.ControlValueChanged
        ucrReceiverFirstVars.Clear()
        ucrReceiverFirstVars.SetMeAsReceiver()

        If rdoSkim.Checked Then
            clsDummyFunction.AddParameter("checked", "skim", iPosition:=0)
            ucrReceiverFirstVars.SetSingleTypeStatus(False)
            ucrBase.clsRsyntax.SetBaseROperator(clsGroupByPipeOperator)
        ElseIf rdoTwoVariable.Checked Then
            clsDummyFunction.AddParameter("checked", "customize", iPosition:=0)
            ucrBase.clsRsyntax.SetBaseRFunction(clsRCustomSummaryFunction)
            ucrReceiverFirstVars.SetSingleTypeStatus(True, bIsCategoricalNumeric:=True)
        Else
            ucrReceiverThreeVariableFirstFactor.SetMeAsReceiver()
            clsDummyFunction.AddParameter("checked", "three_variable", iPosition:=0)
        End If
        UpdateClsRenameCombineFunction()
        ChangeLocations()
        UpdateClsCombineFrequencyFactorParameterFunction()
    End Sub

    Private Sub UpdateClsRenameCombineFunction()
        clsRenameCombineFunction.RemoveParameterByName("by_var")
        clsRenameCombineFunction.RemoveParameterByName("second")
        clsRenameCombineFunction.RemoveParameterByName("third")
        clsRenameCombineFunction.RemoveParameterByName("fifth")
        If rdoThreeVariable.Checked Then
            If ucrReceiverNumericVariable.strCurrDataType = "factor" AndAlso Not ucrReceiverNumericVariable.IsEmpty Then
                clsRenameCombineFunction.AddParameter("second", "2", iPosition:=1, bIncludeArgumentName:=False)
                clsRenameCombineFunction.AddParameter("by_var", "3", iPosition:=2)
                clsRenameCombineFunction.AddParameter("fifth", "5", iPosition:=4, bIncludeArgumentName:=False)
            ElseIf ucrReceiverNumericVariable.strCurrDataType = "numeric" AndAlso Not ucrReceiverNumericVariable.IsEmpty Then
                clsRenameCombineFunction.AddParameter("by_var", "2", iPosition:=1)
                clsRenameCombineFunction.AddParameter("third", "3", iPosition:=2, bIncludeArgumentName:=False)
            End If
        ElseIf rdoThreeVariable.Checked Then
            clsRenameCombineFunction.AddParameter("by_var", "2", iPosition:=1)
            clsRenameCombineFunction.AddParameter("third", "3", iPosition:=2, bIncludeArgumentName:=False)
        End If
    End Sub

    Private Sub ChangeLocations()
        grpFrequency.Location = New Point(10, 302)
        If rdoSkim.Checked Then
            ucrBase.Location = New Point(iUcrBaseXLocation, 328)
            Me.Size = New Point(iDialogueXsize, 425)
        ElseIf rdoTwoVariable.Checked Then
            If strFirstVariablesType = "categorical" AndAlso
                strSecondVariableType = "categorical" Then
                ucrBase.Location = New Point(iUcrBaseXLocation, 435)
                Me.Size = New Point(iDialogueXsize, 530)
            Else
                ucrBase.Location = New Point(iUcrBaseXLocation, 328)
                Me.Size = New Point(iDialogueXsize, 425)
            End If
        ElseIf rdoThreeVariable.Checked Then
            If ucrReceiverNumericVariable.strCurrDataType = "factor" AndAlso
                Not ucrReceiverNumericVariable.IsEmpty Then
                ucrBase.Location = New Point(iUcrBaseXLocation, 435)
                Me.Size = New Point(iDialogueXsize, 530)
                grpFrequency.Location = New Point(10, 250)
            Else
                ucrBase.Location = New Point(iUcrBaseXLocation, 328)
                Me.Size = New Point(iDialogueXsize, 425)
                grpFrequency.Location = New Point(10, 302)
            End If
        End If
    End Sub

    Private Sub ucrReceiverSecondOpt_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverSkimrGroupByFactor.ControlValueChanged
        If ucrReceiverSkimrGroupByFactor.IsEmpty Then
            clsGroupByPipeOperator.RemoveParameterByName("group")
        Else
            clsGroupByPipeOperator.AddParameter("group", clsRFunctionParameter:=clsGroupByFunction, iPosition:=1, bIncludeArgumentName:=False)
        End If
    End Sub

    Private Sub EnableDisableFrequencyControls()
        grpThreeVariablePercentages.Visible = False
        If rdoTwoVariable.Checked Then
            If strFirstVariablesType = "categorical" AndAlso strSecondVariableType = "categorical" Then
                grpTwoVariablePercentages.Visible = True
                grpFrequency.Visible = True
                ucrChkDisplayMargins.Visible = True
                ucrInputMarginName.Visible = ucrChkDisplayMargins.Checked
            Else
                ucrReceiverFirstVars.SetMeAsReceiver()
                DisableFrequencyControls()
            End If
        ElseIf rdoSkim.Checked Then
            DisableFrequencyControls()
        Else
            If ucrReceiverNumericVariable.strCurrDataType = "factor" AndAlso
                Not ucrReceiverNumericVariable.IsEmpty Then
                grpThreeVariablePercentages.Visible = True
                grpTwoVariablePercentages.Visible = False
                grpFrequency.Visible = True
                ucrChkDisplayMargins.Visible = True
                ucrInputMarginName.Visible = ucrChkDisplayMargins.Checked
            Else
                ucrReceiverThreeVariableFirstFactor.SetMeAsReceiver()
                DisableFrequencyControls()
            End If
            ChangeLocations()
        End If
    End Sub

    Private Sub DisableFrequencyControls()
        grpTwoVariablePercentages.Visible = False
        grpFrequency.Visible = False
        ucrChkDisplayMargins.Visible = False
        ucrInputMarginName.Visible = False
    End Sub

    Private Sub SwapMmtableHeaderFunctions()
        clsMmtablePlusOperator.RemoveParameterByName("second_header_top_left")
        clsMmtablePlusOperator.RemoveParameterByName("second_header_left_top")
        If rdoTwoVariable.Checked Then
            clsMmtablePlusOperator.AddParameter("header_top_left", clsRFunctionParameter:=clsHeaderTopLeftFunction, iPosition:=1)
            clsMmtablePlusOperator.AddParameter("header_left_top", clsRFunctionParameter:=clsHeaderLeftTopFunction, iPosition:=2)
            If Not ucrReceiverSecondTwoVariableFactor.IsEmpty Then
                If ucrNudColumnFactors.GetText = 1 Then
                    clsHeaderLeftTopFunction.AddParameter("variable", Chr(39) & "by_var" & Chr(39), iPosition:=0)
                    clsHeaderTopLeftFunction.AddParameter("variable", ucrReceiverSecondTwoVariableFactor.GetVariableNames(), iPosition:=0)
                ElseIf ucrNudColumnFactors.GetText = 2 Then
                    clsHeaderTopLeftFunction.AddParameter("variable", Chr(39) & "by_var" & Chr(39), iPosition:=0)
                    clsHeaderLeftTopFunction.AddParameter("variable", ucrReceiverSecondTwoVariableFactor.GetVariableNames(), iPosition:=0)
                End If
            End If
        ElseIf rdoThreeVariable.Checked Then
            If Not ucrReceiverThreeVariableSecondFactor.IsEmpty Then
                If ucrNudColumnFactors.GetText = 1 Then
                    clsHeaderLeftTopFunction.AddParameter("variable", Chr(39) & "by_var" & Chr(39), iPosition:=0)
                    clsHeaderTopLeftFunction.AddParameter("variable", ucrReceiverThreeVariableSecondFactor.GetVariableNames(), iPosition:=0)
                ElseIf ucrNudColumnFactors.GetText = 2 Then
                    clsHeaderTopLeftFunction.AddParameter("variable", Chr(39) & "by_var" & Chr(39), iPosition:=0)
                    clsHeaderLeftTopFunction.AddParameter("variable", ucrReceiverThreeVariableSecondFactor.GetVariableNames(), iPosition:=0)
                End If
            End If
            If Not ucrReceiverNumericVariable.IsEmpty Then
                If ucrNudColumnFactors.GetText = 1 Then
                    clsSecondHeaderTopLeftFunction.AddParameter("variable", ucrReceiverNumericVariable.GetVariableNames(), iPosition:=0)
                    clsMmtablePlusOperator.AddParameter("second_header_top_left", clsRFunctionParameter:=clsSecondHeaderTopLeftFunction, iPosition:=3)
                ElseIf ucrNudColumnFactors.GetText = 2 Then
                    clsSecondHeaderLeftTopFunction.AddParameter("variable", ucrReceiverNumericVariable.GetVariableNames(), iPosition:=0)
                    clsMmtablePlusOperator.AddParameter("second_header_left_top", clsRFunctionParameter:=clsSecondHeaderLeftTopFunction, iPosition:=3)
                End If
            End If
        End If
    End Sub

    Private Sub AddRemoveFrequencyParameters()
        If rdoTwoVariable.Checked Then
            If strFirstVariablesType = "categorical" AndAlso strSecondVariableType = "categorical" Then
                For Each strParameter In lstFrequencyParameters
                    clsFrequencyTablesFunction.RemoveParameterByName(strParameter)
                Next
                For Each clsParameter In clsCombineFrequencyParametersFunction.clsParameters
                    clsFrequencyTablesFunction.AddParameter(clsParameter)
                Next
            End If
        ElseIf rdoThreeVariable.Checked Then
            For Each strParameter In lstFrequencyParameters
                clsFrequencyTablesFunction.RemoveParameterByName(strParameter)
            Next
            If ucrReceiverNumericVariable.strCurrDataType = "factor" AndAlso Not ucrReceiverNumericVariable.IsEmpty Then
                For Each clsParameter In clsThreeVariableCombineFrequencyParametersFunction.clsParameters
                    clsFrequencyTablesFunction.AddParameter(clsParameter)
                Next
            End If
        End If
    End Sub

    Private Sub Frequencies_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkPercentageProportion.ControlValueChanged,
        ucrChkDisplayAsPercentage.ControlValueChanged, ucrNudSigFigs.ControlValueChanged, ucrChkDisplayMargins.ControlValueChanged,
        ucrReceiverPercentages.ControlValueChanged, ucrInputMarginName.ControlValueChanged, ucrChkThreeVariablePercentageProportion.ControlValueChanged,
        ucrReceiverThreeVariableMultiplePercentages.ControlValueChanged, ucrChkThreeVariableDisplayAsPercentage.ControlValueChanged
        If rdoTwoVariable.Checked Then
            If ucrChkDisplayAsPercentage.Checked Then
                ucrReceiverPercentages.SetMeAsReceiver()
            Else
                ucrReceiverFirstVars.SetMeAsReceiver()
            End If
        ElseIf rdoThreeVariable.checked Then
            If ucrChkThreeVariableDisplayAsPercentage.Checked Then
                ucrReceiverThreeVariableMultiplePercentages.SetMeAsReceiver()
            Else
                ucrReceiverThreeVariableFirstFactor.SetMeAsReceiver()
            End If
        End If
        If ucrChkDisplayMargins.Checked Then
            ucrInputMarginName.Visible = True
            clsCombineFrequencyParametersFunction.AddParameter("margin_name", Chr(34) & ucrInputMarginName.GetText & Chr(34), iPosition:=6)
            clsThreeVariableCombineFrequencyParametersFunction.AddParameter("margin_name", Chr(34) & ucrInputMarginName.GetText & Chr(34), iPosition:=6)
        Else
            ucrInputMarginName.Visible = False
            clsCombineFrequencyParametersFunction.RemoveParameterByName("margin_name")
            clsThreeVariableCombineFrequencyParametersFunction.RemoveParameterByName("margin_name")
        End If
        AddRemoveFrequencyParameters()
    End Sub

    Private Sub ucrNudColumnFactors_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrNudColumnFactors.ControlValueChanged
        SwapMmtableHeaderFunctions()
    End Sub

    Private Sub ucrSelectorDescribeTwoVar_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrSelectorDescribeTwoVar.ControlValueChanged
        clsGroupByPipeOperator.AddParameter("data", clsRFunctionParameter:=ucrSelectorDescribeTwoVar.ucrAvailableDataFrames.clsCurrDataFrame, iPosition:=0)
        clsMapFrequencyPipeOperator.AddParameter("data", clsRFunctionParameter:=ucrSelectorDescribeTwoVar.ucrAvailableDataFrames.clsCurrDataFrame, iPosition:=0)
        clsFrequencyTablesFunction.AddParameter("data_name", Chr(34) & ucrSelectorDescribeTwoVar.ucrAvailableDataFrames.cboAvailableDataFrames.Text & Chr(34), iPosition:=0)
    End Sub

    Private Sub UpdateClsCombineFrequencyFactorParameterFunction()
        clsCombineFrequencyFactorParameterFunction.RemoveParameterByName("factor_two")
        clsFrequencyTablesFunction.RemoveParameterByName("columns_to_summarise")
        If rdoThreeVariable.Checked Then
            If ucrReceiverNumericVariable.strCurrDataType = "factor" AndAlso Not ucrReceiverNumericVariable.IsEmpty Then
                clsCombineFrequencyFactorParameterFunction.AddParameter("factor_two", ucrReceiverNumericVariable.GetVariableNames(),
                                                                       iPosition:=1, bIncludeArgumentName:=False)
            ElseIf ucrReceiverNumericVariable.strCurrDataType = "numeric" AndAlso Not ucrReceiverNumericVariable.IsEmpty Then
                clsFrequencyTablesFunction.AddParameter("columns_to_summarise", ucrReceiverNumericVariable.GetVariableNames(), iPosition:=3)
            End If
        End If
    End Sub

    Private Sub ucrReceiverNumericVariable_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverNumericVariable.ControlValueChanged
        UpdateClsRenameCombineFunction()
        UpdateClsCombineFrequencyFactorParameterFunction()
        SwapMmtableHeaderFunctions()
        EnableDisableFrequencyControls()
        AddRemoveFrequencyParameters()
    End Sub
End Class