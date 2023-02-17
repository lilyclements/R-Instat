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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DlgDefineClimaticData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grpElements = New System.Windows.Forms.GroupBox()
        Me.ucrReceiverMaxRH = New instat.ucrReceiverSingle()
        Me.lblMaxRH = New System.Windows.Forms.Label()
        Me.ucrReceiverMinRH = New instat.ucrReceiverSingle()
        Me.lblMinimumRH = New System.Windows.Forms.Label()
        Me.ucrReceiverWindDirection = New instat.ucrReceiverSingle()
        Me.ucrReceiverRain = New instat.ucrReceiverSingle()
        Me.ucrReceiverSunshine = New instat.ucrReceiverSingle()
        Me.lblRain = New System.Windows.Forms.Label()
        Me.ucrReceiverRadiation = New instat.ucrReceiverSingle()
        Me.ucrReceiverMaxTemp = New instat.ucrReceiverSingle()
        Me.ucrReceiverCloudCover = New instat.ucrReceiverSingle()
        Me.lblMaxTemp = New System.Windows.Forms.Label()
        Me.lblCloudCover = New System.Windows.Forms.Label()
        Me.lblMinTemp = New System.Windows.Forms.Label()
        Me.lblRadiation = New System.Windows.Forms.Label()
        Me.ucrReceiverWindSpeed = New instat.ucrReceiverSingle()
        Me.lblSunshine = New System.Windows.Forms.Label()
        Me.ucrReceiverMinTemp = New instat.ucrReceiverSingle()
        Me.lblWindSpeed = New System.Windows.Forms.Label()
        Me.lblWindDirection = New System.Windows.Forms.Label()
        Me.lblStationName = New System.Windows.Forms.Label()
        Me.lblDOY = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.grpDateTime = New System.Windows.Forms.GroupBox()
        Me.ucrReceiverYear = New instat.ucrReceiverSingle()
        Me.ucrReceiverDOY = New instat.ucrReceiverSingle()
        Me.ucrReceiverDate = New instat.ucrReceiverSingle()
        Me.ucrReceiverMonth = New instat.ucrReceiverSingle()
        Me.ucrReceiverDay = New instat.ucrReceiverSingle()
        Me.grpStation = New System.Windows.Forms.GroupBox()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.ucrReceiverLongitude = New instat.ucrReceiverSingle()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.UcrReceiverLatitude = New instat.ucrReceiverSingle()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.ucrReceiverAltitude = New instat.ucrReceiverSingle()
        Me.ucrReceiverStationName = New instat.ucrReceiverSingle()
        Me.cmdCheckUnique = New System.Windows.Forms.Button()
        Me.ucrInputCheckInput = New instat.ucrInputTextBox()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrSelectorDefineClimaticData = New instat.ucrSelectorByDataFrameAddRemove()
        Me.grpElements.SuspendLayout()
        Me.grpDateTime.SuspendLayout()
        Me.grpStation.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpElements
        '
        Me.grpElements.Controls.Add(Me.ucrReceiverMaxRH)
        Me.grpElements.Controls.Add(Me.lblMaxRH)
        Me.grpElements.Controls.Add(Me.ucrReceiverMinRH)
        Me.grpElements.Controls.Add(Me.lblMinimumRH)
        Me.grpElements.Controls.Add(Me.ucrReceiverWindDirection)
        Me.grpElements.Controls.Add(Me.ucrReceiverRain)
        Me.grpElements.Controls.Add(Me.ucrReceiverSunshine)
        Me.grpElements.Controls.Add(Me.lblRain)
        Me.grpElements.Controls.Add(Me.ucrReceiverRadiation)
        Me.grpElements.Controls.Add(Me.ucrReceiverMaxTemp)
        Me.grpElements.Controls.Add(Me.ucrReceiverCloudCover)
        Me.grpElements.Controls.Add(Me.lblMaxTemp)
        Me.grpElements.Controls.Add(Me.lblCloudCover)
        Me.grpElements.Controls.Add(Me.lblMinTemp)
        Me.grpElements.Controls.Add(Me.lblRadiation)
        Me.grpElements.Controls.Add(Me.ucrReceiverWindSpeed)
        Me.grpElements.Controls.Add(Me.lblSunshine)
        Me.grpElements.Controls.Add(Me.ucrReceiverMinTemp)
        Me.grpElements.Controls.Add(Me.lblWindSpeed)
        Me.grpElements.Controls.Add(Me.lblWindDirection)
        Me.grpElements.Location = New System.Drawing.Point(306, 6)
        Me.grpElements.Name = "grpElements"
        Me.grpElements.Size = New System.Drawing.Size(146, 424)
        Me.grpElements.TabIndex = 3
        Me.grpElements.TabStop = False
        Me.grpElements.Text = "Elements"
        '
        'ucrReceiverMaxRH
        '
        Me.ucrReceiverMaxRH.AutoSize = True
        Me.ucrReceiverMaxRH.frmParent = Me
        Me.ucrReceiverMaxRH.Location = New System.Drawing.Point(16, 395)
        Me.ucrReceiverMaxRH.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMaxRH.Name = "ucrReceiverMaxRH"
        Me.ucrReceiverMaxRH.Selector = Nothing
        Me.ucrReceiverMaxRH.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverMaxRH.strNcFilePath = ""
        Me.ucrReceiverMaxRH.TabIndex = 19
        Me.ucrReceiverMaxRH.ucrSelector = Nothing
        '
        'lblMaxRH
        '
        Me.lblMaxRH.AutoSize = True
        Me.lblMaxRH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMaxRH.Location = New System.Drawing.Point(16, 379)
        Me.lblMaxRH.Name = "lblMaxRH"
        Me.lblMaxRH.Size = New System.Drawing.Size(90, 13)
        Me.lblMaxRH.TabIndex = 18
        Me.lblMaxRH.Text = "Maximum RH (%):"
        '
        'ucrReceiverMinRH
        '
        Me.ucrReceiverMinRH.AutoSize = True
        Me.ucrReceiverMinRH.frmParent = Me
        Me.ucrReceiverMinRH.Location = New System.Drawing.Point(16, 354)
        Me.ucrReceiverMinRH.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMinRH.Name = "ucrReceiverMinRH"
        Me.ucrReceiverMinRH.Selector = Nothing
        Me.ucrReceiverMinRH.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverMinRH.strNcFilePath = ""
        Me.ucrReceiverMinRH.TabIndex = 17
        Me.ucrReceiverMinRH.ucrSelector = Nothing
        '
        'lblMinimumRH
        '
        Me.lblMinimumRH.AutoSize = True
        Me.lblMinimumRH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMinimumRH.Location = New System.Drawing.Point(16, 338)
        Me.lblMinimumRH.Name = "lblMinimumRH"
        Me.lblMinimumRH.Size = New System.Drawing.Size(87, 13)
        Me.lblMinimumRH.TabIndex = 16
        Me.lblMinimumRH.Text = "Minimum RH (%):"
        '
        'ucrReceiverWindDirection
        '
        Me.ucrReceiverWindDirection.AutoSize = True
        Me.ucrReceiverWindDirection.frmParent = Me
        Me.ucrReceiverWindDirection.Location = New System.Drawing.Point(16, 193)
        Me.ucrReceiverWindDirection.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverWindDirection.Name = "ucrReceiverWindDirection"
        Me.ucrReceiverWindDirection.Selector = Nothing
        Me.ucrReceiverWindDirection.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverWindDirection.strNcFilePath = ""
        Me.ucrReceiverWindDirection.TabIndex = 9
        Me.ucrReceiverWindDirection.ucrSelector = Nothing
        '
        'ucrReceiverRain
        '
        Me.ucrReceiverRain.AutoSize = True
        Me.ucrReceiverRain.frmParent = Me
        Me.ucrReceiverRain.Location = New System.Drawing.Point(16, 31)
        Me.ucrReceiverRain.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverRain.Name = "ucrReceiverRain"
        Me.ucrReceiverRain.Selector = Nothing
        Me.ucrReceiverRain.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverRain.strNcFilePath = ""
        Me.ucrReceiverRain.TabIndex = 1
        Me.ucrReceiverRain.ucrSelector = Nothing
        '
        'ucrReceiverSunshine
        '
        Me.ucrReceiverSunshine.AutoSize = True
        Me.ucrReceiverSunshine.frmParent = Me
        Me.ucrReceiverSunshine.Location = New System.Drawing.Point(16, 231)
        Me.ucrReceiverSunshine.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverSunshine.Name = "ucrReceiverSunshine"
        Me.ucrReceiverSunshine.Selector = Nothing
        Me.ucrReceiverSunshine.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverSunshine.strNcFilePath = ""
        Me.ucrReceiverSunshine.TabIndex = 11
        Me.ucrReceiverSunshine.ucrSelector = Nothing
        '
        'lblRain
        '
        Me.lblRain.AutoSize = True
        Me.lblRain.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRain.Location = New System.Drawing.Point(16, 16)
        Me.lblRain.Name = "lblRain"
        Me.lblRain.Size = New System.Drawing.Size(32, 13)
        Me.lblRain.TabIndex = 0
        Me.lblRain.Text = "Rain:"
        '
        'ucrReceiverRadiation
        '
        Me.ucrReceiverRadiation.AutoSize = True
        Me.ucrReceiverRadiation.frmParent = Me
        Me.ucrReceiverRadiation.Location = New System.Drawing.Point(16, 272)
        Me.ucrReceiverRadiation.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverRadiation.Name = "ucrReceiverRadiation"
        Me.ucrReceiverRadiation.Selector = Nothing
        Me.ucrReceiverRadiation.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverRadiation.strNcFilePath = ""
        Me.ucrReceiverRadiation.TabIndex = 13
        Me.ucrReceiverRadiation.ucrSelector = Nothing
        '
        'ucrReceiverMaxTemp
        '
        Me.ucrReceiverMaxTemp.AutoSize = True
        Me.ucrReceiverMaxTemp.frmParent = Me
        Me.ucrReceiverMaxTemp.Location = New System.Drawing.Point(16, 111)
        Me.ucrReceiverMaxTemp.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMaxTemp.Name = "ucrReceiverMaxTemp"
        Me.ucrReceiverMaxTemp.Selector = Nothing
        Me.ucrReceiverMaxTemp.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverMaxTemp.strNcFilePath = ""
        Me.ucrReceiverMaxTemp.TabIndex = 5
        Me.ucrReceiverMaxTemp.ucrSelector = Nothing
        '
        'ucrReceiverCloudCover
        '
        Me.ucrReceiverCloudCover.AutoSize = True
        Me.ucrReceiverCloudCover.frmParent = Me
        Me.ucrReceiverCloudCover.Location = New System.Drawing.Point(16, 313)
        Me.ucrReceiverCloudCover.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverCloudCover.Name = "ucrReceiverCloudCover"
        Me.ucrReceiverCloudCover.Selector = Nothing
        Me.ucrReceiverCloudCover.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverCloudCover.strNcFilePath = ""
        Me.ucrReceiverCloudCover.TabIndex = 15
        Me.ucrReceiverCloudCover.ucrSelector = Nothing
        '
        'lblMaxTemp
        '
        Me.lblMaxTemp.AutoSize = True
        Me.lblMaxTemp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMaxTemp.Location = New System.Drawing.Point(16, 96)
        Me.lblMaxTemp.Name = "lblMaxTemp"
        Me.lblMaxTemp.Size = New System.Drawing.Size(117, 13)
        Me.lblMaxTemp.TabIndex = 4
        Me.lblMaxTemp.Text = "Maximum Temperature:"
        '
        'lblCloudCover
        '
        Me.lblCloudCover.AutoSize = True
        Me.lblCloudCover.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCloudCover.Location = New System.Drawing.Point(16, 297)
        Me.lblCloudCover.Name = "lblCloudCover"
        Me.lblCloudCover.Size = New System.Drawing.Size(68, 13)
        Me.lblCloudCover.TabIndex = 14
        Me.lblCloudCover.Text = "Cloud Cover:"
        '
        'lblMinTemp
        '
        Me.lblMinTemp.AutoSize = True
        Me.lblMinTemp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMinTemp.Location = New System.Drawing.Point(16, 55)
        Me.lblMinTemp.Name = "lblMinTemp"
        Me.lblMinTemp.Size = New System.Drawing.Size(111, 13)
        Me.lblMinTemp.TabIndex = 2
        Me.lblMinTemp.Text = "Minimum Temperature"
        '
        'lblRadiation
        '
        Me.lblRadiation.AutoSize = True
        Me.lblRadiation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRadiation.Location = New System.Drawing.Point(16, 257)
        Me.lblRadiation.Name = "lblRadiation"
        Me.lblRadiation.Size = New System.Drawing.Size(55, 13)
        Me.lblRadiation.TabIndex = 12
        Me.lblRadiation.Text = "Radiation:"
        '
        'ucrReceiverWindSpeed
        '
        Me.ucrReceiverWindSpeed.AutoSize = True
        Me.ucrReceiverWindSpeed.frmParent = Me
        Me.ucrReceiverWindSpeed.Location = New System.Drawing.Point(16, 152)
        Me.ucrReceiverWindSpeed.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverWindSpeed.Name = "ucrReceiverWindSpeed"
        Me.ucrReceiverWindSpeed.Selector = Nothing
        Me.ucrReceiverWindSpeed.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverWindSpeed.strNcFilePath = ""
        Me.ucrReceiverWindSpeed.TabIndex = 7
        Me.ucrReceiverWindSpeed.ucrSelector = Nothing
        '
        'lblSunshine
        '
        Me.lblSunshine.AutoSize = True
        Me.lblSunshine.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSunshine.Location = New System.Drawing.Point(16, 217)
        Me.lblSunshine.Name = "lblSunshine"
        Me.lblSunshine.Size = New System.Drawing.Size(85, 13)
        Me.lblSunshine.TabIndex = 10
        Me.lblSunshine.Text = "Sunshine Hours:"
        '
        'ucrReceiverMinTemp
        '
        Me.ucrReceiverMinTemp.AutoSize = True
        Me.ucrReceiverMinTemp.frmParent = Me
        Me.ucrReceiverMinTemp.Location = New System.Drawing.Point(16, 70)
        Me.ucrReceiverMinTemp.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMinTemp.Name = "ucrReceiverMinTemp"
        Me.ucrReceiverMinTemp.Selector = Nothing
        Me.ucrReceiverMinTemp.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverMinTemp.strNcFilePath = ""
        Me.ucrReceiverMinTemp.TabIndex = 3
        Me.ucrReceiverMinTemp.ucrSelector = Nothing
        '
        'lblWindSpeed
        '
        Me.lblWindSpeed.AutoSize = True
        Me.lblWindSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWindSpeed.Location = New System.Drawing.Point(16, 137)
        Me.lblWindSpeed.Name = "lblWindSpeed"
        Me.lblWindSpeed.Size = New System.Drawing.Size(69, 13)
        Me.lblWindSpeed.TabIndex = 6
        Me.lblWindSpeed.Text = "Wind Speed:"
        '
        'lblWindDirection
        '
        Me.lblWindDirection.AutoSize = True
        Me.lblWindDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWindDirection.Location = New System.Drawing.Point(16, 178)
        Me.lblWindDirection.Name = "lblWindDirection"
        Me.lblWindDirection.Size = New System.Drawing.Size(80, 13)
        Me.lblWindDirection.TabIndex = 8
        Me.lblWindDirection.Text = "Wind Direction:"
        '
        'lblStationName
        '
        Me.lblStationName.AutoSize = True
        Me.lblStationName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStationName.Location = New System.Drawing.Point(7, 16)
        Me.lblStationName.Name = "lblStationName"
        Me.lblStationName.Size = New System.Drawing.Size(38, 13)
        Me.lblStationName.TabIndex = 0
        Me.lblStationName.Text = "Name:"
        '
        'lblDOY
        '
        Me.lblDOY.AutoSize = True
        Me.lblDOY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDOY.Location = New System.Drawing.Point(15, 180)
        Me.lblDOY.Name = "lblDOY"
        Me.lblDOY.Size = New System.Drawing.Size(66, 13)
        Me.lblDOY.TabIndex = 8
        Me.lblDOY.Text = "Day of Year:"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDay.Location = New System.Drawing.Point(15, 139)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(29, 13)
        Me.lblDay.TabIndex = 6
        Me.lblDay.Text = "Day:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMonth.Location = New System.Drawing.Point(15, 98)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(40, 13)
        Me.lblMonth.TabIndex = 4
        Me.lblMonth.Text = "Month:"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblYear.Location = New System.Drawing.Point(15, 57)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 2
        Me.lblYear.Text = "Year:"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDate.Location = New System.Drawing.Point(15, 17)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(33, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date:"
        '
        'grpDateTime
        '
        Me.grpDateTime.Controls.Add(Me.lblDOY)
        Me.grpDateTime.Controls.Add(Me.ucrReceiverYear)
        Me.grpDateTime.Controls.Add(Me.lblDate)
        Me.grpDateTime.Controls.Add(Me.lblMonth)
        Me.grpDateTime.Controls.Add(Me.ucrReceiverDOY)
        Me.grpDateTime.Controls.Add(Me.lblYear)
        Me.grpDateTime.Controls.Add(Me.ucrReceiverDate)
        Me.grpDateTime.Controls.Add(Me.ucrReceiverMonth)
        Me.grpDateTime.Controls.Add(Me.ucrReceiverDay)
        Me.grpDateTime.Controls.Add(Me.lblDay)
        Me.grpDateTime.Location = New System.Drawing.Point(154, 207)
        Me.grpDateTime.Name = "grpDateTime"
        Me.grpDateTime.Size = New System.Drawing.Size(148, 223)
        Me.grpDateTime.TabIndex = 2
        Me.grpDateTime.TabStop = False
        Me.grpDateTime.Tag = ""
        Me.grpDateTime.Text = "Date and Time"
        '
        'ucrReceiverYear
        '
        Me.ucrReceiverYear.AutoSize = True
        Me.ucrReceiverYear.frmParent = Me
        Me.ucrReceiverYear.Location = New System.Drawing.Point(15, 72)
        Me.ucrReceiverYear.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverYear.Name = "ucrReceiverYear"
        Me.ucrReceiverYear.Selector = Nothing
        Me.ucrReceiverYear.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverYear.strNcFilePath = ""
        Me.ucrReceiverYear.TabIndex = 3
        Me.ucrReceiverYear.ucrSelector = Nothing
        '
        'ucrReceiverDOY
        '
        Me.ucrReceiverDOY.AutoSize = True
        Me.ucrReceiverDOY.frmParent = Me
        Me.ucrReceiverDOY.Location = New System.Drawing.Point(15, 195)
        Me.ucrReceiverDOY.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverDOY.Name = "ucrReceiverDOY"
        Me.ucrReceiverDOY.Selector = Nothing
        Me.ucrReceiverDOY.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverDOY.strNcFilePath = ""
        Me.ucrReceiverDOY.TabIndex = 9
        Me.ucrReceiverDOY.ucrSelector = Nothing
        '
        'ucrReceiverDate
        '
        Me.ucrReceiverDate.AutoSize = True
        Me.ucrReceiverDate.frmParent = Me
        Me.ucrReceiverDate.Location = New System.Drawing.Point(15, 31)
        Me.ucrReceiverDate.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverDate.Name = "ucrReceiverDate"
        Me.ucrReceiverDate.Selector = Nothing
        Me.ucrReceiverDate.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverDate.strNcFilePath = ""
        Me.ucrReceiverDate.TabIndex = 1
        Me.ucrReceiverDate.ucrSelector = Nothing
        '
        'ucrReceiverMonth
        '
        Me.ucrReceiverMonth.AutoSize = True
        Me.ucrReceiverMonth.frmParent = Me
        Me.ucrReceiverMonth.Location = New System.Drawing.Point(15, 113)
        Me.ucrReceiverMonth.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMonth.Name = "ucrReceiverMonth"
        Me.ucrReceiverMonth.Selector = Nothing
        Me.ucrReceiverMonth.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverMonth.strNcFilePath = ""
        Me.ucrReceiverMonth.TabIndex = 5
        Me.ucrReceiverMonth.ucrSelector = Nothing
        '
        'ucrReceiverDay
        '
        Me.ucrReceiverDay.AutoSize = True
        Me.ucrReceiverDay.frmParent = Me
        Me.ucrReceiverDay.Location = New System.Drawing.Point(15, 154)
        Me.ucrReceiverDay.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverDay.Name = "ucrReceiverDay"
        Me.ucrReceiverDay.Selector = Nothing
        Me.ucrReceiverDay.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverDay.strNcFilePath = ""
        Me.ucrReceiverDay.TabIndex = 7
        Me.ucrReceiverDay.ucrSelector = Nothing
        '
        'grpStation
        '
        Me.grpStation.Controls.Add(Me.lblLongitude)
        Me.grpStation.Controls.Add(Me.ucrReceiverLongitude)
        Me.grpStation.Controls.Add(Me.lblLatitude)
        Me.grpStation.Controls.Add(Me.UcrReceiverLatitude)
        Me.grpStation.Controls.Add(Me.lblAltitude)
        Me.grpStation.Controls.Add(Me.ucrReceiverAltitude)
        Me.grpStation.Controls.Add(Me.lblStationName)
        Me.grpStation.Controls.Add(Me.ucrReceiverStationName)
        Me.grpStation.Location = New System.Drawing.Point(13, 208)
        Me.grpStation.Name = "grpStation"
        Me.grpStation.Size = New System.Drawing.Size(135, 173)
        Me.grpStation.TabIndex = 1
        Me.grpStation.TabStop = False
        Me.grpStation.Tag = ""
        Me.grpStation.Text = "Station"
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLongitude.Location = New System.Drawing.Point(7, 93)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(57, 13)
        Me.lblLongitude.TabIndex = 6
        Me.lblLongitude.Text = "Longitude:"
        '
        'ucrReceiverLongitude
        '
        Me.ucrReceiverLongitude.AutoSize = True
        Me.ucrReceiverLongitude.frmParent = Me
        Me.ucrReceiverLongitude.Location = New System.Drawing.Point(7, 108)
        Me.ucrReceiverLongitude.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverLongitude.Name = "ucrReceiverLongitude"
        Me.ucrReceiverLongitude.Selector = Nothing
        Me.ucrReceiverLongitude.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverLongitude.strNcFilePath = ""
        Me.ucrReceiverLongitude.TabIndex = 7
        Me.ucrReceiverLongitude.ucrSelector = Nothing
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLatitude.Location = New System.Drawing.Point(7, 55)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(48, 13)
        Me.lblLatitude.TabIndex = 4
        Me.lblLatitude.Text = "Latitude:"
        '
        'UcrReceiverLatitude
        '
        Me.UcrReceiverLatitude.AutoSize = True
        Me.UcrReceiverLatitude.frmParent = Me
        Me.UcrReceiverLatitude.Location = New System.Drawing.Point(7, 70)
        Me.UcrReceiverLatitude.Margin = New System.Windows.Forms.Padding(0)
        Me.UcrReceiverLatitude.Name = "UcrReceiverLatitude"
        Me.UcrReceiverLatitude.Selector = Nothing
        Me.UcrReceiverLatitude.Size = New System.Drawing.Size(120, 20)
        Me.UcrReceiverLatitude.strNcFilePath = ""
        Me.UcrReceiverLatitude.TabIndex = 5
        Me.UcrReceiverLatitude.ucrSelector = Nothing
        '
        'lblAltitude
        '
        Me.lblAltitude.AutoSize = True
        Me.lblAltitude.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAltitude.Location = New System.Drawing.Point(7, 132)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(45, 13)
        Me.lblAltitude.TabIndex = 2
        Me.lblAltitude.Text = "Altitude:"
        '
        'ucrReceiverAltitude
        '
        Me.ucrReceiverAltitude.AutoSize = True
        Me.ucrReceiverAltitude.frmParent = Me
        Me.ucrReceiverAltitude.Location = New System.Drawing.Point(7, 147)
        Me.ucrReceiverAltitude.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverAltitude.Name = "ucrReceiverAltitude"
        Me.ucrReceiverAltitude.Selector = Nothing
        Me.ucrReceiverAltitude.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverAltitude.strNcFilePath = ""
        Me.ucrReceiverAltitude.TabIndex = 3
        Me.ucrReceiverAltitude.ucrSelector = Nothing
        '
        'ucrReceiverStationName
        '
        Me.ucrReceiverStationName.AutoSize = True
        Me.ucrReceiverStationName.frmParent = Me
        Me.ucrReceiverStationName.Location = New System.Drawing.Point(7, 31)
        Me.ucrReceiverStationName.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverStationName.Name = "ucrReceiverStationName"
        Me.ucrReceiverStationName.Selector = Nothing
        Me.ucrReceiverStationName.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverStationName.strNcFilePath = ""
        Me.ucrReceiverStationName.TabIndex = 1
        Me.ucrReceiverStationName.ucrSelector = Nothing
        '
        'cmdCheckUnique
        '
        Me.cmdCheckUnique.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCheckUnique.Location = New System.Drawing.Point(9, 435)
        Me.cmdCheckUnique.Name = "cmdCheckUnique"
        Me.cmdCheckUnique.Size = New System.Drawing.Size(139, 23)
        Me.cmdCheckUnique.TabIndex = 4
        Me.cmdCheckUnique.Text = "Check Duplicates"
        Me.cmdCheckUnique.UseVisualStyleBackColor = True
        '
        'ucrInputCheckInput
        '
        Me.ucrInputCheckInput.AddQuotesIfUnrecognised = True
        Me.ucrInputCheckInput.AutoSize = True
        Me.ucrInputCheckInput.IsMultiline = False
        Me.ucrInputCheckInput.IsReadOnly = False
        Me.ucrInputCheckInput.Location = New System.Drawing.Point(154, 437)
        Me.ucrInputCheckInput.Name = "ucrInputCheckInput"
        Me.ucrInputCheckInput.Size = New System.Drawing.Size(253, 21)
        Me.ucrInputCheckInput.TabIndex = 5
        '
        'ucrBase
        '
        Me.ucrBase.AutoSize = True
        Me.ucrBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrBase.Location = New System.Drawing.Point(13, 464)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(408, 52)
        Me.ucrBase.TabIndex = 6
        '
        'ucrSelectorDefineClimaticData
        '
        Me.ucrSelectorDefineClimaticData.AutoSize = True
        Me.ucrSelectorDefineClimaticData.bDropUnusedFilterLevels = False
        Me.ucrSelectorDefineClimaticData.bShowHiddenColumns = False
        Me.ucrSelectorDefineClimaticData.bUseCurrentFilter = True
        Me.ucrSelectorDefineClimaticData.Location = New System.Drawing.Point(13, 14)
        Me.ucrSelectorDefineClimaticData.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorDefineClimaticData.Name = "ucrSelectorDefineClimaticData"
        Me.ucrSelectorDefineClimaticData.Size = New System.Drawing.Size(213, 183)
        Me.ucrSelectorDefineClimaticData.TabIndex = 0
        '
        'DlgDefineClimaticData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(464, 522)
        Me.Controls.Add(Me.ucrInputCheckInput)
        Me.Controls.Add(Me.cmdCheckUnique)
        Me.Controls.Add(Me.grpStation)
        Me.Controls.Add(Me.grpDateTime)
        Me.Controls.Add(Me.grpElements)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.ucrSelectorDefineClimaticData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgDefineClimaticData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Define Climatic Data"
        Me.grpElements.ResumeLayout(False)
        Me.grpElements.PerformLayout()
        Me.grpDateTime.ResumeLayout(False)
        Me.grpDateTime.PerformLayout()
        Me.grpStation.ResumeLayout(False)
        Me.grpStation.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrSelectorDefineClimaticData As ucrSelectorByDataFrameAddRemove
    Friend WithEvents grpElements As GroupBox
    Friend WithEvents ucrReceiverDate As ucrReceiverSingle
    Friend WithEvents ucrReceiverRain As ucrReceiverSingle
    Friend WithEvents ucrReceiverMaxTemp As ucrReceiverSingle
    Friend WithEvents ucrReceiverWindDirection As ucrReceiverSingle
    Friend WithEvents ucrReceiverSunshine As ucrReceiverSingle
    Friend WithEvents ucrReceiverRadiation As ucrReceiverSingle
    Friend WithEvents ucrReceiverCloudCover As ucrReceiverSingle
    Friend WithEvents lblCloudCover As Label
    Friend WithEvents lblRadiation As Label
    Friend WithEvents lblWindDirection As Label
    Friend WithEvents lblSunshine As Label
    Friend WithEvents lblWindSpeed As Label
    Friend WithEvents ucrReceiverMinTemp As ucrReceiverSingle
    Friend WithEvents ucrReceiverWindSpeed As ucrReceiverSingle
    Friend WithEvents lblRain As Label
    Friend WithEvents lblMinTemp As Label
    Friend WithEvents lblMaxTemp As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrReceiverDay As ucrReceiverSingle
    Friend WithEvents lblDay As Label
    Friend WithEvents ucrReceiverMonth As ucrReceiverSingle
    Friend WithEvents lblMonth As Label
    Friend WithEvents ucrReceiverYear As ucrReceiverSingle
    Friend WithEvents lblYear As Label
    Friend WithEvents ucrReceiverStationName As ucrReceiverSingle
    Friend WithEvents lblStationName As Label
    Friend WithEvents lblDOY As Label
    Friend WithEvents ucrReceiverDOY As ucrReceiverSingle
    Friend WithEvents grpDateTime As GroupBox
    Friend WithEvents grpStation As GroupBox
    Friend WithEvents ucrInputCheckInput As ucrInputTextBox
    Friend WithEvents cmdCheckUnique As Button
    Friend WithEvents ucrReceiverMinRH As ucrReceiverSingle
    Friend WithEvents lblMinimumRH As Label
    Friend WithEvents ucrReceiverMaxRH As ucrReceiverSingle
    Friend WithEvents lblMaxRH As Label
    Friend WithEvents lblAltitude As Label
    Friend WithEvents ucrReceiverAltitude As ucrReceiverSingle
    Friend WithEvents lblLongitude As Label
    Friend WithEvents ucrReceiverLongitude As ucrReceiverSingle
    Friend WithEvents lblLatitude As Label
    Friend WithEvents UcrReceiverLatitude As ucrReceiverSingle
End Class
