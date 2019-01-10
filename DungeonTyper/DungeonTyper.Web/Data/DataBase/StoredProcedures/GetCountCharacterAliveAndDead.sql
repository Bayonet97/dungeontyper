-- =============================================
-- Author:        <Raphael>
-- Create date: <14/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spCharacterGetAllAliveAndDeadCount' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spCharacterGetAllAliveAndDeadCount]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DungeonTyper].[spCharacterGetAllAliveAndDeadCount]
AS
BEGIN

    SET NOCOUNT ON;
SELECT 
	SUM(CASE WHEN [Alive] = 1 THEN 1 ELSE 0 END) AS Alive, 
	SUM(CASE WHEN [Alive] = 0 THEN 1 ELSE 0 END) AS Dead
FROM 
	[DungeonTyper].[Character]	
END
GO