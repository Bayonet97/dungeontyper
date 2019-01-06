USE [dbi397017]
GO


IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Item' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[Item]
GO
IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CharacterInventory_Items' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[CharacterInventory_Items]
GO
IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CharacterEquipment_Items' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[CharacterEquipment_Items]
GO
IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CharacterClass_Abilities' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[CharacterClass_Abilities]
GO
IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Character_Abilities' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[Character_Abilities]
GO
IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Character' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[Character]
GO
IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CharacterClass' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[CharacterClass]
GO
IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Ability' AND TABLE_SCHEMA = 'DungeonTyper') DROP TABLE [DungeonTyper].[Ability]
GO

CREATE TABLE [DungeonTyper].[CharacterClass] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [ClassName]       VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_CharacterClass] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [DungeonTyper].[Ability] (
	[Id]                 INT    IDENTITY (1, 1) NOT NULL,
    [AbilityName]	     VARCHAR (20)    NOT NULL,
	[AbilityDescription] VARCHAR (100),
	CONSTRAINT [PK_Ability] PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [DungeonTyper].[Item] (
	[Id]            INT    IDENTITY (1, 1) NOT NULL,
    [ItemName]	    VARCHAR (20)    NOT NULL,
	[ItemType]		INT NOT NULL, -- 0 = ..., 1 = ..., 2 = ...
	CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [DungeonTyper].[Character] (
    [Id]                INT    IDENTITY (1, 1) NOT NULL,
	[CharacterName]		VARCHAR (20)	   NOT NULL,
    [CharacterClassId]  INT    NOT NULL,
	[Alive]				BIT    NOT NULL,
    CONSTRAINT [PK_Character] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Character_CharacterClass] FOREIGN KEY ([CharacterClassId]) REFERENCES [DungeonTyper].[CharacterClass] ([Id])
);

CREATE TABLE [DungeonTyper].[CharacterInventory_Items] (
	[Id]            INT IDENTITY (1, 1) NOT NULL,
    [CharacterId]	INT NOT NULL,
	[ItemId]		INT NOT NULL,
	[ItemQuantity]	INT NOT NULL
	CONSTRAINT [PK_CharacterInventory_Items] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_CharacterInventory_Items_Character] FOREIGN KEY ([CharacterId]) REFERENCES [DungeonTyper].[Character] ([Id]),
	CONSTRAINT [FK_CharacterInventory_Items_Item] FOREIGN KEY ([ItemId]) REFERENCES [DungeonTyper].[Item] ([Id])
);

CREATE TABLE [DungeonTyper].[CharacterEquipment_Items] (
	[Id]            INT    IDENTITY (1, 1) NOT NULL,
	[CharacterId]   INT NOT NULL,
    [EquipmentSlot] INT NOT NULL, -- Slot 1 "Weapon", Slot 2 "Off-Hand", Slot 3 "Helmet"...
	[ItemId]		INT NOT NULL
	CONSTRAINT [PK_CharacterEquipment_Items] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_CharacterEquipment_Items_Character] FOREIGN KEY ([CharacterId]) REFERENCES [DungeonTyper].[Character] ([Id]),
	CONSTRAINT [FK_CharacterEquipment_Items_Item] FOREIGN KEY ([ItemId]) REFERENCES [DungeonTyper].[Item] ([Id])
);

CREATE TABLE [DungeonTyper].[CharacterClass_Abilities] (
	[Id]				    INT    IDENTITY (1, 1) NOT NULL,
    [CharacterClassId]	    INT    NOT NULL,
	[AbilityId]				INT	   NOT NULL,
	CONSTRAINT [PK_CharacterClass_Abilities] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_CharacterClass_Abilities_CharacterClass] FOREIGN KEY ([CharacterClassId]) REFERENCES [DungeonTyper].[CharacterClass] ([Id]),
	CONSTRAINT [PK_CharacterClass_Abilities_Ability] FOREIGN KEY ([AbilityId]) REFERENCES [DungeonTyper].[Ability] ([Id])
);

CREATE TABLE [DungeonTyper].[Character_Abilities] (
	[Id]                INT    IDENTITY (1, 1) NOT NULL,
    [CharacterId]	    INT    NOT NULL,
	[AbilityId]			INT	   NOT NULL,
	CONSTRAINT [PK_Character_Abilities] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Character_Abilities_Character] FOREIGN KEY ([CharacterId]) REFERENCES [DungeonTyper].[Character] ([Id]),
	CONSTRAINT [FK_Character_Abilities_Ability] FOREIGN KEY ([AbilityId]) REFERENCES [DungeonTyper].[Ability] ([Id])
);
GO