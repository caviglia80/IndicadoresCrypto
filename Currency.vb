
<Serializable()>
Public Class Currency


	Implements IDisposable
	Private disposed As Boolean = False

	Private _Name As String
	Public Property Name() As String
		Get
			Return _Name
		End Get
		Set(ByVal value As String)
			_Name = value
		End Set
	End Property

	Private _Rank As Integer
	Public Property Rank() As Integer
		Get
			Return _Rank
		End Get
		Set(ByVal value As Integer)
			_Rank = value
		End Set
	End Property

	Private _Precio As String
	Public Property Precio() As String
		Get
			Return _Precio
		End Get
		Set(ByVal value As String)
			_Precio = value
		End Set
	End Property

	Private _CapitalMercado As Long
	Public Property CapitalMercado() As Long
		Get
			Return _CapitalMercado
		End Get
		Set(ByVal value As Long)
			_CapitalMercado = value
		End Set
	End Property

	Private _Volumen As Long
	Public Property Volumen() As Long
		Get
			Return _Volumen
		End Get
		Set(ByVal value As Long)
			_Volumen = value
		End Set
	End Property

	Private _HTML As String
	Public Property HTML() As String
		Get
			Return _HTML
		End Get
		Set(ByVal value As String)
			_HTML = value
		End Set
	End Property

	Private _Listado As List(Of Currency)
	Public Property Listado() As List(Of Currency)
		Get
			Return _Listado
		End Get
		Set(ByVal value As List(Of Currency))
			_Listado = value
		End Set
	End Property

	Private _DateOfLastRead As DateTime
	Public Property DateOfLastRead() As DateTime
		Get
			Return _DateOfLastRead
		End Get
		Set(ByVal value As DateTime)
			_DateOfLastRead = value
		End Set
	End Property

	Private _AlerText As String
	Public Property AlerText() As String
		Get
			Return _AlerText
		End Get
		Set(ByVal value As String)
			_AlerText = value
		End Set
	End Property

	Private _AlerType As String
	Public Property AlerType() As String
		Get
			Return _AlerType
		End Get
		Set(ByVal value As String)
			_AlerType = value
		End Set
	End Property






	Private _AciertosCM As Integer
	Public Property AciertosCM() As Integer
		Get
			Return _AciertosCM
		End Get
		Set(ByVal value As Integer)
			_AciertosCM = value
		End Set
	End Property

	Private _AciertosVolumen As Integer
	Public Property AciertosVolumen() As Integer
		Get
			Return _AciertosVolumen
		End Get
		Set(ByVal value As Integer)
			_AciertosVolumen = value
		End Set
	End Property

	Private _AciertosRanking As Integer
	Public Property AciertosRanking() As Integer
		Get
			Return _AciertosRanking
		End Get
		Set(ByVal value As Integer)
			_AciertosRanking = value
		End Set
	End Property

	'Private _Aciertos_CM_Volumen As Integer
	'Public Property Aciertos_CM_Volumen() As Integer
	'	Get
	'		Return _Aciertos_CM_Volumen
	'	End Get
	'	Set(ByVal value As Integer)
	'		_Aciertos_CM_Volumen = value
	'	End Set
	'End Property


	'Private _VencimientoAciertos As DateTime
	'Public Property VencimientoAciertos() As DateTime
	'	Get
	'		Return _VencimientoAciertos
	'	End Get
	'	Set(ByVal value As DateTime)
	'		_VencimientoAciertos = value
	'	End Set
	'End Property














	Private ReadOnly Find_Name As String = "sc-1eb5slv-0 iworPT"
	Private ReadOnly Find_Rank As String = "sc-1eb5slv-0 etpvrL"
	Private ReadOnly Find_Precio As String = "sc-131di3y-0 cLgOOr"
	Private ReadOnly Find_CapitalMercado As String = "sc-1ow4cwt-1 ieFnWP"
	Private ReadOnly Find_Volumen As String = "sc-1eb5slv-0 hykWbK font_weight_500"
	Private ReadOnly Trim_Fin As String = "\u003C"









	'La necesito para serializar
	Public Sub New()
		_HTML = HTML
		_Name = ""
		_Rank = 0
		_Precio = "0"
		_CapitalMercado = 0
		_Volumen = 0
		_DateOfLastRead = DateTime.Now
		_AlerType = ""
		_AlerText = ""
		_AciertosCM = 0
		_AciertosVolumen = 0
		_AciertosRanking = 0
	End Sub


	Public Sub New(CurrencyToClone As Currency)
		_HTML = CurrencyToClone.HTML
		_Name = CurrencyToClone.Name
		_Rank = CurrencyToClone.Rank
		_Precio = CurrencyToClone.Precio
		_CapitalMercado = CurrencyToClone.CapitalMercado
		_Volumen = CurrencyToClone.Volumen
		_DateOfLastRead = CurrencyToClone.DateOfLastRead
		_AlerType = CurrencyToClone.AlerType
		_AlerText = CurrencyToClone.AlerText
		_AciertosCM = CurrencyToClone.AciertosCM
		_AciertosVolumen = CurrencyToClone.AciertosVolumen
		_AciertosRanking = CurrencyToClone.AciertosRanking
	End Sub





	Public Sub New(HTML As String)
		_HTML = HTML
		_Name = ""
		_Rank = 0
		_Precio = "0"
		_CapitalMercado = 0
		_Volumen = 0
		_DateOfLastRead = DateTime.Now
		_AlerType = ""
		_AlerText = ""
		_AciertosCM = 0
		_AciertosVolumen = 0
		_AciertosRanking = 0
		GetList()
	End Sub

	Public Sub New(Name As String, Rank As Integer, Precio As String, CapitalMercado As Long, Volumen As Long)
		_Name = Name
		_Rank = Rank
		_Precio = Precio
		_CapitalMercado = CapitalMercado
		_Volumen = Volumen
		_DateOfLastRead = DateTime.Now
		_AlerType = ""
		_AlerText = ""
		_AciertosCM = 0
		_AciertosVolumen = 0
		_AciertosRanking = 0
	End Sub

	Private Sub GetList()
		If _HTML = "" Then Return
		_Listado = New List(Of Currency)



		For Each parts As String In _HTML.Split(New String() {"icon-Star"}, StringSplitOptions.None)
			If parts.Length > 4000 Then Continue For
			If parts.Length < 10 Then Continue For

			Try
				Dim N As String = "null"
				Dim R As Integer = 0
				Dim P As String = "0"
				Dim CM As Long = 0
				Dim V As Long = 0

				If parts.Contains(Find_Name) Then
					N = parts.Split(New String() {Find_Name}, StringSplitOptions.None)(1).Split(New String() {">"}, StringSplitOptions.None)(1).Split(New String() {Trim_Fin}, StringSplitOptions.None)(0).Trim
				Else
					'ERROR
				End If

				If parts.Contains(Find_Rank) Then
					R = CInt(parts.Split(New String() {Find_Rank}, StringSplitOptions.None)(1).Split(New String() {">"}, StringSplitOptions.None)(1).Split(New String() {Trim_Fin}, StringSplitOptions.None)(0).Trim)
				Else
					'ERROR
				End If

				Try
					If parts.Contains(Find_Precio) Then
						P = parts.Split(New String() {Find_Precio}, StringSplitOptions.None)(1).Split(New String() {"$"}, StringSplitOptions.None)(1).Split(New String() {Trim_Fin}, StringSplitOptions.None)(0).Trim
					End If
				Catch
					P = "0"
				End Try


				If parts.Contains(Find_CapitalMercado) Then
					CM = CLng(parts.Split(New String() {Find_CapitalMercado}, StringSplitOptions.None)(1).Split(New String() {"$"}, StringSplitOptions.None)(1).Split(New String() {Trim_Fin}, StringSplitOptions.None)(0).Replace(",", "").Trim)
				End If

				If parts.Contains(Find_Volumen) Then
					V = CLng(parts.Split(New String() {Find_Volumen}, StringSplitOptions.None)(1).Split(New String() {"$"}, StringSplitOptions.None)(1).Split(New String() {Trim_Fin}, StringSplitOptions.None)(0).Replace(",", "").Trim)
				End If

				_Listado.Add(New Currency(N, R, P, CM, V))
			Catch ex As Exception
				Clipboard.SetText(parts)
				MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
			End Try
		Next

	End Sub









	Protected Overridable Sub Dispose(ByVal disposing As Boolean)
		If Not Me.disposed Then
			If disposing Then
				' Insert code to free managed resources.
				GC.Collect()
			End If
			' Insert code to free unmanaged resources.
			GC.Collect()
		End If
		Me.disposed = True
	End Sub

	Public Sub Dispose() Implements IDisposable.Dispose
		Dispose(True)
		GC.SuppressFinalize(Me)
	End Sub

	Protected Overrides Sub Finalize()
		Dispose(False)
		MyBase.Finalize()
	End Sub


	<System.Runtime.InteropServices.DllImport("Kernel32")>
	Private Shared Function CloseHandle(ByVal handle As IntPtr) As [Boolean]
	End Function


End Class








