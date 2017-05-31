<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sdgCanonicalCorrelation
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
        Me.tbRegOptions = New System.Windows.Forms.TabControl()
        Me.tbDisplay = New System.Windows.Forms.TabPage()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.ucrChkCoefficients = New instat.ucrCheck()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.ucrChkCanonicalCorrelations = New instat.ucrCheck()
        Me.tbGraphics = New System.Windows.Forms.TabPage()
        Me.rdoYVariables = New System.Windows.Forms.RadioButton()
        Me.rdoXVariables = New System.Windows.Forms.RadioButton()
        Me.chkPairwisePlot = New System.Windows.Forms.CheckBox()
        Me.ucrSdgButtons = New instat.ucrButtonsSubdialogue()
        Me.ucrPnlPairwisePlot = New instat.UcrPanel()
        Me.ucrChkPairwisePlot = New instat.ucrCheck()
        Me.tbRegOptions.SuspendLayout()
        Me.tbDisplay.SuspendLayout()
        Me.tbGraphics.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbRegOptions
        '
        Me.tbRegOptions.Controls.Add(Me.tbDisplay)
        Me.tbRegOptions.Controls.Add(Me.tbGraphics)
        Me.tbRegOptions.Location = New System.Drawing.Point(2, 3)
        Me.tbRegOptions.Name = "tbRegOptions"
        Me.tbRegOptions.SelectedIndex = 0
        Me.tbRegOptions.Size = New System.Drawing.Size(206, 193)
        Me.tbRegOptions.TabIndex = 0
        '
        'tbDisplay
        '
        Me.tbDisplay.Controls.Add(Me.ucrChkPairwisePlot)
        Me.tbDisplay.Controls.Add(Me.RadioButton1)
        Me.tbDisplay.Controls.Add(Me.ucrChkCoefficients)
        Me.tbDisplay.Controls.Add(Me.RadioButton2)
        Me.tbDisplay.Controls.Add(Me.ucrChkCanonicalCorrelations)
        Me.tbDisplay.Controls.Add(Me.ucrPnlPairwisePlot)
        Me.tbDisplay.Location = New System.Drawing.Point(4, 22)
        Me.tbDisplay.Name = "tbDisplay"
        Me.tbDisplay.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDisplay.Size = New System.Drawing.Size(198, 167)
        Me.tbDisplay.TabIndex = 0
        Me.tbDisplay.Tag = "Display"
        Me.tbDisplay.Text = "Display"
        Me.tbDisplay.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(23, 138)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(78, 17)
        Me.RadioButton1.TabIndex = 6
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Tag = "Y_Variables"
        Me.RadioButton1.Text = "Y Variables"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'ucrChkCoefficients
        '
        Me.ucrChkCoefficients.Checked = False
        Me.ucrChkCoefficients.Location = New System.Drawing.Point(15, 43)
        Me.ucrChkCoefficients.Name = "ucrChkCoefficients"
        Me.ucrChkCoefficients.Size = New System.Drawing.Size(100, 20)
        Me.ucrChkCoefficients.TabIndex = 0
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(23, 115)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(78, 17)
        Me.RadioButton2.TabIndex = 5
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Tag = "X_Variables"
        Me.RadioButton2.Text = "X Variables"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'ucrChkCanonicalCorrelations
        '
        Me.ucrChkCanonicalCorrelations.Checked = False
        Me.ucrChkCanonicalCorrelations.Location = New System.Drawing.Point(15, 17)
        Me.ucrChkCanonicalCorrelations.Name = "ucrChkCanonicalCorrelations"
        Me.ucrChkCanonicalCorrelations.Size = New System.Drawing.Size(100, 20)
        Me.ucrChkCanonicalCorrelations.TabIndex = 0
        '
        'tbGraphics
        '
        Me.tbGraphics.Controls.Add(Me.rdoYVariables)
        Me.tbGraphics.Controls.Add(Me.rdoXVariables)
        Me.tbGraphics.Controls.Add(Me.chkPairwisePlot)
        Me.tbGraphics.Location = New System.Drawing.Point(4, 22)
        Me.tbGraphics.Name = "tbGraphics"
        Me.tbGraphics.Padding = New System.Windows.Forms.Padding(3)
        Me.tbGraphics.Size = New System.Drawing.Size(198, 167)
        Me.tbGraphics.TabIndex = 1
        Me.tbGraphics.Tag = "Graphics"
        Me.tbGraphics.Text = "Graphics"
        Me.tbGraphics.UseVisualStyleBackColor = True
        '
        'rdoYVariables
        '
        Me.rdoYVariables.AutoSize = True
        Me.rdoYVariables.Location = New System.Drawing.Point(18, 61)
        Me.rdoYVariables.Name = "rdoYVariables"
        Me.rdoYVariables.Size = New System.Drawing.Size(78, 17)
        Me.rdoYVariables.TabIndex = 3
        Me.rdoYVariables.TabStop = True
        Me.rdoYVariables.Tag = "Y_Variables"
        Me.rdoYVariables.Text = "Y Variables"
        Me.rdoYVariables.UseVisualStyleBackColor = True
        '
        'rdoXVariables
        '
        Me.rdoXVariables.AutoSize = True
        Me.rdoXVariables.Location = New System.Drawing.Point(18, 38)
        Me.rdoXVariables.Name = "rdoXVariables"
        Me.rdoXVariables.Size = New System.Drawing.Size(78, 17)
        Me.rdoXVariables.TabIndex = 2
        Me.rdoXVariables.TabStop = True
        Me.rdoXVariables.Tag = "X_Variables"
        Me.rdoXVariables.Text = "X Variables"
        Me.rdoXVariables.UseVisualStyleBackColor = True
        '
        'chkPairwisePlot
        '
        Me.chkPairwisePlot.AutoSize = True
        Me.chkPairwisePlot.Location = New System.Drawing.Point(10, 15)
        Me.chkPairwisePlot.Name = "chkPairwisePlot"
        Me.chkPairwisePlot.Size = New System.Drawing.Size(86, 17)
        Me.chkPairwisePlot.TabIndex = 1
        Me.chkPairwisePlot.Tag = "Pairwise_Plot"
        Me.chkPairwisePlot.Text = "Pairwise Plot"
        Me.chkPairwisePlot.UseVisualStyleBackColor = True
        '
        'ucrSdgButtons
        '
        Me.ucrSdgButtons.Location = New System.Drawing.Point(41, 201)
        Me.ucrSdgButtons.Name = "ucrSdgButtons"
        Me.ucrSdgButtons.Size = New System.Drawing.Size(142, 30)
        Me.ucrSdgButtons.TabIndex = 0
        '
        'ucrPnlPairwisePlot
        '
        Me.ucrPnlPairwisePlot.Location = New System.Drawing.Point(15, 111)
        Me.ucrPnlPairwisePlot.Name = "ucrPnlPairwisePlot"
        Me.ucrPnlPairwisePlot.Size = New System.Drawing.Size(100, 50)
        Me.ucrPnlPairwisePlot.TabIndex = 8
        '
        'ucrChkPairwisePlot
        '
        Me.ucrChkPairwisePlot.Checked = False
        Me.ucrChkPairwisePlot.Location = New System.Drawing.Point(15, 89)
        Me.ucrChkPairwisePlot.Name = "ucrChkPairwisePlot"
        Me.ucrChkPairwisePlot.Size = New System.Drawing.Size(100, 20)
        Me.ucrChkPairwisePlot.TabIndex = 7
        '
        'sdgCanonicalCorrelation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(213, 233)
        Me.Controls.Add(Me.tbRegOptions)
        Me.Controls.Add(Me.ucrSdgButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "sdgCanonicalCorrelation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "PCA_Options"
        Me.Text = "PCA Options"
        Me.tbRegOptions.ResumeLayout(False)
        Me.tbDisplay.ResumeLayout(False)
        Me.tbDisplay.PerformLayout()
        Me.tbGraphics.ResumeLayout(False)
        Me.tbGraphics.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ucrSdgButtons As ucrButtonsSubdialogue
    Friend WithEvents tbRegOptions As TabControl
    Friend WithEvents tbDisplay As TabPage
    Friend WithEvents tbGraphics As TabPage
    Friend WithEvents chkPairwisePlot As CheckBox
    Friend WithEvents rdoYVariables As RadioButton
    Friend WithEvents rdoXVariables As RadioButton
    Friend WithEvents ucrChkCoefficients As ucrCheck
    Friend WithEvents ucrChkCanonicalCorrelations As ucrCheck
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents ucrPnlPairwisePlot As UcrPanel
    Friend WithEvents ucrChkPairwisePlot As ucrCheck
End Class