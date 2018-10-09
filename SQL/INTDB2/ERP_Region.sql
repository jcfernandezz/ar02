USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Region]    Script Date: 10/09/2018 15:23:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ERP_Region]') AND type in (N'U'))
DROP TABLE [dbo].[ERP_Region]
GO

USE [INTDB2]
GO

/****** Object:  Table [dbo].[ERP_Region]    Script Date: 10/09/2018 15:23:11 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ERP_Region](
	[pk_id] [int] NOT NULL,
	[region_id] [int] NOT NULL,
	[language_code] [char](2) NOT NULL,
	[region] [char](100) NULL,
	[parent_id] [int] NOT NULL,
	[number] [int] NOT NULL,
	[sync_version_st] [int] NULL,
	[sync_version_erp] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_ERP_Region] UNIQUE NONCLUSTERED 
(
	[region_id] ASC,
	[language_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


