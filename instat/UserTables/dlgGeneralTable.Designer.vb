﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgGeneralTable
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
        Me.lblColumns = New System.Windows.Forms.Label()
        Me.btnMoreOptions = New System.Windows.Forms.Button()
        Me.ucrNudPreview = New instat.ucrNud()
        Me.ucrChkPreview = New instat.ucrCheck()
        Me.ucrSaveTable = New instat.ucrSave()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrReceiverMultipleCols = New instat.ucrReceiverMultiple()
        Me.ucrSelectorCols = New instat.ucrSelectorByDataFrameAddRemove()
        Me.SuspendLayout()
        '
        'lblColumns
        '
        Me.lblColumns.AutoSize = True
        Me.lblColumns.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblColumns.Location = New System.Drawing.Point(247, 50)
        Me.lblColumns.Name = "lblColumns"
        Me.lblColumns.Size = New System.Drawing.Size(50, 13)
        Me.lblColumns.TabIndex = 24
        Me.lblColumns.Text = "Columns:"
        '
        'btnMoreOptions
        '
        Me.btnMoreOptions.Location = New System.Drawing.Point(9, 204)
        Me.btnMoreOptions.Name = "btnMoreOptions"
        Me.btnMoreOptions.Size = New System.Drawing.Size(141, 23)
        Me.btnMoreOptions.TabIndex = 25
        Me.btnMoreOptions.Text = "Table Options"
        Me.btnMoreOptions.UseVisualStyleBackColor = True
        '
        'ucrNudPreview
        '
        Me.ucrNudPreview.AutoSize = True
        Me.ucrNudPreview.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudPreview.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudPreview.Location = New System.Drawing.Point(370, 174)
        Me.ucrNudPreview.Margin = New System.Windows.Forms.Padding(6)
        Me.ucrNudPreview.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudPreview.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudPreview.Name = "ucrNudPreview"
        Me.ucrNudPreview.Size = New System.Drawing.Size(50, 20)
        Me.ucrNudPreview.TabIndex = 31
        Me.ucrNudPreview.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrChkPreview
        '
        Me.ucrChkPreview.AutoSize = True
        Me.ucrChkPreview.Checked = False
        Me.ucrChkPreview.Location = New System.Drawing.Point(250, 175)
        Me.ucrChkPreview.Margin = New System.Windows.Forms.Padding(6)
        Me.ucrChkPreview.Name = "ucrChkPreview"
        Me.ucrChkPreview.Size = New System.Drawing.Size(119, 23)
        Me.ucrChkPreview.TabIndex = 30
        '
        'ucrSaveTable
        '
        Me.ucrSaveTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrSaveTable.Location = New System.Drawing.Point(9, 242)
        Me.ucrSaveTable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSaveTable.Name = "ucrSaveTable"
        Me.ucrSaveTable.Size = New System.Drawing.Size(319, 24)
        Me.ucrSaveTable.TabIndex = 27
        '
        'ucrBase
        '
        Me.ucrBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrBase.Location = New System.Drawing.Point(9, 276)
        Me.ucrBase.Margin = New System.Windows.Forms.Padding(4)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(410, 52)
        Me.ucrBase.TabIndex = 26
        '
        'ucrReceiverMultipleCols
        '
        Me.ucrReceiverMultipleCols.AutoSize = True
        Me.ucrReceiverMultipleCols.frmParent = Me
        Me.ucrReceiverMultipleCols.Location = New System.Drawing.Point(250, 63)
        Me.ucrReceiverMultipleCols.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMultipleCols.Name = "ucrReceiverMultipleCols"
        Me.ucrReceiverMultipleCols.Selector = Nothing
        Me.ucrReceiverMultipleCols.Size = New System.Drawing.Size(141, 100)
        Me.ucrReceiverMultipleCols.strNcFilePath = ""
        Me.ucrReceiverMultipleCols.TabIndex = 23
        Me.ucrReceiverMultipleCols.ucrSelector = Nothing
        '
        'ucrSelectorCols
        '
        Me.ucrSelectorCols.AutoSize = True
        Me.ucrSelectorCols.bDropUnusedFilterLevels = False
        Me.ucrSelectorCols.bShowHiddenColumns = False
        Me.ucrSelectorCols.bUseCurrentFilter = True
        Me.ucrSelectorCols.Location = New System.Drawing.Point(9, 9)
        Me.ucrSelectorCols.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorCols.Name = "ucrSelectorCols"
        Me.ucrSelectorCols.Size = New System.Drawing.Size(213, 183)
        Me.ucrSelectorCols.TabIndex = 22
        '
        'dlgGeneralTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 338)
        Me.Controls.Add(Me.ucrNudPreview)
        Me.Controls.Add(Me.ucrChkPreview)
        Me.Controls.Add(Me.ucrSaveTable)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.btnMoreOptions)
        Me.Controls.Add(Me.lblColumns)
        Me.Controls.Add(Me.ucrReceiverMultipleCols)
        Me.Controls.Add(Me.ucrSelectorCols)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgGeneralTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Presentation Table"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ucrSelectorCols As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrReceiverMultipleCols As ucrReceiverMultiple
    Friend WithEvents btnMoreOptions As Button
    Friend WithEvents lblColumns As Label
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrSaveTable As ucrSave
    Friend WithEvents ucrNudPreview As ucrNud
    Friend WithEvents ucrChkPreview As ucrCheck
End Class
