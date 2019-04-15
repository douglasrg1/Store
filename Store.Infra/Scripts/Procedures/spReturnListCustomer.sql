create procedure spReturnListCustomer

as
select 
    c.[Id],
    concat(c.[FirstName],' ',c.[LastName]) AS [Name],
    c.[Document],
    c.[Email],
    c.[Phone]
  from
    [Customer] c