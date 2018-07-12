Imports System
Imports System.IO
Imports ADODB
Imports Microsoft.Dynamics.GP.eConnect
Imports System.Xml
Imports System.Data.SqlClient
Public Class IntegraGPXML
    Dim strSrv As String
    Dim strDba As String
    Dim cnCustomer As ADODB.Recordset
    Dim sConnection As String
    Dim xmlDoc As XmlDocument
    Dim sCountry As String
    Dim iCustomer As Integer
    Dim sName As String
    Dim sShortName As String
    Dim sStatementName As String
    Dim sCuit As String
    Dim dCreditLimit As Double
    Dim sMainAddress1 As String
    Dim sMainAddress2 As String
    Dim sMainZip As String
    Dim sMainCity As String
    Dim sMainState As String
    Dim sMainCountryCode As String
    Dim sMainPhone As String
    Dim sMainFax As String
    Dim sBillingAddress1 As String
    Dim sBillingAddress2 As String
    Dim sBillingZip As String
    Dim sBillingCity As String
    Dim sBillingState As String
    Dim sBillingCountryCode As String
    Dim sBillingPhone As String
    Dim sBillingFax As String
    Dim sShippingAddress1 As String
    Dim sShippingAddress2 As String
    Dim sShippingZip As String
    Dim sShippingCity As String
    Dim sShippingState As String
    Dim sShippingCountryCode As String
    Dim sShippingPhone As String
    Dim sShippingFax As String
    Dim sTaxClasification As String
    Dim iStatus As Integer
    Dim iID As Integer
    Dim iLeidos As Integer
    Dim iIntegrados As Integer
    Dim iRechazados As Integer
    Dim CLeidos As Integer
    Dim CIntegrados As Integer
    Dim CRechazados As Integer
    Dim PLeidos As Integer
    Dim PIntegrados As Integer
    Dim PRechazados As Integer
    Dim FechaProceso As Date
    Dim ErrorIntegracion As String
    Dim sINTERID As String
    Dim iEmpresa As Integer
    Dim sContacto As String
    Dim dFechaVenc As Date
    Dim sPaymentType As String
    Dim sTxnID As String
    Dim dFechaEmision As String
    Dim sBillingCountryDatabase As String
    Dim OrigenDatos As String
    Dim sTEXTO As String
    Dim sPath As String
    Dim sArchivo As String
    Dim TXRGNNUM As String
    Dim strPath As String
    Public Function IntegrarXML(ByVal APPPath, ByRef CLILeidos, ByRef CLIIntegrados, ByRef CLIRechazados, ByRef COMPLeidos, ByRef COMPIntegrados, ByRef COMPRechazados)
        iLeidos = 0
        iIntegrados = 0
        iRechazados = 0
        CLeidos = 0
        CIntegrados = 0
        CRechazados = 0
        PLeidos = 0
        PIntegrados = 0
        PRechazados = 0
        FechaProceso = Now()
        strPath = APPPath
        'gGrabarLog("Antes Abrir INI", APPPath, CLeidos, CIntegrados, CRechazados)
        AbrirINI(APPPath)
        'gGrabarLog("Despues Abrir INI", APPPath, CLeidos, CIntegrados, CRechazados)
        gAbrirLog(APPPath)
        'gGrabarLog("Antes Armar Datos", APPPath, CLeidos, CIntegrados, CRechazados)
        ArmarDatos(APPPath)
        gGrabarLog("despues Armar Datos", APPPath, CLeidos, CIntegrados, CRechazados)
        ArmarDatosSOP(APPPath)
        'gGrabarLog("despues Armar Datos SOP", APPPath, CLeidos, CIntegrados, CRechazados)

        gCerrarLog(APPPath)
        'gGrabarLog("Antes cerrar log", APPPath, CLeidos, CIntegrados, CRechazados)
        CLILeidos = iLeidos
        CLIIntegrados = iIntegrados
        CLIRechazados = iRechazados
        COMPLeidos = CLeidos
        COMPIntegrados = CIntegrados
        COMPRechazados = CRechazados
        IntegrarXML = True
    End Function
    Public Function IntegrarValorpix(ByVal APPPath, ByVal SourceData, ByRef CLILeidos, ByRef CLIIntegrados, ByRef CLIRechazados, ByRef COMPLeidos, ByRef COMPIntegrados, ByRef COMPRechazados, ByRef PREPLeidos, ByRef PREPIntegrados, ByRef PREPRechazados)
        iLeidos = 0
        iIntegrados = 0
        iRechazados = 0
        CLeidos = 0
        CIntegrados = 0
        CRechazados = 0
        PLeidos = 0
        PIntegrados = 0
        PRechazados = 0
        OrigenDatos = SourceData
        FechaProceso = Now()
        AbrirINI(APPPath)
        gAbrirLog(APPPath)
        ArmarDatos(APPPath)
        ArmarDatosPrepago(APPPath)
        ArmarDatosSOP(APPPath)

        gCerrarLog(APPPath)
        CLILeidos = iLeidos
        CLIIntegrados = iIntegrados
        CLIRechazados = iRechazados
        COMPLeidos = CLeidos
        COMPIntegrados = CIntegrados
        COMPRechazados = CRechazados
        PREPLeidos = PLeidos
        PREPIntegrados = PIntegrados
        PREPRechazados = PRechazados
        IntegrarValorpix = True
    End Function
    Public Function ValorpixPrefetura(ByVal APPPath, ByVal SourceData, ByRef CLILeidos, ByRef CLIIntegrados, ByRef CLIRechazados, ByRef COMPLeidos, ByRef COMPIntegrados, ByRef COMPRechazados, ByRef PREPLeidos, ByRef PREPIntegrados, ByRef PREPRechazados, ByVal dFecha)
        iLeidos = 0
        iIntegrados = 0
        iRechazados = 0
        CLeidos = 0
        CIntegrados = 0
        CRechazados = 0
        PLeidos = 0
        PIntegrados = 0
        PRechazados = 0
        OrigenDatos = SourceData
        FechaProceso = dFecha
        AbrirINI(APPPath)
        gAbrirLog(APPPath)
        ArmarDatos(APPPath)
        ArmarDatosPrepago(APPPath)
        ArmarDatosSOP(APPPath)

        gCerrarLog(APPPath)
        CLILeidos = iLeidos
        CLIIntegrados = iIntegrados
        CLIRechazados = iRechazados
        COMPLeidos = CLeidos
        COMPIntegrados = CIntegrados
        COMPRechazados = CRechazados
        PREPLeidos = PLeidos
        PREPIntegrados = PIntegrados
        PREPRechazados = PRechazados
    End Function
    Public Function GeneraTXTPrefeitura(ByVal APPPath, ByVal dFecha)
        Dim SQLSTR As String
        Dim Actualizado As Boolean
        'Dim FinFactura As Boolean
        Dim invoice_id As Long
        'Dim LCLEidos As Integer

        CLeidos = 0
        CIntegrados = 0
        CRechazados = 0

        sArchivo = Trim(sPath) & "GP_PREFEITURA_" & Format(CDate(FechaProceso), "yyyyMMdd") & Format(CDate(FechaProceso), "HHmmssfff") & ".TXT"
        SQLSTR = "EXEC VALORPIX_TII..ACA_GP_TO_PREFEITURA '" & Format(CDate(FechaProceso), "yyyyMMdd") & "' "

        cnCustomer = New ADODB.Recordset
        cnCustomer.CursorType = CursorTypeEnum.adOpenStatic
        'cnCustomer.ActiveConnection.Connectiontimeout = 0

        cnCustomer.Open(SQLSTR, sConnection)

        dFechaEmision = Format(Now, "MM-dd-yyyy")
        If Not cnCustomer.EOF Then
            cnCustomer.MoveFirst()
            While Not cnCustomer.EOF
                CLeidos = CLeidos + 1

                sTEXTO = cnCustomer.Fields("TEXTO").Value
                TXRGNNUM = cnCustomer.Fields("TXRGNNUM").Value
                If CLeidos = 1 Then
                    gAbrirArchivo(sArchivo, sTEXTO)
                End If
                invoice_id = cnCustomer.Fields("invoice_id").Value
                If invoice_id <> 0 And invoice_id <> 99999999 Then
                    Actualizado = ActualizaRPS(invoice_id, cnCustomer.Fields("SOPNUMBE").Value, sTEXTO, _
                                        cnCustomer.Fields("SERIERPS").Value, _
                                        cnCustomer.Fields("NRORPS").Value, sArchivo, TXRGNNUM)
                End If
                'gGrabarArchivo(sArchivo, sTEXTO)

                cnCustomer.MoveNext()

            End While

        End If

        cnCustomer.Close()
        cnCustomer = Nothing

        'gGrabarLog("Comprobantes", APPPath, CLeidos, CIntegrados, CRechazados)

    End Function
    Public Function AbrirINI(ByVal AppPath)
        On Error GoTo Err_Main

        Dim sCmd As String
        Dim sCmpy As String
        Dim sErr As String
        Dim strArchivo As String

        Dim intI As Long
        Dim vntLineas() As Object
        Dim vDatos() As String
        If OrigenDatos = "" Then
            strArchivo = AppPath + "\param.ini"
        Else
            strArchivo = AppPath + "\" + Trim(OrigenDatos) + ".ini"
        End If
        gLeerArchivo(strArchivo, vntLineas)
        If UBound(vntLineas) >= 0 And vntLineas(0) <> "" Then
            For intI = LBound(vntLineas) To UBound(vntLineas)
                DesarmarLinea(vntLineas(intI), vDatos)
                strSrv = vDatos(0)
                strDba = vDatos(1)
            Next
        End If

        If strDba = "VALORPIX" Then
            sBillingCountryDatabase = "VALORPIX"
        Else
            sBillingCountryDatabase = "DYNAMICS"
        End If

        ' msgbox
        sConnection = ""
        sConnection = "Provider=sqloledb;" & _
           "Data Source=" & strSrv & ";" & _
           "Initial Catalog=" & strDba & ";" & _
        "Integrated Security=SSPI"
        '   "User Id=sa;Password=1"

        cnCustomer = New ADODB.Recordset
        cnCustomer.CursorType = CursorTypeEnum.adOpenStatic
        'cnCustomer.ActiveConnection.Connectiontimeout = 0

        cnCustomer.Open("SELECT @@VERSION AS NROVER", sConnection)

        cnCustomer.Close()
        cnCustomer = Nothing
        Exit Function

Err_Main:
        Console.Write("No se pudo conectar al servidor")

    End Function
    Public Function ArmarDatos(ByVal APPPath)
        Dim SQLSTR As String
        Dim sXML As String
        Dim Integrado As Boolean
        Dim ClienteIntegrado As Integer
        Dim Actualizado, bExistsCustomer As Boolean
        Dim Cliente As String
        Dim strSql As String
        Dim mycon As SqlConnection
        Dim mycon2 As SqlConnection
        Dim StrError As String
        Dim Resultado As Integer
        Dim sSERVER As String
        'Dim comUserSelect As SqlCommand
        'Dim myreader As SqlDataReader

        'SQLSTR = "SELECT * FROM " & strDba & "..INT_USER_VIEW where country='Argentina'"
        SQLSTR = "SELECT * FROM " & strDba & "..INT_USER_VIEW "

        'gGrabarLog("Armar Datos Antes cnCustomer new", APPPath, CLeidos, CIntegrados, CRechazados)
        'mycon2 = New SqlConnection("Data Source=" & strSrv & "; Initial Catalog=" & strDba & "; Integrated Security=SSPI")
        'comUserSelect = New SqlCommand(SQLSTR, mycon2)
        'comUserSelect.CommandTimeout() = 0
        'mycon2.Open()

        'myreader = comUserSelect.ExecuteReader

        'While (myreader.Read = True)


        cnCustomer = New ADODB.Recordset
        cnCustomer.CursorType = CursorTypeEnum.adOpenStatic


        'gGrabarLog("Armar Datos Antes cnCustomer OPEN: " & sConnection, APPPath, CLeidos, CIntegrados, CRechazados)
        'gGrabarLog("Armar Datos Antes cnCustomer OPEN: " & SQLSTR, APPPath, CLeidos, CIntegrados, CRechazados)
        cnCustomer.Open(SQLSTR, sConnection)
        'cnCustomer.ActiveConnection.ConnectionTimeout = 0

        'gGrabarLog("Armar Datos despues cnCustomer OPEN: " & SQLSTR, APPPath, CLeidos, CIntegrados, CRechazados)

        If Not cnCustomer.EOF Then
            'gGrabarLog("Armar Datos cnCustomer antes primer registro", APPPath, CLeidos, CIntegrados, CRechazados)
            cnCustomer.MoveFirst()
            'gGrabarLog("Armar Datos cnCustomer despues primer registro", APPPath, CLeidos, CIntegrados, CRechazados)
            While Not cnCustomer.EOF
                'gGrabarLog("Armar Datos nueva lectura cnCustomer", APPPath, CLeidos, CIntegrados, CRechazados)
                iLeidos = iLeidos + 1
                sSERVER = Trim(cnCustomer.Fields("SERVIDOR").Value)
                'gGrabarLog("Leyó SERVIDOR ", APPPath, CLeidos, CIntegrados, CRechazados)
                sINTERID = Trim(cnCustomer.Fields("INTERID").Value)
                'gGrabarLog("Leyó INTERID ", APPPath, CLeidos, CIntegrados, CRechazados)
                sCountry = cnCustomer.Fields("Country").Value
                If Trim(sINTERID) <> "GBRA" Then
                    'MsgBox("Acá está " & sINTERID)
                    iCustomer = cnCustomer.Fields("Customer").Value
                    'gGrabarLog("Leyó Customer ", APPPath, CLeidos, CIntegrados, CRechazados)
                    iEmpresa = cnCustomer.Fields("Empresa").Value
                    'gGrabarLog("Leyó Empresa ", APPPath, CLeidos, CIntegrados, CRechazados)
                    If iEmpresa <> 0 Then
                        Cliente = Microsoft.VisualBasic.Right("00000000" & CStr(iEmpresa), 9)
                    Else
                        Cliente = "U" & Microsoft.VisualBasic.Right("00000000" & CStr(iCustomer), 8)
                    End If
                Else
                    Cliente = cnCustomer.Fields("Customer").Value
                End If
                sName = cnCustomer.Fields("Name").Value
                'gGrabarLog("Leyó Nombre ", APPPath, CLeidos, CIntegrados, CRechazados)
                'sName = Replace(sName, "&", "y")
                sShortName = cnCustomer.Fields("ShortName").Value
                'gGrabarLog("Leyó ShortName ", APPPath, CLeidos, CIntegrados, CRechazados)
                'sShortName = Replace(sShortName, "&", "y")
                sStatementName = cnCustomer.Fields("StatementName").Value
                'gGrabarLog("Leyó StatementName ", APPPath, CLeidos, CIntegrados, CRechazados)
                'sStatementName = Replace(sStatementName, "&", "y")
                sContacto = cnCustomer.Fields("Contact").Value
                'gGrabarLog("Leyó Contact ", APPPath, CLeidos, CIntegrados, CRechazados)
                bExistsCustomer = True
                If Not CHECKCUSTOMER(sSERVER, sINTERID, Cliente) Then
                    bExistsCustomer = False
                    sTaxClasification = cnCustomer.Fields("TaxClasification").Value
                    'gGrabarLog("Leyó TaxClasification ", APPPath, CLeidos, CIntegrados, CRechazados)
                    If Trim(sINTERID) = "ARTST" Or Trim(sINTERID) = "GARG" Or Trim(sINTERID) = "ARG10" Then
                        If Len(Replace(cnCustomer.Fields("CUIT_NIC").Value, "-", "")) <> 0 Then
                            sCuit = Replace(cnCustomer.Fields("CUIT_NIC").Value, "-", "") & "            80"
                        Else
                            sCuit = ""
                        End If
                    Else
                        sCuit = Microsoft.VisualBasic.Left(cnCustomer.Fields("CUIT_NIC").Value, 25)
                    End If
                    dCreditLimit = CDbl(cnCustomer.Fields("CreditLimit").Value)
                End If
                sMainAddress1 = cnCustomer.Fields("Address1").Value
                sMainAddress2 = cnCustomer.Fields("Address2").Value
                sMainZip = cnCustomer.Fields("Zip").Value
                sMainCity = cnCustomer.Fields("City").Value
                sMainState = cnCustomer.Fields("State").Value
                sMainCountryCode = cnCustomer.Fields("Countrycode").Value
                sMainPhone = cnCustomer.Fields("Phone").Value
                sMainFax = cnCustomer.Fields("Fax").Value
                'iStatus = cnCustomer.Fields("Status").Value
                'iID = cnCustomer.Fields("ID").Value

                'gGrabarLog("Comienza XML ", APPPath, CLeidos, CIntegrados, CRechazados)
                sXML = "<!-- Customer Create -->" & vbNewLine
                sXML = sXML & "<eConnect xmlns:dt=""urn:schemas-microsoft-com:datatypes"">" & vbNewLine
                sXML = sXML & "    <RMCustomerMasterType>" & vbNewLine
                sXML = sXML & "		<taUpdateCreateCustomerRcd>" & vbNewLine
                sXML = sXML & "           " & ArmarLineaXML(Cliente, "CUSTNMBR", "")
                If sName = "" Then
                    sXML = sXML & "           " & ArmarLineaXML(sContacto, "CUSTNAME", "1")
                Else
                    sXML = sXML & "           " & ArmarLineaXML(sName, "CUSTNAME", "1")
                End If
                sXML = sXML & "           " & ArmarLineaXML(sStatementName, "STMTNAME", "1")
                If Not bExistsCustomer Then
                    If Trim(sINTERID) = "GARG" Or sINTERID = "ARTST" Or sINTERID = "ARG10" Then
                        If Trim(sTaxClasification) = "IVA Inscripto" Then
                            sXML = sXML & "           " & ArmarLineaXML("CLIE A", "CUSTCLAS", "")
                        Else
                            If Microsoft.VisualBasic.Left(Trim(sTaxClasification), 3) = "Exp" Then
                                sXML = sXML & "           " & ArmarLineaXML("CLIE E", "CUSTCLAS", "")
                            Else
                                sXML = sXML & "           " & ArmarLineaXML("CLIE B", "CUSTCLAS", "")
                            End If
                        End If
                    Else
                        sXML = sXML & "           " & ArmarLineaXML(CLASSID(sINTERID, sSERVER), "CUSTCLAS", "")
                    End If
                End If
                sXML = sXML & "           " & ArmarLineaXML(sShortName, "SHRTNAME", "1")
                sXML = sXML & "           " & ArmarLineaXML("MAIN", "ADRSCODE", "")
                sXML = sXML & "           " & ArmarLineaXML(sContacto, "CNTCPRSN", "1")
                sXML = sXML & "           " & ArmarLineaXML(sMainAddress1, "ADDRESS1", "1")
                sXML = sXML & "           " & ArmarLineaXML(sMainAddress2, "ADDRESS2", "1")
                sXML = sXML & "           " & ArmarLineaXML(sMainCity, "CITY", "1")
                sXML = sXML & "           " & ArmarLineaXML(sMainState, "STATE", "1")
                sXML = sXML & "           " & ArmarLineaXML(sMainZip, "ZIPCODE", "1")
                sXML = sXML & "           " & ArmarLineaXML(sMainCountryCode, "COUNTRY", "1")
                'If Not bExistsCustomer Then
                sXML = sXML & "           " & ArmarLineaXML(Trim(sMainPhone), "PHNUMBR1", "1")
                'End If
                sXML = sXML & "           " & ArmarLineaXML(sMainFax, "FAX", "1")
                sXML = sXML & "           " & ArmarLineaXML("MAIN", "PRBTADCD", "")
                sXML = sXML & "           " & ArmarLineaXML("MAIN", "PRSTADCD", "")
                sXML = sXML & "           " & ArmarLineaXML("MAIN", "STADDRCD", "")
                If Not bExistsCustomer Then
                    sXML = sXML & "           " & ArmarLineaXML(sTaxClasification, "USERDEF1", "")
                End If
                'sXML = sXML & "           " & ArmarLineaXML("2", "CRLMTTYP")
                'sXML = sXML & "           " & ArmarLineaXML(Str(dCreditLimit), "CRLMTAMT")
                If Not bExistsCustomer Then
                    sXML = sXML & "           " & ArmarLineaXML(sCuit, "TXRGNNUM", "1")
                End If
                sXML = sXML & "           <KPCALHST>1</KPCALHST>" & vbNewLine
                If Not bExistsCustomer Then
                    sXML = sXML & "           <UseCustomerClass>1</UseCustomerClass>" & vbNewLine
                    sXML = sXML & "           <UpdateIfExists>0</UpdateIfExists>" & vbNewLine
                Else
                    sXML = sXML & "           <UpdateIfExists>1</UpdateIfExists>" & vbNewLine
                End If
                sXML = sXML & "		</taUpdateCreateCustomerRcd>" & vbNewLine
                'sXML = sXML & "		<taCreateCustomerAddress>" & vbNewLine
                'sXML = sXML & "           " & ArmarLineaXML(iCustomer, "CUSTNMBR")
                'sXML = sXML & "           " & ArmarLineaXML("BILLING", "ADRSCODE")
                'sXML = sXML & "           " & ArmarLineaXML(sBillingAddress1, "ADDRESS1")
                'sXML = sXML & "           " & ArmarLineaXML(sBillingAddress2, "ADDRESS2")
                'sXML = sXML & "           " & ArmarLineaXML(sBillingCity, "CITY")
                'sXML = sXML & "           " & ArmarLineaXML(sBillingState, "STATE")
                'sXML = sXML & "           " & ArmarLineaXML(sBillingZip, "ZIPCODE")
                'sXML = sXML & "           " & ArmarLineaXML(sBillingCountryCode, "COUNTRY")
                'sXML = sXML & "           " & ArmarLineaXML(sBillingPhone, "PHNUMBR1")
                'sXML = sXML & "           " & ArmarLineaXML(sBillingFax, "FAX")
                'sXML = sXML & "		</taCreateCustomerAddress>" & vbNewLine
                'sXML = sXML & "		<taCreateCustomerAddress>" & vbNewLine
                'sXML = sXML & "           " & ArmarLineaXML(iCustomer, "CUSTNMBR")
                'sXML = sXML & "           " & ArmarLineaXML("SHIPPING", "ADRSCODE")
                'sXML = sXML & "           " & ArmarLineaXML(sShippingAddress1, "ADDRESS1")
                'sXML = sXML & "           " & ArmarLineaXML(sShippingAddress2, "ADDRESS2")
                'sXML = sXML & "           " & ArmarLineaXML(sShippingCity, "CITY")
                'sXML = sXML & "           " & ArmarLineaXML(sShippingState, "STATE")
                'sXML = sXML & "           " & ArmarLineaXML(sShippingZip, "ZIPCODE")
                'sXML = sXML & "           " & ArmarLineaXML(sShippingCountryCode, "COUNTRY")
                'sXML = sXML & "           " & ArmarLineaXML(sShippingPhone, "PHNUMBR1")
                'sXML = sXML & "           " & ArmarLineaXML(sShippingFax, "FAX")
                'sXML = sXML & "		</taCreateCustomerAddress>" & vbNewLine
                sXML = sXML & "	</RMCustomerMasterType>" & vbNewLine
                sXML = sXML & "</eConnect>"
                'gGrabarLog(sXML, APPPath, iLeidos, iIntegrados, iRechazados)

                'gGrabarLog("Antes IntegraXML " & sXML, APPPath, CLeidos, CIntegrados, CRechazados)
                Integrado = IntegraXML(sSERVER, sINTERID, sXML, ErrorIntegracion)
                gGrabarLog("Despues IntegraXML " & ErrorIntegracion, APPPath, CLeidos, CIntegrados, CRechazados)
                If Integrado = True Then
                    iIntegrados = iIntegrados + 1
                    ClienteIntegrado = 1
                    If Trim(sINTERID) <> "GBRA" Then
                        Actualizado = Actualiza(sSERVER, iCustomer, sINTERID, FechaProceso, ClienteIntegrado, ErrorIntegracion)
                    Else
                        Actualizado = Actualiza(sSERVER, Cliente, sINTERID, FechaProceso, ClienteIntegrado, ErrorIntegracion)

                    End If
                Else
                    If Trim(sINTERID) <> "GBRA" Then
                        Actualizado = Actualiza(sSERVER, iCustomer, sINTERID, FechaProceso, ClienteIntegrado, ErrorIntegracion)
                    Else
                        Actualizado = Actualiza(sSERVER, Cliente, sINTERID, FechaProceso, ClienteIntegrado, ErrorIntegracion)

                    End If
                    iRechazados = iRechazados + 1
                    ClienteIntegrado = 0
                    If VerificarACA_Set_Customer_Error(sSERVER, sINTERID) Then
                        mycon = New SqlConnection("Data Source=" & sSERVER & "; Initial Catalog=" & sINTERID & "; Integrated Security=SSPI")
                        mycon.Open()

                        Dim cmd4 As SqlCommand = New SqlCommand(sINTERID & "..ACA_Set_Customer_Error", mycon)

                        cmd4.CommandType = CommandType.StoredProcedure

                        If Trim(sINTERID) = "ARTST" Or Trim(sINTERID) = "GARG" Or Trim(sINTERID) = "ARG10" Then
                            If Len(Replace(cnCustomer.Fields("CUIT_NIC").Value, "-", "")) <> 0 Then
                                sCuit = Replace(cnCustomer.Fields("CUIT_NIC").Value, "-", "") & "            80"
                            Else
                                sCuit = ""
                            End If
                        Else
                            sCuit = Microsoft.VisualBasic.Left(cnCustomer.Fields("CUIT_NIC").Value, 25)
                        End If
                        cmd4.Parameters.Add("@I_vCUSTNMBR", SqlDbType.Char, 15, ParameterDirection.Input).Value = Cliente.Trim
                        cmd4.Parameters.Add("@I_vTXRGNNUM", SqlDbType.Char, 15, ParameterDirection.Input).Value = sCuit.Trim
                        'cmd4.CommandTimeout = 0

                        Resultado = cmd4.ExecuteNonQuery

                        mycon.Close()
                        mycon = Nothing
                        cmd4 = Nothing
                    End If

                End If
                '                Else
                '                ClienteIntegrado = 0
                '                ErrorIntegracion = "El cliente ya existe"
                '                Actualizado = Actualiza(iCustomer, iStatus, sINTERID, FechaProceso, ClienteIntegrado, ErrorIntegracion)
                '                iRechazados = iRechazados + 1

                '                End If

                mycon = New SqlConnection("Data Source=" & sSERVER & "; Initial Catalog=" & sINTERID & "; Integrated Security=SSPI")
                mycon.Open()

                'gGrabarLog("Despues abrir conexion SQL para crear vendedores", APPPath, iLeidos, iIntegrados, iRechazados)
                Dim cmd1 As SqlCommand = New SqlCommand("IF EXISTS(SELECT name from sysobjects WHERE name = 'ACA_CREAR_VENDEDORES' AND xtype = 'P') BEGIN EXEC ACA_CREAR_VENDEDORES END ", mycon)

                cmd1.CommandType = CommandType.Text

                'cmd1.CommandTimeout = 0

                Resultado = cmd1.ExecuteNonQuery

                'gGrabarLog("Despues ejecutar conexion SQL para crear vendedores", APPPath, iLeidos, iIntegrados, iRechazados)

                mycon.Close()
                mycon = Nothing
                cmd1 = Nothing

                'gGrabarLog("Clientes", APPPath, iLeidos, iIntegrados, iRechazados)

                cnCustomer.MoveNext()
            End While
        Else
            'gGrabarLog("Armar Datos cnCustomer sin datos", APPPath, CLeidos, CIntegrados, CRechazados)

        End If
        'gGrabarLog("Antes cnCustomer close", APPPath, CLeidos, CIntegrados, CRechazados)
        cnCustomer.Close()
        'gGrabarLog("Despues cnCustomer close", APPPath, CLeidos, CIntegrados, CRechazados)
        cnCustomer = Nothing
        gGrabarLog("Despues cnCustomer nothing", APPPath, CLeidos, CIntegrados, CRechazados)
        'myreader.Close()
        'mycon2.Close()
        'comUserSelect = Nothing

    End Function
    Public Function VerificarACA_Set_Customer_Error(ByVal sSERVIDOR, ByVal INTERID) As Boolean
        Dim rs As ADODB.Recordset
        Dim SQLSTR As String
        Dim sConnect As String

        sConnect = ""
        sConnect = "Provider=sqloledb;" & _
           "Data Source=" & sSERVIDOR & ";" & _
           "Initial Catalog=" & INTERID & ";" & _
        "Integrated Security=SSPI"

        rs = New ADODB.Recordset
        rs.CursorType = CursorTypeEnum.adOpenStatic

        SQLSTR = "SELECT name FROM " + Trim(INTERID) + "..sysobjects WHERE name = 'ACA_Set_Customer_Error' AND xtype = 'P' "

        rs.Open(SQLSTR, sConnect)

        If Not rs.EOF Then
            rs.MoveFirst()
            While Not rs.EOF
                VerificarACA_Set_Customer_Error = True
                Exit While
            End While
        Else
            VerificarACA_Set_Customer_Error = False
        End If

        rs.Close()

        rs = Nothing

    End Function
    Public Function VerificarACA_Set_Invoice_Error(ByVal sSERVIDOR, ByVal INTERID) As Boolean
        Dim rs As ADODB.Recordset
        Dim SQLSTR As String
        Dim sConnect As String

        sConnect = ""
        sConnect = "Provider=sqloledb;" & _
           "Data Source=" & sSERVIDOR & ";" & _
           "Initial Catalog=" & INTERID & ";" & _
        "Integrated Security=SSPI"

        rs = New ADODB.Recordset
        rs.CursorType = CursorTypeEnum.adOpenStatic

        SQLSTR = "SELECT name FROM " + Trim(INTERID) + "..sysobjects WHERE name = 'ACA_Set_Invoice_Error' AND xtype = 'P' "

        rs.Open(SQLSTR, sConnect)

        If Not rs.EOF Then
            rs.MoveFirst()
            While Not rs.EOF
                VerificarACA_Set_Invoice_Error = True

                Exit While
            End While
        Else
            VerificarACA_Set_Invoice_Error = False
        End If

        rs.Close()

        rs = Nothing

    End Function
    Public Function ArmarLineaXML(ByVal sDato, ByVal sNombre, ByVal sData)
        Dim sDato2 As String
        sDato2 = sDato
        If Trim(sDato2) = "" Then
            'ArmarLineaXML = ""
            ' Exit Function
            ArmarLineaXML = "<" & Trim(sNombre) & "></" & Trim(sNombre) & ">" & vbNewLine
        Else
            If sData = "1" Then
                ArmarLineaXML = "<" & Trim(sNombre) & ">" & "<![CDATA[" & Trim(sDato2) & "]]></" & Trim(sNombre) & ">" & vbNewLine
            Else
                ArmarLineaXML = "<" & Trim(sNombre) & ">" & Trim(sDato2) & "</" & Trim(sNombre) & ">" & vbNewLine
            End If
        End If
    End Function
    Public Function gLeerArchivo(ByVal sArchivo As String, ByRef vntLineasArchivo() As Object) As Boolean

        Dim intConta As Long

        Try

            intConta = 0
            ReDim vntLineasArchivo(intConta)

            ' Create an instance of StreamReader to read from a file.
            Using sr As StreamReader = New StreamReader(sArchivo)
                Dim line As String
                ' Read and display the lines from the file until the end 
                ' of the file is reached.
                Do
                    ReDim Preserve vntLineasArchivo(intConta) 'Redimensiono el vector para agregar una nueva linea
                    vntLineasArchivo(intConta) = sr.ReadLine()  'Guardo en el vector la linea leida
                    intConta = intConta + 1 'Incremento el contador de posiciones
                Loop Until line Is Nothing
            End Using
            gLeerArchivo = True


        Catch E As Exception
            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(E.Message)
        End Try

    End Function
    Public Function DesarmarLinea(ByVal sLinea As String, ByRef vDatos() As String)
        Dim i As Integer
        Dim iPos As Integer

        i = 0
        ReDim vDatos(i)
        iPos = InStr(1, sLinea, ";", vbTextCompare)
        While iPos <> 0
            ReDim Preserve vDatos(i)
            vDatos(i) = Microsoft.VisualBasic.Left(sLinea, iPos - 1)
            sLinea = Microsoft.VisualBasic.Right(sLinea, Len(sLinea) - iPos)
            i = i + 1
            iPos = InStr(1, sLinea, ";", vbTextCompare)
        End While

    End Function
    Public Function GetNextCashNumber(ByVal sServer, ByVal sCompany)
        'Instantiate a GetNextDocNumbers object
        Dim NextDocNumberObject As New GetNextDocNumbers
        Dim ConnectionString As String

        ConnectionString = Conexion(sServer, sCompany)

        GetNextCashNumber = NextDocNumberObject.GetNextRMNumber(IncrementDecrement.Increment, RMPaymentType.RMPayments, ConnectionString)
        'MSAL 28-08-2015
        'GetNextCashNumber = NextDocNumberObject.GetNextIVNumber(GetNextDocNumbers.IncrementDecrement.Increment, GetNextDocNumbers.RMPaymentType.RMPayments, ConnectionString)


    End Function
    Public Function IntegraXML(ByVal sServer As String, ByVal sCompany As String, ByVal sXML As String, ByRef strErrorEconnect As String)

        Dim eConnResult As Boolean
        Dim ConnectionString As String

        'Instantiate an eConnectMethods object
        Dim eConnObject As New eConnectMethods

        'gGrabarLog("IntegraXML Antes Conexion " & sServer & sCompany, "", CLeidos, CIntegrados, CRechazados)
        ConnectionString = Conexion(sServer, sCompany)
        'gGrabarLog("IntegraXML Despues Conexion " & sServer & sCompany, "", CLeidos, CIntegrados, CRechazados)

        Try
            'Clear the textbox that displays the result
            strErrorEconnect = ""

            'Create an XmlDocument object and set it to preserve the doc structure
            xmlDoc = New XmlDocument
            xmlDoc.PreserveWhitespace = True

            'Load the current contents of the XmlDoc_TextBox control into the xmlDoc object
            'MsgBox(sXML)
            xmlDoc.LoadXml(sXML)

            'If the update returned TRUE, it was successfully completed
            'MSAL 28-08-2015
            'Se reemplaza eConnectEntryPoint por CreateEntity(), revisar si no hay que reemplazarla por Update Entity o Creaatte Entity
            eConnResult = eConnObject.CreateEntity(ConnectionString, xmlDoc.OuterXml)
            '-eConnResult = eConnObject.eConnect_EntryPoint(ConnectionString, EnumTypes.ConnectionStringType.SqlClient, xmlDoc.OuterXml, EnumTypes.SchemaValidationType.None)
            If eConnResult = True Then
                'If the method returned TRUE, notify the user of a successful operation.
                strErrorEconnect = "XML document was successfully submitted by eConnect"

                IntegraXML = True

            Else
                'If the method returned FALSE, notify the user
                'Typically, an exception would also occur which should be trapped by the Catch block
                strErrorEconnect = "XML document could not be submitted"

                IntegraXML = False

            End If
        Catch eConnErr As eConnectException
            strErrorEconnect = eConnErr.Message
            IntegraXML = False
        Catch ex As ApplicationException
            strErrorEconnect = ex.Message
            IntegraXML = False
        End Try

    End Function

    Public Function IntegraTrxXML(ByVal sServer As String, ByVal sCompany As String, ByVal sXML As String, ByRef strErrorEconnect As String)

        Dim eConnResult As String
        Dim ConnectionString As String

        'Instantiate an eConnectMethods object
        Dim eConnObject As New eConnectMethods

        gGrabarLog("IntegraXML Conexion " & sServer & "-" & sCompany, strPath, CLeidos, CIntegrados, CRechazados)
        ConnectionString = Conexion(sServer, sCompany)
        'gGrabarLog("IntegraXML Despues Conexion " & sServer & sCompany, "", CLeidos, CIntegrados, CRechazados)

        Try
            'Clear the textbox that displays the result
            strErrorEconnect = ""

            'Create an XmlDocument object and set it to preserve the doc structure
            xmlDoc = New XmlDocument
            xmlDoc.PreserveWhitespace = True

            'Load the current contents of the XmlDoc_TextBox control into the xmlDoc object
            'MsgBox(sXML)
            xmlDoc.LoadXml(sXML)

            'If the update returned TRUE, it was successfully completed
            'MSAL 28-08-2015
            'Se reemplaza eConnectEntryPoint por CreateEntity(), revisar si no hay que reemplazarla por Update Entity o Creaatte Entity
            'gGrabarLog("IntegraTrxXML Antes Entity: " & sXML, strPath, CLeidos, CIntegrados, CRechazados)
            eConnResult = eConnObject.CreateTransactionEntity(ConnectionString, sXML) 'xmlDoc.OuterXml)
            gGrabarLog("IntegraTrxXML DEspues Entity: " & eConnResult, strPath, CLeidos, CIntegrados, CRechazados)
            'eConnResult = eConnObject.eConnect_EntryPoint(ConnectionString, EnumTypes.ConnectionStringType.SqlClient, xmlDoc.OuterXml, EnumTypes.SchemaValidationType.None)
            IntegraTrxXML = True
            strErrorEconnect = "XML document was successfully submitted by eConnect"

            'Exit Function
            'If eConnResult = True Then
            'If the method returned TRUE, notify the user of a successful operation.
            'strErrorEconnect = "XML document was successfully submitted by eConnect"

            'IntegraTrxXML = True

            'Else
            'If the method returned FALSE, notify the user
            'Typically, an exception would also occur which should be trapped by the Catch block
            'strErrorEconnect = "XML document could not be submitted"

            'IntegraTrxXML = False

            'End If
        Catch eConnErr As eConnectException
            gGrabarLog("Porque sale con error? 1)" & eConnErr.Message, strPath, CLeidos, CIntegrados, CRechazados)
            strErrorEconnect = eConnErr.Message
            IntegraTrxXML = False
        Catch ex As ApplicationException
            gGrabarLog("Porque sale con error? 2)", strPath, CLeidos, CIntegrados, CRechazados)
            strErrorEconnect = ex.Message
            IntegraTrxXML = False
        End Try

    End Function

    Public Function ActualizaRPS(ByVal ID, ByVal SOPNUMBE, ByVal Serie, ByVal NroRPS, ByVal TXTRegistro, ByVal TXTArchivo, ByVal TXRGNNUM)
        Dim rs As ADODB.Connection
        Dim strSQL As String
        Dim sConeccion As String
        Dim IntegradaFC As Integer
        Dim IntegradoSTR As String
        Dim dfecha As String

        rs = New ADODB.Connection
        'rs.CursorType = CursorTypeEnum.adOpenStatic

        sConeccion = "Provider=sqloledb;" & _
           "Data Source=" & strSrv & ";" & _
           "Initial Catalog=" & sINTERID & ";" & _
            "Integrated Security=SSPI"
        IntegradaFC = 0
        IntegradoSTR = " sync_version_erp = sync_version_st, "

        strSQL = "INSERT INTO VALORPIX_TII..RPS_Generados " & _
                    CStr(ID) & ", '" & _
                    SOPNUMBE & "', '" & TXRGNNUM & "', '" & Serie & "', '" & NroRPS & "', '" & _
                    dfecha & _
                    " ProcessedDate = '" & Format(CDate(Now()), "yyyyMMdd") & " " & Format(CDate(Now()), "HH:mm:ss") & "' " & _
                    " WHERE invoice_id = " & CStr(ID)

        rs.Open(sConeccion)
        rs.Execute(strSQL)

        rs.Close()

        rs = Nothing

        'ActualizaSOP = True
    End Function

    Public Function Conexion(ByVal sServidor, ByVal sCompania)
        Dim ConnectionString As String

        'gGrabarLog("Conexion 1 " & sServidor & sCompania, "", CLeidos, CIntegrados, CRechazados)
        ConnectionString = "Data Source=" & sServidor & _
            ";Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" & sCompania & ";"
        'gGrabarLog("Conexion 2 " & sServidor & sCompania, "", CLeidos, CIntegrados, CRechazados)
        'ConnectionString = "Data Source=" & sServidor & _
        '    ";User Id=sa;Password=1;Persist Security Info=False;Initial Catalog=" & sCompania & ";"

        Conexion = ConnectionString

    End Function
    Public Function Actualiza(ByVal sSERVIDOR, ByVal ID, ByVal INTERID, ByVal Fecha, ByVal CustIntegrado, ByVal Mensaje)
        Dim rs As ADODB.Connection
        Dim strSQL As String
        Dim sConeccion As String
        Dim IntegradoSTR As String

        rs = New ADODB.Connection
        'rs.CursorType = CursorTypeEnum.adOpenStatic
        'rs.CommandTimeout = 0

        'MSAL 28-06-2018.Actualizo en el mismo servidor que levanto la vista INT_USER_VIEW
        'sConeccion = "Provider=sqloledb;" & _
        '   "Data Source=" & sSERVIDOR & ";" & _
        '   "Initial Catalog=" & INTERID & ";" & _
        '    "Integrated Security=SSPI"

        sConeccion = "Provider=sqloledb;" & _
           "Data Source=" & strSrv & ";" & _
           "Initial Catalog=" & strDba & ";" & _
            "Integrated Security=SSPI"


        If CustIntegrado = 1 Then
            IntegradoSTR = " sync_version_erp = sync_version_st, "
        Else
            IntegradoSTR = ""
        End If
        strSQL = "UPDATE " & strDba & "..ERP_Organisation SET "
        strSQL = strSQL & IntegradoSTR
        strSQL = strSQL & " integrated = " & CStr(CustIntegrado) & ", "
        strSQL = strSQL & " processed = '" & Format(CDate(Now()), "yyyyMMdd") & " " & Format(CDate(Now()), "hh:mm:ss") & "', "
        strSQL = strSQL & " int_message = '" & Microsoft.VisualBasic.Left(Mensaje, 255) & "' "
        strSQL = strSQL & " WHERE merged_org_id = '" & CStr(ID) & "' "
        rs.Open(sConeccion)
        rs.Execute(strSQL)
        rs.Close()

        'strSQL = strSQL & Chr(13) & " UPDATE " & strDba & "..ERP_User_Accounting_Assigned_Credit SET "
        'If CustIntegrado = 1 Then
        ' strSQL = strSQL & " sync_version_erp = " & CStr(iStatus) & " "
        'End If
        'strSQL = strSQL & " WHERE user_id = " & CStr(ID)
        'rs.Open(sConeccion)
        'rs.Execute(strSQL)
        'rs.Close()

        rs = Nothing

        Actualiza = True
    End Function
    Public Function ActualizaSOP(ByVal sSERVIDOR, ByVal ID, ByVal INTERID, ByVal Fecha, ByVal IntegradaSO, ByVal Mensaje)
        Dim rs As ADODB.Connection
        Dim strSQL As String
        Dim sConeccion As String
        Dim IntegradaFC As Integer
        Dim IntegradoSTR As String

        rs = New ADODB.Connection
        'rs.CursorType = CursorTypeEnum.adOpenStatic
        'rs.CommandTimeout = 0

        'sConeccion = "Provider=sqloledb;" & _
        '   "Data Source=" & sSERVIDOR & ";" & _
        '   "Initial Catalog=" & INTERID & ";" & _
        '    "Integrated Security=SSPI"

        sConeccion = "Provider=sqloledb;" & _
          "Data Source=" & strSrv & ";" & _
          "Initial Catalog=" & strDba & ";" & _
           "Integrated Security=SSPI"

        IntegradaFC = 0
        If IntegradaSO Then
            IntegradaFC = 1
            IntegradoSTR = " sync_version_erp = sync_version_st, "
        Else
            IntegradoSTR = ""
        End If

        strSQL = "UPDATE " & strDba & "..ERP_Invoice SET " & _
                    IntegradoSTR & _
                    " IntegrationStatus = " & CStr(IntegradaFC) & ", " & _
                    " ProcessedDate = '" & Format(CDate(Now()), "yyyyMMdd") & " " & Format(CDate(Now()), "HH:mm:ss") & "', " & _
                    " ErrorStr = '" & Microsoft.VisualBasic.Left(Mensaje, 255) & "' " & _
                    " WHERE invoice_id = " & CStr(ID)

        'gGrabarLog("Antes rs.Open " & strSrv & strDba, strPath, CLeidos, CIntegrados, CRechazados)
        gGrabarLog("SQL " & strSrv & ":" & strDba & " : " & INTERID & " : " & strDba & " --> ", strPath, CLeidos, CIntegrados, CRechazados)
        gGrabarLog("-- " & strSQL & " --> ", strPath, CLeidos, CIntegrados, CRechazados)
        On Error GoTo ActualizaErrores
        rs.Open(sConeccion)
        'gGrabarLog("-- ", strPath, CLeidos, CIntegrados, CRechazados)
        'gGrabarLog("Despues rs.Open" & strSrv & strDba, strPath, CLeidos, CIntegrados, CRechazados)
        rs.Execute(strSQL)

        rs.Close()

        rs = Nothing

        ActualizaSOP = True
        Exit Function
ActualizaErrores:
        gGrabarLog("Actualiza " & sSERVIDOR & " " & INTERID & " " & strDba & " " & strSQL, strPath, CLeidos, CIntegrados, CRechazados)
        Exit Function
    End Function
    Public Function ActualizaCust(ByVal sSERVER)
        Dim rs As ADODB.Connection
        Dim rs2 As ADODB.Recordset
        Dim strSQL As String
        Dim sConeccion As String

        rs2 = New ADODB.Recordset

        rs2.CursorType = CursorTypeEnum.adOpenStatic
        'rs2.ActiveConnection.CommandTimeout = 0

        strSQL = "SELECT DISTINCT B.INTERID FROM " & strDba & "..ERP_User A INNER JOIN " & sBillingCountryDatabase & "..BillingCountryDatabase B ON A.tax_ref_country_code = B.CCode "

        rs2.Open(strSQL, sConnection)

        If Not rs2.EOF Then
            rs2.MoveFirst()
            While Not rs2.EOF

                rs = New ADODB.Connection
                'rs.CommandTimeout = 0

                sConeccion = "Provider=sqloledb;" & _
                   "Data Source=" & sSERVER & ";" & _
                           "Initial Catalog=" & strDba & ";" & _
                            "Integrated Security=SSPI"
                '  ARMA EL SCRIPT
                strSQL = "UPDATE " & strDba & "..ERP_User_accounting_Assigned_Credit " & _
                            "SET available_credit_limit = CUSTBLNC-UNPSTOSA, sync_version_erp = c.sync_version_st + 1 " & _
                            "FROM " + Trim(rs2.Fields("INTERID").Value) + "..RM00101 A INNER JOIN " + Trim(rs2.Fields("INTERID").Value) + "..RM00103 B ON A.CUSTNMBR = B.CUSTNMBR " & _
                            "INNER JOIN " & strDba & "..ERP_User_accounting_Assigned_Credit C ON CONVERT(INT, A.CUSTNMBR)= C.[user_id]  " & _
                            "WHERE (IsNumeric(A.CUSTNMBR) = 1 And c.sync_version_erp >= c.sync_version_st) " & _
                            "and c.available_credit_limit <> CUSTBLNC-UNPSTOSA "

                rs.Open(sConeccion)
                rs.Execute(strSQL)

                rs.Close()

                rs = Nothing

                rs2.MoveNext()
            End While
        End If
        rs2.Close()
        rs2 = Nothing
        ActualizaCust = True
    End Function

    Public Function ArmarDatosSOP(ByVal APPPath)
        Dim SQLSTR As String
        Dim sXML, sXML2 As String
        Dim Integrado As Boolean
        Dim ClienteIntegrado As Integer
        Dim Actualizado As Boolean
        Dim sCliente As String
        Dim FinFactura As Boolean
        Dim invoice_id As Long
        Dim Subtotal As Double
        Dim SubtotalLinea As Double
        Dim SubtotalNeto As Double
        Dim Lote As String
        Dim ItemDesc As String
        Dim SOPID As String
        'MSAL 08-03-2018
        Dim SOPLETRA As String
        'MSAL 08-03-2018
        Dim TaxID, TaxPlan, sCUSTCLAS As String
        Dim Descuento, Impuesto, TotalDoc As Double
        'MSAL 16-01-2017
        Dim TotalDocPAgo As Double
        'MSAL 16-01-2017
        Dim SopType As Integer
        Dim SOPNUMBE As String
        Dim mycon As SqlConnection
        Dim Resultado As Integer
        Dim sLPRSNID As String
        Dim sSERVER As String
        Dim FinRecordset As Boolean
        Dim cuenta As Integer = 0
        Dim totalprice As Double

        FinRecordset = False

        CLeidos = 0
        CIntegrados = 0
        CRechazados = 0
        sXML = "<!-- Sop Invoice with payments and manual taxes -->" & vbNewLine
        sXML = sXML & "<eConnect xmlns:dt=""urn:schemas-microsoft-com:datatypes"">" & vbNewLine
        sXML = sXML & "    <SOPTransactionType>" & vbNewLine
        sXML = sXML & "		<taSopLineIvcInsert_Items>" & vbNewLine
        'gGrabarLog(sXML, APPPath, CLeidos, CIntegrados, CRechazados)

        SQLSTR = "SELECT * FROM " & strDba & "..INT_INVOICE_VIEW ORDER BY invoice_id, soptype, article_id "

        'gGrabarLog("Armar Datos SOP", APPPath, CLeidos, CIntegrados, CRechazados)
        cnCustomer = New ADODB.Recordset
        cnCustomer.CursorType = CursorTypeEnum.adOpenStatic
        'cnCustomer.ActiveConnection.CommandTimeout = 0

        'gGrabarLog("Armar Datos SOP 0 " & sConnection, APPPath, CLeidos, CIntegrados, CRechazados)
        gGrabarLog("---------------------------------------------------------", APPPath, CLeidos, CIntegrados, CRechazados)
        gGrabarLog("---------------------------------------------------------", APPPath, CLeidos, CIntegrados, CRechazados)
        gGrabarLog("Armar Datos SOP --> " & sConnection & " " & SQLSTR, APPPath, CLeidos, CIntegrados, CRechazados)
        cnCustomer.Open(SQLSTR, sConnection)
        'gGrabarLog("Armar Datos SOP 0 ", APPPath, CLeidos, CIntegrados, CRechazados)

        On Error GoTo SOPErrores
        'gGrabarLog("cnCustomer.Open(SQLSTR, sConnection)", APPPath, CLeidos, CIntegrados, CRechazados)
        ' 0 If Trim(sINTERID) <> "GBRA" Then
        If Trim(sINTERID) <> "GBRA" Then
            dFechaEmision = Format(Now, "MM-dd-yyyy")
            ' 0 Cierra
        End If
        ' 1 If Not cnCustomer.EOF Then
        If Not cnCustomer.EOF Then
            FinRecordset = False
            'gGrabarLog("If Not cnCustomer.EOF", APPPath, CLeidos, CIntegrados, CRechazados)
            cnCustomer.MoveFirst()
            'gGrabarLog("cnCustomer.MoveFirst()", APPPath, CLeidos, CIntegrados, CRechazados)
            gGrabarLog("Inicio Factura -->", APPPath, CLeidos, CIntegrados, CRechazados)
            ' 2 While Not cnCustomer.EOF
            While Not cnCustomer.EOF
                FinRecordset = False
                'gGrabarLog("While Not cnCustomer.EOF", APPPath, CLeidos, CIntegrados, CRechazados)
                sSERVER = Trim(cnCustomer.Fields("SERVIDOR").Value)
                SOPNUMBE = ""
                ' 3 If Trim(sINTERID) = "GBRA" Then
                If Trim(sINTERID) = "GBRA" Then
                    dFechaEmision = Format(cnCustomer.Fields("date_invoice").Value, "MM-dd-yyyy")
                    sLPRSNID = Trim(Replace(Replace(Replace(cnCustomer.Fields("CNPJ_AGENCIA").Value, ".", ""), "-", ""), " ", ""))
                    ' 3 Cierra
                End If
                'gGrabarLog("Segundo2", APPPath, CLeidos, CIntegrados, CRechazados)
                sINTERID = cnCustomer.Fields("INTERID").Value
                'gGrabarLog("Armar Datos SOP 6 " & sINTERID, APPPath, CLeidos, CIntegrados, CRechazados)
                ' 4 If Trim(sINTERID) <> "GBRA" Then
                If Trim(sINTERID) <> "GBRA" Then
                    iCustomer = cnCustomer.Fields("user_id").Value
                    iEmpresa = cnCustomer.Fields("org_id").Value
                    ' 5 If iEmpresa <> 0 Then
                    If iEmpresa <> 0 Then
                        sCliente = Microsoft.VisualBasic.Right("00000000" & CStr(iEmpresa), 9)
                    Else
                        sCliente = "U" & Microsoft.VisualBasic.Right("00000000" & CStr(iCustomer), 8)
                        ' 5 Cierra
                    End If

                    '                sCliente = Microsoft.VisualBasic.Right("00000000" & CStr(cnCustomer.Fields("user_id").Value), 8)

                Else
                    'gGrabarLog("Segundo3", APPPath, CLeidos, CIntegrados, CRechazados)
                    SOPNUMBE = cnCustomer.Fields("invoice_number_text").Value
                    'gGrabarLog("Segundo31", APPPath, CLeidos, CIntegrados, CRechazados)
                    SOPNUMBE = GetSOPNUMBE(APPPath, sINTERID, SOPNUMBE, sSERVER)
                    'gGrabarLog("Segundo32", APPPath, CLeidos, CIntegrados, CRechazados)
                    sCliente = cnCustomer.Fields("org_id").Value
                    'gGrabarLog("Segundo4", APPPath, CLeidos, CIntegrados, CRechazados)
                    ' 4 Cierra
                End If
                'gGrabarLog("Armar Datos SOP 7 pre CUSTCLASSID", APPPath, CLeidos, CIntegrados, CRechazados)
                sCUSTCLAS = CUSTCLASSID(sSERVER, sINTERID, APPPath, sCliente)
                'gGrabarLog("Armar Datos SOP 7b post CUSTCLASSID " & sSERVER, APPPath, CLeidos, CIntegrados, CRechazados)
                invoice_id = cnCustomer.Fields("invoice_id").Value
                Lote = CStr(Year(Today())) & Microsoft.VisualBasic.Right("0" & CStr(Month(Today())), 2) & Microsoft.VisualBasic.Right("0" & CStr(Microsoft.VisualBasic.Day(Today())), 2)

                gGrabarLog("Levanto Articulo --> " & sSERVER & " id:" & CStr(invoice_id) & " txt:" & SOPNUMBE, APPPath, CLeidos, CIntegrados, CRechazados)

                'gGrabarLog("Segundo5", APPPath, CLeidos, CIntegrados, CRechazados)
                ItemDesc = Trim(cnCustomer.Fields("article_name").Value) + " " + cnCustomer.Fields("article_description").Value
                SopType = cnCustomer.Fields("soptype").Value
                SOPID = DOCID(sSERVER, sINTERID, SopType, APPPath)
                'gGrabarLog("Segundo6", APPPath, CLeidos, CIntegrados, CRechazados)
                ' 6 If Trim(sINTERID) = "GARG" Or sINTERID = "ARTST" Then
                If Trim(sINTERID) = "GARG" Or sINTERID = "ARTST" Or sINTERID = "ARG10" Then
                    'MSAL 08-03-2018
                    'If Microsoft.VisualBasic.Mid(sCUSTCLAS, 6, 1) = "A" Then
                    'SOPLETRA = "M"
                    'Else
                    SOPLETRA = Microsoft.VisualBasic.Mid(sCUSTCLAS, 6, 1)
                    'End If
                    'MSAL 08-03-2018 - Al finalizar sacar el tema de la letra M para 
                    If SOPLETRA = "M" Then
                        SOPID = Microsoft.VisualBasic.Left(SOPID, 3) & SOPLETRA & _
                                    "0003"

                    Else
                        SOPID = Microsoft.VisualBasic.Left(SOPID, 3) & SOPLETRA & _
                                    "0001"

                    End If
                Else
                    If Trim(sINTERID) = "GBRA" Then
                        If Left(SOPNUMBE, 1) = "C" Then
                            SOPID = "SERIE C"
                        Else
                            SOPID = "SERIE B"
                        End If
                    End If
                    ' 6 Cierra
                End If
                'gGrabarLog("Tercero", APPPath, CLeidos, CIntegrados, CRechazados)
                ' 7 If cnCustomer.Fields("vat_percentage").Value <> 0 Then
                If cnCustomer.Fields("vat_percentage").Value <> 0 Then
                    TaxID = IDImpuesto(sSERVER, sINTERID, CStr(cnCustomer.Fields("vat_percentage").Value), sCliente, TaxPlan)
                Else
                    TaxID = ""
                    TaxPlan = ""
                    ' 7 Cierra
                End If
                sPaymentType = cnCustomer.Fields("payment_type").Value
                sTxnID = Trim(cnCustomer.Fields("txn_id").Value)
                If Trim(sINTERID) = "GCOL" Or Trim(sINTERID) = "COL10" Then
                    If Trim(sPaymentType) <> "invoice" And Trim(sPaymentType) <> "" And Trim(sTxnID) <> "" Then
                        TaxPlan = "V-IVA"
                    End If
                End If
                sXML = sXML & "		    <taSopLineIvcInsert>" & vbNewLine
                sXML = sXML & "           " & ArmarLineaXML(CStr(cnCustomer.Fields("soptype").Value), "SOPTYPE", "")
                ' 8 If Trim(sINTERID) <> "GBRA" Then
                If Trim(sINTERID) <> "GBRA" Then
                    sXML = sXML & "           " & ArmarLineaXML("", "SOPNUMBE", "")
                Else
                    sXML = sXML & "           " & ArmarLineaXML(SOPNUMBE, "SOPNUMBE", "")
                    ' 8 Cierra
                End If
                sXML = sXML & "           " & ArmarLineaXML(sCliente, "CUSTNMBR", "")
                sXML = sXML & "           " & ArmarLineaXML(dFechaEmision, "DOCDATE", "")
                sXML = sXML & "           " & ArmarLineaXML("", "LOCNCODE", "")
                sXML = sXML & "           " & ArmarLineaXML(cnCustomer.Fields("article_type").Value, "ITEMNMBR", "1")
                'If Trim(sINTERID) = "GCHI" Or Trim(sINTERID) = "GCOL" Then
                ' 9 If Trim(sINTERID) = "GCHI" Or Trim(sINTERID) = "CHI10" Then
                If Trim(sINTERID) = "GCHI" Or Trim(sINTERID) = "CHI10" Then
                    SubtotalLinea = Int(CDbl(cnCustomer.Fields("provision_recipient_price").Value) + 0.5)
                    ' 10 If SubtotalLinea = 0 Then
                    If SubtotalLinea = 0 Then
                        SubtotalNeto = SubtotalNeto + Int(CDbl(cnCustomer.Fields("price").Value) + 0.5)
                    Else
                        SubtotalNeto = SubtotalNeto + SubtotalLinea
                        ' 10 Cierra
                    End If
                    Subtotal = Subtotal + Int(CDbl(cnCustomer.Fields("price").Value) + 0.5)
                    Descuento = Int(CDbl(cnCustomer.Fields("discount").Value) + 0.5)
                    Impuesto = Int(CDbl(cnCustomer.Fields("vat").Value) + 0.5)
                    TotalDoc = Int((Subtotal - Descuento + Impuesto) + 0.5)
                    TotalDocPAgo = TotalDoc   'MSAL 05-06-2018
                    sXML = sXML & "           " & ArmarLineaXML(CStr(Int(CDbl(cnCustomer.Fields("price").Value) + 0.5)), "UNITPRCE", "")
                    sXML = sXML & "           " & ArmarLineaXML(CStr(Int(CDbl(cnCustomer.Fields("price").Value) + 0.5)), "XTNDPRCE", "")
                Else
                    SubtotalLinea = Redondear(CDbl(cnCustomer.Fields("provision_recipient_price").Value))
                    ' 11 If SubtotalLinea = 0 Then
                    If SubtotalLinea = 0 Then
                        SubtotalNeto = SubtotalNeto + Redondear(CDbl(cnCustomer.Fields("price").Value))
                    Else
                        SubtotalNeto = SubtotalNeto + SubtotalLinea
                        ' 11 Cierra
                    End If
                    Subtotal = Subtotal + Redondear(CDbl(cnCustomer.Fields("price").Value))
                    Descuento = Redondear(CDbl(cnCustomer.Fields("discount").Value))
                    If Trim(sINTERID) <> "GMOPE" And Trim(sINTERID) <> "GMSER" And Trim(sINTERID) <> "COL10" And Trim(sINTERID) <> "MEX10" Then
                        Impuesto = Redondear(CDbl(cnCustomer.Fields("vat").Value))
                    End If
                    TotalDocPAgo = Redondear((Subtotal - Descuento + Redondear(CDbl(cnCustomer.Fields("vat").Value)))) 'MSAL 16-01-2017
                    TotalDoc = Redondear((Subtotal - Descuento + Impuesto))

                    sXML = sXML & "           " & ArmarLineaXML(CStr(Redondear(CDbl(cnCustomer.Fields("price").Value))), "UNITPRCE", "")
                    sXML = sXML & "           " & ArmarLineaXML(CStr(Redondear(CDbl(cnCustomer.Fields("price").Value))), "XTNDPRCE", "")
                    ' 9 Cierra
                End If
                'gGrabarLog("Cuarto", APPPath, CLeidos, CIntegrados, CRechazados)
                sXML = sXML & "           " & ArmarLineaXML("1", "QUANTITY", "")
                sXML = sXML & "           " & ArmarLineaXML(ItemDesc, "ITEMDESC", "1")
                sXML = sXML & "           " & ArmarLineaXML(SOPID, "DOCID", "1")
                ' 12 If Trim(sINTERID) = "GBRA" Then
                If Trim(sINTERID) = "GBRA" Then
                    sXML = sXML + "           " & ArmarLineaXML(sLPRSNID, "SLPRSNID", "1")
                    ' 12 Cierra
                End If
                'gGrabarLog("Cuarto 1", APPPath, CLeidos, CIntegrados, CRechazados)
                If Trim(sINTERID) = "GCOL" Or Trim(sINTERID) = "COL10" Then
                    If Trim(sPaymentType) <> "invoice" And Trim(sPaymentType) <> "" And Trim(sTxnID) <> "" Then
                        sXML = sXML & "           " & ArmarLineaXML(TaxPlan, "TAXSCHID", "")
                    End If

                End If
                sXML = sXML & "           " & ArmarLineaXML(cnCustomer.Fields("img_url").Value, "ShipToName", "1")
                sXML = sXML & "           " & ArmarLineaXML(CStr(cnCustomer.Fields("article_id").Value), "INTEGRATIONID", "")
                'sXML = sXML & "           " & ArmarLineaXML(Chr(34) & Trim(cnCustomer.Fields("info").Value & Chr(34)), "CMMTTEXT")
                sXML = sXML & "           " & ArmarLineaXML(cnCustomer.Fields("CURNCYID").Value, "CURNCYID", "1")

                sXML = sXML & "		    </taSopLineIvcInsert>" & vbNewLine

                sXML2 = "		</taSopLineIvcInsert_Items>	" & vbNewLine
                ' 13 If Trim(sINTERID) <> "GCOL" Then
                'gGrabarLog("Cuarto 2", APPPath, CLeidos, CIntegrados, CRechazados)
                If Trim(sINTERID) <> "GCOL" And Trim(sINTERID) <> "COL10" And Trim(sINTERID) <> "GMOPE" And Trim(sINTERID) <> "GMSER" And Trim(sINTERID) <> "MEX10" Then
                    ' 14 If CDbl(cnCustomer.Fields("vat").Value) <> 0 Then
                    If CDbl(cnCustomer.Fields("vat").Value) <> 0 Then
                        sXML2 = sXML2 + "		 <taSopLineIvcTaxInsert>" & vbNewLine
                        sXML2 = sXML2 + "           " & ArmarLineaXML(CStr(cnCustomer.Fields("soptype").Value), "SOPTYPE", "")
                        sXML2 = sXML2 + "           <TAXTYPE>0</TAXTYPE>" & vbNewLine
                        ' 15 If Trim(sINTERID) <> "GBRA" Then
                        If Trim(sINTERID) <> "GBRA" Then
                            sXML2 = sXML2 + "           <SOPNUMBE></SOPNUMBE>" & vbNewLine
                        Else
                            sXML2 = sXML2 & "           " & ArmarLineaXML(SOPNUMBE, "SOPNUMBE", "")
                            ' 15 Ciera
                        End If
                        sXML2 = sXML2 & "           " & ArmarLineaXML(sCliente, "CUSTNMBR", "")
                        sXML2 = sXML2 + "           <LNITMSEQ>0</LNITMSEQ>" & vbNewLine
                        sXML2 = sXML2 + "           " & ArmarLineaXML(CStr(Redondear(SubtotalNeto)), "SALESAMT", "")
                        sXML2 = sXML2 & "           " & ArmarLineaXML(CStr(TaxID), "TAXDTLID", "")
                        sXML2 = sXML2 & "			" & ArmarLineaXML(CStr(Redondear(Impuesto)), "STAXAMNT", "")
                        sXML2 = sXML2 & "		 </taSopLineIvcTaxInsert>" & vbNewLine
                        ' 14 Cierra
                    End If
                    ' 13 Cierra
                End If
                'gGrabarLog("Cuarto 3", APPPath, CLeidos, CIntegrados, CRechazados)
                ' 16 If Trim(sPaymentType) <> "invoice" And Trim(sPaymentType) <> "" And Trim(sINTERID) <> "GBRA" Then
                If Trim(sPaymentType) <> "invoice" And Trim(sPaymentType) <> "" And Trim(sINTERID) <> "GBRA" Then
                    sXML2 = sXML2 + "		 <taCreateSopPaymentInsertRecord_Items>" & vbNewLine
                    sXML2 = sXML2 + "		 	<taCreateSopPaymentInsertRecord>" & vbNewLine
                    sXML2 = sXML2 + "		 			" & ArmarLineaXML(CStr(cnCustomer.Fields("soptype").Value), "SOPTYPE", "")
                    ' 17 If Trim(sINTERID) <> "GBRA" Then
                    'gGrabarLog("Cuarto 4", APPPath, CLeidos, CIntegrados, CRechazados)
                    If Trim(sINTERID) <> "GBRA" Then
                        sXML2 = sXML2 + "           <SOPNUMBE></SOPNUMBE>" & vbNewLine
                    Else
                        sXML2 = sXML2 & "           " & ArmarLineaXML(SOPNUMBE, "SOPNUMBE", "")
                        ' 17 Cierra
                    End If
                    sXML2 = sXML2 + "		 			" & ArmarLineaXML(sCliente, "CUSTNMBR", "1")
                    sXML2 = sXML2 + "		 			" & ArmarLineaXML("", "CUSTNAME", "1")
                    sXML2 = sXML2 + "		 			" & ArmarLineaXML(dFechaEmision, "DOCDATE", "")

                    'gGrabarLog("Cuarto 5", APPPath, CLeidos, CIntegrados, CRechazados)

                    If Trim(sINTERID) = "GCOL" Or Trim(sINTERID) = "COL10" Then 'MSAL 16-01-2017
                        'gGrabarLog("Cuarto 5.0", APPPath, CLeidos, CIntegrados, CRechazados)
                        sXML2 = sXML2 + "		 			" & ArmarLineaXML(CStr(Redondear(CDbl(cnCustomer.Fields("totalprice").Value))), "DOCAMNT", "")
                        'gGrabarLog("Cuarto 5.1", APPPath, CLeidos, CIntegrados, CRechazados)
                    Else
                        'gGrabarLog("Cuarto 5.1.5", APPPath, CLeidos, CIntegrados, CRechazados)
                        sXML2 = sXML2 + "		 			" & ArmarLineaXML(CStr(Redondear(TotalDocPAgo)), "DOCAMNT", "") 'MSAL 16-01-2017
                        'gGrabarLog("Cuarto 5.2", APPPath, CLeidos, CIntegrados, CRechazados)
                    End If
                    'Else 'MSAL 16-01-2017
                    'sXML2 = sXML2 + "		 			" & ArmarLineaXML(CStr(Redondear(TotalDoc)), "DOCAMNT", "") 'Linea Original
                    'End If 'MSAL 16-01-2017
                    'gGrabarLog("Cuarto 6", APPPath, CLeidos, CIntegrados, CRechazados)
                    sXML2 = sXML2 + "		 			<CHEKBKID>" & Trim(UCase(sPaymentType)) & "</CHEKBKID>" & vbNewLine
                    sXML2 = sXML2 + "		 			" & ArmarLineaXML(Trim(sTxnID), "CHEKNMBR", "1")
                    sXML2 = sXML2 + "		 			<PYMTTYPE>4</PYMTTYPE>" & vbNewLine
                    'sXML2 = sXML2 + "		 			<PYMTTYPE>5</PYMTTYPE>" & vbNewLine
                    sXML2 = sXML2 + "		 	</taCreateSopPaymentInsertRecord>" & vbNewLine
                    sXML2 = sXML2 + "		 </taCreateSopPaymentInsertRecord_Items>" & vbNewLine
                    ' 16 Cierra
                    'gGrabarLog("Cuarto 7", APPPath, CLeidos, CIntegrados, CRechazados)
                End If
                'gGrabarLog("Quinto", APPPath, CLeidos, CIntegrados, CRechazados)
                sXML2 = sXML2 & "		<taSopHdrIvcInsert>" & vbNewLine
                sXML2 = sXML2 + "           " & ArmarLineaXML(CStr(cnCustomer.Fields("soptype").Value), "SOPTYPE", "")
                sXML2 = sXML2 + "			<DOCID>" & SOPID & "</DOCID>" & vbNewLine
                ' 18 If Trim(sINTERID) <> "GBRA" Then
                If Trim(sINTERID) <> "GBRA" Then
                    sXML2 = sXML2 + "           <SOPNUMBE></SOPNUMBE>" & vbNewLine
                Else
                    sXML2 = sXML2 & "           " & ArmarLineaXML(SOPNUMBE, "SOPNUMBE", "")
                    ' 18 Cierra
                End If
                ' 19 If Trim(sINTERID) <> "GBRA" Then
                If Trim(sINTERID) <> "GBRA" Then
                    sXML2 = sXML2 + "			<TAXSCHID>" & TaxPlan & "</TAXSCHID>" & vbNewLine
                Else
                    sXML2 = sXML2 + "			<TAXSCHID> </TAXSCHID>" & vbNewLine
                    ' 19 Cierra
                End If
                'sXML2 = sXML2 + "			" & ArmarLineaXML(CStr(CDbl(cnCustomer.Fields("vat").Value)), "TAXAMNT", "")
                ' 20 If Trim(sINTERID) <> "GCOL" Then
                If Trim(sINTERID) <> "GCOL" And Trim(sINTERID) <> "COL10" And Trim(sINTERID) <> "GMOPE" And Trim(sINTERID) <> "GMSER" And Trim(sINTERID) <> "MEX10" Then
                    sXML2 = sXML2 + "			" & ArmarLineaXML(CStr(Redondear(Impuesto)), "TAXAMNT", "")
                    ' 20 Cierra
                End If
                sXML2 = sXML2 + "			<LOCNCODE></LOCNCODE>" & vbNewLine
                sXML2 = sXML2 + "			" & ArmarLineaXML(dFechaEmision, "DOCDATE", "")
                sXML2 = sXML2 + "			" & ArmarLineaXML(CStr(Redondear(Descuento)), "TRDISAMT", "")
                sXML2 = sXML2 + "			" & ArmarLineaXML(sCliente, "CUSTNMBR", "")
                sXML2 = sXML2 + "			" & ArmarLineaXML("", "CUSTNAME", "1")
                ' 21 If Trim(sINTERID) = "GBRA" Then
                If Trim(sINTERID) = "GBRA" Then
                    sXML2 = sXML2 + "			" & ArmarLineaXML(CStr(cnCustomer.Fields("NOTAFISCAL").Value), "CSTPONBR", "")
                    ' 21 Cierra
                End If
                ' 22 If Trim(sINTERID) <> "GCOL" Then  06/01/2018 agregado GMOPE GMSER y MEX10 AL IF
                'If Trim(sINTERID) <> "GCOL" And Trim(sINTERID) <> "COL10" And Trim(sINTERID) <> "GMOPE" And Trim(sINTERID) <> "GMSER" And Trim(sINTERID) <> "MEX10" Then
                If Trim(sINTERID) <> "GCOL" Then
                    sXML2 = sXML2 + "			" & ArmarLineaXML(CStr(Redondear(Subtotal)), "SUBTOTAL", "")
                    sXML2 = sXML2 + "			" & ArmarLineaXML(CStr(Redondear(TotalDoc)), "DOCAMNT", "")
                    ' 22 Cierra
                End If
                ' 23 If Trim(sPaymentType) <> "invoice" And Trim(sPaymentType) <> "" Then
                If Trim(sPaymentType) <> "invoice" And Trim(sPaymentType) <> "" Then
                    sXML2 = sXML2 + "			" & ArmarLineaXML(CStr(Redondear(TotalDoc)), "PYMTRCVD", "")
                    ' 23 Cierra
                End If
                ' 24 If Trim(sINTERID) = "GBRA" Then
                If Trim(sINTERID) = "GBRA" Then
                    sXML2 = sXML2 + "			" & ArmarLineaXML(sLPRSNID, "SLPRSNID", "1")
                    '  24 Cierra
                End If
                sXML2 = sXML2 + "			" & ArmarLineaXML(Lote, "BACHNUMB", "1")
                ' 25 If Trim(sINTERID) = "GBRA" Then
                If Trim(sINTERID) = "GBRA" Then
                    sXML2 = sXML2 + "			" & ArmarLineaXML("", "PYMTRMID", "")
                    ' 25 Cierra
                End If
                dFechaVenc = cnCustomer.Fields("date_pay_by").Value
                ' 26 If Trim(sINTERID) = "GMOPE" Or Trim(sINTERID) = "GMSER" Then
                If Trim(sINTERID) = "GMOPE" Or Trim(sINTERID) = "GMSER" Or Trim(sINTERID) = "MEX10" Then
                    sXML2 = sXML2 + "			" & ArmarLineaXML(Format(DateAdd(DateInterval.Day, GetPYMTRMIDDays(sSERVER, sINTERID, sCliente), Today()), "MM-dd-yyyy"), "DUEDATE", "")
                Else
                    sXML2 = sXML2 + "			" & ArmarLineaXML(Format(DateAdd(DateInterval.Day, 30, Today()), "MM-dd-yyyy"), "DUEDATE", "")
                    ' 26 Cierra
                End If
                ' 27 If Trim(sINTERID) <> "GCOL" Then
                If Trim(sINTERID) <> "GCOL" And Trim(sINTERID) <> "COL10" And Trim(sINTERID) <> "GMOPE" And Trim(sINTERID) <> "GMSER" And Trim(sINTERID) <> "MEX10" Then
                    sXML2 = sXML2 + "			" & ArmarLineaXML("1", "USINGHEADERLEVELTAXES", "")
                Else
                    ' 28 If Trim(sINTERID) <> "GBRA" Then
                    If Trim(sINTERID) <> "GBRA" And (Trim(sINTERID) = "GMOPE" Or Trim(sINTERID) = "GMSER" Or Trim(sINTERID) = "COL10" Or Trim(sINTERID) = "MEX10") Then
                        sXML2 = sXML2 + "			" & ArmarLineaXML("1", "CREATETAXES", "")
                    Else
                        sXML2 = sXML2 + "			" & ArmarLineaXML("0", "CREATETAXES", "")
                        ' 28 Cierra
                    End If
                    ' 27 Cierra
                End If
                'gGrabarLog("Sexto", APPPath, CLeidos, CIntegrados, CRechazados)
                sXML2 = sXML2 + "           " & ArmarLineaXML(cnCustomer.Fields("CURNCYID").Value, "CURNCYID", "")
                sXML2 = sXML2 + "           " & ArmarLineaXML(CStr(cnCustomer.Fields("invoice_id").Value), "INTEGRATIONID", "")
                'sXML2 = sXML2 + "           " & ArmarLineaXML(Chr(34) & Trim(cnCustomer.Fields("billing_address").Value & Chr(34)), "CMMTTEXT")
                'sXML2 = sXML2 + "           " & ArmarLineaXML(Chr(34) & Trim(cnCustomer.Fields("shipping_address").Value & Chr(34)), "NOTETEXT")
                ' 29 If Trim(sINTERID) = "GCOL" Then
                If Trim(sINTERID) = "GCOL" Or Trim(sINTERID) = "COL10" Then
                    sXML2 = sXML2 + "			" & ArmarLineaXML("1", "DEFPRICING", "")
                    ' 29 Cierra
                End If
                ' 30 If Trim(sINTERID) = "GBRA" Then
                If Trim(sINTERID) = "GBRA" Then
                    sXML2 = sXML2 + "           " & ArmarLineaXML(cnCustomer.Fields("invoice_cost_center_id").Value, "USRDEFND1", "1")
                    sXML2 = sXML2 + "           " & ArmarLineaXML(CStr(cnCustomer.Fields("agencia_user_id").Value), "USRDEFND2", "1")
                    ' 31 If Trim(sPaymentType) <> "invoice" And Trim(sPaymentType) <> "" Then
                    If Trim(sPaymentType) <> "invoice" And Trim(sPaymentType) <> "" Then
                        sXML2 = sXML2 + "           " & ArmarLineaXML(Trim(sPaymentType), "USRDEFND3", "1")
                        '31 Cierra
                    End If
                    ' 30 Cierra
                End If
                sXML2 = sXML2 + "	 </taSopHdrIvcInsert>" & vbNewLine
                sXML2 = sXML2 + "   </SOPTransactionType>" & vbNewLine
                sXML2 = sXML2 + "</eConnect>" & vbNewLine

                cnCustomer.MoveNext()
                'gGrabarLog("cnCustomer.MoveNext()" & CStr(invoice_id), APPPath, CLeidos, CIntegrados, CRechazados)
                FinFactura = False

                ' 32 If Not cnCustomer.EOF Then
                If Not cnCustomer.EOF Then
                    'gGrabarLog("If Not cnCustomer.EOF" & CStr(invoice_id), APPPath, CLeidos, CIntegrados, CRechazados)
                    ' 33 If invoice_id <> cnCustomer.Fields("invoice_id").Value Or _
                    If invoice_id <> cnCustomer.Fields("invoice_id").Value Or _
                                ((invoice_id = cnCustomer.Fields("invoice_id").Value) And SopType <> cnCustomer.Fields("soptype").Value) Then
                        FinFactura = True
                        ' 33 Cierra
                    End If
                Else
                    'gGrabarLog("Move Next EOF" & CStr(invoice_id), APPPath, CLeidos, CIntegrados, CRechazados)
                    FinRecordset = True
                    cuenta = 1
                    FinFactura = True
                    ' 32 Cierra
                End If
                ' 34 If FinFactura Then
                If FinFactura Then
                    'gGrabarLog("Fin Factura " & CStr(invoice_id) & " " & "Final", APPPath, CLeidos, CIntegrados, CRechazados)
                    gGrabarLog("Integro Factura " & sXML + sXML2, APPPath, CLeidos, CIntegrados, CRechazados)
                    ErrorIntegracion = ""
                    'gGrabarLog("Antes llamada IntegraTrxXML", APPPath, CLeidos, CIntegrados, CRechazados)
                    Integrado = IntegraTrxXML(sSERVER, sINTERID, sXML + sXML2, ErrorIntegracion)
                    'gGrabarLog("Despues llamada IntegraTrxXML", APPPath, CLeidos, CIntegrados, CRechazados)
                    ' 35 If Integrado = True Then
                    If Integrado = True Then
                        CLeidos = CLeidos + 1
                        CIntegrados = CIntegrados + 1
                        ClienteIntegrado = 1
                    Else
                        CLeidos = CLeidos + 1
                        CRechazados = CRechazados + 1
                        ClienteIntegrado = 0
                        ' 35 Cierra
                    End If
                    'Actualizado = ActualizaSOP(invoice_id, sINTERID)
                    gGrabarLog("Antes Actualiza SOP " & CStr(invoice_id) & " " & ErrorIntegracion & " --> ", APPPath, CLeidos, CIntegrados, CRechazados)
                    Actualizado = ActualizaSOP(sSERVER, invoice_id, sINTERID, FechaProceso, Integrado, ErrorIntegracion)
                    gGrabarLog("Inicio Factura", APPPath, CLeidos, CIntegrados, CRechazados)
                    ' 36 If VerificarACA_Set_Invoice_Error(sSERVER, sINTERID) Then
                    'If VerificarACA_Set_Invoice_Error(sSERVER, sINTERID) And Not Integrado Then
                    'gGrabarLog("VerificarACA_Set_Invoice_Error " & CStr(invoice_id), APPPath, CLeidos, CIntegrados, CRechazados)
                    'mycon = New SqlConnection("Data Source=" & sSERVER & "; Initial Catalog=" & sINTERID & "; Integrated Security=SSPI")
                    'mycon.Open()
                    'Dim cmd4 As SqlCommand = New SqlCommand(sINTERID & "..ACA_Set_Invoice_Error", mycon)

                    'cmd4.CommandType = CommandType.StoredProcedure

                    'cmd4.Parameters.Add("@invoice_id ", SqlDbType.Int, ParameterDirection.Input).Value = invoice_id
                    'cmd4.Parameters.Add("@SOPTYPE", SqlDbType.SmallInt, ParameterDirection.Input).Value = SopType
                    'cmd4.CommandTimeout = 0

                    'Resultado = cmd4.ExecuteNonQuery
                    'mycon.Close()
                    'mycon = Nothing
                    'cmd4 = Nothing
                    ' 36 Cierra
                    'End If
                    'If Not FinRecordset Then
                    sXML = "<!-- Sop Invoice with payments and manual taxes -->" & vbNewLine
                    'sXML = sXML & "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?>" & vbNewLine
                    sXML = sXML & "<eConnect xmlns:dt=""urn:schemas-microsoft-com:datatypes"">" & vbNewLine
                    sXML = sXML & "    <SOPTransactionType>" & vbNewLine
                    sXML = sXML & "		<taSopLineIvcInsert_Items>" & vbNewLine
                    Subtotal = 0
                    SubtotalNeto = 0
                    Impuesto = 0
                End If
                'gGrabarLog("Octavo", APPPath, CLeidos, CIntegrados, CRechazados)
                ' 34 Cierra
                'End If
                'gGrabarLog("Antes end while cnCustomer.EOF ", APPPath, CLeidos, CIntegrados, CRechazados)
                ' 2 Cierra
            End While
            'gGrabarLog("Antes end if cnCustomer.EOF ", APPPath, CLeidos, CIntegrados, CRechazados)
            ' 1 Cierra
        End If

        'gGrabarLog("Termina Armar Datos SOP", APPPath, CLeidos, CIntegrados, CRechazados)
        cnCustomer.Close()
        cnCustomer = Nothing

        'gGrabarLog("Termina Armar Datos SOP", APPPath, CLeidos, CIntegrados, CRechazados)

        Exit Function
SOPErrores:
        gGrabarLog("cuenta: " & CStr(cuenta) & Err.Description & " " & _
                Err.Erl, APPPath, CLeidos, CIntegrados, CRechazados)

        Exit Function

    End Function
    Public Function DOCID(ByVal sSERVIDOR, ByVal sBaseid, ByVal iSopType, ByVal APPPath)
        Dim rs As ADODB.Recordset
        Dim SQLSTR As String
        Dim sConnect As String

        sConnect = ""
        sConnect = "Provider=sqloledb;" & _
           "Data Source=" & sSERVIDOR & ";" & _
           "Initial Catalog=" & sBaseid & ";" & _
        "Integrated Security=SSPI"

        rs = New ADODB.Recordset
        rs.CursorType = CursorTypeEnum.adOpenStatic
        'rs.ActiveConnection.CommandTimeout = 0

        If iSopType = 3 Then
            SQLSTR = "SELECT INVDOCID FROM " + Trim(sBaseid) + "..SOP40100 "
        Else
            SQLSTR = "SELECT RETDOCID AS INVDOCID FROM " + Trim(sBaseid) + "..SOP40100 "
        End If
        rs.Open(SQLSTR, sConnect)

        If Not rs.EOF Then
            rs.MoveFirst()
            While Not rs.EOF
                DOCID = Trim(rs.Fields("INVDOCID").Value)
                Exit While
            End While
        Else
            If iSopType = 3 Then
                DOCID = "FV A"
            Else
                DOCID = "NC A"
            End If
        End If

        rs.Close()

        rs = Nothing
    End Function
    Public Function GetSOPNUMBE(ByVal APPPath, ByVal sBaseid, ByVal sSOPNUMBE, ByVal sSERVER)
        Dim rs As ADODB.Recordset
        Dim SQLSTR As String
        Dim sConnect As String

        sConnect = ""
        sConnect = "Provider=sqloledb;" & _
           "Data Source=" & sSERVER & ";" & _
           "Initial Catalog=" & sBaseid & ";" & _
        "Integrated Security=SSPI"

        rs = New ADODB.Recordset
        rs.CursorType = CursorTypeEnum.adOpenStatic
        'rs.ActiveConnection.CommandTimeout = 0

        SQLSTR = "SELECT " & Trim(sBaseid) & ".dbo.TII_GET_NEXT_SOPNUMBE('" & Trim(sSOPNUMBE) & "') SOPNUMBE "
        'gGrabarLog("Segundo311", APPPath, CLeidos, CIntegrados, CRechazados)
        rs.Open(SQLSTR, sConnect)

        If Not rs.EOF Then
            'gGrabarLog("Segundo312", APPPath, CLeidos, CIntegrados, CRechazados)
            rs.MoveFirst()
            'gGrabarLog("Segundo313", APPPath, CLeidos, CIntegrados, CRechazados)
            While Not rs.EOF
                'gGrabarLog("Segundo314", APPPath, CLeidos, CIntegrados, CRechazados)
                GetSOPNUMBE = Trim(rs.Fields("SOPNUMBE").Value)
                'gGrabarLog("Segundo315", APPPath, CLeidos, CIntegrados, CRechazados)
                Exit While
            End While
        End If

        rs.Close()

        rs = Nothing
    End Function

    Public Function CLASSID(ByVal sBaseid, ByVal sSERVER)
        Dim rs As ADODB.Recordset
        Dim SQLSTR As String
        Dim sConnect As String

        sConnect = ""
        sConnect = "Provider=sqloledb;" & _
           "Data Source=" & sSERVER & ";" & _
           "Initial Catalog=" & sBaseid & ";" & _
        "Integrated Security=SSPI"


        rs = New ADODB.Recordset
        rs.CursorType = CursorTypeEnum.adOpenStatic
        'rs.ActiveConnection.CommandTimeout = 0

        SQLSTR = "SELECT CLASSID FROM " + Trim(sBaseid) + "..RM00201 WHERE DEFLTCLS = 1 "

        rs.Open(SQLSTR, sConnect)

        If Not rs.EOF Then
            rs.MoveFirst()
            While Not rs.EOF
                CLASSID = Trim(rs.Fields("CLASSID").Value)
                Exit While
            End While
        Else
            CLASSID = "CLIE A"
        End If

        rs.Close()

        rs = Nothing
    End Function
    Public Function CUSTCLASSID(ByVal sSERVIDOR, ByVal sBaseid, ByVal APPPATH, ByVal sCustomer)
        Dim rs As ADODB.Recordset
        Dim SQLSTR As String
        Dim sConnect As String

        sConnect = ""
        sConnect = "Provider=sqloledb;" & _
           "Data Source=" & sSERVIDOR & ";" & _
           "Initial Catalog=" & sBaseid & ";" & _
        "Integrated Security=SSPI"

        rs = New ADODB.Recordset
        rs.CursorType = CursorTypeEnum.adOpenStatic
        'rs.ActiveConnection.CommandTimeout = 0

        'gGrabarLog("CUSTCLASSID 1 " & sSERVIDOR & " " & sBaseid, APPPATH, CLeidos, CIntegrados, CRechazados)
        SQLSTR = "SELECT CUSTCLAS FROM " + Trim(sBaseid) + "..RM00101 WHERE CUSTNMBR = '" & Trim(sCustomer) & "' "

        'gGrabarLog("CUSTCLASSID 2 " & sSERVIDOR & " " & sBaseid, APPPATH, CLeidos, CIntegrados, CRechazados)
        rs.Open(SQLSTR, sConnect)
        'gGrabarLog("CUSTCLASSID 3 " & sSERVIDOR & " " & sBaseid, APPPATH, CLeidos, CIntegrados, CRechazados)

        If Not rs.EOF Then
            rs.MoveFirst()
            While Not rs.EOF
                CUSTCLASSID = Trim(rs.Fields("CUSTCLAS").Value)
                Exit While
            End While
        Else
            CUSTCLASSID = ""
        End If

        rs.Close()

        rs = Nothing
    End Function

    Public Function IDImpuesto(ByVal sSERVIDOR, ByVal sBaseID, ByVal TaxPercent, ByVal sCustomer, ByRef sPlan)
        Dim rs As ADODB.Recordset
        Dim SQLSTR As String
        Dim sConnect As String

        sConnect = ""
        sConnect = "Provider=sqloledb;" & _
           "Data Source=" & sSERVIDOR & ";" & _
           "Initial Catalog=" & sBaseID & ";" & _
        "Integrated Security=SSPI"

        rs = New ADODB.Recordset
        rs.CursorType = CursorTypeEnum.adOpenStatic
        'rs.ActiveConnection.CommandTimeout = 0

        SQLSTR = "SELECT TOP 1 B.TAXSCHID, C.TAXDTLID FROM " + Trim(sBaseID) + "..RM00101 A INNER JOIN " + Trim(sBaseID) + "..TX00102 B ON A.TAXSCHID = B. TAXSCHID " & _
                    " INNER JOIN " + Trim(sBaseID) + "..TX00201 C ON B.TAXDTLID = C.TAXDTLID WHERE TXDTLPCT = " + CStr(CDbl(TaxPercent)) + " " & _
                    " AND A.CUSTNMBR = '" + Trim(sCustomer) + "' "

        rs.Open(SQLSTR, sConnect)

        If Not rs.EOF Then
            rs.MoveFirst()
            While Not rs.EOF
                sPlan = Trim(rs.Fields("TAXSCHID").Value)
                IDImpuesto = Trim(rs.Fields("TAXDTLID").Value)
                Exit While
            End While
        Else
            sPlan = "V-I21"
            IDImpuesto = "V-IVA 21"
        End If

        rs.Close()

        rs = Nothing

    End Function
    Public Function CHECKCUSTOMER(ByVal sSERVIDOR, ByVal sBaseid, ByVal sCustomer) As Boolean
        Dim rs As ADODB.Recordset
        Dim SQLSTR As String
        Dim sConnect As String

        sConnect = ""
        sConnect = "Provider=sqloledb;" & _
           "Data Source=" & sSERVIDOR & ";" & _
           "Initial Catalog=" & sBaseid & ";" & _
        "Integrated Security=SSPI"

        rs = New ADODB.Recordset
        rs.CursorType = CursorTypeEnum.adOpenStatic
        'rs.ActiveConnection.CommandTimeout = 0

        gGrabarLog("CheckCustomer 1 ", "", CLeidos, CIntegrados, CRechazados)
        SQLSTR = "SELECT CUSTNMBR FROM " + Trim(sBaseid) + "..RM00101 WHERE CUSTNMBR = '" & Trim(sCustomer) & "' "
        gGrabarLog("CheckCustomer 2 ", "", CLeidos, CIntegrados, CRechazados)

        rs.Open(SQLSTR, sConnect)
        gGrabarLog("CheckCustomer Open ", "", CLeidos, CIntegrados, CRechazados)

        If Not rs.EOF Then
            rs.MoveFirst()
            While Not rs.EOF
                CHECKCUSTOMER = True
                Exit While
            End While
        Else
            CHECKCUSTOMER = False
        End If
        gGrabarLog("CheckCustomer " & CStr(CHECKCUSTOMER), "", CLeidos, CIntegrados, CRechazados)

        rs.Close()

        rs = Nothing
    End Function
    Public Function GetPYMTRMIDDays(ByVal sSERVIDOR, ByVal sBaseid, ByVal sCustomer) As Integer
        Dim rs As ADODB.Recordset
        Dim SQLSTR As String
        Dim sConnect As String

        sConnect = ""
        sConnect = "Provider=sqloledb;" & _
           "Data Source=" & sSERVIDOR & ";" & _
           "Initial Catalog=" & sBaseid & ";" & _
        "Integrated Security=SSPI"

        GetPYMTRMIDDays = 0

        rs = New ADODB.Recordset
        rs.CursorType = CursorTypeEnum.adOpenStatic
        'rs.ActiveConnection.CommandTimeout = 0

        SQLSTR = "SELECT DUEDTDS FROM " + Trim(sBaseid) + "..RM00101 A INNER JOIN " + Trim(sBaseid) + "..SY03300 B ON A.PYMTRMID = B.PYMTRMID WHERE A.CUSTNMBR = '" & Trim(sCustomer) & "' "

        rs.Open(SQLSTR, sConnect)

        If Not rs.EOF Then
            rs.MoveFirst()
            While Not rs.EOF
                GetPYMTRMIDDays = Val(rs.Fields("DUEDTDS").Value)
                Exit While
            End While
        End If

        rs.Close()

        rs = Nothing
    End Function
    Public Function gAbrirLog(ByVal APPPath As String)
        Dim strArchivo As String

        strArchivo = APPPath + "\GettyeConnect.LOG"

        My.Computer.FileSystem.WriteAllText(strArchivo, "Inicio : " & CStr(Now()) & ControlChars.CrLf, True)

    End Function
    Public Function gGrabarLog(ByVal sIntegracionTexto As String, ByVal APPPath As String, ByVal rLeidos As Integer, ByVal rIntegrados As Integer, ByVal rRechazados As Integer)
        Dim strArchivo As String

        strArchivo = APPPath + "\GettyeConnect.LOG"

        My.Computer.FileSystem.WriteAllText(strArchivo, _
        "     " & sIntegracionTexto & ": " & "Leídos: " & CStr(rLeidos) & ", Integrados: " & _
        CStr(rIntegrados) & ", Rechazados: " & CStr(rRechazados) & ControlChars.CrLf, True)

    End Function
    Public Function gCerrarLog(ByVal APPPath As String)
        Dim strArchivo As String

        strArchivo = APPPath + "\GettyeConnect.LOG"

        My.Computer.FileSystem.WriteAllText(strArchivo, "Finalización : " & CStr(Now()) & ControlChars.CrLf, True)

    End Function

    Public Function ArmarDatosPrepago(ByVal APPPath)
        Dim SQLSTR As String
        Dim sXML As String
        Dim Integrado As Boolean
        Dim Actualizado As Boolean
        Dim sCliente As String
        Dim invoice_id As Long
        Dim Lote As String
        Dim ItemDesc As String
        Dim sCUSTCLAS As String
        Dim sCashNumber As String

        If strDba <> "VALORPIX" Then
            Exit Function
        End If
        PLeidos = 0
        PIntegrados = 0
        PRechazados = 0

        SQLSTR = "SELECT * FROM " & strDba & "..INT_PREPAID_VIEW ORDER BY invoice_id "

        cnCustomer = New ADODB.Recordset
        cnCustomer.CursorType = CursorTypeEnum.adOpenStatic
        'cnCustomer.ActiveConnection.CommandTimeout = 0

        cnCustomer.Open(SQLSTR, sConnection)

        dFechaEmision = Format(Now, "MM-dd-yyyy")
        If Not cnCustomer.EOF Then
            cnCustomer.MoveFirst()
            While Not cnCustomer.EOF
                sINTERID = cnCustomer.Fields("INTERID").Value

                iCustomer = cnCustomer.Fields("merged_org_id").Value
                iEmpresa = cnCustomer.Fields("merged_org_id").Value
                If iEmpresa <> 0 Then
                    sCliente = Microsoft.VisualBasic.Right("00000000" & CStr(iEmpresa), 9)
                Else
                    sCliente = "U" & Microsoft.VisualBasic.Right("00000000" & CStr(iCustomer), 8)
                End If

                '                sCliente = Microsoft.VisualBasic.Right("00000000" & CStr(cnCustomer.Fields("user_id").Value), 8)
                sCUSTCLAS = CUSTCLASSID(strSrv, sINTERID, APPPath, sCliente)
                invoice_id = cnCustomer.Fields("invoice_id").Value
                Lote = CStr(Year(Today())) & Microsoft.VisualBasic.Right("0" & CStr(Month(Today())), 2) & Microsoft.VisualBasic.Right("0" & CStr(Microsoft.VisualBasic.Day(Today())), 2)
                ItemDesc = cnCustomer.Fields("invoice_number_text").Value
                sPaymentType = UCase(cnCustomer.Fields("payment_type").Value)
                sTxnID = Trim(cnCustomer.Fields("txn_id").Value)
                sCashNumber = GetNextCashNumber(strSrv, sINTERID)
                sXML = "<!-- RM Receipt with Check -->" & vbNewLine
                sXML = sXML & "<eConnect xmlns:dt=""urn:schemas-microsoft-com:datatypes"">" & vbNewLine
                sXML = sXML & "    <RMCashReceiptsType>" & vbNewLine
                sXML = sXML & "		<taRMCashReceiptInsert>" & vbNewLine
                sXML = sXML & "           " & ArmarLineaXML(sCliente, "CUSTNMBR", "")
                sXML = sXML & "           " & ArmarLineaXML(sCashNumber, "DOCNUMBR", "")
                sXML = sXML & "           " & ArmarLineaXML(dFechaEmision, "DOCDATE", "")
                sXML = sXML & "           " & ArmarLineaXML(CStr(CDbl(cnCustomer.Fields("payed").Value)), "ORTRXAMT", "")
                sXML = sXML & "           " & ArmarLineaXML(dFechaEmision, "GLPOSTDT", "")
                sXML = sXML + "			  " & ArmarLineaXML(Lote, "BACHNUMB", "1")
                sXML = sXML & "           " & ArmarLineaXML("0", "CSHRCTYP", "")
                sXML = sXML + "			  " & ArmarLineaXML(sPaymentType, "CHEKBKID", "")
                sXML = sXML + "			  " & ArmarLineaXML(sTxnID, "CHEKNMBR", "")
                sXML = sXML + "		</taRMCashReceiptInsert>" & vbNewLine
                sXML = sXML + "    </RMCashReceiptsType>" & vbNewLine
                sXML = sXML + "</eConnect>" & vbNewLine

                Integrado = IntegraXML(strSrv, sINTERID, sXML, ErrorIntegracion)

                If Integrado = True Then
                    PLeidos = PLeidos + 1
                    PIntegrados = PIntegrados + 1
                Else
                    PLeidos = PLeidos + 1
                    PRechazados = PRechazados + 1
                End If
                Actualizado = ActualizaSOP(strSrv, invoice_id, sINTERID, FechaProceso, Integrado, ErrorIntegracion)

                cnCustomer.MoveNext()

            End While

        End If

        cnCustomer.Close()
        cnCustomer = Nothing

        'gGrabarLog("Prepagos", APPPath, PLeidos, PIntegrados, PRechazados)

    End Function
    Public Function Redondear(ByVal Importe As Double) As Double
        Dim ARedondear As Double
        Dim ImporteStr As String
        Dim iPos As Integer
        ARedondear = Int(Importe * 100 + 0.5)
        ImporteStr = ARedondear.ToString
        ImporteStr = Replace(ImporteStr, ",", ".")
        iPos = InStr(ImporteStr, ".")
        If iPos = 0 Then
            ImporteStr = "000" & Trim(ImporteStr) & ".00"
        End If
        iPos = InStr(ImporteStr, ".")
        If iPos <> 0 Then
            ImporteStr = Mid(ImporteStr, 1, iPos - 3) & "." & Mid(ImporteStr, iPos - 2, 2)
            Redondear = Val(ImporteStr)
        End If

    End Function
    Public Function gAbrirArchivo(ByVal APPPath As String, ByVal TTexto As String)
        Dim strArchivo As String

        strArchivo = APPPath

        My.Computer.FileSystem.WriteAllText(strArchivo, TTexto & ControlChars.CrLf, False, System.Text.Encoding.UTF8)

    End Function
    Public Function gGrabarArchivo(ByVal APPPath As String, ByVal TTexto As String)
        Dim strArchivo As String

        strArchivo = APPPath

        '        Select Case iEncode1
        '            Case 0
        'My.Computer.FileSystem.WriteAllText(strArchivo, TTexto & ControlChars.CrLf, True, System.Text.Encoding.Default)
        '            Case 1
        '        My.Computer.FileSystem.WriteAllText(strArchivo, TTexto & ControlChars.CrLf, True, System.Text.Encoding.ASCII)
        '            Case 2
        '        My.Computer.FileSystem.WriteAllText(strArchivo, TTexto & ControlChars.CrLf, True, System.Text.Encoding.Unicode)
        '            Case 3
        '        My.Computer.FileSystem.WriteAllText(strArchivo, TTexto & ControlChars.CrLf, True, System.Text.Encoding.UTF32)
        '            Case 4
        '        My.Computer.FileSystem.WriteAllText(strArchivo, TTexto & ControlChars.CrLf, True, System.Text.Encoding.UTF7)
        '            Case 5
        My.Computer.FileSystem.WriteAllText(strArchivo, TTexto & ControlChars.CrLf, True, System.Text.Encoding.UTF8)
        '        End Select

    End Function

End Class
