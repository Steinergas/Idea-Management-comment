CREATE TABLE [dbo].[Ideas] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (200) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Author_Id]   NVARCHAR (128) NULL,
    [Deadline1]   DATETIME       NOT NULL,
    [Deadline2]   DATETIME       NOT NULL,
    [Comment]     NVARCHAR (MAX) NULL,
    [Name] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_dbo.Ideas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Ideas_dbo.AspNetUsers_Author_Id] FOREIGN KEY ([Author_Id]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Author_Id]
    ON [dbo].[Ideas]([Author_Id] ASC);

