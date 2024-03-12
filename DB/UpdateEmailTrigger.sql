USE [EF_Hash_Token]
GO

/****** Object:  Trigger [dbo].[UpdateEmailConfirmation]    Script Date: 10-03-24 13:41:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[UpdateEmailConfirmation]   
   ON  [dbo].[Users] 
   AFTER UPDATE
AS 
BEGIN        
SET NOCOUNT ON;
DECLARE @Id INT = (SELECT INSERTED.UserId FROM INSERTED)
DECLARE @PreviousEmail NVARCHAR(250) = (SELECT deleted.Email FROM DELETED WHERE UserId = @Id)
DECLARE @UserEmail NVARCHAR(250) = (SELECT INSERTED.Email FROM INSERTED)

IF @PreviousEmail != @UserEmail
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

ALTER TABLE [dbo].[Users] ENABLE TRIGGER [UpdateEmailConfirmation]
GO


