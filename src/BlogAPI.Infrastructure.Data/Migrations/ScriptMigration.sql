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
CREATE TABLE [Posts] (
    [PostId] uniqueidentifier NOT NULL,
    [Titulo] nvarchar(max) NOT NULL,
    [Conteudo] NVarchar(MAX) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([PostId])
);

CREATE TABLE [Comments] (
    [ComentarioId] uniqueidentifier NOT NULL,
    [PostId] uniqueidentifier NOT NULL,
    [Conteudo] NVarchar(MAX) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([ComentarioId]),
    CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([PostId]) ON DELETE CASCADE
);

CREATE INDEX [IX_Comments_PostId] ON [Comments] ([PostId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251212131414_InicioProjeto', N'9.0.11');

COMMIT;
GO

