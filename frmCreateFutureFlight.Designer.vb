<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateFutureFlight
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
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtMilesFlown = New System.Windows.Forms.TextBox()
        Me.dtmDepartureTime = New System.Windows.Forms.DateTimePicker()
        Me.dtmLandingTime = New System.Windows.Forms.DateTimePicker()
        Me.dtmFlightDate = New System.Windows.Forms.DateTimePicker()
        Me.cboToAirport = New System.Windows.Forms.ComboBox()
        Me.cboFromAirport = New System.Windows.Forms.ComboBox()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboPlane = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(283, 367)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(184, 45)
        Me.btnExit.TabIndex = 31
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(52, 367)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(155, 45)
        Me.btnSubmit.TabIndex = 30
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtMilesFlown
        '
        Me.txtMilesFlown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMilesFlown.Location = New System.Drawing.Point(231, 267)
        Me.txtMilesFlown.Name = "txtMilesFlown"
        Me.txtMilesFlown.Size = New System.Drawing.Size(274, 26)
        Me.txtMilesFlown.TabIndex = 29
        '
        'dtmDepartureTime
        '
        Me.dtmDepartureTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmDepartureTime.Location = New System.Drawing.Point(231, 192)
        Me.dtmDepartureTime.Name = "dtmDepartureTime"
        Me.dtmDepartureTime.Size = New System.Drawing.Size(274, 26)
        Me.dtmDepartureTime.TabIndex = 28
        '
        'dtmLandingTime
        '
        Me.dtmLandingTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmLandingTime.Location = New System.Drawing.Point(231, 230)
        Me.dtmLandingTime.Name = "dtmLandingTime"
        Me.dtmLandingTime.Size = New System.Drawing.Size(274, 26)
        Me.dtmLandingTime.TabIndex = 27
        '
        'dtmFlightDate
        '
        Me.dtmFlightDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFlightDate.Location = New System.Drawing.Point(231, 143)
        Me.dtmFlightDate.Name = "dtmFlightDate"
        Me.dtmFlightDate.Size = New System.Drawing.Size(274, 26)
        Me.dtmFlightDate.TabIndex = 26
        '
        'cboToAirport
        '
        Me.cboToAirport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboToAirport.FormattingEnabled = True
        Me.cboToAirport.Location = New System.Drawing.Point(231, 102)
        Me.cboToAirport.Name = "cboToAirport"
        Me.cboToAirport.Size = New System.Drawing.Size(274, 28)
        Me.cboToAirport.TabIndex = 25
        '
        'cboFromAirport
        '
        Me.cboFromAirport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFromAirport.FormattingEnabled = True
        Me.cboFromAirport.Location = New System.Drawing.Point(231, 61)
        Me.cboFromAirport.Name = "cboFromAirport"
        Me.cboFromAirport.Size = New System.Drawing.Size(274, 28)
        Me.cboFromAirport.TabIndex = 24
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlightNumber.Location = New System.Drawing.Point(231, 29)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(274, 26)
        Me.txtFlightNumber.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(47, 268)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 25)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Miles Flown"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(47, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 25)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Departure Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 25)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Arrival Time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 25)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Departure Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 25)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Arrival Airport "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 25)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Departure Airport"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 25)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Flight Number"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(47, 308)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 25)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Plane"
        '
        'cboPlane
        '
        Me.cboPlane.FormattingEnabled = True
        Me.cboPlane.Location = New System.Drawing.Point(227, 308)
        Me.cboPlane.Name = "cboPlane"
        Me.cboPlane.Size = New System.Drawing.Size(278, 24)
        Me.cboPlane.TabIndex = 33
        '
        'frmCreateFutureFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 444)
        Me.Controls.Add(Me.cboPlane)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtMilesFlown)
        Me.Controls.Add(Me.dtmDepartureTime)
        Me.Controls.Add(Me.dtmLandingTime)
        Me.Controls.Add(Me.dtmFlightDate)
        Me.Controls.Add(Me.cboToAirport)
        Me.Controls.Add(Me.cboFromAirport)
        Me.Controls.Add(Me.txtFlightNumber)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCreateFutureFlight"
        Me.Text = "frmCreateFutureFlight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents txtMilesFlown As TextBox
    Friend WithEvents dtmDepartureTime As DateTimePicker
    Friend WithEvents dtmLandingTime As DateTimePicker
    Friend WithEvents dtmFlightDate As DateTimePicker
    Friend WithEvents cboToAirport As ComboBox
    Friend WithEvents cboFromAirport As ComboBox
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cboPlane As ComboBox
End Class
