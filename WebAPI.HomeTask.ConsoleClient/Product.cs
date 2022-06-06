namespace WebAPI.HomeTask.ConsoleClient
{
    internal record Product
    (
        int ProductId,
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
