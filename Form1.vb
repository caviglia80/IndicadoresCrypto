Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports System.IO
Imports Telegram.Bot

Public Class Form1

	Public BOT As New TelegramBotClient("")

	Private S_ListaNueva As New List(Of Currency)
	Private S_ListaVieja As New List(Of Currency)
	Private Matches As New List(Of Currency)


	Private ListaMensajes As New List(Of String)

	Private WithEvents WV1 As New WebView2 With {.ZoomFactor = 0.1, .Source = New Uri("about:blank")}
	Private WithEvents WV2 As New WebView2 With {.ZoomFactor = 0.1, .Source = New Uri("about:blank")}
	Private WithEvents WV3 As New WebView2 With {.ZoomFactor = 0.1, .Source = New Uri("about:blank")}
	Private WithEvents WV4 As New WebView2 With {.ZoomFactor = 0.1, .Source = New Uri("about:blank")}
	Private WithEvents WV5 As New WebView2 With {.ZoomFactor = 0.1, .Source = New Uri("about:blank")}
	Private WithEvents WV6 As New WebView2 With {.ZoomFactor = 0.1, .Source = New Uri("about:blank")}

	Private ReadOnly Uri1 As New Uri("https://coinmarketcap.com/es/")
	Private ReadOnly Uri2 As New Uri("https://coinmarketcap.com/es/?page=2")
	Private ReadOnly Uri3 As New Uri("https://coinmarketcap.com/es/?page=3")
	Private ReadOnly Uri4 As New Uri("https://coinmarketcap.com/es/?page=4")
	Private ReadOnly Uri5 As New Uri("https://coinmarketcap.com/es/?page=5")
	Private ReadOnly Uri6 As New Uri("https://coinmarketcap.com/es/?page=6")

	Private ReadOnly ScriptJs_ScrollBottom As String = "var _fullScrollIntervalID = setInterval(function() {if (window.scrollY + window.innerHeight >= document.body.scrollHeight) { window.clearInterval(_fullScrollIntervalID);  } else { window.scrollBy(0, 50); } }, 17);"

	Private ReadOnly FILE_List As String = "List"
	Private ItsMatch As Boolean = False
	Private ListoParaIniciar As Boolean = False
	Private ListoParaComprobar As Boolean = False
	Private nuevasAlertas As Integer = 0









	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			Try
				If Not IsAvailable() Then
					MsgBox("Gil xD", vbCritical)
					Close()
					Dispose()
					End
				End If
			Catch : End Try
			CheckForIllegalCrossThreadCalls = False
			cargarSettings()
			configurarControlesDefault()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTNplay.Click
		Try
			Application.DoEvents()
			If BTNplay.Text = "PLAY" Then
				BTNplay.Text = "STOP"
				AccederAControles(False)
				IniciarLecturaWV2()
			Else
				Application.DoEvents()
				AccederAControles(True)
				BTNplay.Text = "PLAY"
				Me.Text = "Listo."
			End If

			ListoParaIniciar = False
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub RestarProcess() Handles RealTime.Tick
		Try
			If ListoParaIniciar Then
				PrintCurrentLine()
				ListoParaIniciar = False
				IniciarLecturaWV2()
			End If

			If ListoParaComprobar Then
				PrintCurrentLine()
				ListoParaComprobar = False
				Comprobar()
			End If
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub IniciarLecturaWV2()
		Try
			PrintCurrentLine()
			If BTNplay.Text = "PLAY" Then Return
			ListoParaIniciar = False
			nuevasAlertas = 0
			Me.Text = "Cargando.."
			Log3.Text = "Divisas: 0"
			S_ListaNueva.Clear()
			WV1.Source = Uri1
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Function IsAvailable() As Boolean
		Try
			If Now > CDate("01/07/2022") Then Return False Else Return True
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return False
	End Function

	Private Sub cargarSettings()
		Try
			TBVolumen.Text = My.Settings.volumen
			TBCapitalMercado.Text = My.Settings.capmercado
			TBRanking.Text = My.Settings.ranking

			TBtid.Text = My.Settings.IDsTelegram
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub configurarControlesDefault() Handles Me.Resize
		Try
			Dim LV1WR As Integer = (LV1.Width / 5 - 2) / 2
			Dim LV1W As Integer = (LV1.Width / 5) + (LV1WR / 5) - 1
			LV1.Columns.Clear()
			LV1.View = View.Details
			LV1.FullRowSelect = True
			LV1.Columns.Add("Ranking", LV1WR, HorizontalAlignment.Left)
			LV1.Columns.Add("Divisa", LV1W, HorizontalAlignment.Left)
			LV1.Columns.Add("Precio", LV1W, HorizontalAlignment.Left)
			LV1.Columns.Add("CapitalMercado", LV1W, HorizontalAlignment.Left)
			LV1.Columns.Add("Volumen", LV1W, HorizontalAlignment.Left)

			'Dim LV2WR As Integer = (LV2.Width / 6 - 2) / 2
			'Dim LV2W As Integer = (LV2.Width / 6) + (LV2WR / 6)
			'LV2.Columns.Clear()
			'LV2.View = View.Details
			'LV2.FullRowSelect = True
			'LV2.Columns.Add("Ranking", LV2WR, HorizontalAlignment.Left)
			'LV2.Columns.Add("Divisa", LV2W, HorizontalAlignment.Left)
			'LV2.Columns.Add("Precio", LV2W, HorizontalAlignment.Left)
			'LV2.Columns.Add("CapitalMercado", LV2W, HorizontalAlignment.Left)
			'LV2.Columns.Add("Volumen", LV2W, HorizontalAlignment.Left)
			'LV2.Columns.Add("Alerta", LV2W * 8, HorizontalAlignment.Left)

			Dim LV2WR As Integer = (LV2.Width / 3 - 2) / 3
			Dim LV2W As Integer = (LV2.Width / 3) + (LV2WR / 3)
			LV2.Columns.Clear()
			LV2.View = View.Details
			LV2.FullRowSelect = True
			LV2.Columns.Add("Ranking", LV2WR, HorizontalAlignment.Left)
			LV2.Columns.Add("Divisa", LV2W, HorizontalAlignment.Left)
			'LV2.Columns.Add("Precio", LV2W, HorizontalAlignment.Left)
			'LV2.Columns.Add("CapitalMercado", LV2W, HorizontalAlignment.Left)
			'LV2.Columns.Add("Volumen", LV2W, HorizontalAlignment.Left)
			LV2.Columns.Add("Alerta", LV2W, HorizontalAlignment.Left)
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Async Sub WV1_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WV1.NavigationCompleted
		Try
			If sender.Source.ToString = "about:blank" Then Return
			PrintCurrentLine()
			LOG(sender.Source.ToString)
			Await NavigatioCompletedScripts(sender)
			If BTNplay.Text = "PLAY" Then Return
			Application.DoEvents()
			WV2.Source = Uri2
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Async Sub WV2_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WV2.NavigationCompleted
		Try
			If sender.Source.ToString = "about:blank" Then Return
			PrintCurrentLine()
			LOG(sender.Source.ToString)
			Await NavigatioCompletedScripts(sender)
			If BTNplay.Text = "PLAY" Then Return
			Application.DoEvents()
			WV3.Source = Uri3
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Async Sub WV3_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WV3.NavigationCompleted
		Try
			If sender.Source.ToString = "about:blank" Then Return
			PrintCurrentLine()
			LOG(sender.Source.ToString)
			Await NavigatioCompletedScripts(sender)
			If BTNplay.Text = "PLAY" Then Return
			Application.DoEvents()
			WV4.Source = Uri4
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Async Sub WV4_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WV4.NavigationCompleted
		Try
			If sender.Source.ToString = "about:blank" Then Return
			PrintCurrentLine()
			LOG(sender.Source.ToString)
			Await NavigatioCompletedScripts(sender)
			If BTNplay.Text = "PLAY" Then Return
			Application.DoEvents()
			WV5.Source = Uri5
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Async Sub WV5_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WV5.NavigationCompleted
		Try
			If sender.Source.ToString = "about:blank" Then Return
			PrintCurrentLine()
			LOG(sender.Source.ToString)
			Await NavigatioCompletedScripts(sender)
			If BTNplay.Text = "PLAY" Then Return
			Application.DoEvents()
			WV6.Source = Uri6
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Async Sub WV6_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WV6.NavigationCompleted
		Try
			If sender.Source.ToString = "about:blank" Then Return
			PrintCurrentLine()
			LOG(sender.Source.ToString)
			Await NavigatioCompletedScripts(sender)

			Application.DoEvents()
			ActualizarLista_LV1()

			Application.DoEvents()
			LimpiarWV2()

			Application.DoEvents()

			ListoParaComprobar = True
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub LimpiarWV2()
		Try
			PrintCurrentLine()
			WV1.Source = New Uri("about:blank")
			WV2.Source = New Uri("about:blank")
			WV3.Source = New Uri("about:blank")
			WV4.Source = New Uri("about:blank")
			WV5.Source = New Uri("about:blank")
			WV6.Source = New Uri("about:blank")
			Application.DoEvents()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Async Function TraerHTML(Browser As WebView2) As Task(Of String)
		Try
			Return Await Browser.ExecuteScriptAsync("document.documentElement.outerHTML;")
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return ""
	End Function

	Private Async Function NavigatioCompletedScripts(Browser As WebView2) As Task(Of Boolean)
		Try
			PrintCurrentLine()
			Await Browser.ExecuteScriptAsync(ScriptJs_ScrollBottom)
			While New Currency(Await TraerHTML(Browser)).Listado.Count <> 99
				Threading.Thread.Sleep(2000)
			End While

			LOG("LEIDOS:     " + S_ListaNueva.Count.ToString)

			'Scrapeo
			S_ListaNueva.AddRange(New Currency(Await TraerHTML(Browser)).Listado)

			PrintCurrentLine()
			Return True
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return False
	End Function

	Private Sub SacarDuplicadosByName()
		Try
			If S_ListaNueva.Count = 0 Then Return
			PrintCurrentLine()
			Dim tmp As New List(Of Currency)
			tmp.AddRange(S_ListaNueva.GroupBy(Function(x) x.Name).Select(Function(y) y.First()))
			S_ListaNueva.Clear()
			S_ListaNueva.AddRange(tmp)
			tmp.Clear()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub SacarDuplicadosByObject()
		Try
			Dim tmp As New List(Of Currency)
			'tmp.AddRange(Matches.GroupBy(Function(x) x).Select(Function(y) y.First()))
			Matches.Clear()
			Matches.AddRange(tmp)
			tmp.Clear()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub ActualizarLista_LV1()
		Try
			PrintCurrentLine()
			LV1.Items.Clear()
			Dim item As ListViewItem

			SacarDuplicadosByName()
			'S_ListaNueva = S_ListaNueva.OrderBy(Function(C) C.Rank).ToList()

			Dim tmp As New List(Of Currency)
			tmp.AddRange(S_ListaNueva.OrderBy(Function(C) C.Rank).ToList())
			S_ListaNueva.Clear()
			S_ListaNueva.AddRange(tmp)
			tmp.Clear()

			For Each c As Currency In S_ListaNueva
				item = New ListViewItem
				item.Text = c.Rank.ToString
				item.SubItems.Add(c.Name)
				item.SubItems.Add(String.Concat("$ ", c.Precio))
				item.SubItems.Add(String.Concat("$ ", SepararMiles(c.CapitalMercado)))
				item.SubItems.Add(String.Concat("$ ", SepararMiles(c.Volumen)))
				item.ForeColor = Color.Cyan
				LV1.Items.Add(item)
			Next
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub ActualizarLista_LV2()
		Try
			PrintCurrentLine()
			LV2.Items.Clear()
			Dim item As ListViewItem

			Dim tmp As New List(Of Currency)
			tmp.AddRange(Matches.OrderBy(Function(C) C.Rank).ToList())
			Matches.Clear()
			Matches.AddRange(tmp)
			tmp.Clear()

			For Each c As Currency In Matches
				item = New ListViewItem
				item.Text = c.Rank.ToString
				item.SubItems.Add(c.Name)
				'item.SubItems.Add(String.Concat("$ ", c.Precio))
				'item.SubItems.Add(String.Concat("$ ", SepararMiles(c.CapitalMercado)))
				'item.SubItems.Add(String.Concat("$ ", SepararMiles(c.Volumen)))
				item.SubItems.Add(c.AlerType)
				item.ForeColor = Color.Lime
				LV2.Items.Add(item)
			Next
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub ContarDivisas() Handles RealTime.Tick
		Try
			Log3.Text = String.Concat("Divisas Cargadas: ", S_ListaNueva.Count.ToString)

			If nuevasAlertas > 0 Then
				Log4.Text = String.Concat("Alertas: ", Matches.Count.ToString, " +", nuevasAlertas.ToString)
				Log4.ForeColor = Color.Lime
			Else
				Log4.Text = String.Concat("Alertas: ", Matches.Count.ToString)
				Log4.ForeColor = Color.Cyan
			End If

			If S_ListaVieja.Count = 0 Then
				Me.Text = "Cargando Lista de Referencia.."
			End If

		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub ConexionStatus() Handles RealTime.Tick
		Try
			Application.DoEvents()
			If My.Computer.Network.IsAvailable Then
				If My.Computer.Network.Ping("www.google.com", 350) Then
					Lconexion.Text = "Conexión estable !"
					Lconexion.ForeColor = Color.Lime
				Else
					Lconexion.Text = "Conexión inestable."
					Lconexion.ForeColor = Color.Gold
				End If
			Else
				Lconexion.Text = "Sin conexión !"
				Lconexion.ForeColor = Color.Red
				WaitNewConection()
			End If
			Application.DoEvents()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub WaitNewConection()
		Try
			PrintCurrentLine()
			Dim Vieja As Date = Now
			Dim Ahora As TimeSpan = Now.Subtract(Vieja)

			While Not My.Computer.Network.IsAvailable
				Me.Text = String.Concat("Esperando conexión.. Transcurrido: ", Ahora.Hours.ToString, ": ", Ahora.Minutes.ToString, ": ", Ahora.Seconds.ToString)
				Threading.Thread.Sleep(1000)
			End While

			ListoParaIniciar = False
			IniciarLecturaWV2()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub BTNLimpiar_Click(sender As Object, e As EventArgs) Handles BTNLimpiar.Click
		Try
			Matches.Clear()
			LV2.Items.Clear()
			Log4.Text = "Alertas: 0"
			nuevasAlertas = 0
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
		Try
			Me.Dispose()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub TBCapitalMercado_TextChanged(sender As Object, e As EventArgs) Handles TBCapitalMercado.TextChanged
		Try
			If TBCapitalMercado.Text.Length = 0 Then TBCapitalMercado.Text = "0"
			My.Settings.capmercado = TBCapitalMercado.Text
			My.Settings.Save()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub TBVolumen_TextChanged(sender As Object, e As EventArgs) Handles TBVolumen.TextChanged
		Try
			If TBVolumen.Text.Length = 0 Then TBVolumen.Text = "0"
			My.Settings.volumen = TBVolumen.Text
			My.Settings.Save()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub TBRanking_TextChanged(sender As Object, e As EventArgs) Handles TBRanking.TextChanged
		Try
			If TBRanking.Text.Length = 0 Then TBRanking.Text = "0"
			My.Settings.ranking = TBRanking.Text
			My.Settings.Save()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub TBtid_TextChanged(sender As Object, e As EventArgs) Handles TBtid.TextChanged
		Try
			If TBtid.Text.Length = 0 Then TBtid.Text = " "
			My.Settings.IDsTelegram = TBtid.Text
			My.Settings.Save()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub logFile(log As String)
		Try
			File.AppendAllText("Log.dat", String.Concat(Environment.NewLine, log, Environment.NewLine, "----------------------------------------------------"))
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub AccederAControles(Permiso As Boolean)
		Try
			TBVolumen.Enabled = Permiso
			TBCapitalMercado.Enabled = Permiso
			TBRanking.Enabled = Permiso
			CBCapitalMercado.Enabled = Permiso
			CBVolumen.Enabled = Permiso
			CBRanking.Enabled = Permiso
			TBtid.Enabled = Permiso
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub










	Private Sub TEST() Handles RealTime.Tick
		Try




			TextBox1.Text = String.Concat("S_ListaVieja: ", S_ListaVieja.Count.ToString, Environment.NewLine, "S_ListaNueva: ", S_ListaNueva.Count.ToString, Environment.NewLine, "coinciden: ", coinciden.ToString)





		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub










	Dim coinciden As Integer = 0



	Private Sub Comprobar()
		Try
			If S_ListaVieja.Count >= 588 Then

				PrintCurrentLine()

				Interaction.Beep()
				'MsgBox(S_ListaVieja.FindAll(Function(c) c.Name.ToLower = "bitcoin").Count.ToString)



				For Each DNueva In S_ListaNueva
					If DNueva Is Nothing Then Continue For
					If DNueva.Name.Length < 2 Then Continue For

					Dim DVieja As Currency = S_ListaVieja.Find(Function(c) c.Name = DNueva.Name)
					If DVieja Is Nothing Then Continue For
					If DVieja.Name.Length < 2 Then Continue For
					PrintCurrentLine()

					CLx_Capital(DVieja, DNueva)
					CLx_Volumen(DVieja, DNueva)
					CLx_Rank(DVieja, DNueva)
				Next



				LOG("Maches:      " + Matches.Count.ToString())
			End If



			S_ListaVieja.Clear()
			S_ListaVieja.AddRange(S_ListaNueva)
			S_ListaNueva.Clear()




			PrintCurrentLine()







			Me.Text = "Listo."
			If ItsMatch Then
				'Muestro los matches nuevos
				ItsMatch = False
				ActualizarLista_LV2()
				SendMessaje(ListaMensajes)
			End If

			PrintCurrentLine()


			WaitToPlay()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub











	Private Sub CLx_Capital(ByRef C1 As Currency, ByRef C2 As Currency)
		Try
			If My.Settings.capmercado = "0" Then Return
			'Quiere decir que el nuevo supera al viejo (viejo + cap.Indicador)
			If C2.CapitalMercado > (C1.CapitalMercado + CLng(TBCapitalMercado.Text)) Then

				C2.AciertosCM = C1.AciertosCM + 1

				Dim permanencia As String = ""

				For i = 1 To C2.AciertosCM
					permanencia += "⭐"
				Next

				C2.AlerText = String.Concat("🚩 Name: ", C2.Name, Environment.NewLine,
											"🚩 Alerta: Capital 💸", Environment.NewLine,
											permanencia, Environment.NewLine,
											Environment.NewLine,
											DevolverLineaCM(C1, C2), Environment.NewLine,
											Environment.NewLine,
											DevolverLineaPrecio(C1, C2), Environment.NewLine,
											Environment.NewLine,
											DevolverLineaTiempo(C1, DateTime.Now.Subtract(C1.DateOfLastRead)), Environment.NewLine,
											Environment.NewLine,
											DevolverLinkCripto(C2))

				C2.AlerType = "CAPITAL"








				'File.AppendAllText("test1.dat", String.Concat(Environment.NewLine, C2.Name, vbTab, vbTab, permanencia, vbTab, vbTab, C2.CapitalMercado.ToString, vbTab, vbTab, C2.AlerType))


				logFile(C2.AlerText)
				If CBCapitalMercado.Checked Then
					ListaMensajes.Add(C2.AlerText)
				End If

				Matches.Add(C2)
				nuevasAlertas += 1
				ItsMatch = True



				'Dim CMM As Long = C2.CapitalMercado
				'If Matches.Find(Function(c) c.CapitalMercado = CMM) Is Nothing Then
				'	logFile(C2.AlerText)
				'	If CBCapitalMercado.Checked Then
				'		ListaMensajes.Add(C2.AlerText)
				'	End If

				'	Matches.Add(C2)
				'	nuevasAlertas += 1
				'	ItsMatch = True
				'Else
				'	'MsgBox(C2.Name + "  " + permanencia)
				'	'MsgBox(C2.Name + "  " + permanencia + "  " + CMM.ToString)
				'End If
			End If
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub


















	Private Sub CLx_Volumen(ByRef C1 As Currency, ByRef C2 As Currency)
		Try
			If My.Settings.volumen = "0" Then Return
			'Quiere decir que el nuevo supera al viejo (viejo + cap.Indicador)
			If C2.Volumen > (C1.Volumen + CLng(TBVolumen.Text)) Then

				C2.AciertosVolumen = C1.AciertosVolumen + 1

				Dim permanencia As String = ""

				For i = 1 To C2.AciertosVolumen
					permanencia += "⭐"
				Next

				C2.AlerText = String.Concat("🚩 Name: ", C2.Name, Environment.NewLine,
											"🚩 Alerta: Volumen 🔊", Environment.NewLine,
											permanencia, Environment.NewLine,
											Environment.NewLine,
											DevolverLineaVolumen(C1, C2), Environment.NewLine,
											Environment.NewLine,
											DevolverLineaPrecio(C1, C2), Environment.NewLine,
											Environment.NewLine,
											DevolverLineaTiempo(C1, DateTime.Now.Subtract(C1.DateOfLastRead)), Environment.NewLine,
											Environment.NewLine,
											DevolverLinkCripto(C2))
				C2.AlerType = "VOLUMEN"









				'File.AppendAllText("test1.dat", String.Concat(Environment.NewLine, C2.Name, vbTab, vbTab, permanencia, vbTab, vbTab, C2.Volumen.ToString, vbTab, vbTab, C2.AlerType))




				logFile(C2.AlerText)
				If CBVolumen.Checked Then
					ListaMensajes.Add(C2.AlerText)
				End If

				Matches.Add(C2)
				nuevasAlertas += 1
				ItsMatch = True





				'Dim VOLL As Long = C2.Volumen
				'If Matches.Find(Function(c) c.Volumen = VOLL) Is Nothing Then
				'	logFile(C2.AlerText)
				'	If CBVolumen.Checked Then
				'		ListaMensajes.Add(C2.AlerText)
				'	End If

				'	Matches.Add(C2)
				'	nuevasAlertas += 1
				'	ItsMatch = True
				'Else
				'	'MsgBox(C2.Name + "  " + permanencia)
				'	'MsgBox(C2.Name + "  " + permanencia + "  " + VOLL.ToString)
				'End If
			End If
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Sub CLx_Rank(ByRef C1 As Currency, ByRef C2 As Currency)
		Try
			If My.Settings.ranking = "0" Then Return
			'Quiere decir que si el num es negativo, va 0
			If C2.Rank < If((C1.Rank - CInt(TBRanking.Text)) < 0, 1, C1.Rank - CInt(TBRanking.Text)) Then

				C2.AciertosRanking = C1.AciertosRanking + 1

				Dim permanencia As String = ""

				For i = 1 To C2.AciertosRanking
					permanencia += "⭐"
				Next

				C2.AlerText = String.Concat("🚩 Name: ", C2.Name, Environment.NewLine,
											"🚩 Alerta: Ranking 🔝", Environment.NewLine,
											permanencia, Environment.NewLine,
											Environment.NewLine,
											DevolverLineaRanking(C1, C2), Environment.NewLine,
											Environment.NewLine,
											DevolverLineaPrecio(C1, C2), Environment.NewLine,
											Environment.NewLine,
											DevolverLineaTiempo(C1, DateTime.Now.Subtract(C1.DateOfLastRead)), Environment.NewLine,
											Environment.NewLine,
											DevolverLinkCripto(C2))
				C2.AlerType = "RANKING"






				'File.AppendAllText("test1.dat", String.Concat(Environment.NewLine, C2.Name, vbTab, vbTab, permanencia, vbTab, vbTab, C2.Rank.ToString, vbTab, vbTab, C2.AlerType))






				logFile(C2.AlerText)
				If CBRanking.Checked Then
					ListaMensajes.Add(C2.AlerText)
				End If

				Matches.Add(C2)
				nuevasAlertas += 1
				ItsMatch = True




				'Dim Rank As Integer = C2.Rank
				'If Matches.Find(Function(c) c.Rank = Rank) Is Nothing Then
				'	logFile(C2.AlerText)
				'	If CBRanking.Checked Then
				'		ListaMensajes.Add(C2.AlerText)
				'	End If

				'	Matches.Add(C2)
				'	nuevasAlertas += 1
				'	ItsMatch = True
				'Else
				'	'MsgBox(C2.Name + "  " + permanencia)
				'	'MsgBox(C2.Name + "  " + permanencia + "  " + Rank.ToString)
				'End If
			End If
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Function DevolverLineaPrecio(ByVal C1 As Currency, ByVal C2 As Currency) As String
		Try
			Dim C1Price As Double = Convert.ToDouble(C1.Precio.Replace(",", ""), Globalization.CultureInfo.InvariantCulture)
			Dim C2Price As Double = Convert.ToDouble(C2.Precio.Replace(",", ""), Globalization.CultureInfo.InvariantCulture)
			Dim Diferencia As Double = C2Price - C1Price
			Dim Porcentaje As Double = (Diferencia * 100) / C2Price
			Dim PorcentajeStr As String = If(Math.Round(Porcentaje, 2).ToString.Contains("-"), Math.Round(Porcentaje, 2).ToString, String.Concat("+", Math.Round(Porcentaje, 2).ToString))
			Return String.Concat(
								"💹 💲 ", PorcentajeStr, "%", Environment.NewLine,
								"➡ 💲 ", C2.Precio, Environment.NewLine,
								"🔙 💲 ", C1.Precio)
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return "Precio Error"
	End Function

	Private Function DevolverLinkCripto(ByVal C2 As Currency) As String
		Try
			Return String.Concat("Link:", Environment.NewLine, "https://coinmarketcap.com/es/currencies/", C2.Name.ToLower, "/").Replace(" ", "-")
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return "Error Link"
	End Function

	Private Function DevolverLineaCM(ByVal C1 As Currency, ByVal C2 As Currency) As String
		Try
			Return String.Concat(
									"🔝 💲 ", SepararMiles((C2.CapitalMercado - C1.CapitalMercado).ToString), Environment.NewLine,
									"🚨 💲 ", SepararMiles(TBCapitalMercado.Text), Environment.NewLine,
									"➡ 💲 ", SepararMiles(C2.CapitalMercado.ToString), Environment.NewLine,
									"🔙 💲 ", SepararMiles(C1.CapitalMercado.ToString))
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return "Error CM"
	End Function

	Private Function DevolverLineaVolumen(ByVal C1 As Currency, ByVal C2 As Currency) As String
		Try
			Return String.Concat(
									"🔝 💲 ", SepararMiles((C2.Volumen - C1.Volumen).ToString), Environment.NewLine,
									"🚨 💲 ", SepararMiles(TBVolumen.Text), Environment.NewLine,
									"➡ 💲 ", SepararMiles(C2.Volumen.ToString), Environment.NewLine,
									"🔙 💲 ", SepararMiles(C1.Volumen.ToString))
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return "Error Volumen"
	End Function

	Private Function DevolverLineaRanking(ByVal C1 As Currency, ByVal C2 As Currency) As String
		Try
			Return String.Concat(
									"🔝 ", (C2.Rank - C1.Rank).ToString.Replace("-", ""), Environment.NewLine,
									"🚨 ", TBRanking.Text, Environment.NewLine,
									"➡ ", C2.Rank.ToString, Environment.NewLine,
									"🔙 ", C1.Rank.ToString)
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return "Error Ranking"
	End Function

	Private Function DevolverLineaTiempo(ByVal C1 As Currency, Ts As TimeSpan) As String
		Try
			Return String.Concat(
									"⏱Transcurrido: ", If(Ts.Days > 0, String.Concat(Ts.Days, " Días."), String.Concat("(", Ts.Hours, ")h. (", Ts.Minutes, ")m. (", Ts.Seconds, ")s.")), Environment.NewLine,
									"⏰Inicio: ", C1.DateOfLastRead.ToShortTimeString, " - Fin: ", Now.ToShortTimeString)
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return "Error Tiempo"
	End Function

	Private Sub WaitToPlay()
		Try
			Dim t As New Task(New Action(Sub()
											 For i As Integer = 20 To 0 Step -1
												 Dim J As Integer = i
												 If BTNplay.Text = "PLAY" Then Exit Sub
												 Try
													 Me.Invoke(Sub()
																   If BTNplay.Text = "PLAY" Then Exit Sub
																   Me.Text = String.Concat("Próximo en ", J.ToString)
																   If J = 0 Then ListoParaIniciar = True
																   Application.DoEvents()
															   End Sub)
												 Catch ex As Exception
													 MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
												 End Try
												 Threading.Thread.Sleep(1000)
											 Next
										 End Sub))
			t.Start()
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Public Sub SendMessaje(List As List(Of String))
		Try
			PrintCurrentLine()
			Try
				If List.Count >= 10 Then
					Dim TextToSend As String = ""
					Dim contador As Integer = 0

					For Each Line In List
						TextToSend += String.Concat(Line, Environment.NewLine, "___________________________", Environment.NewLine, Environment.NewLine, Environment.NewLine)
						contador += 1

						If contador = 10 Then
							contador = 0
							Sendd(TextToSend)
							TextToSend = ""
							Application.DoEvents()
						End If
					Next

					If TextToSend.Length > 0 Then
						Sendd(TextToSend)
						TextToSend = ""
						Application.DoEvents()
					End If
				Else
					For Each msj In List
						Sendd(msj)
						Application.DoEvents()
					Next
				End If
				ListaMensajes.Clear()
			Catch ex As Exception
				MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
			End Try
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Private Function Sendd(Txt As String) As Boolean
		Try
			PrintCurrentLine()
			If Txt = "" Then Return False
			If My.Computer.Network.IsAvailable Then
				If My.Settings.IDsTelegram = " " Or My.Settings.IDsTelegram = "" Then Return False
				Me.Invoke(Async Sub()
							  Try
								  If My.Settings.IDsTelegram.Contains(",") Then
									  For Each ID As String In My.Settings.IDsTelegram.Split(","c, StringSplitOptions.RemoveEmptyEntries).ToList
										  Await BOT.SendTextMessageAsync(ID, Txt, disableWebPagePreview:=True)
									  Next
								  Else
									  Await BOT.SendTextMessageAsync(My.Settings.IDsTelegram, Txt, disableWebPagePreview:=True)
								  End If
							  Catch ex As Exception
								  MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
							  End Try
							  Application.DoEvents()
						  End Sub)
			End If
			Return True
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return False
	End Function

	Public Sub LOG(Str As String)
		Try
			My.Computer.FileSystem.WriteAllText("seguimiento.dat", String.Concat(DateTime.Now.ToString(), " - ", Str, vbCrLf), True)
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Public Sub PrintCurrentLine()
		Try
			LOG(String.Concat("Line: ", New StackTrace(True).GetFrame(1).GetFileLineNumber.ToString, "				", New StackTrace(True).GetFrame(1).GetMethod().Name))
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub





End Class
















