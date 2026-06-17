<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminAssignPilotFlight
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFlights = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPilots = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(52, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Flights"
        '
        'cboFlights
        '
        Me.cboFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFlights.FormattingEnabled = True
        Me.cboFlights.Location = New System.Drawing.Point(164, 102)
        Me.cboFlights.Name = "cboFlights"
        Me.cboFlights.Size = New System.Drawing.Size(231, 28)
        Me.cboFlights.TabIndex = 36
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(225, 165)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(155, 59)
        Me.btnExit.TabIndex = 35
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(38, 165)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(145, 59)
        Me.btnSubmit.TabIndex = 34
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Pilot"
        '
        'cboPilots
        '
        Me.cboPilots.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPilots.FormattingEnabled = True
        Me.cboPilots.Location = New System.Drawing.Point(164, 52)
        Me.cboPilots.Name = "cboPilots"
        Me.cboPilots.Size = New System.Drawing.Size(231, 28)
        Me.cboPilots.TabIndex = 32
        '
        'frmAdminAssignPilotFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 299)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFlights)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPilots)
        Me.Name = "frmAdminAssignPilotFlight"
        Me.Text = "frmAdminAssignPilotFlight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents cboFlights As ComboBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPilots As ComboBox
End Class
