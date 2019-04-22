create procedure spRemoverAddress
    @CustomerId UNIQUEIDENTIFIER
as
delete from Address
    where @CustomerId = [CustomerId]