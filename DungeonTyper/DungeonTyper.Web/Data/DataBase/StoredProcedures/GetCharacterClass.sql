-- =============================================
-- Author:        <Stef Boelens>
-- Create date: <dd/mm/yyyy>
-- Description:    <Buitendoor, Killerapp Semester 2, >
-- =============================================

USE [dbi397017]
GO

IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'stp_ProcedureName' AND ROUTINE_SCHEMA = 'S2Buitendoor') DROP PROCEDURE [S2Buitendoor].stp_ProcedureName
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [S2Buitendoor].[stp_ProcedureName]
    -- Add the parameters for the stored procedure here
    @Param1 varchar(50),
    @Param2 int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    
END
GO