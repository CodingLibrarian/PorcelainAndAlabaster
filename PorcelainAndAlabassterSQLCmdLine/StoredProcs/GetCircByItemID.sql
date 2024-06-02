SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/02/24
-- Description:	Get Circulation by PatronID
-- =============================================
CREATE OR ALTER   PROCEDURE [dbo].[GetCirculationByItemID] (@itemID int)
AS  
BEGIN  
    SELECT
		b.title,
		b.author,
		c.checkoutDate,
		i.barcode,
		i.dueDate,
		i.itemType,
		i.holdId,
		p.firstName,
		p.lastName,
		c.patronId
	FROM Circulation as C
	LEFT JOIN ItemRecords as I
	ON I.id = c.itemId
	LEFT JOIN BibRecords as B
	ON B.id = I.bibRecordId
	LEFT JOIN Patrons as P
	ON P.id = C.patronId
	WHERE C.itemId = @itemID
END
