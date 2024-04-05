﻿'R-Instat
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
Public Class sdgDefineAnnualRainfall

    Public clsReforMattAnnualSummariesFunction, clsReformatCropSuccessFunction, clsReformatSeasonStartFunction, clsReformatTempSummariesFunction, clsReformatMonthlyTempSummaries As New RFunction
    Public clsRsyntax As New RSyntax
    Public bControlsInitialised As Boolean = False

    Private Sub sdgDefineAnnualRainfall_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
    End Sub

    Public Sub InitialiseControls()
        ucrSelectorDefineAnnualRain.SetParameter(New RParameter("data", 0))
        ucrSelectorDefineAnnualRain.SetParameterIsrfunction()

        ucrSelectorAnnualTemp.SetParameter(New RParameter("data", 0))
        ucrSelectorAnnualTemp.SetParameterIsrfunction()

        ucrSelectorCropProp.SetParameter(New RParameter("data", 0))
        ucrSelectorCropProp.SetParameterIsrfunction()

        ucrSelectorSeasonStartProp.SetParameter(New RParameter("data", 0))
        ucrSelectorSeasonStartProp.SetParameterIsrfunction()

        ucrSelecetorMonthlyTemp.SetParameter(New RParameter("data", 0))
        ucrSelecetorMonthlyTemp.SetParameterIsrfunction()

        ucrReceiverStation.SetParameter(New RParameter("station_col", 1))
        ucrReceiverStation.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverStation.SetParameterIsRFunction()

        ucrReceiverYear.SetParameter(New RParameter("year_col", 2))
        ucrReceiverYear.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverYear.SetParameterIsRFunction()

        ucrReceiverStartRainDOY.SetParameter(New RParameter("start_rains_doy_col", 3))
        ucrReceiverStartRainDOY.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverStartRainDOY.SetParameterIsRFunction()

        ucrReceiverStartRainDate.SetParameter(New RParameter("start_rains_date_col", 4))
        ucrReceiverStartRainDate.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverStartRainDate.SetParameterIsRFunction()

        ucrReceiverEndRainsDOY.SetParameter(New RParameter("end_rains_doy_col", 5))
        ucrReceiverEndRainsDOY.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverEndRainsDOY.SetParameterIsRFunction()

        ucrReceiverEndRainsDate.SetParameter(New RParameter("end_rains_date_col", 6))
        ucrReceiverEndRainsDate.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverEndRainsDate.SetParameterIsRFunction()

        ucrReceiverEndSeasonDOY.SetParameter(New RParameter("end_season_doy_col", 7))
        ucrReceiverEndSeasonDOY.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverEndSeasonDOY.SetParameterIsRFunction()

        ucrReceiverEndSeasonDate.SetParameter(New RParameter("end_season_date_col", 8))
        ucrReceiverEndSeasonDate.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverEndSeasonDate.SetParameterIsRFunction()

        ucrReceiverSeasonalRain.SetParameter(New RParameter("seasonal_rain_col", 9))
        ucrReceiverSeasonalRain.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverSeasonalRain.SetParameterIsRFunction()

        ucrReceiverRainDaysSeason.SetParameter(New RParameter("n_seasonal_rain_col", 10))
        ucrReceiverRainDaysSeason.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverRainDaysSeason.SetParameterIsRFunction()

        ucrReceiverRainDaysYear.SetParameter(New RParameter("n_rain_col", 11))
        ucrReceiverRainDaysYear.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverRainDaysYear.SetParameterIsRFunction()

        ucrReceiverSeasonalLength.SetParameter(New RParameter("season_length_col", 12))
        ucrReceiverSeasonalLength.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverSeasonalLength.SetParameterIsRFunction()

        ucrReceiverAnnualRain.SetParameter(New RParameter("annual_rain_col", 13))
        ucrReceiverAnnualRain.Selector = ucrSelectorDefineAnnualRain
        ucrReceiverAnnualRain.SetParameterIsRFunction()

        ucrReceiverStationCrop.SetParameter(New RParameter("station_col", 1))
        ucrReceiverStationCrop.Selector = ucrSelectorCropProp
        ucrReceiverStationCrop.SetParameterIsRFunction()

        ucrReceiverTotalRain.SetParameter(New RParameter("total_rain_col", 2))
        ucrReceiverTotalRain.Selector = ucrSelectorCropProp
        ucrReceiverTotalRain.SetParameterIsRFunction()

        ucrReceiverPlantingDay.SetParameter(New RParameter("plant_day_col", 3))
        ucrReceiverPlantingDay.Selector = ucrSelectorCropProp
        ucrReceiverPlantingDay.SetParameterIsRFunction()

        ucrReceiverPlantingLenghth.SetParameter(New RParameter("plant_length_col", 4))
        ucrReceiverPlantingLenghth.Selector = ucrSelectorCropProp
        ucrReceiverPlantingLenghth.SetParameterIsRFunction()

        ucrReceiverPropSuccess.SetParameter(New RParameter("prop_success_col", 5))
        ucrReceiverPropSuccess.Selector = ucrSelectorCropProp
        ucrReceiverPropSuccess.SetParameterIsRFunction()

        'Season start
        ucrReceiverSeasonStationProb.SetParameter(New RParameter("station_col", 1))
        ucrReceiverSeasonStationProb.Selector = ucrSelectorSeasonStartProp
        ucrReceiverSeasonStationProb.SetParameterIsRFunction()

        ucrReceiverSeasonYear.SetParameter(New RParameter("year_col", 2))
        ucrReceiverSeasonYear.Selector = ucrSelectorSeasonStartProp
        ucrReceiverSeasonYear.SetParameterIsRFunction()


        ucrReceiverSeasonPlantingDay.SetParameter(New RParameter("plant_day_col", 3))
        ucrReceiverSeasonPlantingDay.Selector = ucrSelectorSeasonStartProp
        ucrReceiverSeasonPlantingDay.SetParameterIsRFunction()


        ucrReceiverPlantingDayCondition.SetParameter(New RParameter("plant_day_cond_col", 5))
        ucrReceiverPlantingDayCondition.Selector = ucrSelectorSeasonStartProp
        ucrReceiverPlantingDayCondition.SetParameterIsRFunction()

        'Annual Temp
        ucrReceiverAnnualTempStation.SetParameter(New RParameter("station_col", 1))
        ucrReceiverAnnualTempStation.Selector = ucrSelectorAnnualTemp
        ucrReceiverAnnualTempStation.SetParameterIsRFunction()

        ucrReceiverAnnualTempYr.SetParameter(New RParameter("year_col", 2))
        ucrReceiverAnnualTempYr.Selector = ucrSelectorAnnualTemp
        ucrReceiverAnnualTempYr.SetParameterIsRFunction()

        ucrReceiverMeanAnnual.SetParameter(New RParameter("mean_tmin_col", 3))
        ucrReceiverMeanAnnual.Selector = ucrSelectorAnnualTemp
        ucrReceiverMeanAnnual.SetParameterIsRFunction()

        ucrReceiverMinMinAnnual.SetParameter(New RParameter("min_tmin_col", 4))
        ucrReceiverMinMinAnnual.Selector = ucrSelectorAnnualTemp
        ucrReceiverMinMinAnnual.SetParameterIsRFunction()

        ucrReceiverMaxMinAnnual.SetParameter(New RParameter("max_tmin_col", 5))
        ucrReceiverMaxMinAnnual.Selector = ucrSelectorAnnualTemp
        ucrReceiverMaxMinAnnual.SetParameterIsRFunction()

        ucrReceiverMeanMaxAnnual.SetParameter(New RParameter("mean_tmax_col", 6))
        ucrReceiverMeanMaxAnnual.Selector = ucrSelectorAnnualTemp
        ucrReceiverMeanMaxAnnual.SetParameterIsRFunction()

        ucrReceiverMinMaxAnnual.SetParameter(New RParameter("min_tmax_col", 7))
        ucrReceiverMinMaxAnnual.Selector = ucrSelectorAnnualTemp
        ucrReceiverMinMaxAnnual.SetParameterIsRFunction()

        ucrReceiverMaxMaxAnnual.SetParameter(New RParameter("max_tmax_col", 8))
        ucrReceiverMaxMaxAnnual.Selector = ucrSelectorAnnualTemp
        ucrReceiverMaxMaxAnnual.SetParameterIsRFunction()

        'Monthly Temp
        ucrReceiverMonthlyTemp.SetParameter(New RParameter("station_col", 1))
        ucrReceiverMonthlyTemp.Selector = ucrSelecetorMonthlyTemp
        ucrReceiverMonthlyTemp.SetParameterIsRFunction()

        ucrReceiverYearMonthly.SetParameter(New RParameter("year_col", 2))
        ucrReceiverYearMonthly.Selector = ucrSelecetorMonthlyTemp
        ucrReceiverYearMonthly.SetParameterIsRFunction()

        ucrReceiverMonthMonthly.SetParameter(New RParameter("month_col", 3))
        ucrReceiverMonthMonthly.Selector = ucrSelecetorMonthlyTemp
        ucrReceiverMonthMonthly.SetParameterIsRFunction()


        ucrReceiverMeanminMontly.SetParameter(New RParameter("mean_tmin_col", 4))
        ucrReceiverMeanminMontly.Selector = ucrSelecetorMonthlyTemp
        ucrReceiverMeanminMontly.SetParameterIsRFunction()

        ucrReceiverMinMinMonthly.SetParameter(New RParameter("min_tmin_col", 5))
        ucrReceiverMinMinMonthly.Selector = ucrSelecetorMonthlyTemp
        ucrReceiverMinMinMonthly.SetParameterIsRFunction()

        ucrReceiverMaxMinMonthly.SetParameter(New RParameter("max_tmin_col", 6))
        ucrReceiverMaxMinMonthly.Selector = ucrSelecetorMonthlyTemp
        ucrReceiverMaxMinMonthly.SetParameterIsRFunction()

        ucrReceiverMeanmaxMonthly.SetParameter(New RParameter("mean_tmax_col", 7))
        ucrReceiverMeanmaxMonthly.Selector = ucrSelecetorMonthlyTemp
        ucrReceiverMeanmaxMonthly.SetParameterIsRFunction()

        ucrReceiverMinMaxMonthly.SetParameter(New RParameter("min_tmax_col", 8))
        ucrReceiverMinMaxMonthly.Selector = ucrSelecetorMonthlyTemp
        ucrReceiverMinMaxMonthly.SetParameterIsRFunction()

        ucrReceiverMaxMaxMonthly.SetParameter(New RParameter("max_tmax_col", 9))
        ucrReceiverMaxMaxMonthly.Selector = ucrSelecetorMonthlyTemp
        ucrReceiverMaxMaxMonthly.SetParameterIsRFunction()

    End Sub
    Public Sub SetRCode(clsNewReforMattAnnualSummaries As RFunction, clsNewReformatCropSuccessFunction As RFunction, clsNewReformatMonthlyTempSummaries As RFunction, clsNewReformatSeasonStartFunction As RFunction, clsNewReformatTempSummariesFunction As RFunction, clsNewRSyntax As RSyntax, Optional bReset As Boolean = False)
        If Not bControlsInitialised Then
            InitialiseControls()
        End If

        clsReforMattAnnualSummariesFunction = clsNewReforMattAnnualSummaries
        clsReformatCropSuccessFunction = clsNewReformatCropSuccessFunction
        clsReformatMonthlyTempSummaries = clsNewReformatMonthlyTempSummaries
        clsReformatSeasonStartFunction = clsNewReformatSeasonStartFunction
        clsReformatTempSummariesFunction = clsNewReformatTempSummariesFunction
        clsRsyntax = clsNewRSyntax

        ucrReceiverAnnualRain.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverEndRainsDate.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverEndRainsDOY.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverEndSeasonDate.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverEndSeasonDOY.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverRainDaysSeason.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverRainDaysYear.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverSeasonalLength.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverSeasonalRain.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverStartRainDate.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverStartRainDOY.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverStation.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrReceiverYear.SetRCode(clsReforMattAnnualSummariesFunction, bReset)
        ucrSelectorAnnualTemp.SetRCode(clsReforMattAnnualSummariesFunction, bReset)

        ucrReceiverStationCrop.SetRCode(clsReformatCropSuccessFunction, bReset)
        ucrReceiverTotalRain.SetRCode(clsReformatCropSuccessFunction, bReset)
        ucrReceiverPlantingDay.SetRCode(clsReformatCropSuccessFunction, bReset)
        ucrReceiverPlantingLenghth.SetRCode(clsReformatCropSuccessFunction, bReset)
        ucrReceiverPropSuccess.SetRCode(clsReformatCropSuccessFunction, bReset)
        ucrSelectorCropProp.SetRCode(clsReformatCropSuccessFunction, bReset)

        ucrReceiverSeasonStationProb.SetRCode(clsReformatSeasonStartFunction, bReset)
        ucrReceiverSeasonYear.SetRCode(clsReformatSeasonStartFunction, bReset)
        ucrReceiverSeasonPlantingDay.SetRCode(clsReformatSeasonStartFunction, bReset)
        ucrReceiverPlantingDayCondition.SetRCode(clsReformatSeasonStartFunction, bReset)
        ucrSelectorSeasonStartProp.SetRCode(clsReformatSeasonStartFunction, bReset)

        ucrReceiverAnnualTempStation.SetRCode(clsReformatTempSummariesFunction, bReset)
        ucrReceiverAnnualTempYr.SetRCode(clsReformatTempSummariesFunction, bReset)
        ucrReceiverMeanAnnual.SetRCode(clsReformatTempSummariesFunction, bReset)
        ucrReceiverMinMaxAnnual.SetRCode(clsReformatTempSummariesFunction, bReset)
        ucrReceiverMaxMinAnnual.SetRCode(clsReformatTempSummariesFunction, bReset)
        ucrReceiverMaxMaxAnnual.SetRCode(clsReformatTempSummariesFunction, bReset)
        ucrReceiverMinMinAnnual.SetRCode(clsReformatTempSummariesFunction, bReset)
        ucrReceiverMeanMaxAnnual.SetRCode(clsReformatTempSummariesFunction, bReset)
        ucrSelectorAnnualTemp.SetRCode(clsReformatTempSummariesFunction, bReset)

        ucrReceiverMonthlyTemp.SetRCode(clsReformatMonthlyTempSummaries, bReset)
        ucrReceiverYearMonthly.SetRCode(clsReformatMonthlyTempSummaries, bReset)
        ucrReceiverMonthMonthly.SetRCode(clsReformatMonthlyTempSummaries, bReset)
        ucrReceiverMeanmaxMonthly.SetRCode(clsReformatMonthlyTempSummaries, bReset)
        ucrReceiverMinMaxMonthly.SetRCode(clsReformatMonthlyTempSummaries, bReset)
        ucrReceiverMaxMinMonthly.SetRCode(clsReformatMonthlyTempSummaries, bReset)
        ucrReceiverMaxMaxMonthly.SetRCode(clsReformatMonthlyTempSummaries, bReset)
        ucrReceiverMinMinMonthly.SetRCode(clsReformatMonthlyTempSummaries, bReset)
        ucrReceiverMeanminMontly.SetRCode(clsReformatMonthlyTempSummaries, bReset)
        ucrSelecetorMonthlyTemp.SetRCode(clsReformatMonthlyTempSummaries, bReset)
    End Sub

End Class