-- use database
USE [Refeel];
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Driver' AND TABLE_SCHEMA = 'dbo')
BEGIN
   DROP TABLE [dbo].[Driver];
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Driver](
	[DriverID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] INT NOT NULL,
	[LicenseID] INT NOT NULL,
	[RatingID] INT NOT NULL,
	[CarID] INT NOT NULL,
	[CreationDate] DATETIME default(getdate()) NOT NULL,
	[IsActive] bit default(0)
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[DriverID] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

--, CONSTRAINT FK_DriverUser FOREIGN KEY (UserID)
--    REFERENCES [User](UserID)

--, CONSTRAINT FK_DriverLicense FOREIGN KEY (LicenseID)
--REFERENCES [License](LicenseID)

--, CONSTRAINT FK_DriverCar FOREIGN KEY (CarID)
--REFERENCES [Car](CarID)
) 


GO


