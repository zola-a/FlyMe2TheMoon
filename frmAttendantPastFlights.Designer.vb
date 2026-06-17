<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendantPastFlights
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblTotalMiles = New System.Windows.Forms.Label()
        Me.lstFlights = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(25, 343)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(213, 42)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblTotalMiles
        '
        Me.lblTotalMiles.AutoSize = True
        Me.lblTotalMiles.Location = New System.Drawing.Point(150, 324)
        Me.lblTotalMiles.Name = "lblTotalMiles"
        Me.lblTotalMiles.Size = New System.Drawing.Size(0, 16)
        Me.lblTotalMiles.TabIndex = 11
        '
        'lstFlights
        '
        Me.lstFlights.FormattingEnabled = True
        Me.lstFlights.ItemHeight = 16
        Me.lstFlights.Location = New System.Drawing.Point(25, 32)
        Me.lstFlights.Name = "lstFlights"
        Me.lstFlights.Size = New System.Drawing.Size(911, 260)
        Me.lstFlights.TabIndex = 10
        '
        'frmAttendantPastFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 450)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblTotalMiles)
        Me.Controls.Add(Me.lstFlights)
        Me.Name = "frmAttendantPastFlights"
        Me.Text = "frmAttendantPastFlights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents lblTotalMiles As Label
    Friend WithEvents lstFlights As ListBox
End Class
