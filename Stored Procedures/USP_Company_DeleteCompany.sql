USE [InterviewTrackerDB]
GO
/****** Object:  StoredProcedure [dbo].[USP_Company_DeleteCompany]    Script Date: 10/22/2023 2:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pathum>
-- Create date: <09/10/2023>
-- Description:	<Delete Company>
-- =============================================
CREATE PROCEDURE [dbo].[USP_Company_DeleteCompany]
	@pint_Flag			INT,
	@pint_Id			INT
AS
BEGIN
	SET NOCOUNT ON;

	IF(@pint_Flag = 0)
	BEGIN
		DELETE Interview
		WHERE CompanyId = @pint_Id;

		DELETE Company
		WHERE Id = @pint_Id;
	END
END
