USE [dbi397017]
GO

--DELETE DATA
DELETE FROM [DungeonTyper].[Character]
DELETE FROM [DungeonTyper].[CharacterClass]
DELETE FROM [DungeonTyper].[Ability]

--INSERT
--	CHARACTERCLASS
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Warrior')
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Mage')
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Rogue')
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Priest')

--	ABILITY
INSERT INTO [DungeonTyper].[Ability]([AbilityName]) VALUES('Fireball')
INSERT INTO [DungeonTyper].[Ability]([AbilityName]) VALUES('Charge')
INSERT INTO [DungeonTyper].[Ability]([AbilityName]) VALUES('Flash Heal')
INSERT INTO [DungeonTyper].[Ability]([AbilityName]) VALUES('Backstab')

--	CHARACTER (foreign key CharacterClassId)
INSERT INTO [DungeonTyper].[Character]([CharacterClassId], [Alive]) VALUES (1, 1)

GO