﻿CREATE TABLE [dbo].[Inventory]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ItemId] INT NOT NULL UNIQUE FOREIGN KEY REFERENCES [dbo].[Item]([Id]),
	[Quantity] INT NULL DEFAULT 0,
	[CreatedOn] DATETIMEOFFSET NOT NULL,
	[UpdatedOn] DATETIMEOFFSET NULL,
);

