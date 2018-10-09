USE [INTDB2]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_Organ__paren__4D1564AE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_Organisation] DROP CONSTRAINT [DF__ERP_Organ__paren__4D1564AE]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_Organ__defau__4E0988E7]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_Organisation] DROP CONSTRAINT [DF__ERP_Organ__defau__4E0988E7]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_Organ__modif__4EFDAD20]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_Organisation] DROP CONSTRAINT [DF__ERP_Organ__modif__4EFDAD20]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_Organ__tax_c__4FF1D159]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_Organisation] DROP CONSTRAINT [DF__ERP_Organ__tax_c__4FF1D159]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_Organ__sync___50E5F592]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_Organisation] DROP CONSTRAINT [DF__ERP_Organ__sync___50E5F592]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_Organ__sync___51DA19CB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_Organisation] DROP CONSTRAINT [DF__ERP_Organ__sync___51DA19CB]
END

GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Organisation]    Script Date: 10/09/2018 15:20:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ERP_Organisation]') AND type in (N'U'))
DROP TABLE [dbo].[ERP_Organisation]
GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Organisation]    Script Date: 10/09/2018 15:20:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ERP_Organisation](
	[org_id] [int] NOT NULL,
	[parent_org_id] [int] NULL,
	[default_user_id] [int] NULL,
	[name] [char](100) NULL,
	[shortname] [char](100) NULL,
	[contactGender] [char](1) NULL,
	[contactFirstName] [char](100) NULL,
	[contactLastName] [char](100) NULL,
	[contactAddress] [char](255) NULL,
	[billingGender] [char](1) NULL,
	[billingFirstName] [char](100) NULL,
	[billingLastName] [char](100) NULL,
	[billingAddress] [char](255) NULL,
	[email] [char](255) NULL,
	[url] [char](255) NULL,
	[status] [char](30) NULL,
	[lastModified] [datetime] NULL,
	[modifiedBy] [int] NULL,
	[old_org_id] [char](10) NULL,
	[name2] [char](255) NULL,
	[name3] [char](255) NULL,
	[sort] [char](255) NULL,
	[contactAddress2] [char](255) NULL,
	[country] [char](2) NULL,
	[state] [char](255) NULL,
	[zip] [char](255) NULL,
	[pobox] [char](255) NULL,
	[zipbox] [char](255) NULL,
	[city] [char](255) NULL,
	[phone] [char](255) NULL,
	[fax] [char](255) NULL,
	[cellphone] [char](255) NULL,
	[ISDNNumber] [char](255) NULL,
	[ISDNType] [char](255) NULL,
	[languageCode] [char](2) NULL,
	[comment] [char](255) NULL,
	[invoiceCustomerId] [char](255) NULL,
	[deliveryCustomerId] [char](255) NULL,
	[admin_comment] [char](255) NULL,
	[custom_field] [char](255) NULL,
	[tax_ref_country_code] [char](2) NULL,
	[tax_number] [char](255) NULL,
	[tax_classification_id] [int] NULL,
	[tax_classification] [char](64) NULL,
	[type] [char](30) NULL,
	[ressort] [char](255) NULL,
	[specification] [char](255) NULL,
	[sync_version_st] [int] NULL,
	[sync_version_erp] [int] NULL,
	[merged_org_id] [char](10) NOT NULL,
	[processed] [datetime] NULL,
	[integrated] [tinyint] NULL,
	[int_message] [char](255) NULL,
	[TypeOfRecord] [tinyint] NULL,
	[CreationDate] [datetime] NULL,
	[tax_number_state] [char](100) NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[ERP_Organisation] ADD [tax_number_city] [char](100) NULL
/****** Object:  Index [PK_ERP_Organisation]    Script Date: 10/09/2018 15:20:32 ******/
ALTER TABLE [dbo].[ERP_Organisation] ADD  CONSTRAINT [PK_ERP_Organisation] PRIMARY KEY CLUSTERED 
(
	[org_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ERP_Organisation] ADD  CONSTRAINT [DF__ERP_Organ__paren__4D1564AE]  DEFAULT ((0)) FOR [parent_org_id]
GO

ALTER TABLE [dbo].[ERP_Organisation] ADD  CONSTRAINT [DF__ERP_Organ__defau__4E0988E7]  DEFAULT ((0)) FOR [default_user_id]
GO

ALTER TABLE [dbo].[ERP_Organisation] ADD  CONSTRAINT [DF__ERP_Organ__modif__4EFDAD20]  DEFAULT ((0)) FOR [modifiedBy]
GO

ALTER TABLE [dbo].[ERP_Organisation] ADD  CONSTRAINT [DF__ERP_Organ__tax_c__4FF1D159]  DEFAULT ((0)) FOR [tax_classification_id]
GO

ALTER TABLE [dbo].[ERP_Organisation] ADD  CONSTRAINT [DF__ERP_Organ__sync___50E5F592]  DEFAULT ((0)) FOR [sync_version_st]
GO

ALTER TABLE [dbo].[ERP_Organisation] ADD  CONSTRAINT [DF__ERP_Organ__sync___51DA19CB]  DEFAULT ((0)) FOR [sync_version_erp]
GO


