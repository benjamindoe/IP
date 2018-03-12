CREATE TABLE [dbo].[Games] (
    [id]             INT          NOT NULL IDENTITY,
    [title]          VARCHAR (50) NOT NULL,
    [description]    TEXT         NULL,
    [overall_rating] TINYINT      NULL,
    [price]          INT          NOT NULL,
    [release_date]   DATE         NULL,
    [age_rating]     VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

