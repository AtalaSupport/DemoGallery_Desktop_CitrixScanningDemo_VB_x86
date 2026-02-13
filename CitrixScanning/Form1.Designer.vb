<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnScan = New System.Windows.Forms.Button
        Me.btnSelect = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(156, 28)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(101, 31)
        Me.btnScan.TabIndex = 3
        Me.btnScan.Text = "Scan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(31, 28)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(101, 31)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Select Device"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 86)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.btnSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Citrix Scanning with DotTwain"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnScan As System.Windows.Forms.Button
    Private WithEvents btnSelect As System.Windows.Forms.Button
End Class
