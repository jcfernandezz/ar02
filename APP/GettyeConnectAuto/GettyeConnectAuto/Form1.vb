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
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objGeneral As New GettyeConnectDLL.IntegraGPXML
        Dim IntegraGP As Boolean

        IntegraGP = objGeneral.IntegrarXML(Application.StartupPath, iLeidos, iIntegrados, iRechazados, CLeidos, CIntegrados, CRechazados)

        Me.Close()

    End Sub
End Class
