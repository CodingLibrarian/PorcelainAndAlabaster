
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Gage
-- Create date: 6/23/24
-- Description:	Return about Library
-- =============================================
CREATE OR ALTER PROCEDURE GetAboutLibrary
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * from AboutLibrary
END
GO
