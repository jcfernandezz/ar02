USE [INTDB2]
GO

/****** Object:  View [dbo].[INT_INVOICE_VIEW]    Script Date: 06/26/2018 17:39:43 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[INT_INVOICE_VIEW]'))
DROP VIEW [dbo].[INT_INVOICE_VIEW]
GO

USE [INTDB2]
GO

/****** Object:  View [dbo].[INT_INVOICE_VIEW]    Script Date: 06/26/2018 17:39:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[INT_INVOICE_VIEW]
AS
SELECT	invoice_number_text
		, case when a.transaction_type = 'sale' then 3 else 4 end soptype
		, a.merged_org_id user_id
		, a.merged_org_id org_id
		, date_invoice
		, a.currency
		, ISNULL([address], '') billing_address
		, isnull(c.description, address_country_code) billing_country
		, ISNULL(shipping_address, '') shipping_address
		, isnull(d.description, shipping_address_country_code) shipping_country
		, license_address
		, isnull(e.description, license_address_country_code) license_country
		, '' tax_number
		, UPPER(RTRIM(article_type) + CASE WHEN CONVERT(VARCHAR, ISNULL(product_domain_id, '')) = '0' 
		                                   THEN '' 
		                                   ELSE CONVERT(VARCHAR, ISNULL(product_domain_id, '')) END) article_type
		, article_name
		, article_description article_description
		 --  ,                   UPPER(article_type)+ CASE WHEN isnull(CONVERT(varchar, product_domain_id), '0') <> '0' THEN CONVERT(varchar, product_domain_id) ELSE '' END  article_type, article_name, article_description article_description, 
        , CASE WHEN cmp.INTERID IN('CHI10', 'GCHI') THEN ROUND(price, 0) ELSE price END price
        , CASE WHEN cmp.INTERID IN('CHI10', 'GCHI') THEN ROUND(vat, 0) ELSE vat end vat
        , ISNULL(info, '') info
        , collection_name collection_name
        , img_url
        , cmp.INTERID
        , a.invoice_id
        , article_id
        , CASE WHEN cmp.INTERID <> 'GSPN' THEN CURNCYID ELSE 'U$S' END CURNCYID
        , a.vat_percentage
        , date_pay_by
        , CASE WHEN cmp.INTERID IN('CHI10', 'GCHI') THEN ROUND(discount, 0) ELSE discount END discount
        , isnull(payment_type, '') payment_type
        , ISNULL(txn_id, '') txn_id
        , provision_recipient_price
        , cmp.SERVIDOR --, cmp.INTERID, ccp.INTERID
        , a.totalprice
FROM	INTDB2..ERP_Invoice a WITH (NOLOCK) 
        inner join INTDB2..ERP_Article b  WITH (NOLOCK) on a.invoice_id = b.invoice_id 
        inner join DYNAMICS..BillingCountryDatabase cmp  WITH (NOLOCK) on a.address_country_code = cmp.CCode 
        inner join DYNAMICS..MC40200 mc WITH (NOLOCK) on a.currency = mc.ISOCURRC 
        INner join INTDB2..ERP_Country_Description c WITH (NOLOCK) on a.address_country_code = c.country_code 
                                                                  and a.lang_code = c.language_code 
		LEFT ouTER join INTDB2..ERP_Organisation u on a.merged_org_id = u.merged_org_id
		LEFT OUTER join DYNAMICS..BillingCountryDatabase ccp  WITH (NOLOCK) on u.tax_ref_country_code = ccp.CCode 
		left outer join INTDB2..ERP_Country_Description d WITH (NOLOCK) on a.shipping_address_country_code = d.country_code 
		                                                               and a.lang_code = d.language_code 
		left outer join INTDB2..ERP_Country_Description e WITH (NOLOCK) on a.license_address_country_code = e.country_code 
		                                                               and a.lang_code = e.language_code 
WHERE	a.sync_version_st > a.sync_version_erp and --a.invoice_id = 101035 and
		a.transaction_type in('sale', 'refund') and a.invoice_status in ('final_pending', 'final_closed') 
  and	b.ref_article_id = 0 --article_type not in('picture_in_vcd') 
  and	ISNULL(cmp.INTERID, '') = iSNull(ccp.INTERID, '.')
  and	a.totalprice <> 0 and a.TypeOfRecord = 0
				  --and a.address_country_code IN('MX') --NOT IN( 'PE', 'CO') -- NOT IN( 'PE', 'CO', 'MX')
  and	a.invoice_id not in(120739, 120862)	-- 
UNION ALL
SELECT invoice_number_text
     , 3 soptype
     , a.merged_org_id user_id
     , a.merged_org_id org_id
     , date_invoice
     , a.currency
     , ISNULL([address], '') billing_address
     , isnull(c.description, address_country_code) billing_country
     , ISNULL(shipping_address, '') shipping_address
     , isnull(d.description, shipping_address_country_code) shipping_country
     , license_address
     , isnull(e.description, license_address_country_code) license_country
     , '' tax_number
     , UPPER(RTRIM(article_type)+CASE WHEN CONVERT(VARCHAR, ISNULL(product_domain_id, '')) = '0' THEN '' ELSE CONVERT(VARCHAR, ISNULL(product_domain_id, '')) END) article_type
     , article_name
     , article_description article_description
     , CASE WHEN cmp.INTERID IN('CHI10', 'GCHI') THEN ROUND(price, 0) ELSE price END price
     , CASE WHEN cmp.INTERID IN('CHI10', 'GCHI') THEN ROUND(vat, 0) ELSE vat end vat
     , ISNULL(info, '') info
     , collection_name collection_name
     , img_url
     , cmp.INTERID
     , a.invoice_id
     , article_id
     , CASE WHEN cmp.INTERID <> 'GSPN' THEN CURNCYID ELSE 'U$S' END CURNCYID
     , a.vat_percentage
     , date_pay_by
     , CASE WHEN cmp.INTERID IN('CHI10', 'GCHI') THEN ROUND(discount, 0) ELSE discount END discount
     , isnull(payment_type, '') payment_type
     , ISNULL(txn_id, '') txn_id
     , provision_recipient_price
     , cmp.SERVIDOR
     , a.totalprice
FROM	INTDB2..ERP_Invoice a WITH (NOLOCK) 
        inner join INTDB2..ERP_Article b  WITH (NOLOCK) on a.invoice_id = b.invoice_id 
        inner join DYNAMICS..BillingCountryDatabase cmp  WITH (NOLOCK) on a.address_country_code = cmp.CCode 
        inner join DYNAMICS..MC40200 mc WITH (NOLOCK) on a.currency = mc.ISOCURRC 
        inner join INTDB2..ERP_Country_Description c WITH (NOLOCK) on a.address_country_code = c.country_code 
                                                                  and a.lang_code = c.language_code 
		left outer join INTDB2..ERP_Organisation u on a.merged_org_id = u.merged_org_id
        LEFT OUTER join DYNAMICS..BillingCountryDatabase ccp  WITH (NOLOCK) on u.tax_ref_country_code = ccp.CCode 
        left outer join INTDB2..ERP_Country_Description d WITH (NOLOCK) on a.shipping_address_country_code = d.country_code 
                                                                  and      a.lang_code = d.language_code 
        left outer join INTDB2..ERP_Country_Description e WITH (NOLOCK) on a.license_address_country_code = e.country_code 
                                                                      and  a.lang_code = e.language_code 
WHERE	a.sync_version_st > a.sync_version_erp and  --a.invoice_id = 101035 and
		a.transaction_type in('sale', 'refund') and a.invoice_status in ('final_cancelled') 
  and	b.ref_article_id = 0 --article_type not in('picture_in_vcd') 
  and	ISNULL(cmp.INTERID, '') = iSNull(ccp.INTERID, '.')
  and	a.totalprice <> 0 and a.TypeOfRecord = 0
				  --and ISNULL(cmp.INTERID, '') NOT IN( 'ARTST', 'ARG10') -- NOT IN( 'PE', 'CO', 'MX')
  and	a.invoice_id not in(120739, 120862) 
UNION ALL
SELECT invoice_number_text
     , 4 soptype
     , a.merged_org_id user_id
     , a.merged_org_id org_id
     , date_invoice
     , a.currency
     , ISNULL([address], '') billing_address
     , isnull(c.description, address_country_code) billing_country
     , ISNULL(shipping_address, '') shipping_address
     , isnull(d.description
     , shipping_address_country_code) shipping_country
     , license_address
     , isnull(e.description, license_address_country_code) license_country
     , '' tax_number
     , UPPER(RTRIM(article_type)+CASE WHEN CONVERT(VARCHAR, ISNULL(product_domain_id, '')) = '0' THEN '' ELSE CONVERT(VARCHAR, ISNULL(product_domain_id, '')) END) article_type
     , article_name
     , article_description article_description
     , CASE WHEN cmp.INTERID IN('CHI10', 'GCHI') THEN ROUND(price, 0) ELSE price END price
     , CASE WHEN cmp.INTERID IN('CHI10', 'GCHI') THEN ROUND(vat, 0) ELSE vat end vat
     , ISNULL(info, '') info
     , collection_name collection_name
     , img_url
     , cmp.INTERID
     , a.invoice_id
     , article_id
     , CASE WHEN cmp.INTERID <> 'GSPN' THEN CURNCYID ELSE 'U$S' END CURNCYID
     , a.vat_percentage
     , date_pay_by
     , CASE WHEN cmp.INTERID IN('CHI10', 'GCHI') THEN ROUND(discount, 0) ELSE discount END discount, isnull(payment_type, '') payment_type
     , ISNULL(txn_id, '') txn_id
     , provision_recipient_price
     , cmp.SERVIDOR
     , a.totalprice
FROM	INTDB2..ERP_Invoice a WITH (NOLOCK) 
        inner join INTDB2..ERP_Article b  WITH (NOLOCK) on a.invoice_id = b.invoice_id 
        inner join DYNAMICS..BillingCountryDatabase cmp  WITH (NOLOCK) on a.address_country_code = cmp.CCode 
        inner join DYNAMICS..MC40200 mc WITH (NOLOCK) on a.currency = mc.ISOCURRC 
        inner join INTDB2..ERP_Country_Description c WITH (NOLOCK) on a.address_country_code = c.country_code 
                                                                and   a.lang_code = c.language_code 
		left outer join INTDB2..ERP_Organisation u on a.merged_org_id = u.merged_org_id
        LEFT OUTER join DYNAMICS..BillingCountryDatabase ccp  WITH (NOLOCK) on u.tax_ref_country_code = ccp.CCode 
        inner join INTDB2..ERP_Country_Description d WITH (NOLOCK) on a.shipping_address_country_code = d.country_code and 
                 a.lang_code = d.language_code 
        left outer join INTDB2..ERP_Country_Description e WITH (NOLOCK) on a.license_address_country_code = e.country_code and 
                 a.lang_code = e.language_code 
WHERE	a.sync_version_st > a.sync_version_erp and  --a.invoice_id = 101035 and
		a.transaction_type in('sale', 'refund') and a.invoice_status in ('final_cancelled') 
 and	b.ref_article_id = 0 --article_type not in('picture_in_vcd') 
 and	ISNULL(cmp.INTERID, '') = iSNull(ccp.INTERID, '.')
 and	a.totalprice <> 0 and a.TypeOfRecord = 0
				  --and a.address_country_code NOT IN( 'PE', 'CO') -- NOT IN( 'PE', 'CO', 'MX')
 and	a.invoice_id not in(120739, 120862) 