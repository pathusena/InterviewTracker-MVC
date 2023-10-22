USE [InterviewTrackerDB]
GO
/****** Object:  StoredProcedure [dbo].[USP_Interview_SaveInterview]    Script Date: 10/22/2023 2:41:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pathum>
-- Create date: <09/16/2023>
-- Description:	<Save Interview>
-- =============================================
CREATE PROCEDURE [dbo].[USP_Interview_SaveInterview]
	@pint_Flag			INT,
	@pint_CompanyId		INT,
	@pint_Id			INT OUTPUT,
	@pstr_Name			VARCHAR(50),
	@pdte_Date			DATETIME,
	@pint_Status		TINYINT,
	@pstr_Remarks		VARCHAR(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	IF(@pint_Flag = 0)
	BEGIN
		SET @pint_Id = NEXT VALUE FOR Interview_Id_Sequence;
		INSERT INTO Interview
			(Id,
			CompanyId,
			[Name],
			[Date],
			Status,
			Remark)
			VALUES (
			@pint_Id,
			@pint_CompanyId,
			@pstr_Name,
			@pdte_Date,
			@pint_Status,
			@pstr_Remarks
			);
	END
	ELSE IF(@pint_Flag = 1)
	BEGIN
		UPDATE Interview
		SET [Name] = @pstr_Name,
			[Date] = @pdte_Date,
			Status = @pint_Status,
			Remark = @pstr_Remarks
		WHERE Id = @pint_Id;
	END

	SELECT @pint_Id;
END
