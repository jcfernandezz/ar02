USE [INTDB2]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_Invoi__tax_c__52CE3E04]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_Invoice] DROP CONSTRAINT [DF__ERP_Invoi__tax_c__52CE3E04]
END

GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Invoice]    Script Date: 10/09/2018 15:20:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ERP_Invoice]') AND type in (N'U'))
DROP TABLE [dbo].[ERP_Invoice]
GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Invoice]    Script Date: 10/09/2018 15:20:22 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ERP_Invoice](
	[invoice_id] [int] NOT NULL,
	[division_id] [int] NULL,
	[lang_code] [char](2) NULL,
	[invoice_version_id] [int] NULL,
	[version_datetime] [datetime] NULL,
	[transaction_type] [char](30) NULL,
	[transaction_ref_invoice_id] [int] NULL,
	[invoice_status] [char](30) NULL,
	[invoice_type] [char](30) NULL,
	[invoice_number] [int] NULL,
	[invoice_number_text] [char](50) NULL,
	[title] [char](255) NULL,
	[object_description] [char](255) NULL,
	[delivery_description] [char](255) NULL,
	[date_invoice] [datetime] NULL,
	[date_letter] [datetime] NULL,
	[date_pay_by] [datetime] NULL,
	[user_id] [int] NULL,
	[org_id] [int] NULL,
	[coworker_id] [int] NULL,
	[total_netto_price_raw] [decimal](14, 2) NULL,
	[apply_discount] [char](1) NULL,
	[discount_percentage] [decimal](10, 2) NULL,
	[discount] [decimal](14, 2) NULL,
	[discount_description] [char](255) NULL,
	[total_netto_price] [decimal](14, 2) NULL,
	[vat_percentage] [decimal](10, 2) NULL,
	[vat] [decimal](14, 2) NULL,
	[tax_reduction_percentage] [decimal](10, 2) NULL,
	[tax_reduction] [decimal](14, 2) NULL,
	[totalprice] [decimal](14, 2) NULL,
	[payed] [decimal](14, 2) NULL,
	[payed_vat] [decimal](10, 2) NULL,
	[payed_tax_reduction] [decimal](14, 2) NULL,
	[delcredere_amount] [decimal](14, 2) NULL,
	[delcredere_date] [datetime] NULL,
	[delcredere_comment] [char](255) NULL,
	[currency] [char](3) NULL,
	[txn_id] [char](20) NULL,
	[payment_type] [char](10) NULL,
	[memo] [text] NULL,
	[payment_status] [char](20) NULL,
	[il_deleted] [char](1) NULL,
	[date_payed] [datetime] NULL,
	[address_origin] [char](30) NULL,
	[address] [text] NULL,
	[address_country_code] [char](2) NULL,
	[used_user_for_shipping_address] [int] NULL,
	[shipping_address_origin] [char](30) NULL,
	[shipping_address] [text] NULL,
	[shipping_address_country_code] [char](2) NULL,
	[used_user_for_license_address] [int] NULL,
	[license_address_origin] [char](30) NULL,
	[license_address] [text] NULL,
	[license_address_country_code] [char](2) NULL,
	[created_by] [int] NULL,
	[modified_by] [int] NULL,
	[created_on] [datetime] NULL,
	[finalized_on] [datetime] NULL,
	[closed_on] [datetime] NULL,
	[cancelled_on] [datetime] NULL,
	[booking_invoice_account_valid] [char](3) NULL,
	[booking_debited_invoice_account_id] [int] NULL,
	[booking_credited_invoice_account_id] [int] NULL,
	[booking_credited_tax_reduction_invoice_account_id] [int] NULL,
	[booking_credited_vat_invoice_account_id] [int] NULL,
	[invoice_cost_center_id] [int] NULL,
	[tax_number] [char](64) NULL,
	[tax_classification] [char](64) NULL,
	[sync_version_st] [int] NULL,
	[sync_version_erp] [int] NULL,
	[tax_classification_id] [int] NULL,
	[merged_org_id] [char](10) NULL,
	[nmb_of_articles] [int] NULL,
	[TypeOfRecord] [tinyint] NULL,
	[CreationDate] [datetime] NULL,
	[ProcessedDate] [datetime] NULL,
	[IntegrationStatus] [smallint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[ERP_Invoice] ADD [ErrorStr] [char](255) NULL
ALTER TABLE [dbo].[ERP_Invoice] ADD [tax_number_state] [char](100) NULL
ALTER TABLE [dbo].[ERP_Invoice] ADD [tax_number_city] [char](100) NULL
ALTER TABLE [dbo].[ERP_Invoice] ADD [unique_user_id] [int] NULL
/****** Object:  Index [PK__ERP_Invoice__10416098]    Script Date: 10/09/2018 15:20:22 ******/
ALTER TABLE [dbo].[ERP_Invoice] ADD PRIMARY KEY CLUSTERED 
(
	[invoice_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ERP_Invoice] ADD  DEFAULT ((0)) FOR [tax_classification_id]
GO


