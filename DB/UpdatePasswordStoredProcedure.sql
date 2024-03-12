CREATE PROCEDURE [dbo].[UpdatePassword]  @Id INT, @PasswordSalt NVARCHAR(MAX),@PasswordHash NVARCHAR(MAX)
AS
BEGIN   

    BEGIN TRY
        UPDATE Users 
        SET PasswordSalt = @PasswordSalt, PasswordHash = @PasswordHash 
        WHERE UserId = @Id;

        DECLARE @UserEmail NVARCHAR(450) = (SELECT Email FROM Users WHERE UserId = @Id);
        DECLARE @BodyMessage NVARCHAR(100) = 'Password changed please confirm ...';

        EXEC msdb.dbo.sp_send_dbmail
            @recipients = @UserEmail, 
            @subject = 'Password changed', 
            @body = @BodyMessage;
    END TRY
    BEGIN CATCH
    END CATCH;
END

