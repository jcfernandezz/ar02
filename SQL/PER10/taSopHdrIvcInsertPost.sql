USE [PER10]
GO

/****** Object:  StoredProcedure [dbo].[taSopHdrIvcInsertPost]    Script Date: 19/12/2018 05:34:42 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

--15/1/19 jcf Agrega ingreso de impuestos en tabla de Localización andina


ALTER PROCEDURE [dbo].[taSopHdrIvcInsertPost]   @I_vSOPTYPE smallint,   @I_vDOCID char(15),   @I_vSOPNUMBE char(21),    
@I_vORIGNUMB char(21),   @I_vORIGTYPE smallint,   @I_vTAXSCHID char(15),   @I_vFRTSCHID char(15),   @I_vMSCSCHID char(15),   
@I_vSHIPMTHD char(15),   @I_vTAXAMNT numeric(19,5),  @I_vLOCNCODE char(10),   @I_vDOCDATE datetime,    @I_vFREIGHT numeric(19,5),  
@I_vMISCAMNT numeric(19,5),  @I_vTRDISAMT numeric(19,5),  @I_vTRADEPCT numeric(19,2),  @I_vDISTKNAM numeric(19,5),   
@I_vMRKDNAMT numeric(19,5),   @I_vCUSTNMBR char(15),    @I_vCUSTNAME char(64),   @I_vCSTPONBR char(20),   @I_vShipToName char(64),  
@I_vADDRESS1 char(60),   @I_vADDRESS2 char(60),   @I_vADDRESS3 char(60),   @I_vCNTCPRSN char(60),   @I_vFAXNUMBR char(21),   
@I_vCITY char(35),   @I_vSTATE char(29),   @I_vZIPCODE char(10),    @I_vCOUNTRY char(60),   @I_vPHNUMBR1 char(21),   
@I_vPHNUMBR2 char(21),   @I_vPHNUMBR3 char(21),   @I_vPrint_Phone_NumberGB smallint,    @I_vSUBTOTAL numeric(19,5),  
@I_vDOCAMNT numeric(19,5),  @I_vPYMTRCVD numeric(19,5),  @I_vSALSTERR char(15),   @I_vSLPRSNID char(15),   @I_vUPSZONE char(3),   
@I_vUSER2ENT char(15),   @I_vBACHNUMB char(15),   @I_vPRBTADCD char(15),   @I_vPRSTADCD char(15),   @I_vFRTTXAMT numeric(19,5),  
@I_vMSCTXAMT numeric(19,5),  @I_vORDRDATE datetime,   @I_vMSTRNUMB int,   @I_vPYMTRMID char(20),   @I_vDUEDATE datetime,   
@I_vDISCDATE datetime,   @I_vREFRENCE char(30),   @I_vUSINGHEADERLEVELTAXES int,  @I_vBatchCHEKBKID char(15),  @I_vCREATECOMM smallint, 
@I_vCOMMAMNT numeric(19,2),  @I_vCOMPRCNT numeric(19,2),  @I_vCREATEDIST smallint,  @I_vCREATETAXES smallint,  @I_vDEFTAXSCHDS smallint,  
@I_vCURNCYID char(15),   @I_vXCHGRATE numeric(19,7),  @I_vRATETPID char(15),   @I_vEXPNDATE datetime,   @I_vEXCHDATE datetime,   
@I_vEXGTBDSC char(30),   @I_vEXTBLSRC char(50),   @I_vRATEEXPR smallint,     @I_vDYSTINCR smallint,   @I_vRATEVARC numeric(19,7), 
@I_vTRXDTDEF smallint,   @I_vRTCLCMTD smallint,   @I_vPRVDSLMT smallint,   @I_vDATELMTS smallint,   @I_vTIME1 datetime,   
@I_vDISAVAMT numeric(19,5),  @I_vDSCDLRAM numeric(19,5),  @I_vDSCPCTAM numeric(19,2),  @I_vFREIGTBLE int,   @I_vMISCTBLE int,   
@I_vCOMMNTID char(15),   @I_vCOMMENT_1 char(50),   @I_vCOMMENT_2 char(50),   @I_vCOMMENT_3 char(50),   @I_vCOMMENT_4 char(50),   
@I_vGPSFOINTEGRATIONID char(30), @I_vINTEGRATIONSOURCE smallint,  @I_vINTEGRATIONID char(30),  @I_vReqShipDate datetime,  
@I_vRequesterTrx smallint,  @I_vCKCreditLimit tinyint,  @I_vCKHOLD tinyint,   @I_vUpdateExisting tinyint,  @I_vQUOEXPDA datetime,   
@I_vQUOTEDAT datetime,   @I_vINVODATE datetime,   @I_vBACKDATE datetime,   @I_vRETUDATE datetime,   @I_vCMMTTEXT varchar(500),  
@I_vPRCLEVEL char(10),   @I_vDEFPRICING tinyint,   @I_vTAXEXMT1 char(25),   @I_vTAXEXMT2 char(25),   @I_vTXRGNNUM char(25),   
@I_vREPTING tinyint,   @I_vTRXFREQU smallint,    @I_vTIMETREP smallint,   @I_vQUOTEDYSTINCR smallint,  @I_vNOTETEXT varchar(8000),  
@I_vUSRDEFND1 char(50),   @I_vUSRDEFND2 char(50),   @I_vUSRDEFND3 char(50),   @I_vUSRDEFND4 varchar(8000),  @I_vUSRDEFND5 varchar(8000),  
@O_iErrorState int output,  @oErrString varchar(255) output   
as  
set nocount on  

IF @O_iErrorState = 0
BEGIN
	DECLARE @COM1 CHAR(50), @COM2 CHAR(50), @COM3 CHAR(50), @COM4 CHAR(50), @COMMENT CHAR(500), @NOTE CHAR(500), @NOTEINDX numeric(19,5)

	declare @PUNTO SMALLINT, @POSAC smallint, @DATEINVOICE datetime, @ORDENVTA CHAR(20)

	DECLARE @iStatus smallint,@iAddCodeErrState int

	
	IF EXISTS(SELECT SOPNUMBE FROM INT_SOPHDR WHERE INTEGRATIONID = convert(int, @I_vINTEGRATIONID) AND SOPTYPE = @I_vSOPTYPE)
		BEGIN

		select
			@iStatus = 0,
			@iAddCodeErrState = 0

		select @O_iErrorState = 67000  

		exec @iStatus = taUpdateString
			@O_iErrorState,
			@oErrString,
			@oErrString output,
			@iAddCodeErrState output

		return (@O_iErrorState)  

	END

	DECLARE @ORDER_LINES INT, @SOPLINES int

	SELECT @ORDER_LINES = count(article_id)  
	FROM INTDB2..ERP_Article
	WHERE ref_article_id = 0 AND invoice_id = convert(int, @I_vINTEGRATIONID)

	SELECT @SOPLINES = COUNT(LNITMSEQ)  
	FROM SOP10200 
	WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE

	SELECT @ORDER_LINES = ISNULL(@ORDER_LINES, 0)

	SELECT @SOPLINES = ISNULL(@SOPLINES, 0)

	IF @ORDER_LINES <> @SOPLINES 
	BEGIN
		select
			@iStatus = 0,
			@iAddCodeErrState = 0

		select @O_iErrorState = 67002  

		exec @iStatus = taUpdateString
			@O_iErrorState,
			@oErrString,
			@oErrString output,
			@iAddCodeErrState output

		return (@O_iErrorState)  
	END

/*	DECLARE @TOTAL NUMERIC(19,5), @IMPUESTO NUMERIC(19,5)

	SELECT @TOTAL = totalprice, @IMPUESTO = vat FROM INTDB2..ERP_Invoice WHERE invoice_id = convert(int, @I_vINTEGRATIONID)

	IF ABS(@TOTAL - @I_vDOCAMNT) > 1 OR ABS(@IMPUESTO - @I_vTAXAMNT) > 1
	BEGIN
		select
			@iStatus = 0,
			@iAddCodeErrState = 0

		select @O_iErrorState = 67003  

		exec @iStatus = taUpdateString
			@O_iErrorState,
			@oErrString,
			@oErrString output,
			@iAddCodeErrState output

		return (@O_iErrorState)  
	END
*/

	IF @I_vSOPTYPE = 4 AND NOT EXISTS(SELECT SOPNUMBE FROM INT_SOPHDR WHERE INTEGRATIONID = @I_vINTEGRATIONID AND SOPTYPE = 3
		AND SOPNUMBE IN(SELECT SOPNUMBE FROM SOP10100 WHERE SOPTYPE = 3 UNION SELECT SOPNUMBE FROM SOP30200 WHERE SOPTYPE =3) )
	BEGIN
		select
			@iStatus = 0,
			@iAddCodeErrState = 0

		select @O_iErrorState = 67005  

		exec @iStatus = taUpdateString
			@O_iErrorState,
			@oErrString,
			@oErrString output,
			@iAddCodeErrState output

		return (@O_iErrorState)  
	
	END
	
	IF EXISTS(SELECT CUSTNMBR FROM ACA_RFE00102 WHERE CUSTNMBR = @I_vCUSTNMBR)
	BEGIN
		DECLARE @DIATOPE SMALLINT
		
		IF EXISTS(SELECT DAY1 FROM ACA_RFE40002 WHERE YEAR1 = YEAR(@I_vDOCDATE) AND MONTH11 = MONTH(@I_vDOCDATE))
		BEGIN		
			SELECT @DIATOPE = DAY1 FROM ACA_RFE40002 WHERE YEAR1 = YEAR(@I_vDOCDATE) AND MONTH11 = MONTH(@I_vDOCDATE)

			SELECT @DIATOPE = ISNULL(@DIATOPE, 31)
			
			if DAY(@I_vDOCDATE) > @DIATOPE
			BEGIN	
				select
					@iStatus = 0,
					@iAddCodeErrState = 0

				select @O_iErrorState = 67004  

				exec @iStatus = taUpdateString
					@O_iErrorState,
					@oErrString,
					@oErrString output,
					@iAddCodeErrState output

				return (@O_iErrorState)  
			END
		END		
	
	END

	IF @I_vSOPTYPE = 4 AND NOT EXISTS(SELECT SOPNUMBE FROM INT_SOPHDR WHERE INTEGRATIONID = @I_vINTEGRATIONID AND SOPTYPE = 3
		AND SOPNUMBE IN(SELECT SOPNUMBE FROM SOP10100 WHERE SOPTYPE = 3 UNION SELECT SOPNUMBE FROM SOP30200 WHERE SOPTYPE =3) )
	BEGIN
		select
			@iStatus = 0,
			@iAddCodeErrState = 0

		select @O_iErrorState = 67005  

		exec @iStatus = taUpdateString
			@O_iErrorState,
			@oErrString,
			@oErrString output,
			@iAddCodeErrState output

		return (@O_iErrorState)  
	
	END
	
	SELECT @NOTE = [address], @COMMENT = shipping_address, @DATEINVOICE = date_invoice, @ORDENVTA = invoice_number_text from INTDB2..ERP_Invoice WHERE invoice_id = convert(int, @I_vINTEGRATIONID)
	
	SELECT @NOTEINDX = NOTEINDX FROM SOP10100 WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE

	IF @NOTEINDX <> 0
	BEGIN
		IF LEN(@NOTE) <> 0 
		INSERT INTO SY03900 SELECT @NOTEINDX, CONVERT(CHAR(8), GETDATE(), 112), CONVERT(VARCHAR, GETDATE(), 108), @NOTE
	END

	SELECT @COM1 = RTRIM(substring(@COMMENT, 1, 50))
	SELECT @COM2 = RTRIM(substring(@COMMENT, 51, 50))
	SELECT @COM3 = RTRIM(substring(@COMMENT, 101, 50))
	SELECT @COM4 = RTRIM(substring(@COMMENT, 151, 50))

	IF NOT EXISTS(SELECT SOPNUMBE 
					FROM SOP10106
					WHERE SOPNUMBE = @I_vSOPNUMBE
						AND
						SOPTYPE = @I_vSOPTYPE)
	BEGIN
		INSERT INTO SOP10106 
			(SOPTYPE, SOPNUMBE, USRDAT01, USERDEF1, COMMENT_1, COMMENT_2, COMMENT_3, COMMENT_4, CMMTTEXT )
			SELECT @I_vSOPTYPE, @I_vSOPNUMBE, @DATEINVOICE, @ORDENVTA, @COM1, @COM2, @COM3, @COM4, @COMMENT
	END
	ELSE
	BEGIN
		UPDATE SOP10106
			SET USRDAT01 = @DATEINVOICE, USERDEF1 = @ORDENVTA, COMMENT_1 = @COM1, COMMENT_2 = @COM2, COMMENT_3 = COMMENT_3, COMMENT_4 = @COM4, CMMTTEXT = @COMMENT
			WHERE SOPNUMBE = @I_vSOPNUMBE
				AND
				SOPTYPE = @I_vSOPTYPE
		
	END

	IF EXISTS(SELECT SOPNUMBE FROM INT_SOPHDR WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE)
	BEGIN
		DELETE INT_SOPHDR WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE
	END

	INSERT INTO INT_SOPHDR SELECT @I_vSOPTYPE, @I_vSOPNUMBE, @I_vINTEGRATIONID, @I_vDOCAMNT, @I_vTAXAMNT, (SELECT RTRIM(CONVERT(char(255), memo)) from INTDB2..ERP_Invoice WHERE invoice_id = CONVERT(int, @I_vINTEGRATIONID))

	--Localización andina requiere ingresar los impuestos
	DECLARE @TAXAMNT NUMERIC(19,5), @ORTAXAMT NUMERIC(19,5)
	DECLARE @WTHAMNT NUMERIC(19,5), @OWTHAMNT NUMERIC(19,5)
	
	SELECT @TAXAMNT = STAXAMNT+FRTTXAMT+MSCTXAMT, @ORTAXAMT = ORSLSTAX+ORFRTTAX+ORMSCTAX
	FROM SOP10105 WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE AND LNITMSEQ = 0 AND STAXAMNT+FRTTXAMT+MSCTXAMT > 0
	
	SELECT @TAXAMNT = ISNULL(@TAXAMNT, 0)
	SELECT @ORTAXAMT = ISNULL(@ORTAXAMT, 0)
	
	SELECT @WTHAMNT = STAXAMNT+FRTTXAMT+MSCTXAMT, @OWTHAMNT = ORSLSTAX+ORFRTTAX+ORMSCTAX
	FROM SOP10105 
	WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE AND LNITMSEQ = 0 AND STAXAMNT+FRTTXAMT+MSCTXAMT < 0
	
	SELECT @WTHAMNT = ISNULL(@WTHAMNT, 0)
	SELECT @OWTHAMNT = ISNULL(@OWTHAMNT, 0)
	
	IF EXISTS(SELECT SOPNUMBE FROM nsatw_sop10100 WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE)
	BEGIN
		DELETE nsatw_sop10100 WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE
	END

	INSERT INTO nsatw_sop10100 (SOPTYPE,SOPNUMBE,	BCHSOURC,		BACHNUMB,	APPLYTAX,TAXAMNT,ORTAXAMT,APPLYWTH,	WTHAMNT,	OWTHAMNT)
					SELECT @I_vSOPTYPE, @I_vSOPNUMBE, 'Sales Entry', @I_vBACHNUMB, 1, @TAXAMNT, @ORTAXAMT, 1,		@WTHAMNT,	@OWTHAMNT;

	--Agrega datos adicionales para FE ubl2.1
	DECLARE @cod_detraccion               char(5) = '00';
	declare @nsa_Cod_Transac              char(5) = '0101';

	if @I_vDOCAMNT>700  
	begin
		set @cod_detraccion = '022'
		set @nsa_Cod_Transac = '1001'
	end

	exec dbo.sp_nsaCOA_GL00014InsUpd
	'9999999999001',
	@I_vCUSTNMBR,
	'Generico',
	@cod_detraccion,
	'',
	'',
	0,
	@I_vSOPNUMBE,
	@I_vSOPTYPE,
	@I_vDOCDATE,
	@nsa_Cod_Transac,
	'00',
	'1/1/1900',
	'',
	'1',
	@I_vDOCDATE,
	0,
	'',
	'',
	0,
	0,
	0,
	@I_vDOCAMNT

END

EXEC TII_GETTY_SOP_AA @I_vSOPTYPE, @I_vSOPNUMBE

select @O_iErrorState = 0  
return (@O_iErrorState)  

GO
