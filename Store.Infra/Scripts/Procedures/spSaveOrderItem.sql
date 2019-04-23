create procedure spSaveOrderItem
@Id uniqueidentifier,
@OrderId uniqueidentifier,
@ProductId uniqueidentifier,
@Quantity decimal,
@Price money

as
insert into [OrderItem] (
    [Id],
    [OrderId],
    [ProductId],
    [Quantity],
    [Price]

)
values (
    @Id,
    @OrderId,
    @ProductId,
    @Quantity,
    @Price
)