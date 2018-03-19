CREATE TABLE [dbo].[Orders]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [user_id] INT NOT NULL, 
    [subtotal] MONEY NOT NULL, 
    [date] DATE NOT NULL, 
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([user_id]) REFERENCES [Users]([id])
)
