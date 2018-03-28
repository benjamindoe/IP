CREATE TABLE [dbo].[Orders] (
    [id]       INT   NOT NULL IDENTITY,
    [user_id]  INT   NOT NULL,
    [subtotal] MONEY NOT NULL,
    [date]     DATE  NOT NULL,
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id]), 
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([id])
);

