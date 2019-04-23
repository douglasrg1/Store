create procedure spReturnProduct
@Id uniqueidentifier
as

select 
  [Title],
  [Description],
  [Image],
  [Price],
  [QuantityOnHand]
  
  from
   [Product]

 where 
   [Id] = @id