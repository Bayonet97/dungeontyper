-- =============================================
-- Author:        <Raphael>
-- Create date: <17/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spCharacterClassAbilities_GetAllByClassName' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spCharacterClassAbilities_GetAllByClassName]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DungeonTyper.spCharacterClassAbilities_GetAllByClassName
    -- Add the parameters for the stored procedure here
    @ClassName VARCHAR(20)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

SELECT [AbilityName],[AbilityDescription]
FROM 
	DungeonTyper.Ability AS ability
WHERE 
	ability.Id = 
	(SELECT [AbilityId]
	FROM DungeonTyper.CharacterClassAbilities AS characterClassAbilities
	WHERE characterClassAbilities.AbilityName = @ClassName)
END
GO