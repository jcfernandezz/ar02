USE [MEX10]
GO

/****** Object:  StoredProcedure [dbo].[taUpdateCreateCustomerRcdPost]    Script Date: 19/12/2018 06:01:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[taUpdateCreateCustomerRcdPost]  @I_vCUSTNMBR char(15),    @I_vHOLD tinyint,    @I_vINACTIVE tinyint,    
@I_vCUSTNAME char(64),    @I_vSHRTNAME char(15),    @I_vSTMTNAME char(64),    @I_vCUSTCLAS char(15),    @I_vCUSTPRIORITY smallint,   
@I_vADRSCODE char(15),    @I_vCNTCPRSN char(60),    @I_vADDRESS1 char(60),    @I_vADDRESS2 char(60),     @I_vADDRESS3 char(60),     
@I_vCITY char(35),    @I_vSTATE char(29),    @I_vZIPCODE char(10),     @I_vCCode char(6),    @I_vCOUNTRY char(60),    
@I_vPHNUMBR1 char(21),    @I_vPHNUMBR2 char(21),    @I_vPHNUMBR3 char(21),    @I_vFAX char(21),    @I_vUPSZONE char(3),    
@I_vSHIPMTHD char(15),    @I_vTAXSCHID char(15),    @I_vSHIPCOMPLETE tinyint,   @I_vPRSTADCD char(15),    @I_vPRBTADCD char(15),    
@I_vSTADDRCD char(15),    @I_vSLPRSNID char(15),    @I_vSALSTERR char(15),    @I_vUSERDEF1 char(20),    @I_vUSERDEF2 char(20),     
@I_vCOMMENT1 char(30),     @I_vCOMMENT2 char(30),     @I_vCUSTDISC numeric(19,2),   @I_vPYMTRMID char(20),    @I_vDISGRPER smallint,     
@I_vDUEGRPER smallint,    @I_vPRCLEVEL char(10),    @I_vNOTETEXT varchar(8000),   @I_vBALNCTYP tinyint,    @I_vFNCHATYP smallint,    
@I_vFNCHPCNT numeric(19,2),   @I_vFINCHDLR numeric(19,5),   @I_vMINPYTYP smallint,    @I_vMINPYPCT numeric(19,2),   
@I_vMINPYDLR numeric(19,5),   @I_vCRLMTTYP smallint,    @I_vCRLMTAMT numeric(19,5),   @I_vCRLMTPER smallint,    @I_vCRLMTPAM numeric(19,5),   
@I_vMXWOFTYP smallint,    @I_vMXWROFAM numeric(19,5),   @I_vRevalue_Customer tinyint,   @I_vPost_Results_To smallint,   
@I_vORDERFULFILLDEFAULT tinyint,  @I_vINCLUDEINDP tinyint,   @I_vCRCARDID char(15),    @I_vCRCRDNUM char(20),    @I_vCCRDXPDT datetime,    
@I_vBANKNAME char(30),    @I_vBNKBRNCH char(20),    @I_vUSERLANG smallint,    @I_vTAXEXMT1 char(25),    @I_vTAXEXMT2 char(25),    
@I_vTXRGNNUM char(25),    @I_vCURNCYID char(15),    @I_vRATETPID char(15),    @I_vSTMTCYCL smallint,    @I_vKPCALHST tinyint,    
@I_vKPERHIST tinyint,    @I_vKPTRXHST tinyint,    @I_vKPDSTHST tinyint,    @I_vSend_Email_Statements tinyint,  
@I_vToEmail_Recipient char(80),    @I_vCcEmail_Recipient char(80),    @I_vBccEmail_Recipient char(80),   @I_vCHEKBKID char(15),    
@I_vDEFCACTY smallint,    @I_vRMCSHACTNUMST varchar(75),   @I_vRMARACTNUMST varchar(75),   @I_vRMSLSACTNUMST varchar(75),   
@I_vRMCOSACTNUMST varchar(75),   @I_vRMIVACTNUMST varchar(75),   @I_vRMTAKACTNUMST varchar(75),   @I_vRMAVACTNUMST varchar(75),   
@I_vRMFCGACTNUMST varchar(75),   @I_vRMWRACTNUMST varchar(75),   @I_vRMSORACTNUMST varchar(75),   @I_vRMOvrpymtWrtoffACTNUMST varchar(75), 
@I_vGPSFOINTEGRATIONID char(30),  @I_vINTEGRATIONSOURCE smallint,   @I_vINTEGRATIONID char(30),   @I_vUseCustomerClass tinyint,   
@I_vCreateAddress tinyint,   @I_vUpdateIfExists tinyint,   @I_vRequesterTrx smallint,   @I_vUSRDEFND1 char(50),        
@I_vUSRDEFND2 char(50),        @I_vUSRDEFND3 char(50),        @I_vUSRDEFND4 varchar(8000),   @I_vUSRDEFND5 varchar(8000),   
@O_iErrorState int output, @oErrString varchar(255) output  
as  
set nocount on  

if NOT exists(SELECT invoice_status 
              FROM INTDB2..ERP_Invoice 
              WHERE invoice_id IN(
                                   SELECT invoice_id 
                                   FROM INTDB2..INT_INVOICE_VIEW 
                                   WHERE user_id = CONVERT(INT, @I_vCUSTNMBR)
                                 ) 
                AND invoice_status in('final_closed', 'final_cancelled')
             )
BEGIN
	DECLARE @iStatus smallint,@iAddCodeErrState int
	DECLARE @REPETICIONES int, @EXISTENTES int

	SELECT @REPETICIONES = ACA_Repeticiones FROM ACA_RID40010 WHERE LEFT(TXRGNNUM, 23) = LEFT(@I_vTXRGNNUM, 23)

	SELECT @REPETICIONES = ISNULL(@REPETICIONES, -1)

	IF EXISTS(SELECT CUSTNMBR FROM RM00101 WITH (NOLOCK) WHERE LEFT(TXRGNNUM, 23) = LEFT(@I_vTXRGNNUM, 23) AND CUSTNMBR <> @I_vCUSTNMBR)
	BEGIN
		IF @REPETICIONES < 0
		BEGIN
			select
				@iStatus = 0,
				@iAddCodeErrState = 0

			select @O_iErrorState = 67001  

			exec @iStatus = taUpdateString
				@O_iErrorState,
				@oErrString,
				@oErrString output,
				@iAddCodeErrState output

			return (@O_iErrorState)  
		END
		IF @REPETICIONES > 0
		BEGIN
			SELECT @EXISTENTES = COUNT(CUSTNMBR) FROM RM00101 WITH (NOLOCK) WHERE LEFT(TXRGNNUM, 23) = LEFT(@I_vTXRGNNUM, 23)
			
			IF @EXISTENTES > @REPETICIONES
			BEGIN

				select
					@iStatus = 0,
					@iAddCodeErrState = 0

				select @O_iErrorState = 67001  

				exec @iStatus = taUpdateString
					@O_iErrorState,
					@oErrString,
					@oErrString output,
					@iAddCodeErrState output

				return (@O_iErrorState)  
			END
		END
	END
END

-- Modificado por MSAL para que solo se inserte en ACA_RFE00102 si el cliente se crea
IF NOT EXISTS (SELECT CUSTNMBR 
               FROM ACA_RFE00102 
               WHERE CUSTNMBR = @I_vCUSTNMBR)
BEGIN
    -- Modificado por MSAL(27-09-2017) para que solo se inserte en ACA_RFE00102 
    -- si el cliente se crea en esta integracion. Asumo que si la fecha de alta y 
    -- modificacion son iguales es porque lo acaba de crear. Sino no estaria en el post.
	IF EXISTS (SELECT CUSTNMBR
               FROM RM00101
               WHERE isnull(MODIFDT,CREATDDT) = CREATDDT
                 AND CUSTNMBR = @I_vCUSTNMBR)
    BEGIN

	    INSERT INTO ACA_RFE00102 SELECT @I_vCUSTNMBR
    END
END

select @O_iErrorState = 0  
return (@O_iErrorState)   

GRANT EXECUTE ON taUpdateCreateCustomerRcdPost TO DYNGRP



GO


