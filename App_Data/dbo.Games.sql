CREATE TABLE [dbo].[Table]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [title] VARCHAR(50) NOT NULL, 
    [description] TEXT NULL, 
    [overall_rating] TINYINT NULL, 
    [price] INT NOT NULL, 
    [release_date] DATE NULL, 
    [age_rating] VARCHAR(10) NULL
)
