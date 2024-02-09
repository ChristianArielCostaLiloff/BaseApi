CREATE TABLE [Security].[RolePermissions] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [IdRole]       INT NOT NULL,
    [IdPermission] INT NOT NULL,
    CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RolePermissions_Permissions_IdPermission] FOREIGN KEY ([IdPermission]) REFERENCES [Security].[Permissions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RolePermissions_Roles_IdRole] FOREIGN KEY ([IdRole]) REFERENCES [Security].[Roles] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_RolePermissions_IdPermission_IdRole]
    ON [Security].[RolePermissions]([IdPermission] ASC, [IdRole] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RolePermissions_IdRole]
    ON [Security].[RolePermissions]([IdRole] ASC);

