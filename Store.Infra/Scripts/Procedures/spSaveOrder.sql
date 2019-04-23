create procedure spSaveOrder
@Id uniqueidentifier,
@CustomerId uniqueidentifier,
@CreateDate datetime,
@Status int,
@NumberOrder varchar(50),
@Total money

as
insert into [Order](
    [Id],
    [CustomerId],
    [CreateDate],
    [Status],
    [NumberOrder],
    [Total]
)
values (
    @Id,
    @CustomerId,
    @CreateDate,
    @Status,
    @NumberOrder,
    @Total

)