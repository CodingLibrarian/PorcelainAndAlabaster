SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/01/24
-- Description:	Procs to insert items
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[InsertItemsRecords] (@itemRecords dbo.ItemRecordType READONLY)
AS  
BEGIN  
    INSERT INTO ItemRecords(barcode, dueDate, itemType, circulationStatsIds, patronId, bibRecordId, holdId)
    SELECT barcode, dueDate, itemType, circulationStatsIds, patronId, bibRecordId, holdId FROM @itemRecords;
END
