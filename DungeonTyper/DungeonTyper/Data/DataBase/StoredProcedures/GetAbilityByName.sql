-- =============================================
-- Author:        <Raphael>
-- Create date: <09/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spAbility_GetByName' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spAbility_GetByName]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DungeonTyper].[spAbility_GetByName]
    -- Add the parameters for the stored procedure here
    @AbilityName VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
SELECT 
   [AbilityName], [AbilityDescription]
FROM 
	[DungeonTyper].[Ability]
WHERE 
	LOWER([AbilityName]) = @AbilityName    
END
GO