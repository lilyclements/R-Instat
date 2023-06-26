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
Public Class sdgPMConstants
    Public bFirstLoad As Boolean = True
    Public bControlsInitialised As Boolean = False
    Public clsListFunction As New RFunction

    Private Sub sdgPMConstants_Load(sender As Object, e As EventArgs) Handles UcrButtonsSubdialogue1.Load
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseControls()
        ucrInputLambda.SetParameter(New RParameter("lambda", 1))
        ucrInputLambda.AddQuotesIfUnrecognised = False
        ucrInputLambda.SetLinkedDisplayControl(lblLambda)

        ucrInputSigma.SetParameter(New RParameter("sigma", 5))
        ucrInputSigma.AddQuotesIfUnrecognised = False

        ucrInputSolarConstant.SetParameter(New RParameter("Gsc", 3))
        ucrInputSolarConstant.AddQuotesIfUnrecognised = False
        ucrInputSolarConstant.SetLinkedDisplayControl(lblSolarConstant)

        ucrNudHeigth.SetParameter(New RParameter("z", 4))
        ucrNudHeigth.SetMinMax(0, 10)
        ucrNudHeigth.Increment = 1

        ucrInputSoilFlux.SetParameter(New RParameter("G", 6))
        ucrInputSoilFlux.AddQuotesIfUnrecognised = False
        ucrInputSoilFlux.SetLinkedDisplayControl(lblSoilFlux)

        ucrInputAs.SetParameter(New RParameter("as", 7))
        ucrInputAs.AddQuotesIfUnrecognised = False
        ucrInputAs.SetLinkedDisplayControl(lblAS)

        ucrInputBS.SetParameter(New RParameter("bs", 8))
        ucrInputBS.AddQuotesIfUnrecognised = False
        ucrInputBS.SetLinkedDisplayControl(lblBS)

        bControlsInitialised = True
    End Sub

    Public Sub SetRFunction(clsNewListFunction As RFunction, Optional bReset As Boolean = False)
        clsListFunction = clsNewListFunction
        If Not bControlsInitialised Then
            InitialiseControls()
        End If
        ucrNudHeigth.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrInputLambda.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrInputSigma.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrInputSoilFlux.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrInputSolarConstant.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrInputAs.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrInputBS.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
    End Sub
End Class