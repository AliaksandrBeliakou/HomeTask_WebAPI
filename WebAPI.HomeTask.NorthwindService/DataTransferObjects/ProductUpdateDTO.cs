namespace WebAPI.HomeTask.NorthwindService.DataTransferObjects
{
    public record ProductUpdateDto(

        string ProductName,
        int SupplierID,
        int CategoryID,
        string? QuantityPerUnit,
        decimal? UnitPrice,
        Int16? UnitsInStock,
        Int16? UnitsOnOrder,
        Int16? ReorderLevel,
        bool Discontinued
        );
}
