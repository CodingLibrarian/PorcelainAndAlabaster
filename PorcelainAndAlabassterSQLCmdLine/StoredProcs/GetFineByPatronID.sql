SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/02/24
-- Description:	Get Fines by PatronID
-- =============================================
CREATE OR ALTER   PROCEDURE [dbo].[GetFinesByPatronID] (@PatronID int)
AS  
BEGIN  
    SELECT
	    f.cost,
		f.fineStatus,
		b.title,
		b.author,
		i.barcode,
		i.dueDate,
		i.itemType,
		i.holdId,
		p.firstName,
		p.lastName,
		f.patronId
	FROM Fines as F
	LEFT JOIN ItemRecords as I
	ON I.id = F.itemId
	LEFT JOIN BibRecords as B
	ON B.id = I.bibRecordId
	LEFT JOIN Patrons as P
	ON P.id = F.patronId
	WHERE F.patronId = @PatronID
END