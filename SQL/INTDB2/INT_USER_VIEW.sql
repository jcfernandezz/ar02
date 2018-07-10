USE [INTDB2]
GO

/****** Object:  View [dbo].[INT_USER_VIEW]    Script Date: 06/26/2018 17:39:04 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[INT_USER_VIEW]'))
DROP VIEW [dbo].[INT_USER_VIEW]
GO

USE [INTDB2]
GO

/****** Object:  View [dbo].[INT_USER_VIEW]    Script Date: 06/26/2018 17:39:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[INT_USER_VIEW]
AS
SELECT C.CCodeDesc Country
     , A.merged_org_id Customer
     , a.name Name
     , rtrim(a.shortname) ShortName
     , a.name StatementName
     , rtrim(A.tax_number) CUIT_NIC
     , 0 CreditLimit
     , contactAddress Address1
     , contactAddress2 Address2
     , zip Zip
     , city City
     , state State
     , tax_ref_country_code Countrycode
     , phone Phone
     , fax Fax
     , A.tax_classification TaxClasification
     , A.sync_version_st Status
     , A.merged_org_id ID
     , B.INTERID
     , Rtrim(A.contactLastName) + ' ' + rtrim(A.contactFirstName) Contact
     , A.merged_org_id Empresa
     , B.SERVIDOR 
FROM	INTDB2..ERP_Organisation A WITH (NOLOCK) 
        inner join DYNAMICS..BillingCountryDatabase B WITH (NOLOCK) ON A.tax_ref_country_code = B.CCode 
        inner join DYNAMICS..UPR41105 C WITH (NOLOCK) ON A.tax_ref_country_code = C.CCode 
				--left outer join ERP_User_Accounting_Assigned_Credit D on A.user_id = D.user_id
where --A.sync_version_st > A.sync_version_erp AND 
         A.city is not null and A.TypeOfRecord = 0 
  AND A.merged_org_id IN(SELECT distinct org_id from INT_INVOICE_VIEW)
















GO