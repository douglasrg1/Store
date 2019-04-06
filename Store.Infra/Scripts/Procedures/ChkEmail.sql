create PROCEDURE spCheckEmail
    @email varchar(160)
AS
    SELECT CASE WHEN exists(
        SELECT[Id] FROM [Customer] WHERE [Email] = @email
    )
    THEN cast(1 as bit)
    else cast(0 as bit) END