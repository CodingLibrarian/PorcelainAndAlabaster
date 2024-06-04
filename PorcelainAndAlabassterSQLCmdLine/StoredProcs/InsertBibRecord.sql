SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/04/24
-- Description:	Procs to insert bibRecords
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[InsertBibRecords] (@bibRecords dbo.BibRecordType READONLY)
AS  
BEGIN  
    INSERT INTO BibRecords(id, title, author, publisher, publisherLocation, publicationYear, created, lastUpdate, isDeleted, items, marcRecord)
    SELECT id, title, author, publisher, publisherLocation, publicationYear, created, lastUpdate, isDeleted, items, marcRecord FROM @bibRecords;
END
