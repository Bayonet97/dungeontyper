-- =============================================
-- Author:        <Raphael>
-- Create date: <17/12/2018>
-- Description:    <DungeonTyper, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'DungeonTyper.spCharacter_CreateNew' AND ROUTINE_SCHEMA = 'DungeonTyper') DROP PROCEDURE [DungeonTyper].[spCharacter_CreateNew]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DungeonTyper.spCharacter_CreateNew
@CharacterName VARCHAR(20),
@ClassName VARCHAR(20)
AS
BEGIN
INSERT INTO [DungeonTyper].[Character] (CharacterName, CharacterClassId, Alive)
VALUES (@CharacterName,
(SELECT [CharacterClass].[Id]
FROM [DungeonTyper].[CharacterClass]
WHERE CharacterClass.ClassName = @ClassName),
1)
END
GO