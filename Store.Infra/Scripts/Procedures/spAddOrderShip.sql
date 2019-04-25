create procedure spAddOrderShip
@Id uniqueidentifier,
@OrderId uniqueidentifier,
@CreateDate datetime,
@EstimatedDeliveryDate datetime,
@Status int

as

insert into [Delivery](
    [Id],
    [OrderId],
    [CreateDate],
    [EstimatedDeliveryDate],
    [Status]
)
values(
    @Id,
    @OrderId,
    @CreateDate,
    @EstimatedDeliveryDate,
    @Status
)