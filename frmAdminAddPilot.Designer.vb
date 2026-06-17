<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminAddPilot
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPilotPassword = New System.Windows.Forms.TextBox()
        Me.txtPilotUserName = New System.Windows.Forms.TextBox()
        Me.cboPilotRoles = New System.Windows.Forms.ComboBox()
        Me.dtmLicense = New System.Windows.Forms.DateTimePicker()
        Me.dtmTermination = New System.Windows.Forms.DateTimePicker()
        Me.dtmHire = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 25)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Password"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(35, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 25)
        Me.Label8.TabIndex = 79
        Me.Label8.Text = "User Name"
        '
        'txtPilotPassword
        '
        Me.txtPilotPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPilotPassword.Location = New System.Drawing.Point(226, 108)
        Me.txtPilotPassword.Name = "txtPilotPassword"
        Me.txtPilotPassword.Size = New System.Drawing.Size(325, 26)
        Me.txtPilotPassword.TabIndex = 78
        '
        'txtPilotUserName
        '
        Me.txtPilotUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPilotUserName.Location = New System.Drawing.Point(226, 33)
        Me.txtPilotUserName.Name = "txtPilotUserName"
        Me.txtPilotUserName.Size = New System.Drawing.Size(325, 26)
        Me.txtPilotUserName.TabIndex = 77
        '
        'cboPilotRoles
        '
        Me.cboPilotRoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPilotRoles.FormattingEnabled = True
        Me.cboPilotRoles.Location = New System.Drawing.Point(234, 476)
        Me.cboPilotRoles.Name = "cboPilotRoles"
        Me.cboPilotRoles.Size = New System.Drawing.Size(288, 28)
        Me.cboPilotRoles.TabIndex = 76
        '
        'dtmLicense
        '
        Me.dtmLicense.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmLicense.Location = New System.Drawing.Point(234, 415)
        Me.dtmLicense.Name = "dtmLicense"
        Me.dtmLicense.Size = New System.Drawing.Size(288, 26)
        Me.dtmLicense.TabIndex = 75
        '
        'dtmTermination
        '
        Me.dtmTermination.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmTermination.Location = New System.Drawing.Point(234, 363)
        Me.dtmTermination.Name = "dtmTermination"
        Me.dtmTermination.Size = New System.Drawing.Size(288, 26)
        Me.dtmTermination.TabIndex = 74
        '
        'dtmHire
        '
        Me.dtmHire.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmHire.Location = New System.Drawing.Point(234, 308)
        Me.dtmHire.Name = "dtmHire"
        Me.dtmHire.Size = New System.Drawing.Size(288, 26)
        Me.dtmHire.TabIndex = 73
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(52, 364)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 25)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Termination Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(52, 475)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 25)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Pilot Role"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(52, 415)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 25)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "License Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(52, 308)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 25)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Hire Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(52, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 25)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Employee ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(52, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 25)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(52, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 25)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "First Name"
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeID.Location = New System.Drawing.Point(234, 259)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(288, 26)
        Me.txtEmployeeID.TabIndex = 65
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(234, 209)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(288, 26)
        Me.txtLastName.TabIndex = 64
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(234, 158)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(288, 26)
        Me.txtFirstName.TabIndex = 63
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(291, 549)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(190, 71)
        Me.btnExit.TabIndex = 62
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(33, 549)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(180, 71)
        Me.btnSubmit.TabIndex = 61
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'frmAdminAddPilot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 650)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPilotPassword)
        Me.Controls.Add(Me.txtPilotUserName)
        Me.Controls.Add(Me.cboPilotRoles)
        Me.Controls.Add(Me.dtmLicense)
        Me.Controls.Add(Me.dtmTermination)
        Me.Controls.Add(Me.dtmHire)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Name = "frmAdminAddPilot"
        Me.Text = "frmAdminAddPilot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPilotPassword As TextBox
    Friend WithEvents txtPilotUserName As TextBox
    Friend WithEvents cboPilotRoles As ComboBox
    Friend WithEvents dtmLicense As DateTimePicker
    Friend WithEvents dtmTermination As DateTimePicker
    Friend WithEvents dtmHire As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmployeeID As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSubmit As Button
End Class
