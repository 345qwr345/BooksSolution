CREATE DATABASE QuickKartDB
GO

USE QuickKartDB
GO

CREATE TABLE [dbo].[Books](
	[BookId] [tinyint] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](100) NULL,
	[AuthorName] [varchar](100) NULL,
	)
GO 
