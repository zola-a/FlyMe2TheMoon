<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistics
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
        Me.lstAttendantMiles = New System.Windows.Forms.ListBox()
        Me.lstPilotMiles = New System.Windows.Forms.ListBox()
        Me.lblAverageMiles = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalFlights = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalCustomers = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(39, 379)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(180, 73)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lstAttendantMiles
        '
        Me.lstAttendantMiles.FormattingEnabled = True
        Me.lstAttendantMiles.ItemHeight = 16
        Me.lstAttendantMiles.Location = New System.Drawing.Point(504, 300)
        Me.lstAttendantMiles.Name = "lstAttendantMiles"
        Me.lstAttendantMiles.Size = New System.Drawing.Size(439, 180)
        Me.lstAttendantMiles.TabIndex = 16
        '
        'lstPilotMiles
        '
        Me.lstPilotMiles.FormattingEnabled = True
        Me.lstPilotMiles.ItemHeight = 16
        Me.lstPilotMiles.Location = New System.Drawing.Point(504, 61)
        Me.lstPilotMiles.Name = "lstPilotMiles"
        Me.lstPilotMiles.Size = New System.Drawing.Size(439, 164)
        Me.lstPilotMiles.TabIndex = 15
        '
        'lblAverageMiles
        '
        Me.lblAverageMiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAverageMiles.Location = New System.Drawing.Point(224, 200)
        Me.lblAverageMiles.Name = "lblAverageMiles"
        Me.lblAverageMiles.Size = New System.Drawing.Size(217, 25)
        Me.lblAverageMiles.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 25)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Avg Miles"
        '
        'lblTotalFlights
        '
        Me.lblTotalFlights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalFlights.Location = New System.Drawing.Point(224, 138)
        Me.lblTotalFlights.Name = "lblTotalFlights"
        Me.lblTotalFlights.Size = New System.Drawing.Size(224, 23)
        Me.lblTotalFlights.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Total Flights"
        '
        'lblTotalCustomers
        '
        Me.lblTotalCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCustomers.Location = New System.Drawing.Point(224, 79)
        Me.lblTotalCustomers.Name = "lblTotalCustomers"
        Me.lblTotalCustomers.Size = New System.Drawing.Size(217, 23)
        Me.lblTotalCustomers.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Total Customers"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(499, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 25)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Pilot Miles"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(499, 272)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 25)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Attendant Miles"
        '
        'frmStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 548)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstAttendantMiles)
        Me.Controls.Add(Me.lstPilotMiles)
        Me.Controls.Add(Me.lblAverageMiles)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTotalFlights)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTotalCustomers)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmStatistics"
        Me.Text = "frmStatistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents lstAttendantMiles As ListBox
    Friend WithEvents lstPilotMiles As ListBox
    Friend WithEvents lblAverageMiles As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalFlights As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotalCustomers As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
