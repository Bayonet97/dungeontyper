-- =============================================
-- Author:        <Raphael>
-- Create date: <14/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spCharacter_Abilities_GetAllNameAndDescriptionByCharacterId' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spCharacter_Abilities_GetAllNameAndDescriptionByCharacterId]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DungeonTyper.spCharacter_Abilities_GetAllNameAndDescriptionByCharacterId
	@CharacterId INT 
AS
BEGIN

    SET NOCOUNT ON;
SELECT 
	[ab].[AbilityName], [ab].[AbilityDescription]
FROM 
	[DungeonTyper].[Ability] AS [ab]
	INNER JOIN 
	[DungeonTyper].[Character_Abilities] AS [chab]
	ON
	[chab].[AbilityId] = [ab].[Id]
	WHERE
	[chab].[CharacterId] = @CharacterId
END
GO