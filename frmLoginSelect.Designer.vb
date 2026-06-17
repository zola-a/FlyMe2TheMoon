<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginSelect
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
        Me.btnEmployeeLogin = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnPassengerLogin = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnEmployeeLogin
        '
        Me.btnEmployeeLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmployeeLogin.Location = New System.Drawing.Point(105, 158)
        Me.btnEmployeeLogin.Name = "btnEmployeeLogin"
        Me.btnEmployeeLogin.Size = New System.Drawing.Size(234, 87)
        Me.btnEmployeeLogin.TabIndex = 5
        Me.btnEmployeeLogin.Text = "Employee Login"
        Me.btnEmployeeLogin.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(105, 277)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(234, 87)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnPassengerLogin
        '
        Me.btnPassengerLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPassengerLogin.Location = New System.Drawing.Point(105, 43)
        Me.btnPassengerLogin.Name = "btnPassengerLogin"
        Me.btnPassengerLogin.Size = New System.Drawing.Size(234, 87)
        Me.btnPassengerLogin.TabIndex = 3
        Me.btnPassengerLogin.Text = "Passenger  Login"
        Me.btnPassengerLogin.UseVisualStyleBackColor = True
        '
        'frmLoginSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 410)
        Me.Controls.Add(Me.btnEmployeeLogin)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPassengerLogin)
        Me.Name = "frmLoginSelect"
        Me.Text = "frmLoginSelect"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnEmployeeLogin As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnPassengerLogin As Button
End Class
