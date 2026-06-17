<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerPastFlights
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
        Me.lstFlights = New System.Windows.Forms.ListBox()
        Me.lblTotalMiles = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(21, 333)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(183, 34)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lstFlights
        '
        Me.lstFlights.FormattingEnabled = True
        Me.lstFlights.ItemHeight = 16
        Me.lstFlights.Location = New System.Drawing.Point(21, 12)
        Me.lstFlights.Name = "lstFlights"
        Me.lstFlights.Size = New System.Drawing.Size(969, 260)
        Me.lstFlights.TabIndex = 10
        '
        'lblTotalMiles
        '
        Me.lblTotalMiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalMiles.Location = New System.Drawing.Point(455, 291)
        Me.lblTotalMiles.Name = "lblTotalMiles"
        Me.lblTotalMiles.Size = New System.Drawing.Size(174, 32)
        Me.lblTotalMiles.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(322, 298)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 25)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Total Miles"
        '
        'frmCustomerPastFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTotalMiles)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstFlights)
        Me.Name = "frmCustomerPastFlights"
        Me.Text = "frmCustomerPastFlights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents lstFlights As ListBox
    Friend WithEvents lblTotalMiles As Label
    Friend WithEvents Label1 As Label
End Class
