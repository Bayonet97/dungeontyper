USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Character' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[Character]
GO
IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CharacterClass' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[CharacterClass]
GO


CREATE TABLE [DungeonTyper].[CharacterClass] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [ClassName]       VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_CharacterClass] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [DungeonTyper].[Character] (
    [Id]                INT    IDENTITY (1, 1) NOT NULL,
    [CharacterClassId]  INT    NOT NULL,
	[Alive]				BIT    NOT NULL,
    CONSTRAINT [PK_Character] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Character_CharacterClass] FOREIGN KEY ([CharacterClassId]) REFERENCES [DungeonTyper].[CharacterClass] ([Id])
);

GO