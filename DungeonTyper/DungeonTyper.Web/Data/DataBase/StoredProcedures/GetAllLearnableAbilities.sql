-- =============================================
-- Author:        <Raphael>
-- Create date: <17/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'DungeonTyper.spCharacter_Abilities_GetAllLearnable' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spCharacter_Abilities_GetAllLearnable]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DungeonTyper].[spCharacter_Abilities_GetAllLearnable]

AS
BEGIN

END
GO