USE [dbi397017]
GO

--DELETE DATA
DELETE FROM [DungeonTyper].[Character]
DELETE FROM [DungeonTyper].[CharacterClass]

--INSERT

--	CHARACTERCLASS
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Warrior')
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Mage')
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Rogue')
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Priest')

--	CHARACTER (foreign key CharacterClassId)
INSERT INTO [DungeonTyper].[Character]([CharacterClassId], [Alive]) VALUES (1, 1)
GO