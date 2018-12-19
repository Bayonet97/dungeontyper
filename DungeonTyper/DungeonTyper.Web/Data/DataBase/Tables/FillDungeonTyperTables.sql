USE [dbi397017]
GO

--DELETE DATA
DELETE FROM [DungeonTyper].[Character]
DELETE FROM [DungeonTyper].[CharacterClass]
DELETE FROM [DungeonTyper].[Ability]
DELETE FROM [DungeonTyper].[CharacterClass_Abilities]

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

--FOREIGN KEYS
--	CHARACTER (foreign key CharacterClassId)
INSERT INTO [DungeonTyper].[Character]([CharacterClassId], [Alive]) VALUES (1, 1)

-- CHARACTERCLASS_ABILITIES (characterlcassId, AbilityId)
	-- Warrior
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (1, 2)
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (1, 4)
	-- Mage
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (2, 1)
	-- Rogue
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (3, 4)
	-- Priest
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (4, 3)

GO