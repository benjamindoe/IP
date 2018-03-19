CREATE TABLE [dbo].[OrderItems] (
    [order_id] INT NOT NULL,
    [game_id]  INT NOT NULL,
    [quantity] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([game_id] ASC, [order_id] ASC), 
    CONSTRAINT [FK_OrderItems_Games] FOREIGN KEY ([game_id]) REFERENCES [Games]([id]), 
    CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([order_id]) REFERENCES [Orders]([id])
);

