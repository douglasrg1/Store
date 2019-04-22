create procedure spReturnCustomer
@Id UNIQUEIDENTIFIER
as
select 
    [Id],
    concat([FirstName],' ',[LastName]) AS [Name],
    [Document],
    [Email]
from
  [Customer]
where 
    @Id = [Id]