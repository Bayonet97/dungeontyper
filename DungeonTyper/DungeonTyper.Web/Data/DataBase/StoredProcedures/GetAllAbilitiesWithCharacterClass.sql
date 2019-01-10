-- =============================================
-- Author:        <Raphael>
-- Create date: <17/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spAbility_CharacterClass_GetAll' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spAbility_CharacterClass_GetAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DungeonTyper].[spAbility_CharacterClass_GetAll]

AS
BEGIN
    SET NOCOUNT ON;
SELECT 
    [ab].[AbilityName] AS AbilityName, [cc].[ClassName] AS CharacterClassName
FROM 
	[DungeonTyper].[Ability] AS [ab]
	LEFT OUTER JOIN 
	[DungeonTyper].[CharacterClass_Abilities] AS [ccabs]
	ON  
	[ccabs].[AbilityId] = [ab].[Id]

	LEFT OUTER JOIN 
	[DungeonTyper].[CharacterClass] AS [cc]
	ON  
	[cc].[Id] = [ccabs].[CharacterClassId]

GROUP BY [ab].[AbilityName], [cc].[ClassName]
ORDER BY [cc].[ClassName] DESC, [ab].[AbilityName]
END
GO