SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/01/24
-- Description:	Procs to insert partons
-- =============================================
CREATE OR ALTER PROCEDURE dbo.InsertUsers (@patrons dbo.PatronType READONLY)
AS  
BEGIN  
    INSERT INTO Patrons(firstName, middleName, lastName, address1, address2, email, homePhone, cellPhone)
    SELECT firstName, middleName, lastName, address1, address2, email, homePhone, cellPhone FROM @patrons;
END
GO
