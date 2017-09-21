Imports System
Imports System.IO
Imports ADODB
Imports Microsoft.Dynamics.GP.eConnect
Imports System.Xml
Public Class Form1
    Dim iLeidos As Integer
    Dim iIntegrados As Integer
    Dim iRechazados As Integer
    Dim CLeidos As Integer
    Dim CIntegrados As Integer
    Dim CRechazados As Integer
    Private Sub Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Ejecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ejecutar.Click
        Dim objGeneral As New GettyeConnectDLL.IntegraGPXML
        Dim IntegraGP As Boolean

        IntegraGP = objGeneral.IntegrarXML(Application.StartupPath, iLeidos, iIntegrados, iRechazados, CLeidos, CIntegrados, CRechazados)

        Me.Leidos.Text = CStr(iLeidos)
        Me.Integrados.Text = CStr(iIntegrados)
        Me.Rechazados.Text = CStr(iRechazados)
        Me.COMPLeidos.Text = CStr(CLeidos)
        Me.COMPIntegrados.Text = CStr(CIntegrados)
        Me.COMPRechazados.Text = CStr(CRechazados)
        Me.TextBox1.Text = "Proceso finalizado ..."

    End Sub
End Class
