USE [ARG10]
GO

/****** Object:  StoredProcedure [dbo].[ACA_Set_Invoice_Error]    Script Date: 07/10/2018 18:12:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACA_Set_Invoice_Error]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACA_Set_Invoice_Error]
GO

USE [ARG10]
GO

/****** Object:  StoredProcedure [dbo].[ACA_Set_Invoice_Error]    Script Date: 07/10/2018 18:12:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[ACA_Set_Invoice_Error] @invoice_id int, @SOPTYPE smallint
AS
/*
IF EXISTS(SELECT SOPNUMBE FROM INT_SOPHDR WHERE INTEGRATIONID = CONVERT(VARCHAR, @invoice_id) AND SOPTYPE = @SOPTYPE)
BEGIN
	UPDATE INTDB2..ERP_Invoice SET ErrorStr = 'Sql procedure error codes returned:  Error Number = 67000  Stored Procedure taSopHdrIvcInsert  Error Description = El invoice_id ' + CONVERT(varchar, @invoice_id) + ' ya ha sido integrado'
	WHERE invoice_id = @invoice_id AND IntegrationStatus = 0
END
*/
IF EXISTS(SELECT CUSTNMBR FROM ACA_RFE00102 WHERE CUSTNMBR = (SELECT RIGHT('00000000' + convert(varchar, merged_org_id), 9) from INTDB2..ERP_Invoice WHERE invoice_id = @invoice_id AND IntegrationStatus = 0))
BEGIN
	DECLARE @DIATOPE SMALLINT, @DOCDATE datetime
	
	SELECT @DOCDATE = convert(char(8), ProcessedDate, 112) from INTDB2..ERP_Invoice WHERE invoice_id = @invoice_id
	
	IF EXISTS(SELECT DAY1 FROM ACA_RFE40002 WHERE YEAR1 = YEAR(@DOCDATE) AND MONTH11 = MONTH(@DOCDATE))
	BEGIN		
		SELECT @DIATOPE = DAY1 FROM ACA_RFE40002 WHERE YEAR1 = YEAR(@DOCDATE) AND MONTH11 = MONTH(@DOCDATE)

		SELECT @DIATOPE = ISNULL(@DIATOPE, 31)
		
		IF day(@DOCDATE) >= @DIATOPE
		BEGIN
			UPDATE INTDB2..ERP_Invoice SET ErrorStr = 'Sql procedure error codes returned:  Error Number = 67004  Stored Procedure taSopHdrIvcInsert  Error Description = La fecha del documento es posterior a la fecha tope configurada'
			WHERE invoice_id = @invoice_id AND IntegrationStatus = 0 AND DAY(@DOCDATE) >= @DIATOPE
		END
	END		

END



GO


