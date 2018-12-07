IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CharacterClass' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE DungeonTyper.CharacterClass
GO

CREATE TABLE [DungeonTyper].[CharacterClass] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Gebruikers] PRIMARY KEY CLUSTERED ([Id] ASC)
);