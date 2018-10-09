USE [INTDB2]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___st_de__7B4643B2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___st_de__7B4643B2]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___user___7C3A67EB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___user___7C3A67EB]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___ref_o__7D2E8C24]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___ref_o__7D2E8C24]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___ref_o__7E22B05D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___ref_o__7E22B05D]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___ref_o__7F16D496]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___ref_o__7F16D496]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___invoi__000AF8CF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___invoi__000AF8CF]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___invoi__00FF1D08]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___invoi__00FF1D08]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___amoun__01F34141]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___amoun__01F34141]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___amoun__02E7657A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___amoun__02E7657A]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User_S__type__03DB89B3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User_S__type__03DB89B3]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___sync___04CFADEC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___sync___04CFADEC]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User___sync___05C3D225]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] DROP CONSTRAINT [DF__ERP_User___sync___05C3D225]
END

GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_User_Sale_Debit_Delta]    Script Date: 10/09/2018 15:23:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ERP_User_Sale_Debit_Delta]') AND type in (N'U'))
DROP TABLE [dbo].[ERP_User_Sale_Debit_Delta]
GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_User_Sale_Debit_Delta]    Script Date: 10/09/2018 15:23:42 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ERP_User_Sale_Debit_Delta](
	[erp_debit_delta_id] [int] IDENTITY(1,1) NOT NULL,
	[st_debit_delta_id] [int] NULL,
	[user_id] [int] NULL,
	[ref_obj_type] [char](20) NULL,
	[ref_obj_id_type] [char](20) NULL,
	[ref_obj_id] [int] NULL,
	[invoice_id] [int] NULL,
	[invoice_version_id] [int] NULL,
	[amount] [decimal](19, 5) NULL,
	[currency] [char](3) NULL,
	[amount_type] [char](20) NULL,
	[type] [char](20) NULL,
	[created_on] [datetime] NULL,
	[sync_version_st] [int] NULL,
	[sync_version_erp] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[erp_debit_delta_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ((0)) FOR [st_debit_delta_id]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ((0)) FOR [user_id]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ('internal') FOR [ref_obj_type]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ('invoice') FOR [ref_obj_id_type]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ((0)) FOR [ref_obj_id]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ((0)) FOR [invoice_id]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ((0)) FOR [invoice_version_id]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ((0.00)) FOR [amount]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ('relative') FOR [amount_type]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ('final') FOR [type]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ((0)) FOR [sync_version_st]
GO

ALTER TABLE [dbo].[ERP_User_Sale_Debit_Delta] ADD  DEFAULT ((0)) FOR [sync_version_erp]
GO


