﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDistances
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrSelectorDistance = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrReceiverLong = New instat.ucrReceiverSingle()
        Me.ucrReceiverLat = New instat.ucrReceiverSingle()
        Me.lblLon = New System.Windows.Forms.Label()
        Me.lblLat = New System.Windows.Forms.Label()
        Me.rdoValue = New System.Windows.Forms.RadioButton()
        Me.rdoVariable = New System.Windows.Forms.RadioButton()
        Me.ucrPnlFrom = New instat.UcrPanel()
        Me.grpFrom = New System.Windows.Forms.GroupBox()
        Me.ucrNudLon = New instat.ucrNud()
        Me.ucrNudLat = New instat.ucrNud()
        Me.lblLongFrom = New System.Windows.Forms.Label()
        Me.lblLatFrom = New System.Windows.Forms.Label()
        Me.ucrReceiverVariable = New instat.ucrReceiverSingle()
        Me.ucrInputVariable = New instat.ucrInputComboBox()
        Me.grpFrom.SuspendLayout()
        Me.SuspendLayout()
        '
        'ucrBase
        '
        Me.ucrBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrBase.Location = New System.Drawing.Point(9, 372)
        Me.ucrBase.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(615, 78)
        Me.ucrBase.TabIndex = 0
        '
        'ucrSelectorDistance
        '
        Me.ucrSelectorDistance.AutoSize = True
        Me.ucrSelectorDistance.bDropUnusedFilterLevels = False
        Me.ucrSelectorDistance.bShowHiddenColumns = False
        Me.ucrSelectorDistance.bUseCurrentFilter = True
        Me.ucrSelectorDistance.Location = New System.Drawing.Point(5, 22)
        Me.ucrSelectorDistance.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorDistance.Name = "ucrSelectorDistance"
        Me.ucrSelectorDistance.Size = New System.Drawing.Size(318, 274)
        Me.ucrSelectorDistance.TabIndex = 1
        '
        'ucrReceiverLong
        '
        Me.ucrReceiverLong.AutoSize = True
        Me.ucrReceiverLong.frmParent = Me
        Me.ucrReceiverLong.Location = New System.Drawing.Point(430, 73)
        Me.ucrReceiverLong.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverLong.Name = "ucrReceiverLong"
        Me.ucrReceiverLong.Selector = Nothing
        Me.ucrReceiverLong.Size = New System.Drawing.Size(180, 30)
        Me.ucrReceiverLong.strNcFilePath = ""
        Me.ucrReceiverLong.TabIndex = 2
        Me.ucrReceiverLong.ucrSelector = Nothing
        '
        'ucrReceiverLat
        '
        Me.ucrReceiverLat.AutoSize = True
        Me.ucrReceiverLat.frmParent = Me
        Me.ucrReceiverLat.Location = New System.Drawing.Point(432, 142)
        Me.ucrReceiverLat.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverLat.Name = "ucrReceiverLat"
        Me.ucrReceiverLat.Selector = Nothing
        Me.ucrReceiverLat.Size = New System.Drawing.Size(180, 30)
        Me.ucrReceiverLat.strNcFilePath = ""
        Me.ucrReceiverLat.TabIndex = 3
        Me.ucrReceiverLat.ucrSelector = Nothing
        '
        'lblLon
        '
        Me.lblLon.AutoSize = True
        Me.lblLon.Location = New System.Drawing.Point(433, 45)
        Me.lblLon.Name = "lblLon"
        Me.lblLon.Size = New System.Drawing.Size(49, 20)
        Me.lblLon.TabIndex = 4
        Me.lblLon.Text = "Long:"
        '
        'lblLat
        '
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(432, 119)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(36, 20)
        Me.lblLat.TabIndex = 5
        Me.lblLat.Text = "Lat:"
        '
        'rdoValue
        '
        Me.rdoValue.AutoSize = True
        Me.rdoValue.Location = New System.Drawing.Point(371, 209)
        Me.rdoValue.Name = "rdoValue"
        Me.rdoValue.Size = New System.Drawing.Size(83, 24)
        Me.rdoValue.TabIndex = 6
        Me.rdoValue.TabStop = True
        Me.rdoValue.Text = "Values"
        Me.rdoValue.UseVisualStyleBackColor = True
        '
        'rdoVariable
        '
        Me.rdoVariable.AutoSize = True
        Me.rdoVariable.Location = New System.Drawing.Point(497, 208)
        Me.rdoVariable.Name = "rdoVariable"
        Me.rdoVariable.Size = New System.Drawing.Size(92, 24)
        Me.rdoVariable.TabIndex = 7
        Me.rdoVariable.TabStop = True
        Me.rdoVariable.Text = "Variable"
        Me.rdoVariable.UseVisualStyleBackColor = True
        '
        'ucrPnlFrom
        '
        Me.ucrPnlFrom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrPnlFrom.Location = New System.Drawing.Point(356, 207)
        Me.ucrPnlFrom.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ucrPnlFrom.Name = "ucrPnlFrom"
        Me.ucrPnlFrom.Size = New System.Drawing.Size(263, 31)
        Me.ucrPnlFrom.TabIndex = 8
        '
        'grpFrom
        '
        Me.grpFrom.Controls.Add(Me.ucrInputVariable)
        Me.grpFrom.Controls.Add(Me.ucrReceiverVariable)
        Me.grpFrom.Controls.Add(Me.lblLatFrom)
        Me.grpFrom.Controls.Add(Me.lblLongFrom)
        Me.grpFrom.Controls.Add(Me.ucrNudLat)
        Me.grpFrom.Controls.Add(Me.ucrNudLon)
        Me.grpFrom.Location = New System.Drawing.Point(347, 186)
        Me.grpFrom.Name = "grpFrom"
        Me.grpFrom.Size = New System.Drawing.Size(275, 135)
        Me.grpFrom.TabIndex = 9
        Me.grpFrom.TabStop = False
        Me.grpFrom.Text = "From:"
        '
        'ucrNudLon
        '
        Me.ucrNudLon.AutoSize = True
        Me.ucrNudLon.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudLon.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudLon.Location = New System.Drawing.Point(56, 57)
        Me.ucrNudLon.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ucrNudLon.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudLon.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudLon.Name = "ucrNudLon"
        Me.ucrNudLon.Size = New System.Drawing.Size(75, 30)
        Me.ucrNudLon.TabIndex = 0
        Me.ucrNudLon.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrNudLat
        '
        Me.ucrNudLat.AutoSize = True
        Me.ucrNudLat.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudLat.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudLat.Location = New System.Drawing.Point(55, 99)
        Me.ucrNudLat.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ucrNudLat.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudLat.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudLat.Name = "ucrNudLat"
        Me.ucrNudLat.Size = New System.Drawing.Size(75, 30)
        Me.ucrNudLat.TabIndex = 1
        Me.ucrNudLat.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'lblLongFrom
        '
        Me.lblLongFrom.AutoSize = True
        Me.lblLongFrom.Location = New System.Drawing.Point(5, 58)
        Me.lblLongFrom.Name = "lblLongFrom"
        Me.lblLongFrom.Size = New System.Drawing.Size(49, 20)
        Me.lblLongFrom.TabIndex = 5
        Me.lblLongFrom.Text = "Long:"
        '
        'lblLatFrom
        '
        Me.lblLatFrom.AutoSize = True
        Me.lblLatFrom.Location = New System.Drawing.Point(7, 101)
        Me.lblLatFrom.Name = "lblLatFrom"
        Me.lblLatFrom.Size = New System.Drawing.Size(36, 20)
        Me.lblLatFrom.TabIndex = 6
        Me.lblLatFrom.Text = "Lat:"
        '
        'ucrReceiverVariable
        '
        Me.ucrReceiverVariable.AutoSize = True
        Me.ucrReceiverVariable.frmParent = Me
        Me.ucrReceiverVariable.Location = New System.Drawing.Point(137, 55)
        Me.ucrReceiverVariable.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverVariable.Name = "ucrReceiverVariable"
        Me.ucrReceiverVariable.Selector = Nothing
        Me.ucrReceiverVariable.Size = New System.Drawing.Size(135, 30)
        Me.ucrReceiverVariable.strNcFilePath = ""
        Me.ucrReceiverVariable.TabIndex = 7
        Me.ucrReceiverVariable.ucrSelector = Nothing
        '
        'ucrInputVariable
        '
        Me.ucrInputVariable.AddQuotesIfUnrecognised = True
        Me.ucrInputVariable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrInputVariable.GetSetSelectedIndex = -1
        Me.ucrInputVariable.IsReadOnly = False
        Me.ucrInputVariable.Location = New System.Drawing.Point(135, 94)
        Me.ucrInputVariable.Margin = New System.Windows.Forms.Padding(9, 9, 9, 9)
        Me.ucrInputVariable.Name = "ucrInputVariable"
        Me.ucrInputVariable.Size = New System.Drawing.Size(135, 32)
        Me.ucrInputVariable.TabIndex = 8
        '
        'dlgDistances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 469)
        Me.Controls.Add(Me.rdoVariable)
        Me.Controls.Add(Me.rdoValue)
        Me.Controls.Add(Me.lblLat)
        Me.Controls.Add(Me.lblLon)
        Me.Controls.Add(Me.ucrReceiverLat)
        Me.Controls.Add(Me.ucrReceiverLong)
        Me.Controls.Add(Me.ucrSelectorDistance)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.ucrPnlFrom)
        Me.Controls.Add(Me.grpFrom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgDistances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Distances"
        Me.grpFrom.ResumeLayout(False)
        Me.grpFrom.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrSelectorDistance As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrReceiverLong As ucrReceiverSingle
    Friend WithEvents rdoVariable As RadioButton
    Friend WithEvents rdoValue As RadioButton
    Friend WithEvents lblLat As Label
    Friend WithEvents lblLon As Label
    Friend WithEvents ucrReceiverLat As ucrReceiverSingle
    Friend WithEvents ucrPnlFrom As UcrPanel
    Friend WithEvents grpFrom As GroupBox
    Friend WithEvents ucrNudLat As ucrNud
    Friend WithEvents ucrNudLon As ucrNud
    Friend WithEvents lblLatFrom As Label
    Friend WithEvents lblLongFrom As Label
    Friend WithEvents ucrInputVariable As ucrInputComboBox
    Friend WithEvents ucrReceiverVariable As ucrReceiverSingle
End Class
