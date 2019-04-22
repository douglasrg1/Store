CREATE PROCEDURE spUpdateCustomer
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(40),
    @LastName VARCHAR(40),
    @Document CHAR(11),
    @Email VARCHAR(160),
    @Phone VARCHAR(13)

AS
    update [Customer]
       set
        [FirstName] = @FirstName,
        [LastName] = @LastName,
        [Document] = @Document,
        [Email] = @Email,
        [Phone] = @Phone

     where [Id] = @Id