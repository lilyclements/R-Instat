﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgMergeAdditionalData
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
        Me.ucrInputSaveDataFrame = New instat.ucrInputTextBox()
        Me.ucrChkSaveDataFrame = New instat.ucrCheck()
        Me.lblMergeBy = New System.Windows.Forms.Label()
        Me.cmdModify = New System.Windows.Forms.Button()
        Me.ucrInputMergingBy = New instat.ucrInputTextBox()
        Me.ucrToDataFrame = New instat.ucrDataFrame()
        Me.lblVariablesToIncludeSecond = New System.Windows.Forms.Label()
        Me.ucrReceiverSecond = New instat.ucrReceiverMultiple()
        Me.ucrFromDataFrame = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrBase = New instat.ucrButtons()
        Me.SuspendLayout()
        '
        'ucrInputSaveDataFrame
        '
        Me.ucrInputSaveDataFrame.AddQuotesIfUnrecognised = True
        Me.ucrInputSaveDataFrame.AutoSize = True
        Me.ucrInputSaveDataFrame.IsMultiline = False
        Me.ucrInputSaveDataFrame.IsReadOnly = False
        Me.ucrInputSaveDataFrame.Location = New System.Drawing.Point(157, 254)
        Me.ucrInputSaveDataFrame.Name = "ucrInputSaveDataFrame"
        Me.ucrInputSaveDataFrame.Size = New System.Drawing.Size(137, 21)
        Me.ucrInputSaveDataFrame.TabIndex = 19
        '
        'ucrChkSaveDataFrame
        '
        Me.ucrChkSaveDataFrame.AutoSize = True
        Me.ucrChkSaveDataFrame.Checked = False
        Me.ucrChkSaveDataFrame.Location = New System.Drawing.Point(8, 253)
        Me.ucrChkSaveDataFrame.Name = "ucrChkSaveDataFrame"
        Me.ucrChkSaveDataFrame.Size = New System.Drawing.Size(143, 23)
        Me.ucrChkSaveDataFrame.TabIndex = 18
        '
        'lblMergeBy
        '
        Me.lblMergeBy.AutoSize = True
        Me.lblMergeBy.Location = New System.Drawing.Point(7, 215)
        Me.lblMergeBy.Name = "lblMergeBy"
        Me.lblMergeBy.Size = New System.Drawing.Size(44, 13)
        Me.lblMergeBy.TabIndex = 14
        Me.lblMergeBy.Text = "Join By:"
        '
        'cmdModify
        '
        Me.cmdModify.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdModify.Location = New System.Drawing.Point(328, 210)
        Me.cmdModify.Name = "cmdModify"
        Me.cmdModify.Size = New System.Drawing.Size(90, 23)
        Me.cmdModify.TabIndex = 16
        Me.cmdModify.Text = "Join Options"
        Me.cmdModify.UseVisualStyleBackColor = True
        '
        'ucrInputMergingBy
        '
        Me.ucrInputMergingBy.AddQuotesIfUnrecognised = True
        Me.ucrInputMergingBy.AutoSize = True
        Me.ucrInputMergingBy.IsMultiline = False
        Me.ucrInputMergingBy.IsReadOnly = False
        Me.ucrInputMergingBy.Location = New System.Drawing.Point(56, 212)
        Me.ucrInputMergingBy.Name = "ucrInputMergingBy"
        Me.ucrInputMergingBy.Size = New System.Drawing.Size(266, 32)
        Me.ucrInputMergingBy.TabIndex = 15
        '
        'ucrToDataFrame
        '
        Me.ucrToDataFrame.AutoSize = True
        Me.ucrToDataFrame.bDropUnusedFilterLevels = False
        Me.ucrToDataFrame.bUseCurrentFilter = True
        Me.ucrToDataFrame.Location = New System.Drawing.Point(248, 14)
        Me.ucrToDataFrame.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrToDataFrame.Name = "ucrToDataFrame"
        Me.ucrToDataFrame.Size = New System.Drawing.Size(151, 50)
        Me.ucrToDataFrame.TabIndex = 10
        '
        'lblVariablesToIncludeSecond
        '
        Me.lblVariablesToIncludeSecond.AutoSize = True
        Me.lblVariablesToIncludeSecond.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVariablesToIncludeSecond.Location = New System.Drawing.Point(248, 69)
        Me.lblVariablesToIncludeSecond.Name = "lblVariablesToIncludeSecond"
        Me.lblVariablesToIncludeSecond.Size = New System.Drawing.Size(103, 13)
        Me.lblVariablesToIncludeSecond.TabIndex = 12
        Me.lblVariablesToIncludeSecond.Text = "Variables to Include:"
        '
        'ucrReceiverSecond
        '
        Me.ucrReceiverSecond.AutoSize = True
        Me.ucrReceiverSecond.frmParent = Me
        Me.ucrReceiverSecond.Location = New System.Drawing.Point(248, 87)
        Me.ucrReceiverSecond.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverSecond.Name = "ucrReceiverSecond"
        Me.ucrReceiverSecond.Selector = Nothing
        Me.ucrReceiverSecond.Size = New System.Drawing.Size(120, 88)
        Me.ucrReceiverSecond.strNcFilePath = ""
        Me.ucrReceiverSecond.TabIndex = 13
        Me.ucrReceiverSecond.ucrSelector = Nothing
        '
        'ucrFromDataFrame
        '
        Me.ucrFromDataFrame.AutoSize = True
        Me.ucrFromDataFrame.bDropUnusedFilterLevels = False
        Me.ucrFromDataFrame.bShowHiddenColumns = False
        Me.ucrFromDataFrame.bUseCurrentFilter = True
        Me.ucrFromDataFrame.Location = New System.Drawing.Point(7, 14)
        Me.ucrFromDataFrame.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrFromDataFrame.Name = "ucrFromDataFrame"
        Me.ucrFromDataFrame.Size = New System.Drawing.Size(213, 183)
        Me.ucrFromDataFrame.TabIndex = 11
        '
        'ucrBase
        '
        Me.ucrBase.AutoSize = True
        Me.ucrBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrBase.Location = New System.Drawing.Point(7, 280)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(405, 52)
        Me.ucrBase.TabIndex = 17
        '
        'dlgMergeAdditionalData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(420, 335)
        Me.Controls.Add(Me.ucrInputSaveDataFrame)
        Me.Controls.Add(Me.ucrChkSaveDataFrame)
        Me.Controls.Add(Me.lblMergeBy)
        Me.Controls.Add(Me.cmdModify)
        Me.Controls.Add(Me.ucrInputMergingBy)
        Me.Controls.Add(Me.ucrToDataFrame)
        Me.Controls.Add(Me.lblVariablesToIncludeSecond)
        Me.Controls.Add(Me.ucrReceiverSecond)
        Me.Controls.Add(Me.ucrFromDataFrame)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgMergeAdditionalData"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Merge Additional Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrInputSaveDataFrame As ucrInputTextBox
    Friend WithEvents ucrChkSaveDataFrame As ucrCheck
    Friend WithEvents lblMergeBy As Label
    Friend WithEvents cmdModify As Button
    Friend WithEvents ucrInputMergingBy As ucrInputTextBox
    Friend WithEvents ucrToDataFrame As ucrDataFrame
    Friend WithEvents lblVariablesToIncludeSecond As Label
    Friend WithEvents ucrReceiverSecond As ucrReceiverMultiple
    Friend WithEvents ucrFromDataFrame As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrBase As ucrButtons
End Class
