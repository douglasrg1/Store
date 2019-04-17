create procedure spReturnCustomerAddresses
    @Id UNIQUEIDENTIFIER
as
    select 
        [Street],
        [NumberAddress],
        [Complement],
        [District],
        [City],
        [State],
        [Country],
        [ZipCode],
        [TypeAddress]


    from
       [Address]
    where
        @Id = [Id]