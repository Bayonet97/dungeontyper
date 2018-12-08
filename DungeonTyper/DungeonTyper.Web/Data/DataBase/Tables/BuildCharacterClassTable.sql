USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CharacterClass' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE DungeonTyper.CharacterClass
GO

CREATE TABLE [DungeonTyper].[CharacterClass] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [ClassName]       VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_CharacterClass] PRIMARY KEY CLUSTERED ([Id] ASC)
);