-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
USE [DigitalDiaryCenter]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateUser]
	-- Add the parameters for the stored procedure here
	@Username nvarchar(25), @Password nvarchar(16),
	@FirstName nvarchar(20),@LastName nvarchar(50),
	@EmailAddress nvarchar(255),@PhoneNumber nvarchar(10)
AS
BEGIN
declare @count int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
set @count = (SELECT COUNT(*)
FROM [User] WHERE Username = @Username 

if(@count = 0)
begin
UPDATE [dbo].[User]
SET 
  Password = @Password,
  FirstName= @Firstname,
  LastName=@Lastname,
  EmailAddress=@Emailaddress,
  PhoneNumber=@Phonenumber
WHERE Username = @Username;
end
select @count
END
