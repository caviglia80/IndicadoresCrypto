<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.LV1 = New System.Windows.Forms.ListView()
		Me.RealTime = New System.Windows.Forms.Timer(Me.components)
		Me.GB2 = New System.Windows.Forms.GroupBox()
		Me.CBRanking = New System.Windows.Forms.CheckBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.CBVolumen = New System.Windows.Forms.CheckBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.CBCapitalMercado = New System.Windows.Forms.CheckBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.TBRanking = New System.Windows.Forms.TextBox()
		Me.TBVolumen = New System.Windows.Forms.TextBox()
		Me.TBCapitalMercado = New System.Windows.Forms.TextBox()
		Me.LV2 = New System.Windows.Forms.ListView()
		Me.BTNLimpiar = New System.Windows.Forms.Button()
		Me.BTNSalir = New System.Windows.Forms.Button()
		Me.Lconexion = New System.Windows.Forms.Label()
		Me.GB3 = New System.Windows.Forms.GroupBox()
		Me.Log4 = New System.Windows.Forms.Label()
		Me.Log3 = New System.Windows.Forms.Label()
		Me.Log1 = New System.Windows.Forms.Label()
		Me.TBtid = New System.Windows.Forms.TextBox()
		Me.BTNplay = New System.Windows.Forms.Button()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.GB2.SuspendLayout()
		Me.GB3.SuspendLayout()
		Me.SuspendLayout()
		'
		'LV1
		'
		Me.LV1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LV1.BackColor = System.Drawing.Color.Black
		Me.LV1.ForeColor = System.Drawing.Color.Lime
		Me.LV1.HideSelection = False
		Me.LV1.Location = New System.Drawing.Point(326, 12)
		Me.LV1.Name = "LV1"
		Me.LV1.Size = New System.Drawing.Size(839, 331)
		Me.LV1.TabIndex = 3
		Me.LV1.UseCompatibleStateImageBehavior = False
		'
		'RealTime
		'
		Me.RealTime.Enabled = True
		Me.RealTime.Interval = 1000
		'
		'GB2
		'
		Me.GB2.BackColor = System.Drawing.Color.DimGray
		Me.GB2.Controls.Add(Me.CBRanking)
		Me.GB2.Controls.Add(Me.Label6)
		Me.GB2.Controls.Add(Me.CBVolumen)
		Me.GB2.Controls.Add(Me.Label5)
		Me.GB2.Controls.Add(Me.CBCapitalMercado)
		Me.GB2.Controls.Add(Me.Label4)
		Me.GB2.Controls.Add(Me.TBRanking)
		Me.GB2.Controls.Add(Me.TBVolumen)
		Me.GB2.Controls.Add(Me.TBCapitalMercado)
		Me.GB2.Location = New System.Drawing.Point(12, 12)
		Me.GB2.Name = "GB2"
		Me.GB2.Size = New System.Drawing.Size(308, 125)
		Me.GB2.TabIndex = 9
		Me.GB2.TabStop = False
		Me.GB2.Text = "Indicadores"
		'
		'CBRanking
		'
		Me.CBRanking.AutoSize = True
		Me.CBRanking.Checked = True
		Me.CBRanking.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CBRanking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.CBRanking.ForeColor = System.Drawing.Color.Cyan
		Me.CBRanking.Location = New System.Drawing.Point(287, 99)
		Me.CBRanking.Name = "CBRanking"
		Me.CBRanking.Size = New System.Drawing.Size(12, 11)
		Me.CBRanking.TabIndex = 12
		Me.CBRanking.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(6, 98)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(50, 15)
		Me.Label6.TabIndex = 19
		Me.Label6.Text = "Ranking"
		'
		'CBVolumen
		'
		Me.CBVolumen.AutoSize = True
		Me.CBVolumen.Checked = True
		Me.CBVolumen.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CBVolumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.CBVolumen.ForeColor = System.Drawing.Color.Cyan
		Me.CBVolumen.Location = New System.Drawing.Point(287, 70)
		Me.CBVolumen.Name = "CBVolumen"
		Me.CBVolumen.Size = New System.Drawing.Size(12, 11)
		Me.CBVolumen.TabIndex = 11
		Me.CBVolumen.UseVisualStyleBackColor = True
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(6, 69)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(54, 15)
		Me.Label5.TabIndex = 18
		Me.Label5.Text = "Volumen"
		'
		'CBCapitalMercado
		'
		Me.CBCapitalMercado.AutoSize = True
		Me.CBCapitalMercado.Checked = True
		Me.CBCapitalMercado.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CBCapitalMercado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.CBCapitalMercado.ForeColor = System.Drawing.Color.Cyan
		Me.CBCapitalMercado.Location = New System.Drawing.Point(287, 41)
		Me.CBCapitalMercado.Name = "CBCapitalMercado"
		Me.CBCapitalMercado.Size = New System.Drawing.Size(12, 11)
		Me.CBCapitalMercado.TabIndex = 10
		Me.CBCapitalMercado.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(6, 40)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(110, 15)
		Me.Label4.TabIndex = 10
		Me.Label4.Text = "Capital de Mercado"
		'
		'TBRanking
		'
		Me.TBRanking.Location = New System.Drawing.Point(134, 95)
		Me.TBRanking.Name = "TBRanking"
		Me.TBRanking.Size = New System.Drawing.Size(147, 23)
		Me.TBRanking.TabIndex = 17
		Me.TBRanking.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'TBVolumen
		'
		Me.TBVolumen.Location = New System.Drawing.Point(134, 66)
		Me.TBVolumen.Name = "TBVolumen"
		Me.TBVolumen.Size = New System.Drawing.Size(147, 23)
		Me.TBVolumen.TabIndex = 16
		Me.TBVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'TBCapitalMercado
		'
		Me.TBCapitalMercado.Location = New System.Drawing.Point(134, 37)
		Me.TBCapitalMercado.Name = "TBCapitalMercado"
		Me.TBCapitalMercado.Size = New System.Drawing.Size(147, 23)
		Me.TBCapitalMercado.TabIndex = 15
		Me.TBCapitalMercado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'LV2
		'
		Me.LV2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LV2.BackColor = System.Drawing.Color.Black
		Me.LV2.ForeColor = System.Drawing.Color.Lime
		Me.LV2.HideSelection = False
		Me.LV2.Location = New System.Drawing.Point(326, 349)
		Me.LV2.Name = "LV2"
		Me.LV2.Size = New System.Drawing.Size(839, 241)
		Me.LV2.TabIndex = 10
		Me.LV2.UseCompatibleStateImageBehavior = False
		'
		'BTNLimpiar
		'
		Me.BTNLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.BTNLimpiar.BackColor = System.Drawing.Color.Black
		Me.BTNLimpiar.Location = New System.Drawing.Point(249, 563)
		Me.BTNLimpiar.Name = "BTNLimpiar"
		Me.BTNLimpiar.Size = New System.Drawing.Size(71, 27)
		Me.BTNLimpiar.TabIndex = 15
		Me.BTNLimpiar.Text = "Limpiar"
		Me.BTNLimpiar.UseVisualStyleBackColor = False
		'
		'BTNSalir
		'
		Me.BTNSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.BTNSalir.BackColor = System.Drawing.Color.Black
		Me.BTNSalir.Location = New System.Drawing.Point(12, 563)
		Me.BTNSalir.Name = "BTNSalir"
		Me.BTNSalir.Size = New System.Drawing.Size(71, 27)
		Me.BTNSalir.TabIndex = 16
		Me.BTNSalir.Text = "Salir"
		Me.BTNSalir.UseVisualStyleBackColor = False
		'
		'Lconexion
		'
		Me.Lconexion.AutoSize = True
		Me.Lconexion.Location = New System.Drawing.Point(12, 271)
		Me.Lconexion.Name = "Lconexion"
		Me.Lconexion.Size = New System.Drawing.Size(12, 15)
		Me.Lconexion.TabIndex = 18
		Me.Lconexion.Text = "-"
		'
		'GB3
		'
		Me.GB3.BackColor = System.Drawing.Color.DimGray
		Me.GB3.Controls.Add(Me.Log4)
		Me.GB3.Controls.Add(Me.Log3)
		Me.GB3.Controls.Add(Me.Log1)
		Me.GB3.Location = New System.Drawing.Point(12, 143)
		Me.GB3.Name = "GB3"
		Me.GB3.Size = New System.Drawing.Size(308, 125)
		Me.GB3.TabIndex = 20
		Me.GB3.TabStop = False
		Me.GB3.Text = "Registro"
		'
		'Log4
		'
		Me.Log4.AutoSize = True
		Me.Log4.Location = New System.Drawing.Point(6, 98)
		Me.Log4.Name = "Log4"
		Me.Log4.Size = New System.Drawing.Size(10, 15)
		Me.Log4.TabIndex = 20
		Me.Log4.Text = "."
		'
		'Log3
		'
		Me.Log3.AutoSize = True
		Me.Log3.Location = New System.Drawing.Point(6, 68)
		Me.Log3.Name = "Log3"
		Me.Log3.Size = New System.Drawing.Size(10, 15)
		Me.Log3.TabIndex = 19
		Me.Log3.Text = "."
		'
		'Log1
		'
		Me.Log1.AutoSize = True
		Me.Log1.Location = New System.Drawing.Point(6, 38)
		Me.Log1.Name = "Log1"
		Me.Log1.Size = New System.Drawing.Size(10, 15)
		Me.Log1.TabIndex = 10
		Me.Log1.Text = "."
		'
		'TBtid
		'
		Me.TBtid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.TBtid.Location = New System.Drawing.Point(12, 534)
		Me.TBtid.Name = "TBtid"
		Me.TBtid.Size = New System.Drawing.Size(308, 23)
		Me.TBtid.TabIndex = 20
		'
		'BTNplay
		'
		Me.BTNplay.BackColor = System.Drawing.Color.Black
		Me.BTNplay.Location = New System.Drawing.Point(249, 274)
		Me.BTNplay.Name = "BTNplay"
		Me.BTNplay.Size = New System.Drawing.Size(71, 27)
		Me.BTNplay.TabIndex = 21
		Me.BTNplay.Text = "PLAY"
		Me.BTNplay.UseVisualStyleBackColor = False
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(40, 385)
		Me.TextBox1.Multiline = True
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(206, 89)
		Me.TextBox1.TabIndex = 22
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(1177, 602)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.BTNplay)
		Me.Controls.Add(Me.TBtid)
		Me.Controls.Add(Me.GB3)
		Me.Controls.Add(Me.Lconexion)
		Me.Controls.Add(Me.BTNSalir)
		Me.Controls.Add(Me.BTNLimpiar)
		Me.Controls.Add(Me.LV2)
		Me.Controls.Add(Me.GB2)
		Me.Controls.Add(Me.LV1)
		Me.DoubleBuffered = True
		Me.ForeColor = System.Drawing.Color.Cyan
		Me.Name = "Form1"
		Me.Text = "CC"
		Me.GB2.ResumeLayout(False)
		Me.GB2.PerformLayout()
		Me.GB3.ResumeLayout(False)
		Me.GB3.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents LV1 As ListView
	Friend WithEvents RealTime As Timer
	Friend WithEvents GB2 As GroupBox
	Friend WithEvents Label6 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents TBRanking As TextBox
	Friend WithEvents TBVolumen As TextBox
	Friend WithEvents TBCapitalMercado As TextBox
	Friend WithEvents CBRanking As CheckBox
	Friend WithEvents CBVolumen As CheckBox
	Friend WithEvents CBCapitalMercado As CheckBox
	Friend WithEvents LV2 As ListView
	Friend WithEvents BTNLimpiar As Button
	Friend WithEvents BTNSalir As Button
	Friend WithEvents Lconexion As Label
	Friend WithEvents GB3 As GroupBox
	Friend WithEvents Log3 As Label
	Friend WithEvents Log1 As Label
	Friend WithEvents Log4 As Label
	Friend WithEvents TBtid As TextBox
	Friend WithEvents BTNplay As Button
	Friend WithEvents TextBox1 As TextBox
End Class
