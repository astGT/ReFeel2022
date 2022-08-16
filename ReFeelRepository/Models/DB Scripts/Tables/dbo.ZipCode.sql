-- use database
USE [Refeel];
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SysBrand' AND TABLE_SCHEMA = 'dbo')
BEGIN
   DROP TABLE [dbo].[SysBrand];
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SysBrand](
	[SysBrandID] [int] IDENTITY(1,1) NOT NULL,
	[Name] Varchar(50),

 CONSTRAINT [PK_SysBrand] PRIMARY KEY CLUSTERED 
(
	[SysBrandID] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

) 

GO

