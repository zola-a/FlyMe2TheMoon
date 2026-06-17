<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendantMain
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
        Me.btnFutureFlights = New System.Windows.Forms.Button()
        Me.btnPastFlights = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnUpdateProfile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnFutureFlights
        '
        Me.btnFutureFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFutureFlights.Location = New System.Drawing.Point(113, 205)
        Me.btnFutureFlights.Name = "btnFutureFlights"
        Me.btnFutureFlights.Size = New System.Drawing.Size(189, 37)
        Me.btnFutureFlights.TabIndex = 17
        Me.btnFutureFlights.Text = "Show Future Flight"
        Me.btnFutureFlights.UseVisualStyleBackColor = True
        '
        'btnPastFlights
        '
        Me.btnPastFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPastFlights.Location = New System.Drawing.Point(113, 126)
        Me.btnPastFlights.Name = "btnPastFlights"
        Me.btnPastFlights.Size = New System.Drawing.Size(189, 37)
        Me.btnPastFlights.TabIndex = 16
        Me.btnPastFlights.Text = "Show Past Flight "
        Me.btnPastFlights.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(113, 282)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(189, 37)
        Me.btnLogout.TabIndex = 15
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnUpdateProfile
        '
        Me.btnUpdateProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateProfile.Location = New System.Drawing.Point(113, 51)
        Me.btnUpdateProfile.Name = "btnUpdateProfile"
        Me.btnUpdateProfile.Size = New System.Drawing.Size(189, 37)
        Me.btnUpdateProfile.TabIndex = 14
        Me.btnUpdateProfile.Text = "Update Profile"
        Me.btnUpdateProfile.UseVisualStyleBackColor = True
        '
        'frmAttendantMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 413)
        Me.Controls.Add(Me.btnFutureFlights)
        Me.Controls.Add(Me.btnPastFlights)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnUpdateProfile)
        Me.Name = "frmAttendantMain"
        Me.Text = "frmAttendantMain"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnFutureFlights As Button
    Friend WithEvents btnPastFlights As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnUpdateProfile As Button
End Class
