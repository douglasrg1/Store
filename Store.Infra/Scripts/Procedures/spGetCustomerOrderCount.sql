create PROCEDURE spCheckDocument
    @document CHAR(11)
AS
    SELECT
        c.[Id],
        concat(c.[FirstName],' ',c.[LastName]) AS [Name],
        c.[Document]
    from
        [Customer] c
        inner join [Order] o on o.[CustomerId] == c[Id]