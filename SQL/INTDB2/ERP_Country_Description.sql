USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Country_Description]    Script Date: 10/09/2018 15:22:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ERP_Country_Description]') AND type in (N'U'))
DROP TABLE [dbo].[ERP_Country_Description]
GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Country_Description]    Script Date: 10/09/2018 15:22:57 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ERP_Country_Description](
	[id] [int] NOT NULL,
	[country_code] [char](2) NOT NULL,
	[language_code] [char](2) NOT NULL,
	[description] [char](255) NULL,
	[sync_version_st] [int] NULL,
	[sync_version_erp] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_ERP_Country_Description] UNIQUE NONCLUSTERED 
(
	[country_code] ASC,
	[language_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


