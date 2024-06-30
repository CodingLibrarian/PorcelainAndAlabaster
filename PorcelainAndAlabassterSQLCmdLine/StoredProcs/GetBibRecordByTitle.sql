SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/02/24
-- Description:	Get BibRecord by Title
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GetBibRecordByTitle] (@searchString varchar(max))
AS  
BEGIN  
    SELECT
		B.id,
		B.title,
		B.author,
		B.publisher,
		B.publisherLocation,
		B.created,
		B.lastUpdate,
		B.isDeleted,
		B.items,
		B.marcRecord
	FROM BibRecords as B
	WHERE B.title LIKE '%' + @searchString + '%'
END
