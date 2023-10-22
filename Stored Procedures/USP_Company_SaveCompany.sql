USE [InterviewTrackerDB]
GO
/****** Object:  StoredProcedure [dbo].[USP_Company_SaveCompany]    Script Date: 10/22/2023 2:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pathum>
-- Create date: <09/03/2023>
-- Description:	<Save Company>
-- =============================================
CREATE PROCEDURE [dbo].[USP_Company_SaveCompany]
	@pint_Flag			INT,
	@pint_Id			INT OUTPUT,
	@pstr_Name			VARCHAR(50),
	@pdte_Date			DATETIME,
	@pstr_Country		VARCHAR(20),
	@pstr_Phone			VARCHAR(20) = NULL,
	@pstr_Description	VARCHAR(100) = NULL,
	@pstr_Remarks		VARCHAR(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	IF(@pint_Flag = 0)
	BEGIN
		SET @pint_Id = NEXT VALUE FOR Company_Id_Sequence;
		INSERT INTO Company
			(Id,
			[Name],
			[Date],
			Country,
			Phone,
			[Description],
			Remarks)
			VALUES (
			@pint_Id,
			@pstr_Name,
			@pdte_Date,
			@pstr_Country,
			@pstr_Phone,
			@pstr_Description,
			@pstr_Remarks
			);
	END
	ELSE IF(@pint_Flag = 1)
	BEGIN
		UPDATE Company
		SET [Name] = @pstr_Name,
			[Date] = @pdte_Date,
			Country = @pstr_Country,
			Phone = @pstr_Phone,
			[Description] = @pstr_Description,
			Remarks = @pstr_Remarks
		WHERE Id = @pint_Id;
	END

	SELECT @pint_Id;
END
