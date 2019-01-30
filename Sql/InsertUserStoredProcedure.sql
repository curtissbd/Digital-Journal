USE [DigitalDiaryCenter]
GO

/****** Object:  StoredProcedure [dbo].[insertUser]    Script Date: 1/30/2019 10:35:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insertUser]
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
FROM [User] WHERE Username = @Username AND Password= @Password )


if(@count = 0)
begin
INSERT INTO [dbo].[User]
           ([Username]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[EmailAddress]
           ,[PhoneNumber])
     VALUES
           (@Username
           ,@Password
           ,@FirstName
           ,@LastName
           ,@EmailAddress
           ,@PhoneNumber)
end
select @count
END
GO

