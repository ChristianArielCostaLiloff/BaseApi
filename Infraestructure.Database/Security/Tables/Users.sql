CREATE TABLE [Security].[Users] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
    [IdRole]      INT           NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Roles_IdRole] FOREIGN KEY ([IdRole]) REFERENCES [Security].[Roles] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_IdRole]
    ON [Security].[Users]([IdRole] ASC);

