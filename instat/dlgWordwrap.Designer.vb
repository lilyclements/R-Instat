﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgWordwrap
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
        Me.ucrSelectorForWrapText = New instat.ucrSelectorByDataFrameAddRemove()
        Me.lblColumnToTransform = New System.Windows.Forms.Label()
        Me.ucrReceiverWrapText = New instat.ucrReceiverSingle()
        Me.ucrPnlTextWrap = New instat.UcrPanel()
        Me.rdoWrapText = New System.Windows.Forms.RadioButton()
        Me.ucrNudWidthWrap = New instat.ucrNud()
        Me.lblWidthWrap = New System.Windows.Forms.Label()
        Me.ucrNewColName = New instat.ucrSave()
        Me.ucrBase = New instat.ucrButtons()
        Me.lblAlign = New System.Windows.Forms.Label()
        Me.ucrAlignment = New instat.ucrInputComboBox()
        Me.grpOptions = New System.Windows.Forms.GroupBox()
        Me.rdoUnWrapText = New System.Windows.Forms.RadioButton()
        Me.grpOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'ucrSelectorForWrapText
        '
        Me.ucrSelectorForWrapText.AutoSize = True
        Me.ucrSelectorForWrapText.bDropUnusedFilterLevels = False
        Me.ucrSelectorForWrapText.bShowHiddenColumns = False
        Me.ucrSelectorForWrapText.bUseCurrentFilter = True
        Me.ucrSelectorForWrapText.Location = New System.Drawing.Point(11, 16)
        Me.ucrSelectorForWrapText.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorForWrapText.Name = "ucrSelectorForWrapText"
        Me.ucrSelectorForWrapText.Size = New System.Drawing.Size(242, 185)
        Me.ucrSelectorForWrapText.TabIndex = 0
        '
        'lblColumnToTransform
        '
        Me.lblColumnToTransform.AutoSize = True
        Me.lblColumnToTransform.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblColumnToTransform.Location = New System.Drawing.Point(263, 28)
        Me.lblColumnToTransform.Name = "lblColumnToTransform"
        Me.lblColumnToTransform.Size = New System.Drawing.Size(107, 13)
        Me.lblColumnToTransform.TabIndex = 1
        Me.lblColumnToTransform.Text = "Column to Transform:"
        '
        'ucrReceiverWrapText
        '
        Me.ucrReceiverWrapText.AutoSize = True
        Me.ucrReceiverWrapText.frmParent = Me
        Me.ucrReceiverWrapText.Location = New System.Drawing.Point(263, 46)
        Me.ucrReceiverWrapText.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverWrapText.Name = "ucrReceiverWrapText"
        Me.ucrReceiverWrapText.Selector = Nothing
        Me.ucrReceiverWrapText.Size = New System.Drawing.Size(135, 26)
        Me.ucrReceiverWrapText.strNcFilePath = ""
        Me.ucrReceiverWrapText.TabIndex = 2
        Me.ucrReceiverWrapText.ucrSelector = Nothing
        '
        'ucrPnlTextWrap
        '
        Me.ucrPnlTextWrap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrPnlTextWrap.Location = New System.Drawing.Point(7, 18)
        Me.ucrPnlTextWrap.Name = "ucrPnlTextWrap"
        Me.ucrPnlTextWrap.Size = New System.Drawing.Size(156, 30)
        Me.ucrPnlTextWrap.TabIndex = 0
        '
        'rdoWrapText
        '
        Me.rdoWrapText.AutoSize = True
        Me.rdoWrapText.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoWrapText.Location = New System.Drawing.Point(12, 23)
        Me.rdoWrapText.Name = "rdoWrapText"
        Me.rdoWrapText.Size = New System.Drawing.Size(51, 17)
        Me.rdoWrapText.TabIndex = 1
        Me.rdoWrapText.TabStop = True
        Me.rdoWrapText.Text = "Wrap"
        Me.rdoWrapText.UseVisualStyleBackColor = True
        '
        'ucrNudWidthWrap
        '
        Me.ucrNudWidthWrap.AutoSize = True
        Me.ucrNudWidthWrap.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudWidthWrap.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudWidthWrap.Location = New System.Drawing.Point(320, 143)
        Me.ucrNudWidthWrap.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudWidthWrap.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudWidthWrap.Name = "ucrNudWidthWrap"
        Me.ucrNudWidthWrap.Size = New System.Drawing.Size(50, 21)
        Me.ucrNudWidthWrap.TabIndex = 5
        Me.ucrNudWidthWrap.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'lblWidthWrap
        '
        Me.lblWidthWrap.AutoSize = True
        Me.lblWidthWrap.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWidthWrap.Location = New System.Drawing.Point(263, 147)
        Me.lblWidthWrap.Name = "lblWidthWrap"
        Me.lblWidthWrap.Size = New System.Drawing.Size(38, 13)
        Me.lblWidthWrap.TabIndex = 4
        Me.lblWidthWrap.Text = "Width:"
        '
        'ucrNewColName
        '
        Me.ucrNewColName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrNewColName.Location = New System.Drawing.Point(11, 220)
        Me.ucrNewColName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNewColName.Name = "ucrNewColName"
        Me.ucrNewColName.Size = New System.Drawing.Size(392, 22)
        Me.ucrNewColName.TabIndex = 8
        '
        'ucrBase
        '
        Me.ucrBase.AutoSize = True
        Me.ucrBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrBase.Location = New System.Drawing.Point(11, 253)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(408, 52)
        Me.ucrBase.TabIndex = 9
        '
        'lblAlign
        '
        Me.lblAlign.AutoSize = True
        Me.lblAlign.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAlign.Location = New System.Drawing.Point(263, 172)
        Me.lblAlign.Name = "lblAlign"
        Me.lblAlign.Size = New System.Drawing.Size(67, 13)
        Me.lblAlign.TabIndex = 6
        Me.lblAlign.Text = "Alignmment :"
        '
        'ucrAlignment
        '
        Me.ucrAlignment.AddQuotesIfUnrecognised = True
        Me.ucrAlignment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrAlignment.GetSetSelectedIndex = -1
        Me.ucrAlignment.IsReadOnly = False
        Me.ucrAlignment.Location = New System.Drawing.Point(263, 189)
        Me.ucrAlignment.Name = "ucrAlignment"
        Me.ucrAlignment.Size = New System.Drawing.Size(136, 23)
        Me.ucrAlignment.TabIndex = 7
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.rdoUnWrapText)
        Me.grpOptions.Controls.Add(Me.rdoWrapText)
        Me.grpOptions.Controls.Add(Me.ucrPnlTextWrap)
        Me.grpOptions.Location = New System.Drawing.Point(263, 80)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(174, 57)
        Me.grpOptions.TabIndex = 3
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "Options:"
        '
        'rdoUnWrapText
        '
        Me.rdoUnWrapText.AutoSize = True
        Me.rdoUnWrapText.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoUnWrapText.Location = New System.Drawing.Point(86, 24)
        Me.rdoUnWrapText.Name = "rdoUnWrapText"
        Me.rdoUnWrapText.Size = New System.Drawing.Size(62, 17)
        Me.rdoUnWrapText.TabIndex = 2
        Me.rdoUnWrapText.TabStop = True
        Me.rdoUnWrapText.Text = "Unwrap"
        Me.rdoUnWrapText.UseVisualStyleBackColor = True
        '
        'dlgWordwrap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 314)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.lblAlign)
        Me.Controls.Add(Me.ucrAlignment)
        Me.Controls.Add(Me.ucrNewColName)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.ucrNudWidthWrap)
        Me.Controls.Add(Me.lblWidthWrap)
        Me.Controls.Add(Me.lblColumnToTransform)
        Me.Controls.Add(Me.ucrReceiverWrapText)
        Me.Controls.Add(Me.ucrSelectorForWrapText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgWordwrap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wordwrap"
        Me.grpOptions.ResumeLayout(False)
        Me.grpOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrSelectorForWrapText As ucrSelectorByDataFrameAddRemove
    Friend WithEvents lblColumnToTransform As Label
    Friend WithEvents ucrReceiverWrapText As ucrReceiverSingle
    Friend WithEvents ucrPnlTextWrap As UcrPanel
    Friend WithEvents rdoWrapText As RadioButton
    Friend WithEvents ucrNudWidthWrap As ucrNud
    Friend WithEvents lblWidthWrap As Label
    Friend WithEvents ucrNewColName As ucrSave
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents lblAlign As Label
    Friend WithEvents ucrAlignment As ucrInputComboBox
    Friend WithEvents grpOptions As GroupBox
    Friend WithEvents rdoUnWrapText As RadioButton
End Class
