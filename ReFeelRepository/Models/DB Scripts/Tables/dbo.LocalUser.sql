-- use database
USE [Refeel];
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LocalUser' AND TABLE_SCHEMA = 'dbo')
BEGIN
   DROP TABLE [dbo].[LocalUser];
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LocalUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] nvarchar(50)  NULL,
	[Lastname] nvarchar(50)  NULL,
	[UserName] nvarchar(50)  NULL,
	[Role] nvarchar(50) null,
	[Password] nvarchar(50) null,
	[PasswordHash] [varbinary](max)  NULL,
	[PasswordSalt] [varbinary](max)  NULL,
	[ImageURL] nvarchar(200),
	[CreationDate] datetime default(getdate())  NULL,
	[UpdateDate] datetime default(getdate())  NULL,
	[PhoneNumber] nvarchar(35)  NULL, -- Will Include extension +40 etc which will provide countryID
	[Email] NVARCHAR(320)  NULL
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


