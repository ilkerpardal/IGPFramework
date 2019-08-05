IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [IGP_MENU] (
    [Id] int NOT NULL IDENTITY,
    [RecordUserId] int NOT NULL,
    [RecordDate] date NOT NULL,
    [UpdateUserId] int NULL,
    [UpdateDate] date NULL,
    [ParentId] int NULL,
    [MenuName] varchar(100) NOT NULL,
    [MenuUrl] varchar(100) NULL,
    CONSTRAINT [PK_IGP_MENU] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [IGP_USER] (
    [Id] int NOT NULL IDENTITY,
    [RecordUserId] int NOT NULL,
    [RecordDate] date NOT NULL,
    [UpdateUserId] int NULL,
    [UpdateDate] date NULL,
    [Name] varchar(200) NOT NULL,
    [Surname] varchar(200) NOT NULL,
    [UserName] varchar(200) NOT NULL,
    [Password] varchar(200) NOT NULL,
    [PhoneNumber] varchar(20) NULL,
    [Email] varchar(50) NULL,
    [IdentityKey] decimal(11) NULL,
    [Birthdate] date NULL,
    [Sex] int NULL,
    CONSTRAINT [PK_IGP_USER] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [IGP_MENU_TRANSACTION] (
    [Id] int NOT NULL IDENTITY,
    [RecordUserId] int NOT NULL,
    [RecordDate] date NOT NULL,
    [UpdateUserId] int NULL,
    [UpdateDate] date NULL,
    [MenuId] int NOT NULL,
    [TransactionName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_IGP_MENU_TRANSACTION] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IGP_MENU_TRANSACTION_IGP_MENU_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [IGP_MENU] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IGP_USER_MENU_PERMISSIONS] (
    [Id] int NOT NULL IDENTITY,
    [RecordUserId] int NOT NULL,
    [RecordDate] date NOT NULL,
    [UpdateUserId] int NULL,
    [UpdateDate] date NULL,
    [UserId] int NOT NULL,
    [MenuId] int NOT NULL,
    [Read] int NOT NULL,
    [Write] int NOT NULL,
    [Modify] int NOT NULL,
    [Report] int NOT NULL,
    CONSTRAINT [PK_IGP_USER_MENU_PERMISSIONS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IGP_USER_MENU_PERMISSIONS_IGP_MENU_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [IGP_MENU] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IGP_USER_MENU_PERMISSIONS_IGP_USER_UserId] FOREIGN KEY ([UserId]) REFERENCES [IGP_USER] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IGP_USER_PASSWORDS] (
    [Id] int NOT NULL IDENTITY,
    [RecordUserId] int NOT NULL,
    [RecordDate] date NOT NULL,
    [UpdateUserId] int NULL,
    [UpdateDate] date NULL,
    [UserId] int NOT NULL,
    [Password] varchar(50) NOT NULL,
    CONSTRAINT [PK_IGP_USER_PASSWORDS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IGP_USER_PASSWORDS_IGP_USER_UserId] FOREIGN KEY ([UserId]) REFERENCES [IGP_USER] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IGP_USER_SESSIONS] (
    [Id] int NOT NULL IDENTITY,
    [RecordUserId] int NOT NULL,
    [RecordDate] date NOT NULL,
    [UpdateUserId] int NULL,
    [UpdateDate] date NULL,
    [UserId] int NOT NULL,
    [SessionId] varchar(50) NULL,
    [LoginDate] date NOT NULL,
    [LogoutDate] date NOT NULL,
    CONSTRAINT [PK_IGP_USER_SESSIONS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IGP_USER_SESSIONS_IGP_USER_UserId] FOREIGN KEY ([UserId]) REFERENCES [IGP_USER] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IGP_USER_TRANSACTION] (
    [Id] int NOT NULL IDENTITY,
    [RecordUserId] int NOT NULL,
    [RecordDate] date NOT NULL,
    [UpdateUserId] int NULL,
    [UpdateDate] date NULL,
    [UserId] int NOT NULL,
    [TransactionId] int NOT NULL,
    CONSTRAINT [PK_IGP_USER_TRANSACTION] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IGP_USER_TRANSACTION_IGP_MENU_TRANSACTION_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [IGP_MENU_TRANSACTION] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IGP_USER_TRANSACTION_IGP_USER_UserId] FOREIGN KEY ([UserId]) REFERENCES [IGP_USER] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_IGP_MENU_TRANSACTION_MenuId] ON [IGP_MENU_TRANSACTION] ([MenuId]);

GO

CREATE UNIQUE INDEX [IX_IGP_USER_UserName] ON [IGP_USER] ([UserName]);

GO

CREATE INDEX [IX_IGP_USER_MENU_PERMISSIONS_MenuId] ON [IGP_USER_MENU_PERMISSIONS] ([MenuId]);

GO

CREATE INDEX [IX_IGP_USER_MENU_PERMISSIONS_UserId] ON [IGP_USER_MENU_PERMISSIONS] ([UserId]);

GO

CREATE INDEX [IX_IGP_USER_PASSWORDS_UserId] ON [IGP_USER_PASSWORDS] ([UserId]);

GO

CREATE INDEX [IX_IGP_USER_SESSIONS_UserId] ON [IGP_USER_SESSIONS] ([UserId]);

GO

CREATE INDEX [IX_IGP_USER_TRANSACTION_TransactionId] ON [IGP_USER_TRANSACTION] ([TransactionId]);

GO

CREATE INDEX [IX_IGP_USER_TRANSACTION_UserId] ON [IGP_USER_TRANSACTION] ([UserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190805202213_mig1', N'2.2.6-servicing-10079');

GO

