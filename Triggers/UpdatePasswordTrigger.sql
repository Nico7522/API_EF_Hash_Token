USE [EF_Hash_Token]
GO

/****** Object:  Trigger [dbo].[UpdatePasswordConfirmation]    Script Date: 10-03-24 13:35:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[UpdatePasswordConfirmation]   
   ON  [dbo].[Users] 
   AFTER UPDATE
AS 
BEGIN        
SET NOCOUNT ON;
DECLARE @Id INT = (SELECT INSERTED.UserId FROM INSERTED)
DECLARE @UserEmail NVARCHAR(250) = (SELECT Email FROM Users WHERE UserId = @Id)
DECLARE @PreviousPasswordHash NVARCHAR(MAX) = (SELECT DELETED.PasswordHash FROM DELETED)
DECLARE @UserPassword NVARCHAR(MAX) = (SELECT INSERTED.PasswordHash FROM INSERTED)

IF @PreviousPasswordHash != @UserPassword
BEGIN
DECLARE @BodyMessage NVARCHAR(300) = 'Go to https://sitequelconque.com/' + CAST(@Id AS NVARCHAR(300))                        

IF @Id IS NOT NULL
BEGIN
    EXEC msdb.dbo.sp_send_dbmail
      @recipients = @UserEmail, 
      @subject = 'Please, confirm your account', 
      @body = @BodyMessage
END
END



END
GO

ALTER TABLE [dbo].[Users] ENABLE TRIGGER [UpdatePasswordConfirmation]
GO


