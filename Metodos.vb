Imports System.IO
Imports System.Text.Json
Imports Newtonsoft.Json


Module Metodos




	Public Sub Serialize(path As String, List As List(Of Currency))
		Try
			File.WriteAllText(path, JsonConvert.SerializeObject(List, Newtonsoft.Json.Formatting.Indented))
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
	End Sub

	Public Function Deserialize(path As String) As List(Of Currency)
		Try



			Return JsonConvert.DeserializeObject(Of List(Of Currency))(File.ReadAllText(path))
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return New List(Of Currency)
	End Function

	Public Function SepararMiles(num As String) As String
		Try
			Return Format(Convert.ToInt64(num), "N").Replace(",00", "").Replace(".", ". ")
		Catch ex As Exception
			MsgBox(String.Concat(New StackTrace().GetFrame(0).GetMethod().Name, Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.ToString))
		End Try
		Return ""
	End Function









End Module




