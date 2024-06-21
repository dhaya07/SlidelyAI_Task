
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Public Class Createsubmission
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim View As New Viewsubmission()


        View.NameTXT.Text = CRName.Text
        View.EmailTXT.Text = CREmail.Text
        View.PhoneNoTXT.Text = CRPhoneNo.Text
        View.GithubTXT.Text = CRGithub.Text
        View.TextBox5.Text = CRStopwatch.Text

        Dim json As String = JsonConvert.SerializeObject(New With {Key .formData = formData})

        Using client As New HttpClient()
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/api/save-data", content)


            If response.IsSuccessStatusCode Then
                Dim Viewsubmission As New Viewsubmission()
                Viewsubmission.NameTXT.Text = CRName.Text
                Viewsubmission.EmailTXT.Text = CREmail.Text
                Viewsubmission.PhoneNoTXT.Text = CRPhoneNo.Text
                Viewsubmission.GithubTXT.Text = CRGithub.Text
                Viewsubmission.TextBox5.Text = CRStopwatch.Text
                Viewsubmission.Show()
            Else
                MessageBox.Show("Error saving data")
            End If
        End Using

        View.Show()

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles CRStopwatch.TextChanged
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CRStopwatch.Text = CRStopwatch.Text + 1

    End Sub
End Class
