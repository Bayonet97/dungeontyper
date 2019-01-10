USE [dbi397017]
GO

--DELETE DATA

DELETE FROM [DungeonTyper].[CharacterClass_Abilities]
DELETE FROM [DungeonTyper].[Character_Abilities]
DELETE FROM [DungeonTyper].[Ability]
DELETE FROM [DungeonTyper].[CharacterClass]
DELETE FROM [DungeonTyper].[Character]

--INSERT
--	CHARACTERCLASS
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Warrior')
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Mage')
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Rogue')
INSERT INTO [DungeonTyper].[CharacterClass]([ClassName]) VALUES('Priest')

--	ABILITY
INSERT INTO [DungeonTyper].[Ability]([AbilityName], [AbilityDescription]) VALUES('Fireball', 'A ball of fire.')
INSERT INTO [DungeonTyper].[Ability]([AbilityName], [AbilityDescription]) VALUES('Charge', 'Violently rush towards the enemy.')
INSERT INTO [DungeonTyper].[Ability]([AbilityName], [AbilityDescription]) VALUES('Flash Heal', 'Some light that mends your wounds.')
INSERT INTO [DungeonTyper].[Ability]([AbilityName], [AbilityDescription]) VALUES('Backstab', 'The weakest parts!')
INSERT INTO [DungeonTyper].[Ability]([AbilityName], [AbilityDescription]) VALUES('Stomp', 'That should stun the enemy.')
INSERT INTO [DungeonTyper].[Ability]([AbilityName], [AbilityDescription]) VALUES('Dodge', 'Better not get hit by that.')
INSERT INTO [DungeonTyper].[Ability]([AbilityName], [AbilityDescription]) VALUES('Pierce', 'Seems like that will sting.')
INSERT INTO [DungeonTyper].[Ability]([AbilityName], [AbilityDescription]) VALUES('Slash', 'That will leave a nasty cut.')


--FOREIGN KEYS
--	CHARACTER (foreign key CharacterClassId)
INSERT INTO [DungeonTyper].[Character]([CharacterName], [CharacterClassId], [Alive]) VALUES ('TestMan', 1, 1)

-- CHARACTERCLASS_ABILITIES (characterlcassId, AbilityId)
	-- Warrior
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (1, 2)
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (1, 5)
	-- Mage
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (2, 1)
	-- Rogue
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (3, 4)
	-- Priest
INSERT INTO [DungeonTyper].[CharacterClass_Abilities]([CharacterClassId], [AbilityId]) VALUES (4, 3)

GO