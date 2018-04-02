CREATE TABLE [dbo].[Users] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (50)  NOT NULL,
    [password] VARCHAR (100) NOT NULL,
    [is_admin] BIT           DEFAULT 0 NULL,
    [firstname] VARCHAR(100) NULL, 
    [surname] VARCHAR(100) NULL, 
    [phone] VARCHAR(15) NULL, 
    [email] VARCHAR(150) NULL, 
    PRIMARY KEY CLUSTERED ([id] ASC)
);

