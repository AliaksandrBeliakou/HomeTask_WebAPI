namespace WebAPI.HomeTask.ConsoleClient
{
    public static class Programm
    {
        public static async Task Main()
        {
            Console.WriteLine("Hellow Human! -_-");
            Console.WriteLine("I gonna pass a few requests to Northwind Web API Service.");

            await RequestHelper.GetAsync<IEnumerable<Product>>(
                "http://localhost:10000/api/products?pageNumber=2&categoryId=1&productsOnPage=4",
                list =>
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                });
            int addedProductId = 0;

            await RequestHelper.SendAsync<int>("http://localhost:10000/api/products/", HttpMethod.Post,
                new Product(0, "Product", 1, 1, "some", 10, 1, 1, 1, true),
                id => addedProductId = id);

            await RequestHelper.GetAsync<Product>($"http://localhost:10000/api/products/{addedProductId}", product => Console.WriteLine(product));

            await RequestHelper.SendAsync<string>($"http://localhost:10000/api/products/{addedProductId}", HttpMethod.Delete, null, _ => Console.WriteLine("Product's gone. :D"));

        }
    }
}

