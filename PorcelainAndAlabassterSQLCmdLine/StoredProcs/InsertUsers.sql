SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 06/01/24
-- Description:	Procs to insert partons
-- =============================================
CREATE OR ALTER PROCEDURE dbo.InsertUsers (@users dbo.UserType READONLY)
AS  
BEGIN  
    INSERT INTO Users(userName)
    SELECT userName FROM @users;
END
GO
