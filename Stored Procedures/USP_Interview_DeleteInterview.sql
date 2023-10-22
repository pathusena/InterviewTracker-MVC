USE [InterviewTrackerDB]
GO
/****** Object:  StoredProcedure [dbo].[USP_Interview_DeleteInterview]    Script Date: 10/22/2023 2:41:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pathum>
-- Create date: <09/16/2023>
-- Description:	<Delete Interview>
-- =============================================
CREATE PROCEDURE [dbo].[USP_Interview_DeleteInterview]
	@pint_Flag			INT,
	@pint_Id			INT
AS
BEGIN
	SET NOCOUNT ON;

	IF(@pint_Flag = 0)
	BEGIN
		DELETE Interview
		WHERE Id = @pint_Id;
	END
END
