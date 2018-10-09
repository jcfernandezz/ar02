USE [INTDB2]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_User__tax_cl__53C2623D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_User] DROP CONSTRAINT [DF__ERP_User__tax_cl__53C2623D]
END

GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_User]    Script Date: 10/09/2018 15:20:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ERP_User]') AND type in (N'U'))
DROP TABLE [dbo].[ERP_User]
GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_User]    Script Date: 10/09/2018 15:20:41 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ERP_User](
	[user_id] [int] NOT NULL,
	[org_id] [int] NULL,
	[rights] [char](30) NULL,
	[email] [char](255) NULL,
	[name] [char](255) NULL,
	[firstname] [char](255) NULL,
	[gender] [char](1) NULL,
	[company] [char](64) NULL,
	[contact_details_from_organization] [int] NULL,
	[resulting_address1] [char](50) NULL,
	[resulting_address2] [char](50) NULL,
	[resulting_zip] [char](10) NULL,
	[resulting_city] [char](100) NULL,
	[resulting_state] [char](64) NULL,
	[resulting_countrycode] [char](2) NULL,
	[resulting_url] [char](128) NULL,
	[phone] [char](20) NULL,
	[mobile] [char](20) NULL,
	[fax] [char](20) NULL,
	[languagecode] [char](2) NULL,
	[status] [char](30) NULL,
	[currency] [char](3) NULL,
	[tax_ref_country_code] [char](2) NULL,
	[tax_number] [char](64) NULL,
	[tax_classification] [char](64) NULL,
	[apply_vat] [int] NULL,
	[vat_percentage] [decimal](10, 2) NULL,
	[apply_tax_reduction] [int] NULL,
	[tax_reduction_percentage] [decimal](10, 2) NULL,
	[sales_user_id] [int] NULL,
	[credit_limit_status] [char](20) NULL,
	[total_credit_limit] [decimal](19, 5) NULL,
	[available_credit_limit] [decimal](19, 5) NULL,
	[credit_limit_currency] [char](3) NULL,
	[date_processed] [datetime] NULL,
	[integrated] [smallint] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[modified_on] [datetime] NULL,
	[sync_version_st] [int] NULL,
	[sync_version_erp] [int] NULL,
	[tax_classification_id] [int] NULL,
	[merged_org_id] [char](10) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[ERP_User] ADD [tax_number_state] [char](100) NULL
ALTER TABLE [dbo].[ERP_User] ADD [tax_number_city] [char](100) NULL
ALTER TABLE [dbo].[ERP_User] ADD [resulting_street_number] [varchar](20) NULL
ALTER TABLE [dbo].[ERP_User] ADD [resulting_street_type] [varchar](30) NULL
ALTER TABLE [dbo].[ERP_User] ADD [resulting_suburb] [varchar](50) NULL
ALTER TABLE [dbo].[ERP_User] ADD [transaction_parameters_source] [varchar](15) NULL
/****** Object:  Index [PK__ERP_User__0E591826]    Script Date: 10/09/2018 15:20:41 ******/
ALTER TABLE [dbo].[ERP_User] ADD PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ERP_User] ADD  DEFAULT ((0)) FOR [tax_classification_id]
GO


