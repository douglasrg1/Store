CREATE PROCEDURE spSaveAddress
    @Id UNIQUEIDENTIFIER,
    @CustomerId UNIQUEIDENTIFIER,
    @Street VARCHAR(50),
    @NumberAddress VARCHAR(10),
    @Complement VARCHAR(60),
    @District VARCHAR(60),
    @City VARCHAR(30),
    @State CHAR(2),
    @Country CHAR(2),
    @ZipCode CHAR(8),
    @TypeAddress INT

AS
    INSERT INTO [Address](
        [Id],
        [CustomerId],
        [Street],
        [NumberAddress],
        [Complement],
        [District],
        [City],
        [State],
        [Country],
        [ZipCode],
        [TypeAddress]
    )
    VALUES(
    @Id,
    @CustomerId,
    @Street,
    @NumberAddress,
    @Complement,
    @District,
    @City,
    @State,
    @Country,
    @ZipCode,
    @TypeAddress
    )