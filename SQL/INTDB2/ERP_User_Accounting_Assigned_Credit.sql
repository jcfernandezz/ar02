USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_User_Accounting_Assigned_Credit]    Script Date: 10/09/2018 15:23:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ERP_User_Accounting_Assigned_Credit]') AND type in (N'U'))
DROP TABLE [dbo].[ERP_User_Accounting_Assigned_Credit]
GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_User_Accounting_Assigned_Credit]    Script Date: 10/09/2018 15:23:35 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ERP_User_Accounting_Assigned_Credit](
	[user_id] [int] NOT NULL,
	[credit_limit_status] [char](20) NULL,
	[total_credit_limit] [decimal](19, 5) NULL,
	[available_credit_limit] [decimal](19, 5) NULL,
	[credit_limit_currency] [char](3) NULL,
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


