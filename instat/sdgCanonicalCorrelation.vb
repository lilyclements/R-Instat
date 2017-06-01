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
Public Class sdgCanonicalCorrelation
    Private bControlsInitialised As Boolean = False
    Private clsRCanCor, clsRCoef As New RFunction
    Public bFirstLoad As Boolean = True
    Public clsRGraphics As New RSyntax

    Public Sub sdgCanonicalCorrelation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)

        If bFirstLoad Then
            bFirstLoad = False
        End If
    End Sub

    Public Sub InitialiseControls()

        ucrChkCanonicalCorrelations.SetParameter(New RParameter("value1"))
        ucrChkCanonicalCorrelations.SetText("Canonical Correlations")
        ucrChkCanonicalCorrelations.SetValueIfChecked(Chr(34) & "cancor" & Chr(34))

        ucrChkCoefficients.SetParameter(New RParameter("value1"))
        ucrChkCoefficients.SetText("Coefficients")
        ucrChkCoefficients.SetValueIfChecked(Chr(34) & "coef" & Chr(34))

        ucrPnlPairwisePlot.AddRadioButton(rdoNoPlot)
        ucrPnlPairwisePlot.AddRadioButton(rdoXVariables)
        ucrPnlPairwisePlot.AddRadioButton(rdoYVariables)
    End Sub


    'clsRGraphics.AddParameter("columns", dlgCanonicalCorrelationAnalysis.ucrReceiverXvariables.GetVariableNames())


    Public Sub SetRFunction(clsNewRCoef As RFunction, clsNewRCanCor As RFunction, Optional bReset As Boolean = False)
        If Not bControlsInitialised Then
            InitialiseControls()
        End If

        clsRCanCor = clsNewRCanCor
        clsRCoef = clsNewRCoef

        'Setting Rcode for the sub dialog
        ucrChkCanonicalCorrelations.SetRCode(clsRCanCor, bReset)
        ucrChkCoefficients.SetRCode(clsRCoef, bReset)
    End Sub

    Public Sub CreatePlots()
        If ucrChkCanonicalCorrelations.Checked Then
            frmMain.clsRLink.RunScript(clsRCanCor.ToScript(), 2)
        End If
        If ucrChkCoefficients.Checked Then
            frmMain.clsRLink.RunScript(clsRCoef.ToScript(), 2)
        End If
        If rdoXVariables.Checked OrElse rdoYVariables.Checked Then
            frmMain.clsRLink.RunScript(clsRGraphics.GetScript(), 2)
        End If
    End Sub
End Class