﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgPolynomials
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
        Me.lblDegree = New System.Windows.Forms.Label()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.ucrSelectorForPolynomial = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrReceiverPolynomial = New instat.ucrReceiverSingle()
        Me.ucrBase = New instat.ucrButtons()
        Me.grpType = New System.Windows.Forms.GroupBox()
        Me.rdoOrthogonal = New System.Windows.Forms.RadioButton()
        Me.rdoSimple = New System.Windows.Forms.RadioButton()
        Me.ucrPnlType = New instat.UcrPanel()
        Me.ucrSavePoly = New instat.ucrSave()
        Me.ucrNudDegree = New instat.ucrNud()
        Me.rdoCenterd = New System.Windows.Forms.RadioButton()
        Me.grpType.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDegree
        '
        Me.lblDegree.AutoSize = True
        Me.lblDegree.Location = New System.Drawing.Point(258, 78)
        Me.lblDegree.Name = "lblDegree"
        Me.lblDegree.Size = New System.Drawing.Size(45, 13)
        Me.lblDegree.TabIndex = 3
        Me.lblDegree.Tag = "Degree"
        Me.lblDegree.Text = "Degree:"
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Location = New System.Drawing.Point(259, 34)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(93, 13)
        Me.lblSelected.TabIndex = 1
        Me.lblSelected.Tag = "Selected"
        Me.lblSelected.Text = "Selected Variable:"
        '
        'ucrSelectorForPolynomial
        '
        Me.ucrSelectorForPolynomial.bAddRemoveParameter = True
        Me.ucrSelectorForPolynomial.bChangeParameterValue = True
        Me.ucrSelectorForPolynomial.bShowHiddenColumns = False
        Me.ucrSelectorForPolynomial.bUseCurrentFilter = True
        Me.ucrSelectorForPolynomial.Location = New System.Drawing.Point(10, 10)
        Me.ucrSelectorForPolynomial.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorForPolynomial.Name = "ucrSelectorForPolynomial"
        Me.ucrSelectorForPolynomial.Size = New System.Drawing.Size(210, 180)
        Me.ucrSelectorForPolynomial.TabIndex = 0
        '
        'ucrReceiverPolynomial
        '
        Me.ucrReceiverPolynomial.bAddRemoveParameter = True
        Me.ucrReceiverPolynomial.bChangeParameterValue = True
        Me.ucrReceiverPolynomial.frmParent = Me
        Me.ucrReceiverPolynomial.Location = New System.Drawing.Point(258, 49)
        Me.ucrReceiverPolynomial.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverPolynomial.Name = "ucrReceiverPolynomial"
        Me.ucrReceiverPolynomial.Selector = Nothing
        Me.ucrReceiverPolynomial.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverPolynomial.TabIndex = 2
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(10, 256)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(410, 52)
        Me.ucrBase.TabIndex = 8
        '
        'grpType
        '
        Me.grpType.Controls.Add(Me.rdoCenterd)
        Me.grpType.Controls.Add(Me.rdoOrthogonal)
        Me.grpType.Controls.Add(Me.rdoSimple)
        Me.grpType.Controls.Add(Me.ucrPnlType)
        Me.grpType.Location = New System.Drawing.Point(255, 109)
        Me.grpType.Name = "grpType"
        Me.grpType.Size = New System.Drawing.Size(123, 106)
        Me.grpType.TabIndex = 14
        Me.grpType.TabStop = False
        Me.grpType.Text = "Type"
        '
        'rdoOrthogonal
        '
        Me.rdoOrthogonal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoOrthogonal.AutoSize = True
        Me.rdoOrthogonal.Location = New System.Drawing.Point(19, 73)
        Me.rdoOrthogonal.Name = "rdoOrthogonal"
        Me.rdoOrthogonal.Size = New System.Drawing.Size(77, 17)
        Me.rdoOrthogonal.TabIndex = 5
        Me.rdoOrthogonal.Tag = "Orthogonal"
        Me.rdoOrthogonal.Text = "Orthogonal"
        Me.rdoOrthogonal.UseVisualStyleBackColor = True
        '
        'rdoSimple
        '
        Me.rdoSimple.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoSimple.AutoSize = True
        Me.rdoSimple.Location = New System.Drawing.Point(19, 23)
        Me.rdoSimple.Name = "rdoSimple"
        Me.rdoSimple.Size = New System.Drawing.Size(56, 17)
        Me.rdoSimple.TabIndex = 3
        Me.rdoSimple.Tag = "Simple"
        Me.rdoSimple.Text = "Simple"
        Me.rdoSimple.UseVisualStyleBackColor = True
        '
        'ucrPnlType
        '
        Me.ucrPnlType.bAddRemoveParameter = True
        Me.ucrPnlType.bChangeParameterValue = True
        Me.ucrPnlType.Location = New System.Drawing.Point(3, 16)
        Me.ucrPnlType.Name = "ucrPnlType"
        Me.ucrPnlType.Size = New System.Drawing.Size(114, 84)
        Me.ucrPnlType.TabIndex = 0
        '
        'ucrSavePoly
        '
        Me.ucrSavePoly.bAddRemoveParameter = True
        Me.ucrSavePoly.bChangeParameterValue = True
        Me.ucrSavePoly.Location = New System.Drawing.Point(9, 223)
        Me.ucrSavePoly.Name = "ucrSavePoly"
        Me.ucrSavePoly.Size = New System.Drawing.Size(294, 24)
        Me.ucrSavePoly.TabIndex = 15
        '
        'ucrNudDegree
        '
        Me.ucrNudDegree.bAddRemoveParameter = True
        Me.ucrNudDegree.bChangeParameterValue = True
        Me.ucrNudDegree.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudDegree.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudDegree.Location = New System.Drawing.Point(308, 77)
        Me.ucrNudDegree.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudDegree.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudDegree.Name = "ucrNudDegree"
        Me.ucrNudDegree.Size = New System.Drawing.Size(50, 20)
        Me.ucrNudDegree.TabIndex = 16
        Me.ucrNudDegree.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'rdoCenterd
        '
        Me.rdoCenterd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoCenterd.AutoSize = True
        Me.rdoCenterd.Location = New System.Drawing.Point(19, 50)
        Me.rdoCenterd.Name = "rdoCenterd"
        Me.rdoCenterd.Size = New System.Drawing.Size(68, 17)
        Me.rdoCenterd.TabIndex = 6
        Me.rdoCenterd.Tag = "Centered"
        Me.rdoCenterd.Text = "Centered"
        Me.rdoCenterd.UseVisualStyleBackColor = True
        '
        'dlgPolynomials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 314)
        Me.Controls.Add(Me.ucrNudDegree)
        Me.Controls.Add(Me.ucrSavePoly)
        Me.Controls.Add(Me.grpType)
        Me.Controls.Add(Me.ucrSelectorForPolynomial)
        Me.Controls.Add(Me.ucrReceiverPolynomial)
        Me.Controls.Add(Me.lblSelected)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.lblDegree)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgPolynomials"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Polynomials"
        Me.Text = "Polynomials"
        Me.grpType.ResumeLayout(False)
        Me.grpType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDegree As Label
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents lblSelected As Label
    Friend WithEvents ucrReceiverPolynomial As ucrReceiverSingle
    Friend WithEvents ucrSelectorForPolynomial As ucrSelectorByDataFrameAddRemove
    Friend WithEvents grpType As GroupBox
    Friend WithEvents rdoOrthogonal As RadioButton
    Friend WithEvents rdoSimple As RadioButton
    Friend WithEvents ucrPnlType As UcrPanel
    Friend WithEvents ucrSavePoly As ucrSave
    Friend WithEvents ucrNudDegree As ucrNud
    Friend WithEvents rdoCenterd As RadioButton
End Class
