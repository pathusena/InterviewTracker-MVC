USE [InterviewTrackerDB]
GO
/****** Object:  StoredProcedure [dbo].[USP_Interview_GetInterview]    Script Date: 10/22/2023 2:41:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pathum>
-- Create date: <09/03/2023>
-- Description:	<Get Interview>
-- =============================================
CREATE PROCEDURE [dbo].[USP_Interview_GetInterview]
	@pint_Flag			INT,
	@pint_CompanyId		INT
AS
BEGIN
	SET NOCOUNT ON;
	IF(@pint_Flag = 0)
	BEGIN
		SELECT * 
		FROM Interview
		WHERE CompanyId = @pint_CompanyId;
	END
END
