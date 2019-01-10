-- =============================================
-- Author:        <Raphael>
-- Create date: <17/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO
IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'DungeonTyper.trCharacter_AfterInsert' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[trCharacter_AfterInsert]
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
    SET NOCOUNT ON;

	DECLARE @CharacterId INT
	DECLARE @CharacterClassId INT
	SELECT @CharacterId = Id FROM inserted
	SELECT @CharacterClassId = CharacterClassId FROM inserted

INSERT INTO 
	[DungeonTyper].[Character_Abilities] ([CharacterId], [AbilityId])
SELECT 
    [Character].[Id], [CharacterClass_Abilities].[AbilityId]
FROM 
	[DungeonTyper].[Character],
	[DungeonTyper].[CharacterClass_Abilities]
WHERE 
	[Character].[Id] = @CharacterId
	AND
	[CharacterClass_Abilities].[CharacterClassID] = @CharacterClassId
END
GO