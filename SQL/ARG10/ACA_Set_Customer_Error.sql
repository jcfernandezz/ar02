USE [ARG10]
GO

/****** Object:  StoredProcedure [dbo].[ACA_Set_Customer_Error]    Script Date: 07/10/2018 18:11:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACA_Set_Customer_Error]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACA_Set_Customer_Error]
GO

USE [ARG10]
GO

/****** Object:  StoredProcedure [dbo].[ACA_Set_Customer_Error]    Script Date: 07/10/2018 18:11:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE procedure [dbo].[ACA_Set_Customer_Error]  @I_vCUSTNMBR char(15), @I_vTXRGNNUM char(25)
as  
set nocount on  

BEGIN
	DECLARE @REPETICIONES int, @EXISTENTES int
	DECLARE @int_message char(255)
	
	select
		@int_message = 'Sql procedure error codes returned:  Error Number = 67001  Stored Procedure taUpdateCreateCustomerRcd  Error Description = El tax_number ya existe en otro cliente  Node Identifier Parameters: taUpdateCreateCustomerRcd                            TXRGNNUM ='

	SELECT @REPETICIONES = ACA_Repeticiones FROM ACA_RID40010 WHERE LEFT(TXRGNNUM, 23) = LEFT(@I_vTXRGNNUM, 23)

	SELECT @REPETICIONES = ISNULL(@REPETICIONES, -1)

	IF EXISTS(SELECT CUSTNMBR FROM RM00101 WITH (NOLOCK) WHERE LEFT(TXRGNNUM, 23) = LEFT(@I_vTXRGNNUM, 23) AND CUSTNMBR <> @I_vCUSTNMBR)
	BEGIN
		IF @REPETICIONES < 0
		BEGIN

			UPDATE INTDB2..ERP_Organisation SET int_message = @int_message where merged_org_id = CONVERT(INT, @I_vCUSTNMBR)
				AND integrated = 0
		END
		IF @REPETICIONES > 0
		BEGIN
			SELECT @EXISTENTES = COUNT(CUSTNMBR) FROM RM00101 WITH (NOLOCK) WHERE LEFT(TXRGNNUM, 23) = LEFT(@I_vTXRGNNUM, 23)
			
			IF @EXISTENTES > @REPETICIONES
			BEGIN

				UPDATE INTDB2..ERP_Organisation SET int_message = @int_message where merged_org_id = CONVERT(INT, @I_vCUSTNMBR)
				AND integrated = 0
			END
		END
	END
END


GO


