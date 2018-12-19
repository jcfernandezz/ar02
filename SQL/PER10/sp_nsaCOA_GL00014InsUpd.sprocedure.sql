IF OBJECT_ID('sp_nsaCOA_GL00014InsUpd','P') IS NOT NULL
DROP PROC dbo.sp_nsaCOA_GL00014InsUpd

GO
--Propósito. Agrega datos adicionales para FE ubl 2.1--19/12/18 jcf Creación--CREATE PROCEDURE dbo.sp_nsaCOA_GL00014InsUpd@nsa_RUC_Cliente              char(19),@CUSTNMBR                     char(15),@NAME                         char(31) = NULL,@cod_detraccion               char(5) = NULL,@motivoNCND                   char(101) = NULL,@comprobanteRelacionado       char(23) = NULL,@comprobanteRelacionaSopt     smallint = NULL,@DOCNUMBR                     char(21),@DOCTYPE                      smallint = NULL,@DOCDATE                      datetime = NULL,@nsa_Cod_Transac              char(5) = NULL,@nsa_Tipo_Comprob             char(3) = NULL,@nsaCOA_Date_Nota             datetime = NULL,@nsa_Iva                      char(3) = NULL,@nsa_Cod_ICE                  char(3) = NULL,@DATERECD                     datetime = NULL,@nsaCOA_Devolucion            tinyint = NULL,@nsa_Cred_Trib                char(3) = NULL,@nsa_Sernota                  char(7) = NULL,@nsa_BaseCero                 numeric = NULL,@nsa_MontoIVA                 numeric = NULL,@nsaCOA_MontoICE              numeric = NULL,@DOCAMNT                      numeric = NULLAS
IF EXISTS (SELECT 1 FROM dbo.nsaCOA_GL00014WHERE nsa_RUC_Cliente = @nsa_RUC_Cliente   AND CUSTNMBR = @CUSTNMBR   AND DOCNUMBR = @DOCNUMBR )
BEGIN
 
UPDATE dbo.nsaCOA_GL00014   SET --NAME                         = @NAME,       cod_detraccion               = @cod_detraccion,       motivoNCND                   = @motivoNCND,       comprobanteRelacionado       = @comprobanteRelacionado,       comprobanteRelacionaSopt     = @comprobanteRelacionaSopt,       --DOCTYPE                      = @DOCTYPE,       --DOCDATE                      = @DOCDATE,       nsa_Cod_Transac              = @nsa_Cod_Transac,       nsa_Tipo_Comprob             = @nsa_Tipo_Comprob,       --nsaCOA_Date_Nota             = @nsaCOA_Date_Nota,       --nsa_Iva                      = @nsa_Iva,       --nsa_Cod_ICE                  = @nsa_Cod_ICE,       --DATERECD                     = @DATERECD,       --nsaCOA_Devolucion            = @nsaCOA_Devolucion,       nsa_Cred_Trib                = @nsa_Cred_Trib       --nsa_Sernota                  = @nsa_Sernota,       --nsa_BaseCero                 = @nsa_BaseCero,       --nsa_MontoIVA                 = @nsa_MontoIVA,       --nsaCOA_MontoICE              = @nsaCOA_MontoICE,       --DOCAMNT                      = @DOCAMNT WHERE nsa_RUC_Cliente = @nsa_RUC_Cliente   AND CUSTNMBR = @CUSTNMBR   AND DOCNUMBR = @DOCNUMBR 
 
END
ELSE
BEGIN
 
INSERT INTO dbo.nsaCOA_GL00014(nsa_RUC_Cliente,CUSTNMBR,NAME,cod_detraccion,motivoNCND,comprobanteRelacionado,comprobanteRelacionaSopt,DOCNUMBR,DOCTYPE,DOCDATE,nsa_Cod_Transac,nsa_Tipo_Comprob,nsaCOA_Date_Nota,nsa_Iva,nsa_Cod_ICE,DATERECD,nsaCOA_Devolucion,nsa_Cred_Trib,nsa_Sernota,nsa_BaseCero,nsa_MontoIVA,nsaCOA_MontoICE,DOCAMNT)SELECT @nsa_RUC_Cliente,@CUSTNMBR,@NAME,@cod_detraccion,@motivoNCND,@comprobanteRelacionado,@comprobanteRelacionaSopt,@DOCNUMBR,@DOCTYPE,@DOCDATE,@nsa_Cod_Transac,@nsa_Tipo_Comprob,@nsaCOA_Date_Nota,@nsa_Iva,@nsa_Cod_ICE,@DATERECD,@nsaCOA_Devolucion,@nsa_Cred_Trib,@nsa_Sernota,@nsa_BaseCero,@nsa_MontoIVA,@nsaCOA_MontoICE,@DOCAMNT
 
END
 
GO
--select *
--from nsaCOA_GL00014

--sp_statistics nsaCOA_GL00014
