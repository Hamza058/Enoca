IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Companies] (
    [CompanyId] int NOT NULL IDENTITY,
    [Status] bit NOT NULL,
    [StartTime] datetime2 NOT NULL,
    [FinishTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([CompanyId])
);
GO

CREATE TABLE [Products] (
    [ProductId] int NOT NULL IDENTITY,
    [ProductName] int NOT NULL,
    [Price] int NOT NULL,
    [CompanyId] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
    CONSTRAINT [FK_Products_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([CompanyId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Orders] (
    [OrderId] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NULL,
    [Date] datetime2 NOT NULL,
    [CompanyId] int NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
    CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Orders_ProductId] ON [Orders] ([ProductId]);
GO

CREATE INDEX [IX_Products_CompanyId] ON [Products] ([CompanyId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230117143639_add_inital', N'6.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'ProductName');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Products] ALTER COLUMN [ProductName] nvarchar(max) NULL;
GO

ALTER TABLE [Products] ADD [Stock] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Companies] ADD [CompanyName] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230117153630_update_column', N'6.0.13');
GO

COMMIT;
GO
