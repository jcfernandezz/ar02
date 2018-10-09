USE [INTDB2]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ERP_Artic__produ__1E256B9B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ERP_Article] DROP CONSTRAINT [DF__ERP_Artic__produ__1E256B9B]
END

GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Article]    Script Date: 10/09/2018 15:20:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ERP_Article]') AND type in (N'U'))
DROP TABLE [dbo].[ERP_Article]
GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Article]    Script Date: 10/09/2018 15:20:07 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ERP_Article](
	[invoice_id] [int] NULL,
	[article_id] [int] NOT NULL,
	[transaction_type] [char](30) NULL,
	[transaction_ref_article_id] [int] NULL,
	[article_type] [char](30) NULL,
	[article_name] [char](100) NULL,
	[article_description] [char](255) NULL,
	[ref_article_id] [int] NULL,
	[ref_article_reference] [char](100) NULL,
	[ref_article_invoice_reference] [char](100) NULL,
	[ref_article_price] [decimal](14, 2) NULL,
	[ref_article_provision] [decimal](14, 2) NULL,
	[ref_article_currency] [char](3) NULL,
	[ref_obj_id] [int] NULL,
	[pic_id] [int] NULL,
	[user_id] [int] NULL,
	[show_discount_info] [char](1) NULL,
	[show_gross_price_info] [char](1) NULL,
	[gross_price] [decimal](14, 2) NULL,
	[discount_description] [char](255) NULL,
	[discount_amount] [decimal](14, 2) NULL,
	[price] [decimal](14, 2) NULL,
	[currency] [char](3) NULL,
	[provision_recipient_user_id] [int] NULL,
	[applied_provision_recipient_percentage_origin] [char](30) NULL,
	[provision_recipient_percentage] [decimal](10, 2) NULL,
	[provision_recipient_substraction] [decimal](14, 2) NULL,
	[provision_recipient_substraction_comment] [char](255) NULL,
	[provision_recipient_price] [decimal](14, 2) NULL,
	[sorder] [int] NULL,
	[sub_sorder] [int] NULL,
	[applied_pricelist] [char](4) NULL,
	[info] [char](255) NULL,
	[comment] [char](255) NULL,
	[show_media_info] [char](1) NULL,
	[media_type] [char](30) NULL,
	[usage_description_for_media] [char](255) NULL,
	[usage_rights_for_media] [char](255) NULL,
	[circulation_of_media] [char](100) NULL,
	[publication_duration_in_media] [char](100) NULL,
	[publication_expiring_date] [datetime] NULL,
	[publication_placement_in_media] [char](100) NULL,
	[publication_size_in_media] [char](50) NULL,
	[delivery_date_on_invoice] [datetime] NULL,
	[media_publication_date] [datetime] NULL,
	[media_code] [char](100) NULL,
	[media_publication_country_code] [char](2) NULL,
	[max_size] [decimal](12, 6) NULL,
	[max_size_type] [char](30) NULL,
	[dpi_size] [smallint] NULL,
	[buyer_note] [char](255) NULL,
	[collection_id] [int] NULL,
	[collection_name] [char](50) NULL,
	[collection_number] [char](64) NULL,
	[img_url] [char](255) NULL,
	[sync_version_st] [int] NULL,
	[sync_version_erp] [int] NULL,
	[TypeOfRecord] [tinyint] NULL,
	[CreationDate] [datetime] NULL,
	[article_subtype] [char](50) NULL,
	[product_media_type] [char](20) NULL,
	[product_domain_id] [int] NULL,
	[product_domain_reference] [char](100) NULL,
	[article_reference] [char](50) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[ERP_Article] ADD [license_exclusivity] [varchar](3) NULL
ALTER TABLE [dbo].[ERP_Article] ADD [license_exclusivity_extended] [int] NULL
ALTER TABLE [dbo].[ERP_Article] ADD [license_usage_number] [int] NULL
ALTER TABLE [dbo].[ERP_Article] ADD [license_usage_name] [varchar](255) NULL
ALTER TABLE [dbo].[ERP_Article] ADD [license_industry_number] [int] NULL
ALTER TABLE [dbo].[ERP_Article] ADD [license_industry_name] [varchar](255) NULL
ALTER TABLE [dbo].[ERP_Article] ADD [license_landcode_list] [varchar](255) NULL
/****** Object:  Index [PK__ERP_Article__1229A90A]    Script Date: 10/09/2018 15:20:07 ******/
ALTER TABLE [dbo].[ERP_Article] ADD PRIMARY KEY CLUSTERED 
(
	[article_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ERP_Article] ADD  DEFAULT ((0)) FOR [product_domain_id]
GO


