create PROCEDURE spCheckDocument
    @document CHAR(11)
AS
    SELECT CASE WHEN exists(
        SELECT[Id] FROM [Customer] WHERE [Document] = @document
    )
    THEN cast(1 as bit)
    else cast(0 as bit) END