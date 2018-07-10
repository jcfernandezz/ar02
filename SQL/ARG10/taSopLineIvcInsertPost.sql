USE [ARG10]
GO

/****** Object:  StoredProcedure [dbo].[taSopLineIvcInsertPost]    Script Date: 07/10/2018 18:04:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


 ALTER procedure [dbo].[taSopLineIvcInsertPost]              @I_vSOPTYPE smallint      ,  @I_vSOPNUMBE char(21)
    , @I_vCUSTNMBR char(15)     , @I_vDOCDATE datetime      , @I_vUSERDATE datetime     ,  @I_vLOCNCODE char(10)     
    , @I_vITEMNMBR char(30)     , @I_vAutoAssignBin smallint, @I_vUNITPRCE numeric(19,5),  @I_vXTNDPRCE numeric(19,5)
    , @I_vQUANTITY numeric(19,5), @I_vMRKDNAMT numeric(19,5), @I_vMRKDNPCT numeric(19,2),  @I_vCOMMNTID char(15)
    , @I_vCOMMENT_1 char(50)    , @I_vCOMMENT_2 char(50)    , @I_vCOMMENT_3 char(50)    ,  @I_vCOMMENT_4 char(50)    
    , @I_vUNITCOST numeric (19,5), @I_vPRCLEVEL char(10)    , @I_vITEMDESC char(100)    ,  @I_vTAXAMNT numeric(19,5)
    , @I_vQTYONHND numeric(19,5), @I_vQTYRTRND numeric(19,5), @I_vQTYINUSE numeric(19,5),  @I_vQTYINSVC numeric(19,5)
    , @I_vQTYDMGED numeric(19,5), @I_vNONINVEN smallint     , @I_vLNITMSEQ int          ,  @I_vDROPSHIP smallint     
    , @I_vQTYTBAOR numeric(19,5), @I_vDOCID char(15)        , @I_vSALSTERR char(15)     ,  @I_vSLPRSNID char(15)
    , @I_vITMTSHID char(15)     , @I_vIVITMTXB smallint     , @I_vTAXSCHID char(15)     ,  @I_vPRSTADCD char(15)
    , @I_vShipToName char(64)   , @I_vCNTCPRSN char(60)     , @I_vADDRESS1 char(60)     ,  @I_vADDRESS2 char(60)     
    , @I_vADDRESS3 char(60)     , @I_vCITY char(35)         , @I_vSTATE char(29)        ,  @I_vZIPCODE char(10)
    , @I_vCOUNTRY char(60)      , @I_vPHONE1 char(21)       , @I_vPHONE2 char(21)       ,  @I_vPHONE3 char(21)
    , @I_vFAXNUMBR char(21)     , @I_vPrint_Phone_NumberGB smallint ,  @I_vEXCEPTIONALDEMAND tinyint
    , @I_vReqShipDate datetime  , @I_vFUFILDAT datetime     , @I_vACTLSHIP datetime     ,  @I_vSHIPMTHD char(15)
    , @I_vINVINDX varchar(75)   , @I_vCSLSINDX varchar(75)  , @I_vSLSINDX varchar(75)   ,  @I_vMKDNINDX varchar(75)
    , @I_vRTNSINDX varchar(75)  , @I_vINUSINDX varchar(75)  , @I_vINSRINDX varchar(75)  ,  @I_vDMGDINDX varchar(75)
    , @I_vAUTOALLOCATESERIAL int, @I_vAUTOALLOCATELOT int   , @I_vGPSFOINTEGRATIONID char(30), @I_vINTEGRATIONSOURCE smallint
    , @I_vINTEGRATIONID char(30), @I_vRequesterTrx smallint , @I_vQTYCANCE numeric(19,5),  @I_vQTYFULFI numeric(19,5)
    , @I_vALLOCATE smallint     , @I_vUpdateIfExists smallint,@I_vRecreateDist smallint,   @I_vQUOTEQTYTOINV numeric(19,5)
    , @I_vTOTALQTY numeric(19,5), @I_vCMMTTEXT varchar(500) , @I_vKitCompMan smallint   ,  @I_vDEFPRICING int
    , @I_vDEFEXTPRICE int       , @I_vCURNCYID char(15)     , @I_vUOFM char(8)          ,  @I_vIncludePromo smallint
    , @I_vCKCreditLimit tinyint , @I_vQtyShrtOpt smallint   , @I_vRECREATETAXES smallint,  @I_vRECREATECOMM smallint
    , @I_vUSRDEFND1 char(50)    , @I_vUSRDEFND2 char(50)    , @I_vUSRDEFND3 char(50)    ,  @I_vUSRDEFND4 varchar(8000)
    , @I_vUSRDEFND5 varchar(8000),@O_iErrorState int output , @oErrString varchar(255) output   
    as  
 
 
set nocount on  
IF @O_iErrorState = 0
BEGIN
	DECLARE @COM1 CHAR(50), @COM2 CHAR(50), @COM3 CHAR(50), @COM4 CHAR(50), @COMMENT CHAR(500)

	declare @PUNTO SMALLINT

	SELECT @COMMENT = info from INTDB2..ERP_Article WHERE article_id = convert(int, @I_vINTEGRATIONID)
	
	SELECT @COM1 = substring(@COMMENT, 1, 50)
	SELECT @PUNTO = LEN(@COM1)
	WHILE SUBSTRING(@COM1, @PUNTO, 1) <> ' ' 
	BEGIN

		SELECT @PUNTO = @PUNTO - 1
	END
	SELECT @COM1 = substring(@COM1, 1, @PUNTO)
	select @PUNTO = @PUNTO + 1

	SELECT @COM2 = substring(@COMMENT, @PUNTO, 50)
	SELECT @PUNTO = LEN(@COM2)
	WHILE SUBSTRING(@COM2, @PUNTO, 1) <> ' ' 
	BEGIN

		SELECT @PUNTO = @PUNTO - 1
	END
	SELECT @COM2 = substring(@COM2, 1, @PUNTO)
	select @PUNTO = @PUNTO + 1 + 50

	SELECT @COM3 = substring(@COMMENT, @PUNTO, 50)
	SELECT @PUNTO = LEN(@COM3)
	WHILE SUBSTRING(@COM3, @PUNTO, 1) <> ' ' 
	BEGIN

		SELECT @PUNTO = @PUNTO - 1
	END
	SELECT @COM3 = substring(@COM3, 1, @PUNTO)
	select @PUNTO = @PUNTO + 1 + 100

	SELECT @COM4 = substring(@COMMENT, @PUNTO, 50)
	SELECT @PUNTO = LEN(@COM4)
	WHILE SUBSTRING(@COM4, @PUNTO, 1) <> ' ' 
	BEGIN

		SELECT @PUNTO = @PUNTO - 1
	END
	SELECT @COM4 = substring(@COM4, 1, @PUNTO)

	IF NOT EXISTS(SELECT SOPNUMBE 
					FROM SOP10202
					WHERE SOPNUMBE = @I_vSOPNUMBE
						AND
						SOPTYPE = @I_vSOPTYPE
						AND 
						LNITMSEQ = @I_vLNITMSEQ)
	BEGIN
		INSERT INTO SOP10202 
			(SOPTYPE, SOPNUMBE, LNITMSEQ, COMMENT_1, COMMENT_2, COMMENT_3, COMMENT_4, CMMTTEXT )
			SELECT @I_vSOPTYPE, @I_vSOPNUMBE, @I_vLNITMSEQ, @COM1, @COM2, @COM3, @COM4, @COMMENT
	END
	ELSE
	BEGIN
		UPDATE SOP10202
			SET COMMENT_1 = @COM1, COMMENT_2 = @COM2, COMMENT_3 = COMMENT_3, COMMENT_4 = @COM4, CMMTTEXT = @COMMENT
			WHERE SOPNUMBE = @I_vSOPNUMBE
				AND
				SOPTYPE = @I_vSOPTYPE
				AND 
				LNITMSEQ = @I_vLNITMSEQ
		
	END

	IF EXISTS(SELECT SOPNUMBE FROM INT_SOPLINE WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE AND LNITMSEQ = @I_vLNITMSEQ)
	BEGIN
		DELETE INT_SOPLINE WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE AND LNITMSEQ = @I_vLNITMSEQ
	END

	INSERT INTO INT_SOPLINE SELECT @I_vSOPTYPE, @I_vSOPNUMBE, @I_vLNITMSEQ, @I_vINTEGRATIONID

	IF EXISTS(SELECT SOPNUMBE FROM INT_SOPLINE_DATA WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE AND LNITMSEQ = @I_vLNITMSEQ)
	BEGIN
		DELETE INT_SOPLINE_DATA WHERE SOPTYPE = @I_vSOPTYPE AND SOPNUMBE = @I_vSOPNUMBE AND LNITMSEQ = @I_vLNITMSEQ
	END

	INSERT INTO INT_SOPLINE_DATA 
			SELECT 
				@I_vSOPTYPE, 
				@I_vSOPNUMBE, 
				@I_vLNITMSEQ, 
				article_name,
				applied_pricelist,
				article_description,
				buyer_note,
				collection_name,
				info,
				usage_description_for_media,
				usage_rights_for_media,
				media_publication_date,
				publication_expiring_date,
				media_publication_country_code,
				delivery_date_on_invoice
			FROM INTDB2..INT_ARTICLE_LINE_DATA
			WHERE article_id = CONVERT(INT, @I_vINTEGRATIONID)

END

select @O_iErrorState = 0  
return (@O_iErrorState)   


GO


