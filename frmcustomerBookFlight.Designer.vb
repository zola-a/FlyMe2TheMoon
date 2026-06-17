<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerBookFlight
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
        Me.lblDesignatedCost = New System.Windows.Forms.Label()
        Me.lblReservedCost = New System.Windows.Forms.Label()
        Me.rdoDesignatedSeat = New System.Windows.Forms.RadioButton()
        Me.rdoReservedSeat = New System.Windows.Forms.RadioButton()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFlights = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblDesignatedCost
        '
        Me.lblDesignatedCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDesignatedCost.Location = New System.Drawing.Point(284, 172)
        Me.lblDesignatedCost.Name = "lblDesignatedCost"
        Me.lblDesignatedCost.Size = New System.Drawing.Size(160, 23)
        Me.lblDesignatedCost.TabIndex = 24
        '
        'lblReservedCost
        '
        Me.lblReservedCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReservedCost.Location = New System.Drawing.Point(284, 132)
        Me.lblReservedCost.Name = "lblReservedCost"
        Me.lblReservedCost.Size = New System.Drawing.Size(160, 23)
        Me.lblReservedCost.TabIndex = 23
        '
        'rdoDesignatedSeat
        '
        Me.rdoDesignatedSeat.AutoSize = True
        Me.rdoDesignatedSeat.Location = New System.Drawing.Point(134, 169)
        Me.rdoDesignatedSeat.Name = "rdoDesignatedSeat"
        Me.rdoDesignatedSeat.Size = New System.Drawing.Size(129, 20)
        Me.rdoDesignatedSeat.TabIndex = 22
        Me.rdoDesignatedSeat.TabStop = True
        Me.rdoDesignatedSeat.Text = "Designated Seat"
        Me.rdoDesignatedSeat.UseVisualStyleBackColor = True
        '
        'rdoReservedSeat
        '
        Me.rdoReservedSeat.AutoSize = True
        Me.rdoReservedSeat.Location = New System.Drawing.Point(134, 129)
        Me.rdoReservedSeat.Name = "rdoReservedSeat"
        Me.rdoReservedSeat.Size = New System.Drawing.Size(119, 20)
        Me.rdoReservedSeat.TabIndex = 21
        Me.rdoReservedSeat.TabStop = True
        Me.rdoReservedSeat.Text = "Reserved Seat"
        Me.rdoReservedSeat.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(284, 263)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(199, 36)
        Me.btnExit.TabIndex = 20
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(42, 263)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(199, 36)
        Me.btnSubmit.TabIndex = 19
        Me.btnSubmit.Text = "Book"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 25)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Seat"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 25)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Flights"
        '
        'cboFlights
        '
        Me.cboFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFlights.FormattingEnabled = True
        Me.cboFlights.Location = New System.Drawing.Point(204, 65)
        Me.cboFlights.Name = "cboFlights"
        Me.cboFlights.Size = New System.Drawing.Size(240, 28)
        Me.cboFlights.TabIndex = 16
        '
        'frmcustomerBookFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 390)
        Me.Controls.Add(Me.lblDesignatedCost)
        Me.Controls.Add(Me.lblReservedCost)
        Me.Controls.Add(Me.rdoDesignatedSeat)
        Me.Controls.Add(Me.rdoReservedSeat)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFlights)
        Me.Name = "frmcustomerBookFlight"
        Me.Text = "frmcustomerBookFlight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDesignatedCost As Label
    Friend WithEvents lblReservedCost As Label
    Friend WithEvents rdoDesignatedSeat As RadioButton
    Friend WithEvents rdoReservedSeat As RadioButton
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboFlights As ComboBox
End Class
