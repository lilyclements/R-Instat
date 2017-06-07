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

Imports instat
Imports instat.Translations
Public Class dlgWaterBalance
    Private bFirstload As Boolean = True
    Private bReset As Boolean = True
    Public clsRWater_bal, clsWaterEndRainsBase, clsEndOfRainsManipulationsFunc, clsREndofRains, clsWaterBalBase, clsWaterBalManipulationsFunc, clsTransformGroupByFunc, clsAddKey, clsYearGroup, clsDayFromAndTo, clsFirstWaterBalanceYear, clsFirstWaterBalanceManipulation60, clsWaterBalanceList, clsWaterBalanceCalc, clsWaterBalance, clsSubCalcList As New RFunction
    Public clsReplaceNA, clsReplaceNA60, clsWaterBalance60, clsWaterFilter60, clsDifference, clsDifferenceList, clsFirstWaterBalance60, clsFirstWaterBalance60List, clsFirstWaterBalance0List, clsWaterFilter60List, clsWaterFilter0List, clsReplaceNA0, clsWaterBalance60List, clsWaterBalance0List, clsWaterBalance0, clsWaterFilter0, clsFirstWaterBalance0 As New RFunction
    Private strCurrDataName As String = ""

    Private Sub dlgWaterBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstload Then
            InitialiseDialog()
            bFirstload = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        autoTranslate(Me)
        TestOKEnabled()
    End Sub

    'Private Sub ucrSelectorForStartofRains_DataFrameChanged() Handles ucrSelectorForWaterBalance.DataFrameChanged
    '    strCurrDataName = Chr(34) & ucrSelectorForWaterBalance.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem & Chr(34)
    '    clsAddKey.AddParameter("data_name", strCurrDataName)
    '    FirstDayofTheYear()
    'End Sub

    Private Sub InitialiseDialog()
        ucrReceiverRainfall.Selector = ucrSelectorForWaterBalance
        ucrReceiverYear.Selector = ucrSelectorForWaterBalance
        ucrReceiverDate.Selector = ucrSelectorForWaterBalance
        ucrReceiverDOY.Selector = ucrSelectorForWaterBalance
        ucrReceiverDate.SetMeAsReceiver()
        ucrReceiverDate.AddIncludedMetadataProperty("Climatic_Type", {Chr(34) & "date" & Chr(34)})
        ucrReceiverStation.AddIncludedMetadataProperty("Climatic_Type", {Chr(34) & "station" & Chr(34)})
        ucrReceiverDOY.AddIncludedMetadataProperty("Climatic_Type", {Chr(34) & "doy" & Chr(34)})
        ucrReceiverRainfall.AddIncludedMetadataProperty("Climatic_Type", {Chr(34) & "rain" & Chr(34)})
        ucrReceiverYear.AddIncludedMetadataProperty("Climatic_Type", {Chr(34) & "year" & Chr(34)})
        ucrReceiverDate.bAutoFill = True
        ucrReceiverDOY.bAutoFill = True
        ucrReceiverRainfall.bAutoFill = True
        ucrReceiverYear.bAutoFill = True

        clsRWater_bal.SetRCommand("instat_calculation$new")
        clsRWater_bal.SetAssignTo("water_bal_calculation")

        clsREndofRains.SetRCommand("instat_calculation$new")
        clsREndofRains.SetAssignTo("end_of_rains_calculation")
        ucrPnlEndofRains.AddRadioButton(rdoRain)
        ucrPnlEndofRains.AddRadioButton(rdoWaterBalance)
        ucrPnlEndofRains.AddRadioButton(rdoBoth)

        ucrNudCapacity.SetParameter(New RParameter("capacity"))
        ucrNudCapacity.SetMinMax(1, Integer.MaxValue)
        ucrNudCapacity.Increment = 1
        ucrNudCapacity.SetLinkedDisplayControl(lblCapacity)

        ucrInputEvaporation.SetParameter(New RParameter("evaporation"))
        ucrInputEvaporation.SetValidationTypeAsNumeric()
        ucrInputEvaporation.SetLinkedDisplayControl(lblEvaporation)

        ucrInputColName.SetParameter(New RParameter("result_name"))
        ucrInputColName.SetName("water_bal")

        'clsAddKey.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$add_key")
        clsDayFromAndTo.SetRCommand("instat_calculation$new")
        clsDayFromAndTo.SetAssignTo("Day_From_and_To")
        clsYearGroup.SetRCommand("instat_calculation$new")
        clsYearGroup.SetAssignTo("Year_Group_Daily")
        clsWaterBalance.SetRCommand("instat_calculation$new")
        clsWaterBalance.SetAssignTo("Water_Balance")
        clsWaterBalanceCalc.SetRCommand("instat_calculation$new")
        clsWaterBalanceCalc.SetAssignTo("Water_Balance_Calc")
        clsFirstWaterBalanceYear.SetRCommand("instat_calculation$new")
        clsFirstWaterBalanceYear.SetAssignTo("First_Water_Balance")
        'ucrBase.clsRsyntax.SetFunction(frmMain.clsRLink.strInstatDataObject & "$apply_instat_calculation")
        clsFirstWaterBalanceManipulation60.SetRCommand("list")
        clsWaterBalanceList.SetRCommand("list")
        clsReplaceNA60.SetRCommand("instat_calculation$new")
        clsReplaceNA0.SetRCommand("instat_calculation$new")
        clsWaterBalance60.SetRCommand("instat_calculation$new")
        clsWaterBalance0.SetRCommand("instat_calculation$new")
        clsWaterFilter60.SetRCommand("instat_calculation$new")
        clsWaterFilter0.SetRCommand("instat_calculation$new")
        clsFirstWaterBalance60.SetRCommand("instat_calculation$new")
        clsFirstWaterBalance0.SetRCommand("instat_calculation$new")

        ' for clarity when it runs
        clsReplaceNA60.SetAssignTo("Replace_NA_60")
        clsReplaceNA0.SetAssignTo("Replace_NA_0")
        clsWaterBalance60.SetAssignTo("Water_Balance_60")
        clsWaterBalance0.SetAssignTo("Water_Balance_0")
        clsWaterFilter60.SetAssignTo("Water_Filter_60")
        clsWaterFilter0.SetAssignTo("Water_Filter_0")
        clsFirstWaterBalance60.SetAssignTo("First_Water_Balance_60")
        clsFirstWaterBalance0.SetAssignTo("First_Water_Balance_0")

        clsWaterBalance60List.SetRCommand("list")
        clsWaterBalance0List.SetRCommand("list")
        clsWaterFilter60List.SetRCommand("list")
        clsWaterFilter0List.SetRCommand("list")
        clsFirstWaterBalance60List.SetRCommand("list")
        clsFirstWaterBalance0List.SetRCommand("list")

        clsDifferenceList.SetRCommand("list")
        clsDifference.SetRCommand("instat_calculation$new")



        'save
        'ucrSaveWaterBalance.SetDataFrameSelector(ucrSelectorForWaterBalance.ucrAvailableDataFrames)
        'ucrSaveWaterBalance.SetLabelText("New Column Name:")
        'ucrSaveWaterBalance.SetIsTextBox()
        'ucrSaveWaterBalance.SetPrefix("Water_Balance")
        'ucrSaveWaterBalance.SetSaveTypeAsColumn()

        'add parameter name
        ucrNudCapacity.Maximum = Integer.MaxValue
        ucrNudCapacity.Increment = 10
        'nudCapacity.DecimalPlaces = 0

        ucrNudTo.Maximum = 366
        'ucrNudTo.SetMinMax(ucrNudFrom.Value + 1, 366)
        'ucrNudFrom.SetMinMax(1, ucrNudFrom.Value - 1)
        ucrNudWBLessThan.Increment = 10
        ucrNudWBLessThan.Maximum = Integer.MaxValue

        ucrInputEvaporation.SetValidationTypeAsNumeric()

        'ucrPnlEndofRains.AddToLinkedControls({ucrNudTotalOverDays, ucrNudAmount}, {rdoRain}, bNewLinkedAddRemoveParameter:=False, bNewLinkedHideIfParameterMissing:=True)
        'ucrPnlEndofRains.AddToLinkedControls({ucrInputEvaporation, ucrNudWBLessThan, ucrNudCapacity}, {rdoWaterBalance}, bNewLinkedAddRemoveParameter:=False, bNewLinkedHideIfParameterMissing:=True)
    End Sub

    Private Sub SetDefaults()
        clsTransformGroupByFunc = New RFunction
        clsWaterBalManipulationsFunc = New RFunction
        clsEndOfRainsManipulationsFunc = New RFunction
        clsWaterBalBase = New RFunction
        ucrSelectorForWaterBalance.Reset()
        'ucrSaveWaterBalance.Reset()

        ucrNudFrom.Value = 1
        ucrNudTo.Value = 366
        ucrNudCapacity.Value = 60
        ucrNudWBLessThan.Value = 40
        ucrInputEvaporation.SetName("5")

        clsWaterBalManipulationsFunc.SetRCommand("list")
        clsWaterBalManipulationsFunc.AddParameter("group_by", clsRFunctionParameter:=clsTransformGroupByFunc, bIncludeArgumentName:=False)

        clsEndOfRainsManipulationsFunc.SetRCommand("list")
        clsEndOfRainsManipulationsFunc.AddParameter("group_by", clsRFunctionParameter:=clsTransformGroupByFunc, bIncludeArgumentName:=False)


        clsTransformGroupByFunc.SetRCommand("instat_calculation$new")
        clsTransformGroupByFunc.AddParameter("type", Chr(34) & "by" & Chr(34))
        clsTransformGroupByFunc.SetAssignTo("grouping")

        clsReplaceNA.SetRCommand("instat_calculation$new")
        clsReplaceNA.AddParameter("type", Chr(34) & "calculation" & Chr(34))
        clsReplaceNA.AddParameter("function_exp", Chr(34) & "replace(" & ucrReceiverRainfall.GetVariableNames(False) & ", is.na(" & ucrReceiverRainfall.GetVariableNames(False) & ")," & ucrNudCapacity.Value & ")" & Chr(34))
        clsReplaceNA.AddParameter("result_name", Chr(34) & "replace_NA" & Chr(34))
        clsReplaceNA.AddParameter("calculated_from", " list(" & strCurrDataName & "= " & ucrReceiverRainfall.GetVariableNames() & ")")
        clsReplaceNA.AddParameter("save", "0")
        clsReplaceNA.SetAssignTo("replace_NA")

        clsWaterBalance60.SetRCommand("instat_calculation$new")
        clsWaterBalance60.AddParameter("type", Chr(34) & "calculation" & Chr(34))
        clsWaterBalance60.AddParameter("result_name", Chr(34) & "Water_Balance_60" & Chr(34))
        clsWaterBalance60.AddParameter("sub_calculations", clsRFunctionParameter:=clsSubCalcList)

        clsWaterBalance60.AddParameter("save", "2")
        clsWaterBalance60.SetAssignTo("Water_Balance_60")
        clsSubCalcList.SetRCommand("list")
        clsSubCalcList.AddParameter("sub1", clsRFunctionParameter:=clsReplaceNA)

        clsRWater_bal.AddParameter("function_exp", Chr(34) & "Reduce(function(x, y) pmin(pmax(x + y - " & ucrInputEvaporation.GetText() & ", 0), " & ucrNudCapacity.Value & "), replace_NA, accumulate=TRUE)" & Chr(34))
        clsRWater_bal.AddParameter("type", Chr(34) & "calculation" & Chr(34))
        clsRWater_bal.AddParameter("result_name", Chr(34) & "water_bal" & Chr(34))
        clsRWater_bal.AddParameter("manipulations", clsRFunctionParameter:=clsWaterBalManipulationsFunc)
        clsRWater_bal.AddParameter("save", 2)

        clsREndofRains.AddParameter("function_exp", Chr(34) & "min(water_bal)")
        clsREndofRains.AddParameter("type", Chr(34) & "summary" & Chr(34))
        clsREndofRains.AddParameter("result_name", Chr(34) & "end_rains" & Chr(34))
        clsREndofRains.AddParameter("manipulations", clsRFunctionParameter:=clsWaterBalManipulationsFunc)
        clsREndofRains.AddParameter("save", 2)

        clsWaterBalBase.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$run_instat_calculation")
        clsWaterBalBase.AddParameter("display", "FALSE")
        clsWaterBalBase.AddParameter("calc", clsRFunctionParameter:=clsRWater_bal)

        clsWaterEndRainsBase.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$run_instat_calculation")
        clsWaterEndRainsBase.AddParameter("display", "FALSE")
        clsWaterEndRainsBase.AddParameter("calc", clsRFunctionParameter:=clsWaterEndRainsBase)

        ucrBase.clsRsyntax.SetBaseRFunction(clsWaterBalBase)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        'ucrPnlTransform.SetRCode(clsMatchFun, bReset)
        'ucrNudSumOver.SetRCode(clsRRollFuncExpr, bReset)
        'ucrReceiverData.SetRCode(clsRRollFuncExpr, bReset)
        'ucrInputSum.SetRCode(clsMatchFun, bReset)
        ucrInputColName.SetRCode(clsRWater_bal, bReset)
    End Sub

    Private Sub ReopenDialog()

    End Sub

    Private Sub TestOKEnabled()
        'If Not ucrReceiverRainfall.IsEmpty AndAlso Not ucrReceiverDate.IsEmpty AndAlso Not ucrReceiverDOY.IsEmpty AndAlso Not ucrReceiverYear.IsEmpty AndAlso ucrNudCapacity.Text <> "" AndAlso ucrNudFrom.Text <> "" AndAlso ucrNudTo.Text <> "" AndAlso Not ucrInputEvaporation.IsEmpty AndAlso ucrNudWBLessThan.Text <> "" AndAlso ucrSaveWaterBalance.IsComplete Then
        '    ucrBase.OKEnabled(True)
        'Else
        '    ucrBase.OKEnabled(False)
        'End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub nudValues()
        ucrNudFrom.Maximum = ucrNudTo.Value - 1
        ucrNudTo.Minimum = ucrNudFrom.Value + 1
    End Sub

    Private Sub AddKeyMethod()
        If Not ucrReceiverDate.IsEmpty Then
            clsAddKey.AddParameter("col_name", ucrReceiverDate.GetVariableNames)
        Else
            clsAddKey.RemoveParameterByName("col_name")
        End If
    End Sub

    Private Sub DayFromAndToMethod()
        clsDayFromAndTo.AddParameter("function_exp", Chr(34) & ucrReceiverDOY.GetVariableNames(False) & ">=" & ucrNudFrom.Value & " & " & ucrReceiverDOY.GetVariableNames(False) & "<=" & ucrNudTo.Value & Chr(34))
        clsDayFromAndTo.AddParameter("calculated_from", " list(" & strCurrDataName & "=" & ucrReceiverDOY.GetVariableNames() & ")")
        clsDayFromAndTo.AddParameter("type", Chr(34) & "filter" & Chr(34))
    End Sub

    Private Sub WaterBalance() ' crashes regardless of this sub
        clsReplaceNA60.AddParameter("type", Chr(34) & "calculation" & Chr(34))
        clsReplaceNA60.AddParameter("function_exp", Chr(34) & "replace(" & ucrReceiverRainfall.GetVariableNames(False) & ", is.na( " & ucrReceiverRainfall.GetVariableNames(False) & "), 60)" & Chr(34))
        clsReplaceNA60.AddParameter("result_name", Chr(34) & "Replace_NA_60" & Chr(34))
        clsReplaceNA60.AddParameter("calculated_from", " list(" & strCurrDataName & "=" & ucrReceiverRainfall.GetVariableNames() & ")")
        clsReplaceNA60.AddParameter("save", "0") ' has save = 2on rcode

        clsWaterBalance60.AddParameter("type", Chr(34) & "calculation" & Chr(34))
        clsWaterBalance60.AddParameter("function_exp", Chr(34) & "Reduce(function(x, y) pmin(pmax(x + y - " & ucrInputEvaporation.GetText & ", 0), " & ucrNudCapacity.Value & "), Replace_NA_60, accumulate=TRUE)" & Chr(34))
        clsWaterBalance60.AddParameter("result_name", Chr(34) & "Water_Balance_60" & Chr(34))
        clsWaterBalance60.AddParameter("sub_calculations", clsRFunctionParameter:=clsWaterBalance60List)
        clsWaterBalance60List.AddParameter("sub1", clsRFunctionParameter:=clsReplaceNA60)
        clsWaterBalance60.AddParameter("save", "0")

        clsWaterFilter60.AddParameter("type", Chr(34) & "filter" & Chr(34))
        clsWaterFilter60.AddParameter("function_exp", Chr(34) & "Water_Balance_60 <= " & ucrNudWBLessThan.Value & Chr(34))
        clsWaterFilter60.AddParameter("sub_calculations", clsRFunctionParameter:=clsWaterFilter60List)
        clsWaterFilter60List.AddParameter("sub1", clsRFunctionParameter:=clsWaterBalance60)

        clsFirstWaterBalance60.AddParameter("type", Chr(34) & "summary" & Chr(34))
        clsFirstWaterBalance60.AddParameter("function_exp", Chr(34) & ucrReceiverDOY.GetVariableNames(False) & "[" & 1 & "]" & Chr(34))
        clsFirstWaterBalance60.AddParameter("result_name", Chr(34) & "First_Water_Balance_60" & Chr(34))
        clsFirstWaterBalance60.AddParameter("calculated_from", "list(" & strCurrDataName & "=" & ucrReceiverDOY.GetVariableNames() & ")")
        clsFirstWaterBalance60.AddParameter("manipulations", clsRFunctionParameter:=clsFirstWaterBalanceManipulation60)
        clsFirstWaterBalance60.AddParameter("save", "0")
        clsFirstWaterBalanceManipulation60.AddParameter("sub2", clsRFunctionParameter:=clsYearGroup, bIncludeArgumentName:=False)
        clsFirstWaterBalanceManipulation60.AddParameter("sub3", clsRFunctionParameter:=clsDayFromAndTo, bIncludeArgumentName:=False)
        clsFirstWaterBalanceManipulation60.AddParameter("sub1", clsRFunctionParameter:=clsWaterFilter60, bIncludeArgumentName:=False)

        clsReplaceNA0.AddParameter("type", Chr(34) & "calculation" & Chr(34))
        clsReplaceNA0.AddParameter("function_exp", Chr(34) & "replace(" & ucrReceiverRainfall.GetVariableNames(False) & ", is.na(" & ucrReceiverRainfall.GetVariableNames(False) & "), 0)" & Chr(34))
        clsReplaceNA0.AddParameter("result_name", Chr(34) & "Replace_NA_0" & Chr(34))
        clsReplaceNA0.AddParameter("calculated_from", " list(" & strCurrDataName & "=" & ucrReceiverRainfall.GetVariableNames() & ")")
        clsReplaceNA0.AddParameter("save", "0")

        clsWaterBalance0.AddParameter("type", Chr(34) & "calculation" & Chr(34))
        clsWaterBalance0.AddParameter("function_exp", Chr(34) & "Reduce(function(x, y) pmin(pmax(x + y - " & ucrInputEvaporation.GetText & ", 0), " & ucrNudCapacity.Value & "), Replace_NA_0, accumulate=TRUE)" & Chr(34))
        clsWaterBalance0.AddParameter("result_name", Chr(34) & "Water_Balance_0" & Chr(34))
        clsWaterBalance0.AddParameter("sub_calculations", clsRFunctionParameter:=clsWaterBalance0List)
        clsWaterBalance0List.AddParameter("sub1", clsRFunctionParameter:=clsReplaceNA0)
        clsWaterBalance0.AddParameter("save", "0")

        clsWaterFilter0.AddParameter("type", Chr(34) & "filter" & Chr(34))
        clsWaterFilter0.AddParameter("function_exp", Chr(34) & "Water_Balance_0 == 0" & Chr(34))
        clsWaterFilter0.AddParameter("sub_calculations", clsRFunctionParameter:=clsWaterFilter0List)
        clsWaterFilter0List.AddParameter("sub1", clsRFunctionParameter:=clsWaterBalance0)

        clsFirstWaterBalance0.AddParameter("type", Chr(34) & "summary" & Chr(34))
        clsFirstWaterBalance0.AddParameter("function_exp", Chr(34) & ucrReceiverDOY.GetVariableNames(False) & "[" & 1 & "]" & Chr(34))
        clsFirstWaterBalance0.AddParameter("result_name", Chr(34) & "First_Water_Balance_0" & Chr(34))
        clsFirstWaterBalance0.AddParameter("calculated_from", "list(" & strCurrDataName & "=" & ucrReceiverDOY.GetVariableNames() & ")")
        clsFirstWaterBalance0.AddParameter("manipulations", clsRFunctionParameter:=clsFirstWaterBalance0List)
        clsFirstWaterBalance0.AddParameter("save", "2")
        clsFirstWaterBalance0List.AddParameter("sub2", clsRFunctionParameter:=clsYearGroup, bIncludeArgumentName:=False)
        clsFirstWaterBalance0List.AddParameter("sub3", clsRFunctionParameter:=clsDayFromAndTo, bIncludeArgumentName:=False)
        clsFirstWaterBalance0List.AddParameter("sub1", clsRFunctionParameter:=clsWaterFilter0, bIncludeArgumentName:=False)
    End Sub

    Private Sub FirstWaterBalancePerYear() ' error occurs when clsDifference runs
        clsDifference.AddParameter("type", Chr(34) & "calculation" & Chr(34))
        clsDifference.AddParameter("function_exp", Chr(34) & "First_Water_Balance_0 - First_Water_Balance_60" & Chr(34))
        clsDifference.AddParameter("result_name", Chr(34) & "Difference" & Chr(34))
        clsDifference.AddParameter("sub_calculations", clsRFunctionParameter:=clsDifferenceList)
        clsDifferenceList.AddParameter("sub1", clsRFunctionParameter:=clsFirstWaterBalance0)
        clsDifferenceList.AddParameter("sub2", clsRFunctionParameter:=clsFirstWaterBalance60)
        clsDifference.AddParameter("save", "0")
        ' try it in the other sub? Or sub on it's own?

        clsWaterBalance.AddParameter("type", Chr(34) & "calculation" & Chr(34))
        clsWaterBalance.AddParameter("function_exp", Chr(34) & "replace(First_Water_Balance_0, Difference != 0, NA)" & Chr(34))
        clsWaterBalance.AddParameter("result_name", Chr(34) & ucrInputColName.GetText() & Chr(34))
        clsWaterBalance.AddParameter("sub_calculations", clsRFunctionParameter:=clsWaterBalanceList)
        clsWaterBalanceList.AddParameter("sub1", clsRFunctionParameter:=clsFirstWaterBalance0)
        clsWaterBalanceList.AddParameter("sub2", clsRFunctionParameter:=clsDifference)
        clsWaterBalance.AddParameter("save", "2")
    End Sub

    Private Sub YearGroupDaily()
        clsYearGroup.AddParameter("type", Chr(34) & "by" & Chr(34))
        clsYearGroup.AddParameter("calculated_from", "list(" & strCurrDataName & "=" & ucrReceiverYear.GetVariableNames & ")")
    End Sub

    'Private Sub FirstDayofTheYear()
    '    ucrBase.clsRsyntax.AddParameter("calc", clsRFunctionParameter:=clsWaterBalance)
    'End Sub

    'Private Sub ucrBase_BeforeClickOk(sender As Object, e As EventArgs) Handles ucrBase.BeforeClickOk
    '    'frmMain.clsRLink.RunScript(clsAddKey.ToScript, strComment:="Water Balance: Defining Date column as key")

    '    FirstDayofTheYear()
    '    DayFromAndToMethod()
    '    WaterBalance()
    '    FirstWaterBalancePerYear()
    'End Sub

    Private Sub ucrReceiverYear_SelectionChanged(sender As Object, e As EventArgs) Handles ucrReceiverYear.SelectionChanged
        YearGroupDaily()
        TestOKEnabled()
    End Sub

    Private Sub ucrReceiverRainfall_SelectionChanged(sender As Object, e As EventArgs) Handles ucrReceiverRainfall.SelectionChanged
        WaterBalance()
        'TestOKEnabled()
    End Sub

    Private Sub ucrReceiverDOY_SelectionChanged(sender As Object, e As EventArgs) Handles ucrReceiverDOY.SelectionChanged
        DayFromAndToMethod()
        FirstWaterBalancePerYear()
        ' TestOKEnabled()
    End Sub

    'Private Sub ucrReceiverDate_SelectionChanged(sender As Object, e As EventArgs) Handles ucrReceiverDate.SelectionChanged
    '    AddKeyMethod()
    '    'TestOKEnabled()
    'End Sub

    Private Sub DayFromAndTo(sender As Object, e As EventArgs)
        DayFromAndToMethod()
        nudValues()
        'TestOKEnabled()
    End Sub

    Private Sub nudWBLessThan_ValueChanged(sender As Object, e As EventArgs) Handles ucrNudWBLessThan.TextChanged
        WaterBalance()
        'TestOKEnabled()
    End Sub

    Private Sub nudCapacity_ValueChanged(sender As Object, e As EventArgs)
        WaterBalance()
        'TestOKEnabled()
    End Sub

    Private Sub ucrInputEvaporation_NameChanged() Handles ucrInputEvaporation.NameChanged
        WaterBalance()
        ' TestOKEnabled()
    End Sub

    Private Sub ucrSaveWaterBalance_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputColName.ControlValueChanged
        clsWaterBalance.SetAssignTo(ucrInputColName.GetText)
        FirstWaterBalancePerYear()
    End Sub

    Private Sub ucrControls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverDate.ControlContentsChanged, ucrReceiverDOY.ControlContentsChanged, ucrReceiverYear.ControlContentsChanged, ucrReceiverRainfall.ControlContentsChanged, ucrNudCapacity.ControlContentsChanged, ucrNudFrom.ControlContentsChanged, ucrNudTo.ControlContentsChanged, ucrInputEvaporation.ControlContentsChanged, ucrNudWBLessThan.ControlContentsChanged
        TestOKEnabled()
    End Sub

    Private Sub ucrPnlEndofRains_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrPnlEndofRains.ControlContentsChanged
        If rdoRain.Checked Then
            'ucrBase.clsRsyntax.SetBaseRFunction(clsSumFunction)
            'ucrBase.clsRsyntax.AddParameter("calc", clsRFunctionParameter:=clsRTrasform)
            'ucrSaveTransform.SetPrefix("Sum")
            'ucrInputColName.SetPrefix("Sum")
            'ucrInputColName.SetName("Sum")
            'grpTransform.Text = "Sum"
            clsWaterBalance0.AddParameter("save", "0")
            clsWaterBalance0.SetAssignTo("Water_Balance_0")
            clsWaterEndRainsBase.AddParameter("calc", clsRFunctionParameter:=clsFirstWaterBalance0)
            ucrBase.clsRsyntax.SetBaseRFunction(clsWaterEndRainsBase)
        ElseIf rdoWaterBalance.Checked Then
            clsReplaceNA.AddParameter("function_exp", Chr(34) & "replace(" & ucrReceiverRainfall.GetVariableNames(False) & ", is.na(" & ucrReceiverRainfall.GetVariableNames(False) & ")," & ucrNudCapacity.Value & ")" & Chr(34))
            clsSubCalcList.AddParameter("sub1", clsRFunctionParameter:=clsReplaceNA)
            clsRWater_bal.AddParameter("sub_calculations", clsRFunctionParameter:=clsSubCalcList)
            clsRWater_bal.AddParameter("function_exp", Chr(34) & "Reduce(function(x, y) pmin(pmax(x + y - " & ucrInputEvaporation.GetText() & ", 0), " & ucrNudCapacity.Value & "), replace_NA, accumulate=TRUE)" & Chr(34))
            clsWaterBalBase.AddParameter("calc", clsRFunctionParameter:=clsRWater_bal)
            ucrBase.clsRsyntax.SetBaseRFunction(clsWaterBalBase)
            'ucrInputColName.SetName("Count")
            'grpTransform.Text = "Count"
        ElseIf rdoBoth.Checked Then
            clsWaterBalance0.AddParameter("save", "2")
            clsWaterBalance0.SetAssignTo("Water_Balance_0")
            'clsWaterBalance0.AddParameter("sub_calculations", clsRFunctionParameter:=clsWaterBalance0List)
            clsWaterEndRainsBase.AddParameter("calc", clsRFunctionParameter:=clsFirstWaterBalance0)
            ucrBase.clsRsyntax.SetBaseRFunction(clsWaterEndRainsBase)
        End If
    End Sub

    Private Sub SetGroupByFuncCalcFrom()
        Dim strCurrDataName As String = ""
        Dim strGroupByCalcFrom As String = ""

        strCurrDataName = Chr(34) & ucrSelectorForWaterBalance.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem & Chr(34)

        If Not ucrReceiverStation.IsEmpty Then
            clsTransformGroupByFunc.SetAssignTo("grouping")
            clsRWater_bal.AddParameter("manipulations", clsRFunctionParameter:=clsWaterBalManipulationsFunc)
            'end rains to be added here
            strGroupByCalcFrom = "list(" & strCurrDataName & "=" & ucrReceiverStation.GetVariableNames() & ")"
        Else
            clsRWater_bal.RemoveParameterByName("manipulations")

        End If
        If strGroupByCalcFrom <> "" Then
            clsTransformGroupByFunc.AddParameter("calculated_from", strGroupByCalcFrom)
        Else
            clsTransformGroupByFunc.RemoveParameterByName("calculated_from")
        End If
    End Sub

    Private Sub ucrReceiverStation_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverStation.ControlValueChanged
        SetGroupByFuncCalcFrom()
    End Sub

    Private Sub ucrBase_BeforeClickOk(sender As Object, e As EventArgs) Handles ucrBase.BeforeClickOk
        'FirstDayofTheYear()
        DayFromAndToMethod()
        WaterBalance()
        FirstWaterBalancePerYear()
        clsRWater_bal.SetAssignTo("water_bal_calculation")
        'clsWaterBalance60.SetAssignTo("water_balance_60")
        clsReplaceNA.SetAssignTo("replace_NA")
        SetGroupByFuncCalcFrom()
        'If rdoRain.Checked Then
        '    'clsRollFunction.AddParameter("calc", clsRFunctionParameter:=clsRWater_bal)
        '    frmMain.clsRLink.RunScript(clsWaterBalBase.ToScript)
        'End If
    End Sub

    Private Sub ucrWBControls_ControlContentsChanged(ucrchangedControl As ucrCore) Handles ucrNudCapacity.ControlContentsChanged, ucrInputEvaporation.ControlContentsChanged
        clsRWater_bal.AddParameter("function_exp", Chr(34) & "Reduce(function(x, y) pmin(pmax(x + y - " & ucrInputEvaporation.GetText() & ", 0), " & ucrNudCapacity.Value & "), replace_NA, accumulate=TRUE)" & Chr(34))
    End Sub

    Private Sub ucrSelectorForWaterBalance_ControlContentsChanged(ucrchangedControl As ucrCore) Handles ucrSelectorForWaterBalance.ControlContentsChanged, ucrReceiverRainfall.ControlContentsChanged
        strCurrDataName = Chr(34) & ucrSelectorForWaterBalance.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem & Chr(34)
        'clsRRainday.AddParameter("function_exp", Chr(34) & "match(" & ucrReceiverData.GetVariableNames(False) & ">=" & ucrInputThreshold.GetText() & ", 1, nomatch = 0)" & Chr(34))
        clsReplaceNA.AddParameter("function_exp", Chr(34) & "replace(" & ucrReceiverRainfall.GetVariableNames(False) & ", is.na(" & ucrReceiverRainfall.GetVariableNames(False) & ")," & ucrNudCapacity.Value & ")" & Chr(34))
        'clsRRainday.AddParameter("calculated_from", " list(" & strCurrDataName & "=" & ucrReceiverData.GetVariableNames() & ")")
        clsRWater_bal.AddParameter("calculated_from", " list(" & strCurrDataName & "=" & ucrReceiverRainfall.GetVariableNames() & ")")
        clsReplaceNA.AddParameter("calculated_from", " list(" & strCurrDataName & "= " & ucrReceiverRainfall.GetVariableNames() & ")")
    End Sub

    Private Sub ucrNudFromTo_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrNudFrom.ControlValueChanged, ucrNudTo.ControlValueChanged
        nudValues()
    End Sub
End Class