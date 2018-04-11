CREATE TABLE [dbo].[GameRatings] (
    [user_id] INT           NOT NULL,
    [game_id] INT           NOT NULL,
    [comment] VARCHAR (150) NULL,
    [rating]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([game_id], [user_id]),
    CONSTRAINT [FK_GameRatings_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id]),
    CONSTRAINT [FK_GameRatings_Games] FOREIGN KEY ([game_id]) REFERENCES [dbo].[Games] ([id])
);

