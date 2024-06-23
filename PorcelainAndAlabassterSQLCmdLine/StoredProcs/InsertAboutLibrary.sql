SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/23/24
-- Description:	Procs to insert about library
-- =============================================
CREATE OR ALTER PROCEDURE dbo.InsertAboutLibrary (@aboutLibrary dbo.AboutLibraryType READONLY)
AS  
BEGIN  
    INSERT INTO AboutLibrary(aboutTheLibrary, missionStatement, visionStatement)
    SELECT aboutTheLibrary, missionStatement, visionStatement FROM @aboutLibrary;
END
GO
