USE [InterviewTrackerDB]
GO
/****** Object:  StoredProcedure [dbo].[USP_Company_GetCompany]    Script Date: 10/22/2023 2:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pathum>
-- Create date: <09/03/2023>
-- Description:	<Get Company>
-- =============================================
CREATE PROCEDURE [dbo].[USP_Company_GetCompany]
	@pint_Flag		INT,
	@pint_Id		INT
AS
BEGIN
	SET NOCOUNT ON;
	IF(@pint_Flag = 0)
	BEGIN
		SELECT * 
		FROM Company
		WHERE (Id = @pint_Id OR @pint_Id = -1);
	END
END
