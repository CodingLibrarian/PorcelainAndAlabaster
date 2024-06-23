SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/23/24
-- Description:	Procs to insert library events
-- =============================================
CREATE OR ALTER PROCEDURE dbo.InsertLibraryEvents (@libraryEvents dbo.LibraryEventType READONLY)
AS  
BEGIN  
    INSERT INTO LibraryEvents(title, eventDescription, imageURL)
    SELECT title, eventDescription, imageURL FROM @libraryEvents;
END
GO
