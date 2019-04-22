create procedure spReturnListCustomerOrders
    @Id UNIQUEIDENTIFIER
as
select 
    c.[Id],
    concat(c.[FirstName],' ',c.[LastName]) AS [Name],
    c.[Document],
    c.[Email],
    o.[NumberOrder],
    o.[Total]
  from
   [Order] o inner join [Customer] c on o.[CustomerId] = c.[Id]
 where 
    @Id = [CustomerId]