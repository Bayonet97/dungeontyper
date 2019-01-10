-- =============================================
-- Author:        <Raphael>
-- Create date: <09/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spCharacterClass_GetByName' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spCharacterClass_GetByName]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DungeonTyper.spCharacterClass_GetByName
    -- Add the parameters for the stored procedure here
    @ClassName VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
SELECT 
	[Id], [ClassName]
FROM 
	[DungeonTyper].[CharacterClass]
WHERE 
	[ClassName] = @ClassName;    
END
GO