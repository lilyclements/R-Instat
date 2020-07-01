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
Partial Class dlgOneVarFitModel
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
        Me.LblVariable = New System.Windows.Forms.Label()
        Me.lblSuccessIf = New System.Windows.Forms.Label()
        Me.lblEquals = New System.Windows.Forms.Label()
        Me.rdoTest = New System.Windows.Forms.RadioButton()
        Me.rdoGeneralCase = New System.Windows.Forms.RadioButton()
        Me.grpConditions = New System.Windows.Forms.GroupBox()
        Me.grpVarAndWilcoxSign = New System.Windows.Forms.GroupBox()
        Me.rdoWilcoxSignTest = New System.Windows.Forms.RadioButton()
        Me.rdoVarSignTest = New System.Windows.Forms.RadioButton()
        Me.ucrPnlWilcoxVarTest = New instat.UcrPanel()
        Me.grpVarAndWilcox = New System.Windows.Forms.GroupBox()
        Me.rdoEnorm = New System.Windows.Forms.RadioButton()
        Me.rdoMeanWilcox = New System.Windows.Forms.RadioButton()
        Me.rdoVarSign = New System.Windows.Forms.RadioButton()
        Me.ucrPnlStats = New instat.UcrPanel()
        Me.ucrChkBinModify = New instat.ucrCheck()
        Me.ucrNudBinomialConditions = New instat.ucrNud()
        Me.ucrOperator = New instat.ucrInputComboBox()
        Me.ucrVariables = New instat.ucrInputComboBox()
        Me.lblHyp = New System.Windows.Forms.Label()
        Me.ucrNudHyp = New instat.ucrNud()
        Me.lblConfidenceLimit = New System.Windows.Forms.Label()
        Me.ucrNudCI = New instat.ucrNud()
        Me.cmdDisplayOptions = New System.Windows.Forms.Button()
        Me.cmdFittingOptions = New System.Windows.Forms.Button()
        Me.rdoEstimate = New System.Windows.Forms.RadioButton()
        Me.ucrInputTests = New instat.ucrInputComboBox()
        Me.ucrChkConvertVariate = New instat.ucrCheck()
        Me.ucrPnlGeneralExactCase = New instat.UcrPanel()
        Me.ucrSaveModel = New instat.ucrSave()
        Me.ucrDistributionChoice = New instat.ucrDistributions()
        Me.ucrReceiverVariable = New instat.ucrReceiverSingle()
        Me.ucrSelectorOneVarFitMod = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrBase = New instat.ucrButtons()
        Me.grpConditions.SuspendLayout()
        Me.grpVarAndWilcoxSign.SuspendLayout()
        Me.grpVarAndWilcox.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblVariable
        '
        Me.LblVariable.AutoSize = True
        Me.LblVariable.Location = New System.Drawing.Point(332, 58)
        Me.LblVariable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblVariable.Name = "LblVariable"
        Me.LblVariable.Size = New System.Drawing.Size(64, 17)
        Me.LblVariable.TabIndex = 8
        Me.LblVariable.Text = "Variable:"
        '
        'lblSuccessIf
        '
        Me.lblSuccessIf.AutoSize = True
        Me.lblSuccessIf.Location = New System.Drawing.Point(4, 135)
        Me.lblSuccessIf.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSuccessIf.Name = "lblSuccessIf"
        Me.lblSuccessIf.Size = New System.Drawing.Size(85, 17)
        Me.lblSuccessIf.TabIndex = 19
        Me.lblSuccessIf.Text = "Success if X"
        '
        'lblEquals
        '
        Me.lblEquals.AutoSize = True
        Me.lblEquals.Location = New System.Drawing.Point(95, 133)
        Me.lblEquals.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEquals.Name = "lblEquals"
        Me.lblEquals.Size = New System.Drawing.Size(16, 17)
        Me.lblEquals.TabIndex = 33
        Me.lblEquals.Text = "="
        '
        'rdoTest
        '
        Me.rdoTest.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoTest.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoTest.FlatAppearance.BorderSize = 2
        Me.rdoTest.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoTest.Location = New System.Drawing.Point(203, 14)
        Me.rdoTest.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoTest.Name = "rdoTest"
        Me.rdoTest.Size = New System.Drawing.Size(168, 34)
        Me.rdoTest.TabIndex = 41
        Me.rdoTest.Text = "Test"
        Me.rdoTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoTest.UseVisualStyleBackColor = True
        '
        'rdoGeneralCase
        '
        Me.rdoGeneralCase.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoGeneralCase.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoGeneralCase.FlatAppearance.BorderSize = 2
        Me.rdoGeneralCase.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoGeneralCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoGeneralCase.Location = New System.Drawing.Point(45, 14)
        Me.rdoGeneralCase.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoGeneralCase.Name = "rdoGeneralCase"
        Me.rdoGeneralCase.Size = New System.Drawing.Size(163, 34)
        Me.rdoGeneralCase.TabIndex = 40
        Me.rdoGeneralCase.Text = "General Case"
        Me.rdoGeneralCase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoGeneralCase.UseVisualStyleBackColor = True
        '
        'grpConditions
        '
        Me.grpConditions.Controls.Add(Me.grpVarAndWilcoxSign)
        Me.grpConditions.Controls.Add(Me.grpVarAndWilcox)
        Me.grpConditions.Controls.Add(Me.ucrChkBinModify)
        Me.grpConditions.Controls.Add(Me.lblEquals)
        Me.grpConditions.Controls.Add(Me.ucrNudBinomialConditions)
        Me.grpConditions.Controls.Add(Me.ucrOperator)
        Me.grpConditions.Controls.Add(Me.ucrVariables)
        Me.grpConditions.Controls.Add(Me.lblSuccessIf)
        Me.grpConditions.Controls.Add(Me.lblHyp)
        Me.grpConditions.Controls.Add(Me.ucrNudHyp)
        Me.grpConditions.Controls.Add(Me.lblConfidenceLimit)
        Me.grpConditions.Controls.Add(Me.ucrNudCI)
        Me.grpConditions.Location = New System.Drawing.Point(332, 151)
        Me.grpConditions.Margin = New System.Windows.Forms.Padding(4)
        Me.grpConditions.Name = "grpConditions"
        Me.grpConditions.Padding = New System.Windows.Forms.Padding(4)
        Me.grpConditions.Size = New System.Drawing.Size(261, 162)
        Me.grpConditions.TabIndex = 34
        Me.grpConditions.TabStop = False
        Me.grpConditions.Text = "Conditions"
        '
        'grpVarAndWilcoxSign
        '
        Me.grpVarAndWilcoxSign.Controls.Add(Me.rdoWilcoxSignTest)
        Me.grpVarAndWilcoxSign.Controls.Add(Me.rdoVarSignTest)
        Me.grpVarAndWilcoxSign.Controls.Add(Me.ucrPnlWilcoxVarTest)
        Me.grpVarAndWilcoxSign.Location = New System.Drawing.Point(7, 79)
        Me.grpVarAndWilcoxSign.Margin = New System.Windows.Forms.Padding(4)
        Me.grpVarAndWilcoxSign.Name = "grpVarAndWilcoxSign"
        Me.grpVarAndWilcoxSign.Padding = New System.Windows.Forms.Padding(4)
        Me.grpVarAndWilcoxSign.Size = New System.Drawing.Size(169, 87)
        Me.grpVarAndWilcoxSign.TabIndex = 62
        Me.grpVarAndWilcoxSign.TabStop = False
        '
        'rdoWilcoxSignTest
        '
        Me.rdoWilcoxSignTest.AutoSize = True
        Me.rdoWilcoxSignTest.Location = New System.Drawing.Point(11, 16)
        Me.rdoWilcoxSignTest.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoWilcoxSignTest.Name = "rdoWilcoxSignTest"
        Me.rdoWilcoxSignTest.Size = New System.Drawing.Size(125, 21)
        Me.rdoWilcoxSignTest.TabIndex = 65
        Me.rdoWilcoxSignTest.TabStop = True
        Me.rdoWilcoxSignTest.Text = "Compare Mean"
        Me.rdoWilcoxSignTest.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.rdoWilcoxSignTest.UseVisualStyleBackColor = True
        '
        'rdoVarSignTest
        '
        Me.rdoVarSignTest.AutoSize = True
        Me.rdoVarSignTest.Location = New System.Drawing.Point(11, 44)
        Me.rdoVarSignTest.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoVarSignTest.Name = "rdoVarSignTest"
        Me.rdoVarSignTest.Size = New System.Drawing.Size(141, 21)
        Me.rdoVarSignTest.TabIndex = 64
        Me.rdoVarSignTest.TabStop = True
        Me.rdoVarSignTest.Text = "Compare Vaiance"
        Me.rdoVarSignTest.UseVisualStyleBackColor = True
        '
        'ucrPnlWilcoxVarTest
        '
        Me.ucrPnlWilcoxVarTest.Location = New System.Drawing.Point(8, 14)
        Me.ucrPnlWilcoxVarTest.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrPnlWilcoxVarTest.Name = "ucrPnlWilcoxVarTest"
        Me.ucrPnlWilcoxVarTest.Size = New System.Drawing.Size(156, 59)
        Me.ucrPnlWilcoxVarTest.TabIndex = 63
        '
        'grpVarAndWilcox
        '
        Me.grpVarAndWilcox.Controls.Add(Me.rdoEnorm)
        Me.grpVarAndWilcox.Controls.Add(Me.rdoMeanWilcox)
        Me.grpVarAndWilcox.Controls.Add(Me.rdoVarSign)
        Me.grpVarAndWilcox.Controls.Add(Me.ucrPnlStats)
        Me.grpVarAndWilcox.Location = New System.Drawing.Point(9, 74)
        Me.grpVarAndWilcox.Margin = New System.Windows.Forms.Padding(4)
        Me.grpVarAndWilcox.Name = "grpVarAndWilcox"
        Me.grpVarAndWilcox.Padding = New System.Windows.Forms.Padding(4)
        Me.grpVarAndWilcox.Size = New System.Drawing.Size(173, 92)
        Me.grpVarAndWilcox.TabIndex = 55
        Me.grpVarAndWilcox.TabStop = False
        '
        'rdoEnorm
        '
        Me.rdoEnorm.AutoSize = True
        Me.rdoEnorm.Location = New System.Drawing.Point(13, 62)
        Me.rdoEnorm.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoEnorm.Name = "rdoEnorm"
        Me.rdoEnorm.Size = New System.Drawing.Size(69, 21)
        Me.rdoEnorm.TabIndex = 65
        Me.rdoEnorm.TabStop = True
        Me.rdoEnorm.Text = "enorm"
        Me.rdoEnorm.UseVisualStyleBackColor = True
        '
        'rdoMeanWilcox
        '
        Me.rdoMeanWilcox.AutoSize = True
        Me.rdoMeanWilcox.Location = New System.Drawing.Point(13, 15)
        Me.rdoMeanWilcox.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoMeanWilcox.Name = "rdoMeanWilcox"
        Me.rdoMeanWilcox.Size = New System.Drawing.Size(125, 21)
        Me.rdoMeanWilcox.TabIndex = 66
        Me.rdoMeanWilcox.TabStop = True
        Me.rdoMeanWilcox.Text = "Compare Mean"
        Me.rdoMeanWilcox.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.rdoMeanWilcox.UseVisualStyleBackColor = True
        '
        'rdoVarSign
        '
        Me.rdoVarSign.AutoSize = True
        Me.rdoVarSign.Location = New System.Drawing.Point(13, 38)
        Me.rdoVarSign.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoVarSign.Name = "rdoVarSign"
        Me.rdoVarSign.Size = New System.Drawing.Size(146, 21)
        Me.rdoVarSign.TabIndex = 64
        Me.rdoVarSign.TabStop = True
        Me.rdoVarSign.Text = "Compare Variance"
        Me.rdoVarSign.UseVisualStyleBackColor = True
        '
        'ucrPnlStats
        '
        Me.ucrPnlStats.Location = New System.Drawing.Point(8, 12)
        Me.ucrPnlStats.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrPnlStats.Name = "ucrPnlStats"
        Me.ucrPnlStats.Size = New System.Drawing.Size(157, 78)
        Me.ucrPnlStats.TabIndex = 63
        '
        'ucrChkBinModify
        '
        Me.ucrChkBinModify.Checked = False
        Me.ucrChkBinModify.Location = New System.Drawing.Point(12, 94)
        Me.ucrChkBinModify.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrChkBinModify.Name = "ucrChkBinModify"
        Me.ucrChkBinModify.Size = New System.Drawing.Size(232, 25)
        Me.ucrChkBinModify.TabIndex = 54
        '
        'ucrNudBinomialConditions
        '
        Me.ucrNudBinomialConditions.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudBinomialConditions.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudBinomialConditions.Location = New System.Drawing.Point(180, 128)
        Me.ucrNudBinomialConditions.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrNudBinomialConditions.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudBinomialConditions.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudBinomialConditions.Name = "ucrNudBinomialConditions"
        Me.ucrNudBinomialConditions.Size = New System.Drawing.Size(67, 25)
        Me.ucrNudBinomialConditions.TabIndex = 50
        Me.ucrNudBinomialConditions.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrOperator
        '
        Me.ucrOperator.AddQuotesIfUnrecognised = True
        Me.ucrOperator.IsReadOnly = False
        Me.ucrOperator.Location = New System.Drawing.Point(116, 128)
        Me.ucrOperator.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.ucrOperator.Name = "ucrOperator"
        Me.ucrOperator.Size = New System.Drawing.Size(59, 26)
        Me.ucrOperator.TabIndex = 24
        '
        'ucrVariables
        '
        Me.ucrVariables.AddQuotesIfUnrecognised = True
        Me.ucrVariables.IsReadOnly = False
        Me.ucrVariables.Location = New System.Drawing.Point(120, 133)
        Me.ucrVariables.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.ucrVariables.Name = "ucrVariables"
        Me.ucrVariables.Size = New System.Drawing.Size(117, 26)
        Me.ucrVariables.TabIndex = 32
        '
        'lblHyp
        '
        Me.lblHyp.AutoSize = True
        Me.lblHyp.Location = New System.Drawing.Point(8, 49)
        Me.lblHyp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHyp.Name = "lblHyp"
        Me.lblHyp.Size = New System.Drawing.Size(110, 17)
        Me.lblHyp.TabIndex = 46
        Me.lblHyp.Text = "Null Hypothesis:"
        '
        'ucrNudHyp
        '
        Me.ucrNudHyp.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudHyp.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudHyp.Location = New System.Drawing.Point(135, 47)
        Me.ucrNudHyp.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrNudHyp.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudHyp.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudHyp.Name = "ucrNudHyp"
        Me.ucrNudHyp.Size = New System.Drawing.Size(67, 25)
        Me.ucrNudHyp.TabIndex = 49
        Me.ucrNudHyp.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'lblConfidenceLimit
        '
        Me.lblConfidenceLimit.AutoSize = True
        Me.lblConfidenceLimit.Location = New System.Drawing.Point(8, 16)
        Me.lblConfidenceLimit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblConfidenceLimit.Name = "lblConfidenceLimit"
        Me.lblConfidenceLimit.Size = New System.Drawing.Size(116, 17)
        Me.lblConfidenceLimit.TabIndex = 47
        Me.lblConfidenceLimit.Text = "Confidence Limit:"
        '
        'ucrNudCI
        '
        Me.ucrNudCI.DecimalPlaces = New Decimal(New Integer() {2, 0, 0, 0})
        Me.ucrNudCI.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudCI.Location = New System.Drawing.Point(133, 12)
        Me.ucrNudCI.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrNudCI.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudCI.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudCI.Name = "ucrNudCI"
        Me.ucrNudCI.Size = New System.Drawing.Size(67, 25)
        Me.ucrNudCI.TabIndex = 48
        Me.ucrNudCI.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'cmdDisplayOptions
        '
        Me.cmdDisplayOptions.Location = New System.Drawing.Point(392, 352)
        Me.cmdDisplayOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDisplayOptions.Name = "cmdDisplayOptions"
        Me.cmdDisplayOptions.Size = New System.Drawing.Size(123, 28)
        Me.cmdDisplayOptions.TabIndex = 44
        Me.cmdDisplayOptions.Text = "Display Options"
        Me.cmdDisplayOptions.UseVisualStyleBackColor = True
        '
        'cmdFittingOptions
        '
        Me.cmdFittingOptions.Location = New System.Drawing.Point(392, 322)
        Me.cmdFittingOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdFittingOptions.Name = "cmdFittingOptions"
        Me.cmdFittingOptions.Size = New System.Drawing.Size(123, 28)
        Me.cmdFittingOptions.TabIndex = 43
        Me.cmdFittingOptions.Text = "Fitting Options"
        Me.cmdFittingOptions.UseVisualStyleBackColor = True
        '
        'rdoEstimate
        '
        Me.rdoEstimate.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoEstimate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoEstimate.FlatAppearance.BorderSize = 2
        Me.rdoEstimate.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoEstimate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoEstimate.Location = New System.Drawing.Point(369, 14)
        Me.rdoEstimate.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoEstimate.Name = "rdoEstimate"
        Me.rdoEstimate.Size = New System.Drawing.Size(168, 34)
        Me.rdoEstimate.TabIndex = 45
        Me.rdoEstimate.Text = "Estimate"
        Me.rdoEstimate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoEstimate.UseVisualStyleBackColor = True
        '
        'ucrInputTests
        '
        Me.ucrInputTests.AddQuotesIfUnrecognised = True
        Me.ucrInputTests.IsReadOnly = False
        Me.ucrInputTests.Location = New System.Drawing.Point(101, 308)
        Me.ucrInputTests.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrInputTests.Name = "ucrInputTests"
        Me.ucrInputTests.Size = New System.Drawing.Size(192, 26)
        Me.ucrInputTests.TabIndex = 46
        '
        'ucrChkConvertVariate
        '
        Me.ucrChkConvertVariate.Checked = False
        Me.ucrChkConvertVariate.Location = New System.Drawing.Point(332, 116)
        Me.ucrChkConvertVariate.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrChkConvertVariate.Name = "ucrChkConvertVariate"
        Me.ucrChkConvertVariate.Size = New System.Drawing.Size(208, 25)
        Me.ucrChkConvertVariate.TabIndex = 42
        '
        'ucrPnlGeneralExactCase
        '
        Me.ucrPnlGeneralExactCase.Location = New System.Drawing.Point(45, 9)
        Me.ucrPnlGeneralExactCase.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrPnlGeneralExactCase.Name = "ucrPnlGeneralExactCase"
        Me.ucrPnlGeneralExactCase.Size = New System.Drawing.Size(495, 43)
        Me.ucrPnlGeneralExactCase.TabIndex = 39
        '
        'ucrSaveModel
        '
        Me.ucrSaveModel.Location = New System.Drawing.Point(13, 352)
        Me.ucrSaveModel.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ucrSaveModel.Name = "ucrSaveModel"
        Me.ucrSaveModel.Size = New System.Drawing.Size(369, 30)
        Me.ucrSaveModel.TabIndex = 38
        '
        'ucrDistributionChoice
        '
        Me.ucrDistributionChoice.Location = New System.Drawing.Point(13, 306)
        Me.ucrDistributionChoice.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrDistributionChoice.Name = "ucrDistributionChoice"
        Me.ucrDistributionChoice.Size = New System.Drawing.Size(292, 37)
        Me.ucrDistributionChoice.TabIndex = 11
        '
        'ucrReceiverVariable
        '
        Me.ucrReceiverVariable.frmParent = Me
        Me.ucrReceiverVariable.Location = New System.Drawing.Point(332, 79)
        Me.ucrReceiverVariable.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverVariable.Name = "ucrReceiverVariable"
        Me.ucrReceiverVariable.Selector = Nothing
        Me.ucrReceiverVariable.Size = New System.Drawing.Size(183, 25)
        Me.ucrReceiverVariable.strNcFilePath = ""
        Me.ucrReceiverVariable.TabIndex = 2
        Me.ucrReceiverVariable.ucrSelector = Nothing
        '
        'ucrSelectorOneVarFitMod
        '
        Me.ucrSelectorOneVarFitMod.bDropUnusedFilterLevels = False
        Me.ucrSelectorOneVarFitMod.bShowHiddenColumns = False
        Me.ucrSelectorOneVarFitMod.bUseCurrentFilter = True
        Me.ucrSelectorOneVarFitMod.Location = New System.Drawing.Point(13, 57)
        Me.ucrSelectorOneVarFitMod.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorOneVarFitMod.Name = "ucrSelectorOneVarFitMod"
        Me.ucrSelectorOneVarFitMod.Size = New System.Drawing.Size(280, 222)
        Me.ucrSelectorOneVarFitMod.TabIndex = 1
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(13, 389)
        Me.ucrBase.Margin = New System.Windows.Forms.Padding(5)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(547, 64)
        Me.ucrBase.TabIndex = 0
        '
        'dlgOneVarFitModel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 460)
        Me.Controls.Add(Me.ucrInputTests)
        Me.Controls.Add(Me.rdoEstimate)
        Me.Controls.Add(Me.cmdDisplayOptions)
        Me.Controls.Add(Me.ucrChkConvertVariate)
        Me.Controls.Add(Me.rdoTest)
        Me.Controls.Add(Me.cmdFittingOptions)
        Me.Controls.Add(Me.rdoGeneralCase)
        Me.Controls.Add(Me.ucrPnlGeneralExactCase)
        Me.Controls.Add(Me.ucrSaveModel)
        Me.Controls.Add(Me.grpConditions)
        Me.Controls.Add(Me.ucrDistributionChoice)
        Me.Controls.Add(Me.LblVariable)
        Me.Controls.Add(Me.ucrReceiverVariable)
        Me.Controls.Add(Me.ucrSelectorOneVarFitMod)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgOneVarFitModel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "One Variable Fit Model"
        Me.grpConditions.ResumeLayout(False)
        Me.grpConditions.PerformLayout()
        Me.grpVarAndWilcoxSign.ResumeLayout(False)
        Me.grpVarAndWilcoxSign.PerformLayout()
        Me.grpVarAndWilcox.ResumeLayout(False)
        Me.grpVarAndWilcox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrSelectorOneVarFitMod As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrReceiverVariable As ucrReceiverSingle
    Friend WithEvents LblVariable As Label
    Friend WithEvents ucrDistributionChoice As ucrDistributions
    Friend WithEvents lblSuccessIf As Label
    Friend WithEvents ucrOperator As ucrInputComboBox
    Friend WithEvents ucrVariables As ucrInputComboBox
    Friend WithEvents lblEquals As Label
    Friend WithEvents ucrSaveModel As ucrSave
    Friend WithEvents rdoTest As RadioButton
    Friend WithEvents rdoGeneralCase As RadioButton
    Friend WithEvents ucrPnlGeneralExactCase As UcrPanel
    Friend WithEvents ucrChkConvertVariate As ucrCheck
    Friend WithEvents ucrNudBinomialConditions As ucrNud
    Friend WithEvents ucrNudHyp As ucrNud
    Friend WithEvents ucrNudCI As ucrNud
    Friend WithEvents grpConditions As GroupBox
    Friend WithEvents ucrChkBinModify As ucrCheck
    Friend WithEvents lblConfidenceLimit As Label
    Friend WithEvents lblHyp As Label
    Friend WithEvents grpVarAndWilcox As GroupBox
    Friend WithEvents rdoMeanWilcox As RadioButton
    Friend WithEvents rdoVarSign As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents rdoEnorm As RadioButton
    Friend WithEvents ucrPnlStats As UcrPanel
    Friend WithEvents grpVarAndWilcoxSign As GroupBox
    Friend WithEvents rdoWilcoxSignTest As RadioButton
    Friend WithEvents rdoVarSignTest As RadioButton
    Friend WithEvents ucrPnlWilcoxVarTest As UcrPanel
    Friend WithEvents cmdDisplayOptions As Button
    Friend WithEvents cmdFittingOptions As Button
    Friend WithEvents rdoEstimate As RadioButton
    Friend WithEvents ucrInputTests As ucrInputComboBox
End Class