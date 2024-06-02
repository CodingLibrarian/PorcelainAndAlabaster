SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/02/24
-- Description:	Get User by ID
-- =============================================
CREATE OR ALTER   PROCEDURE [dbo].[GetUserByID] (@userID int)
AS  
BEGIN  
    SELECT
		U.id,
		U.userName,
		U.settings,
		P.firstName,
		P.middleName,
		P.lastName,
		P.email,
		P.address1,
		P.address2,
		P.homePhone,
		P.cellPhone,
		P.settings
	FROM Users as U
	LEFT JOIN Patrons as P
	ON P.id = U.patronId
	WHERE U.id = @userID
END