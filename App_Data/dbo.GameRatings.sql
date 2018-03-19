CREATE TABLE [dbo].[GameRatings]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [user_id] INT NOT NULL, 
    [game_id] INT NOT NULL, 
    [comment] VARCHAR(150) NULL, 
    [rating] INT NOT NULL, 
    CONSTRAINT [FK_GameRatings_Users] FOREIGN KEY ([user_id]) REFERENCES [Users]([id]), 
    CONSTRAINT [FK_GameRatings_Games] FOREIGN KEY ([game_id]) REFERENCES [Games]([id])
)
