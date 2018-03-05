CREATE TABLE [dbo].[Users] (
    [id]       INT           NOT NULL,
    [username] VARCHAR (50)  NOT NULL,
    [password] VARCHAR (100) NOT NULL,
    [is_admin] BIT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

