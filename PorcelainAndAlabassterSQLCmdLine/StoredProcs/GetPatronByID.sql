/****** Object:  StoredProcedure [dbo].[InsertUsers]    Script Date: 6/2/2024 8:58:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/02/24
-- Description:	Get BibRecord by BibRecordID
-- =============================================
CREATE OR ALTER   PROCEDURE [dbo].[GetBibRecordByID] (@bibRecordID int)
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
	WHERE B.id = @bibRecordID
END
