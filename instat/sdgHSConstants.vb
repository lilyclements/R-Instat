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
Public Class sdgHSConstants
    Public bFirstLoad As Boolean = True
    Public bControlsInitialised As Boolean = False
    Public clsListFunction As New RFunction
    Private Sub sdgHSConstants_Load(sender As Object, e As EventArgs) Handles ucrSdgButtons.Load
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseControls()
        'Location'
        ucrInputLatitude.SetParameter(New RParameter("lat_rad", 2))
        ucrInputLatitude.AddQuotesIfUnrecognised = False
        ucrInputLatitude.SetLinkedDisplayControl(lblLatitude)
        ucrInputLatitude.SetRDefault(0)


        ucrNudElevation.SetParameter(New RParameter("Elev", 0))
        ucrNudElevation.SetMinMax(0, 5000)
        ucrNudElevation.Increment = 1
        ucrNudElevation.SetRDefault(0)
        ucrNudElevation.SetLinkedDisplayControl(lblElevation)

        ucrInputLongitude.SetParameter(New RParameter("Y", 9))
        ucrInputLongitude.AddQuotesIfUnrecognised = False
        ucrInputLongitude.SetLinkedDisplayControl(lblLongitude)
        ucrInputLongitude.SetRDefault(0)

        'Constants'
        ucrInputLambda.SetParameter(New RParameter("lambda", 1))
        ucrInputLambda.AddQuotesIfUnrecognised = False
        ucrInputLambda.IsReadOnly = True
        ucrInputLambda.SetLinkedDisplayControl(lbllambda)
        ucrInputLambda.SetRDefault(2.45)

        ucrInputSolarConstant.SetParameter(New RParameter("Gsc", 3))
        ucrInputSolarConstant.AddQuotesIfUnrecognised = False
        ucrInputSolarConstant.IsReadOnly = True
        ucrInputSolarConstant.SetLinkedDisplayControl(lblSolarConstant)
        ucrInputSolarConstant.SetRDefault(0.082)

        bControlsInitialised = True
    End Sub

    Public Sub SetRFunction(clsNewListFunction As RFunction, Optional bReset As Boolean = False)
        clsListFunction = clsNewListFunction

        If Not bControlsInitialised Then
            InitialiseControls()
        End If

        ucrInputLatitude.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrNudElevation.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrInputLongitude.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrInputLambda.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
        ucrInputSolarConstant.SetRCode(clsListFunction, bReset, bCloneIfNeeded:=True)
    End Sub
End Class