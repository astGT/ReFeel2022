-- use database
USE [Refeel];
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Payment' AND TABLE_SCHEMA = 'dbo')
BEGIN
   DROP TABLE [dbo].[Payment];
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] DATETIME default(getdate()) NOT NULL,
	[BaseAmount] decimal (10,2),
	[SurgeAmount] decimal (10,2),
	[TotalAmount] decimal (10,2),
	[CardAccountNo] varchar(50),
	[TransactionID] int


 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

) 

GO


