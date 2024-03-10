USE [EF_Hash_Token]
GO

/****** Object:  Trigger [dbo].[DisableAccountOnDelete]    Script Date: 10-03-24 13:42:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[DisableAccountOnDelete] 
   ON  [dbo].[Users] 
   INSTEAD OF DELETE
AS 
BEGIN
	UPDATE Users SET IsActive = 0 WHERE UserId = (SELECT UserId FROM deleted)
	DECLARE @Id INT = (SELECT DELETED.UserId FROM DELETED)
	DECLARE @UserEmail NVARCHAR(250) = (SELECT DELETED.Email FROM DELETED)
	DECLARE @BodyMessage NVARCHAR(300) = 'Go to https://localhost:7005/api/User/' + CAST(@Id AS NVARCHAR(300)) +  + ' to reactivate your account'                    
	IF @Id IS NOT NULL
		BEGIN
		EXEC msdb.dbo.sp_send_dbmail
		@recipients = @UserEmail, 
		@subject = 'Your account has been deleted', 
		@body = @BodyMessage
		END
END
GO

ALTER TABLE [dbo].[Users] DISABLE TRIGGER [DisableAccountOnDelete]
GO


