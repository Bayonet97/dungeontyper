-- =============================================
-- Author:        <Raphael>
-- Create date: <17/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spCharacterClass_Abilities_GetAllCount' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spCharacterClass_Abilities_GetAllCount]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DungeonTyper].[spCharacterClass_Abilities_GetAllCount]
AS
BEGIN
    SET NOCOUNT ON;
SELECT 
    [cc].[ClassName], COUNT([ccabs].[AbilityId]) AS [AbilityCount]
FROM 
	[DungeonTyper].[CharacterClass_Abilities] AS [ccabs],
	[DungeonTyper].[CharacterClass] AS [cc]
WHERE 
	[cc].[Id] = [ccabs].[CharacterClassId]
GROUP BY 
	[cc].[ClassName]
END
GO