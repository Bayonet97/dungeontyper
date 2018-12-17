-- =============================================
-- Author:        <Raphael>
-- Create date: <17/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spCharacterClassAbilities_GetAll' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spCharacterClassAbilities_GetAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DungeonTyper.spCharacterClassAbilities_GetAll
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

SELECT 
   [CharacterClass].[ClassName], [Ability].[AbilityName]
FROM 
	DungeonTyper.Ability AS ability,
	DungeonTyper.CharacterClass AS characterClass
	INNER JOIN DungeonTyper.CharacterClass_Abilities AS classAbilities
ON 
	characterClass.Id = classAbilities.CharacterClassId
WHERE 
	ability.Id = classAbilities.AbilityId    
END
GO