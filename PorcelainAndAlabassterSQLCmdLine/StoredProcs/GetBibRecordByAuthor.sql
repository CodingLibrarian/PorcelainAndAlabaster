USE [master]
GO
/****** Object:  StoredProcedure [dbo].[GetBibRecordByID]    Script Date: 6/2/2024 2:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/02/24
-- Description:	Get BibRecord by Author
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GetBibRecordByAuthor] (@bibAuthor varchar(max))
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
	WHERE B.author LIKE '%' + @bibAuthor + '%'
END
