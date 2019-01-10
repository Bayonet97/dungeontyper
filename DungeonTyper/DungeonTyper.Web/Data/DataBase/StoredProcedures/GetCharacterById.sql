-- =============================================
-- Author:        <Raphael>
-- Create date: <09/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spCharacter_GetById' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spCharacter_GetById]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DungeonTyper].[spCharacter_GetById]
    -- Add the parameters for the stored procedure here
    @CharacterId INT
AS
BEGIN
    SET NOCOUNT ON;
SELECT 
	*
FROM 
	[DungeonTyper].[Character]
WHERE 
	[Id] = @CharacterId;    
END
GO