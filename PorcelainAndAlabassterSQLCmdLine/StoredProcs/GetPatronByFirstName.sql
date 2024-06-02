SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/02/24
-- Description:	Get Patron by PatronFirstName
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GetPatronByFirstName] (@patronFirstName varchar(max))
AS  
BEGIN  
    SELECT
		P.firstName,
		P.middleName,
		P.lastName,
		P.email,
		P.address1,
		P.address2,
		P.homePhone,
		P.cellPhone,
		P.settings
	FROM Patrons as P
	WHERE P.firstName LIKE '%' + @patronFirstName + '%'
END
