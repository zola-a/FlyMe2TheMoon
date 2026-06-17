<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotMainMenu
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
        Me.btnShowFutureFlights = New System.Windows.Forms.Button()
        Me.btnShowPastFlights = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnUpdateProfile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnShowFutureFlights
        '
        Me.btnShowFutureFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowFutureFlights.Location = New System.Drawing.Point(90, 169)
        Me.btnShowFutureFlights.Name = "btnShowFutureFlights"
        Me.btnShowFutureFlights.Size = New System.Drawing.Size(220, 37)
        Me.btnShowFutureFlights.TabIndex = 13
        Me.btnShowFutureFlights.Text = "Show Future Flight"
        Me.btnShowFutureFlights.UseVisualStyleBackColor = True
        '
        'btnShowPastFlights
        '
        Me.btnShowPastFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowPastFlights.Location = New System.Drawing.Point(90, 103)
        Me.btnShowPastFlights.Name = "btnShowPastFlights"
        Me.btnShowPastFlights.Size = New System.Drawing.Size(220, 37)
        Me.btnShowPastFlights.TabIndex = 12
        Me.btnShowPastFlights.Text = "Show Past Flight "
        Me.btnShowPastFlights.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(90, 232)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(220, 37)
        Me.btnLogout.TabIndex = 11
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnUpdateProfile
        '
        Me.btnUpdateProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateProfile.Location = New System.Drawing.Point(90, 46)
        Me.btnUpdateProfile.Name = "btnUpdateProfile"
        Me.btnUpdateProfile.Size = New System.Drawing.Size(220, 37)
        Me.btnUpdateProfile.TabIndex = 10
        Me.btnUpdateProfile.Text = "Update Profile"
        Me.btnUpdateProfile.UseVisualStyleBackColor = True
        '
        'frmPilotMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 339)
        Me.Controls.Add(Me.btnShowFutureFlights)
        Me.Controls.Add(Me.btnShowPastFlights)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnUpdateProfile)
        Me.Name = "frmPilotMainMenu"
        Me.Text = "frmPilotMainMenu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnShowFutureFlights As Button
    Friend WithEvents btnShowPastFlights As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnUpdateProfile As Button
End Class
