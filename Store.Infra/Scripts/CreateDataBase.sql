create table[Customer](
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [FirstName] VARCHAR(40) NOT NULL,
    [LastName] VARCHAR(40) NOT NULL,
    [Document] VARCHAR(11) NOT NULL,
    [Email] VARCHAR(160) NOT NULL,
    [Phone] VARCHAR(13) NOT NULL
)

create table [Address](
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [NumberAddress] VARCHAR(10) NOT NULL,
    [Complement] VARCHAR(60) NOT NULL,
    [District] VARCHAR(60) NOT NULL,
    [City] VARCHAR(30) NOT NULL,
    [State] char(2) NOT NULL,
    [Country] char(2) NOT NULL,
    [ZipCode] char(8) not NULL,
    [TypeAddress] INT not NULL default(1),
    foreign KEY ([CustomerId]) references [Customer]([Id])
)

create table[Product](
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [Title] VARCHAR(255) NOT NULL,
    [Description] TEXT NOT NULL,
    [Image] VARCHAR(1024),
    [Price] MONEY not NULL,
    [QuantityOnHand] Decimal(10,2) not NULL
)

create table [Order](
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [CreateDate] DATETIME NOT NULL default(getdate()),
    [Status] int not NULL default(1),
    foreign KEY ([CustomerId]) references [Customer]([Id])
)

create table [OrderItem](
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [OrderId] UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [Quantity] Decimal(10,2) not NULL,
    [Price] MONEY not NULL,
    foreign KEY ([OrderId]) references [Order]([Id]),
    foreign KEY ([ProductId]) references [Product]([Id])
)

create table [Delivery](
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [OrderId] UNIQUEIDENTIFIER NOT NULL,
    [CreateDate] DATETIME NOT NULL default(getdate()),
    [EstimatedDeliveryDate] DATETIME not NULL,
    [Status] int NOT NULL default(1),
    foreign KEY ([OrderId]) references [Order]([Id])
)