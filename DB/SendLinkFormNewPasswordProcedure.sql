USE [EF_Hash_Token]
GO

/****** Object:  StoredProcedure [dbo].[UpdatePassword]    Script Date: 11-03-24 10:34:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SendLinkFormNewPassword] @email NVARCHAR(400)
AS
BEGIN   

    BEGIN TRY
        DECLARE @id INT = (SELECT UserId FROM Users WHERE Email = @email);
        DECLARE @BodyMessage NVARCHAR(300) = 'Go to http://localhost:4200/user/' + convert(NVARCHAR(255), @Id) + '/newpassword';

        EXEC msdb.dbo.sp_send_dbmail
            @recipients = @email, 
            @subject = 'Request form change you''re password', 
            @body = @BodyMessage;
    END TRY
    BEGIN CATCH
    END CATCH;
END
GO

EXEC dbo.SendLinkFormNewPassword @email = 'nico.daddabbo7100@gmail.com'