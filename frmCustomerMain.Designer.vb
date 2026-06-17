<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerMain
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
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.btnShowFuture = New System.Windows.Forms.Button()
        Me.btnShowPast = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnBookFlight = New System.Windows.Forms.Button()
        Me.btnUpdateProfile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWelcome.Location = New System.Drawing.Point(35, 18)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(67, 18)
        Me.lblWelcome.TabIndex = 11
        Me.lblWelcome.Text = "Welcome"
        '
        'btnShowFuture
        '
        Me.btnShowFuture.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowFuture.Location = New System.Drawing.Point(64, 276)
        Me.btnShowFuture.Name = "btnShowFuture"
        Me.btnShowFuture.Size = New System.Drawing.Size(207, 37)
        Me.btnShowFuture.TabIndex = 10
        Me.btnShowFuture.Text = "Show Future Flight"
        Me.btnShowFuture.UseVisualStyleBackColor = True
        '
        'btnShowPast
        '
        Me.btnShowPast.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowPast.Location = New System.Drawing.Point(64, 210)
        Me.btnShowPast.Name = "btnShowPast"
        Me.btnShowPast.Size = New System.Drawing.Size(207, 37)
        Me.btnShowPast.TabIndex = 9
        Me.btnShowPast.Text = "Show Past Flight "
        Me.btnShowPast.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(64, 342)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(207, 37)
        Me.btnLogout.TabIndex = 8
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnBookFlight
        '
        Me.btnBookFlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBookFlight.Location = New System.Drawing.Point(64, 141)
        Me.btnBookFlight.Name = "btnBookFlight"
        Me.btnBookFlight.Size = New System.Drawing.Size(207, 37)
        Me.btnBookFlight.TabIndex = 7
        Me.btnBookFlight.Text = "Book Flight "
        Me.btnBookFlight.UseVisualStyleBackColor = True
        '
        'btnUpdateProfile
        '
        Me.btnUpdateProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateProfile.Location = New System.Drawing.Point(64, 74)
        Me.btnUpdateProfile.Name = "btnUpdateProfile"
        Me.btnUpdateProfile.Size = New System.Drawing.Size(207, 37)
        Me.btnUpdateProfile.TabIndex = 6
        Me.btnUpdateProfile.Text = "Update Profile"
        Me.btnUpdateProfile.UseVisualStyleBackColor = True
        '
        'frmCustomerMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 395)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.btnShowFuture)
        Me.Controls.Add(Me.btnShowPast)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnBookFlight)
        Me.Controls.Add(Me.btnUpdateProfile)
        Me.Name = "frmCustomerMain"
        Me.Text = "frmCustomerMain"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnShowFuture As Button
    Friend WithEvents btnShowPast As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnBookFlight As Button
    Friend WithEvents btnUpdateProfile As Button
End Class
