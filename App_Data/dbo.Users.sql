CREATE TABLE [dbo].[Users] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (50)  NOT NULL,
    [password] VARCHAR (100) NOT NULL,
    [is_admin] BIT           NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

