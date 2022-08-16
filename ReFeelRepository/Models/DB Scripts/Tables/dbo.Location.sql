-- use database
USE [Refeel];
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Location' AND TABLE_SCHEMA = 'dbo')
BEGIN
   DROP TABLE [dbo].[Location];
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[GeoLocationID] int NOT NULL,
	[IsLandMark] bit default(0),
	[LandMarkName] nvarchar(max),
	[RelatedLocationID] int ,
	[CityID] int ,
	[CountyID] int,

 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

, CONSTRAINT FK_LocationGeoLocation FOREIGN KEY (GeoLocationID)
    REFERENCES [GeoLocation](GeoLocationID)
) 



GO


