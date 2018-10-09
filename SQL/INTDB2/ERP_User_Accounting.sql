USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_User_Accounting]    Script Date: 10/09/2018 15:23:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ERP_User_Accounting]') AND type in (N'U'))
DROP TABLE [dbo].[ERP_User_Accounting]
GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_User_Accounting]    Script Date: 10/09/2018 15:23:27 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ERP_User_Accounting](
	[user_id] [int] NOT NULL,
	[sale_invoice_debit_limit_status] [char](20) NULL,
	[sale_invoice_total_debit_limit] [decimal](19, 5) NULL,
	[sale_invoice_finalized_debit] [decimal](19, 5) NULL,
	[sale_invoice_proposal_debit] [decimal](19, 5) NULL,
	[sale_invoice_debit_limit_currency] [char](3) NULL,
	[modified_on] [datetime] NULL,
	[sync_version_st] [int] NULL,
	[sync_version_erp] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


