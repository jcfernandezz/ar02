Public Class Form1
    Dim iLeidos As Integer
    Dim iIntegrados As Integer
    Dim iRechazados As Integer
    Dim CLeidos As Integer
    Dim CIntegrados As Integer
    Dim CRechazados As Integer
    Dim PLeidos As Integer
    Dim PIntegrados As Integer
    Dim PRechazados As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objGeneral As New GettyeConnectDLL.IntegraGPXML
        Dim IntegraGP As Boolean

        IntegraGP = objGeneral.IntegrarXML(Application.StartupPath, iLeidos, iIntegrados, iRechazados, CLeidos, CIntegrados, CRechazados)
        Me.Leidos.Text = CStr(iLeidos)
        Me.Integrados.Text = CStr(iIntegrados)
        Me.Rechazados.Text = CStr(iRechazados)
        Me.COMPLeidos.Text = CStr(CLeidos)
        Me.COMPIntegrados.Text = CStr(CIntegrados)
        Me.COMPRechazados.Text = CStr(CRechazados)
        Me.PREPLeidos.Text = CStr(PLeidos)
        Me.PREPIntegrados.Text = CStr(PIntegrados)
        Me.PREPRechazados.Text = CStr(PRechazados)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim objGeneral As New GettyeConnectDLL.IntegraGPXML
        Dim IntegraGP As Boolean

        IntegraGP = objGeneral.IntegrarValorpix(Application.StartupPath, "GPVALORPIX", iLeidos, iIntegrados, iRechazados, CLeidos, CIntegrados, CRechazados, PLeidos, PIntegrados, PRechazados)
        Me.Leidos.Text = CStr(iLeidos)
        Me.Integrados.Text = CStr(iIntegrados)
        Me.Rechazados.Text = CStr(iRechazados)
        Me.COMPLeidos.Text = CStr(CLeidos)
        Me.COMPIntegrados.Text = CStr(CIntegrados)
        Me.COMPRechazados.Text = CStr(CRechazados)
        Me.PREPLeidos.Text = CStr(PLeidos)
        Me.PREPIntegrados.Text = CStr(PIntegrados)
        Me.PREPRechazados.Text = CStr(PRechazados)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim objGeneral As New GettyeConnectDLL.IntegraGPXML
        Dim IntegraGP As Boolean

        IntegraGP = objGeneral.IntegrarXML(Application.StartupPath, iLeidos, iIntegrados, iRechazados, CLeidos, CIntegrados, CRechazados)

        Me.Leidos.Text = CStr(iLeidos)
        Me.Integrados.Text = CStr(iIntegrados)
        Me.Rechazados.Text = CStr(iRechazados)
        Me.COMPLeidos.Text = CStr(CLeidos)
        Me.COMPIntegrados.Text = CStr(CIntegrados)
        Me.COMPRechazados.Text = CStr(CRechazados)
        '        Me.TextBox1.Text = "Proceso finalizado ..."

    End Sub
End Class
