CREATE TABLE [dbo].[Games] (
    [id]             INT             IDENTITY (1, 1) NOT NULL,
    [title]          VARCHAR (50)    NOT NULL,
    [description]    VARCHAR (MAX)   NULL,
    [overall_rating] TINYINT         NULL,
    [price]          INT             NOT NULL,
    [release_date]   DATE            NULL,
    [age_rating]     VARCHAR (10)    NULL,
    [image]          VARCHAR(100) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
