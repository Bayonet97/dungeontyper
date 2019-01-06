-- =============================================
-- Author:        <Raphael>
-- Create date: <17/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'DungeonTyper.trCharacter_AfterInsert' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP TRIGGER [DungeonTyper].[trCharacter_AfterInsert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [DungeonTyper].[trCharacter_AfterInsert]
ON [DungeonTyper].[Character] 
AFTER INSERT
AS
BEGIN
	DECLARE @CharacterId INT
	DECLARE @CharacterClassId INT
	SELECT @CharacterId = Id FROM inserted
	SELECT @CharacterClassId = CharacterClassId FROM inserted
	-- AFTER CREATING NEW CHARACTER WITH GIVEN CLASS, CHECK THE ABILITIES THE CLASS HAS AND CREATE NEW ROW FOR EACH ABILITY OF CLASS IN CHARACTER_ABILITIES
	INSERT INTO [DungeonTyper].[Character_Abilities]
	VALUES (@CharacterId, 
	INNER JOIN
	(SELECT [AbilityId]
	FROM [DungeonTyper].[CharacterClass_Abilities]
	WHERE CharacterClass_Abilities.CharacterClassId = @CharacterClassId))
END
GO