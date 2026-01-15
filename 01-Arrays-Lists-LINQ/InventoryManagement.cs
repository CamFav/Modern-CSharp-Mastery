/*
 * ============================================
 * ARRAYS AND LOOPS - INVENTORY MANAGEMENT
 * ============================================
 * CONTEXT: E-commerce inventory processing system.
 * OBJECTIVE: Analyze inventory data, calculate statistics and generate reports.
 * TECHNIQUES: Comparison between Basic C# (Parallel Arrays) and Modern C# (LINQ).
 */

namespace InventoryManagement
{
    // ================================
    // Product Class
    // ================================
    class Product
    {
        public string Code { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    // ================================
    // Program Entry Point
    // ================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Basic C# --");
            RunBasicCSharp();
            Console.WriteLine("\n");
            Console.WriteLine("-- Modern C# with LINQ --");
            RunModernCSharp();
        }

        // ================================
        // Basic C# Implementation (Arrays & Loops)
        // ================================
        static void RunBasicCSharp()
        {
            string[] productCodes = { "PROD-001", "PROD-002", "PROD-003", "PROD-004", "PROD-005", "PROD-006", "PROD-007", "PROD-008" };
            int[] stockQuantities = { 45, 120, 78, 0, 200, 15, 89, 0 };
            decimal[] unitPrices = { 29.99m, 15.50m, 45.00m, 12.99m, 8.75m, 99.99m, 34.50m, 19.99m };

            // Total products
            int totalProducts = 0;
            foreach (string code in productCodes) totalProducts++;
            Console.WriteLine($"Total number of products : {totalProducts}");

            // Stock out detection
            for (int i = 0; i < stockQuantities.Length; i++)
            {
                if (stockQuantities[i] == 0)
                    Console.WriteLine($"ALERT : Stock out for {productCodes[i]}");
            }

            // Inventory value
            decimal inventoryValue = 0m;
            for (int i = 0; i < stockQuantities.Length; i++)
                inventoryValue += stockQuantities[i] * unitPrices[i];
            Console.WriteLine($"Total inventory value : ${inventoryValue}");

            // Reorder needed
            for (int i = 0; i < stockQuantities.Length; i++)
            {
                if (stockQuantities[i] < 50)
                    Console.WriteLine($"Reorder needed : {productCodes[i]} (Stock: {stockQuantities[i]})");
            }

            // Advanced statistics
            decimal averageQuantity = (decimal)stockQuantities.Sum() / totalProducts;
            Console.WriteLine($"Average quantity in stock : {averageQuantity:F2}");

            // Highest quantity
            int highestQuantity = stockQuantities[0];
            int highestQuantityIndex = 0;
            for (int i = 1; i < stockQuantities.Length; i++)
            {
                if (stockQuantities[i] > highestQuantity)
                {
                    highestQuantity = stockQuantities[i];
                    highestQuantityIndex = i;
                }
            }
            Console.WriteLine($"Product with highest quantity : {productCodes[highestQuantityIndex]} ({highestQuantity} units)");

            // Highest price
            decimal highestPrice = unitPrices[0];
            int highestPriceIndex = 0;
            for (int i = 1; i < unitPrices.Length; i++)
            {
                if (unitPrices[i] > highestPrice)
                {
                    highestPrice = unitPrices[i];
                    highestPriceIndex = i;
                }
            }
            Console.WriteLine($"Product with highest price : {productCodes[highestPriceIndex]} (${highestPrice:F2})");
        }

        // ================================
        // Modern C# Implementation (LINQ & List<Product>)
        // ================================
        static void RunModernCSharp()
        {
            var products = new List<Product>
            {
                new Product { Code = "PROD-001", Quantity = 45, Price = 29.99m },
                new Product { Code = "PROD-002", Quantity = 120, Price = 15.50m },
                new Product { Code = "PROD-003", Quantity = 78, Price = 45.00m },
                new Product { Code = "PROD-004", Quantity = 0, Price = 12.99m },
                new Product { Code = "PROD-005", Quantity = 200, Price = 8.75m },
                new Product { Code = "PROD-006", Quantity = 15, Price = 99.99m },
                new Product { Code = "PROD-007", Quantity = 89, Price = 34.50m },
                new Product { Code = "PROD-008", Quantity = 0, Price = 19.99m }
            };

            // Total products
            Console.WriteLine($"Total number of products : {products.Count}");

            // Stock out detection
            var outOfStock = products.Where(p => p.Quantity == 0);
            foreach (var product in outOfStock)
                Console.WriteLine($"ALERT : Stock out for {product.Code}");

            // Inventory value
            var inventoryValue = products.Sum(p => p.Quantity * p.Price);
            Console.WriteLine($"Total inventory value : ${inventoryValue}");

            // Reorder needed
            var toReorder = products.Where(p => p.Quantity < 50);
            foreach (var product in toReorder)
                Console.WriteLine($"Reorder needed : {product.Code} (Stock: {product.Quantity})");

            // Average quantity
            var avgQuantity = products.Average(p => (decimal)p.Quantity);
            Console.WriteLine($"Average quantity in stock : {avgQuantity:F2}");

            // Highest quantity
            var productWithHighestQuantity = products.MaxBy(p => p.Quantity)!;
            Console.WriteLine($"Product with highest quantity : {productWithHighestQuantity.Code} ({productWithHighestQuantity.Quantity} units)");

            // Highest price
            var productWithHighestPrice = products.MaxBy(p => p.Price)!;
            Console.WriteLine($"Product with highest price : {productWithHighestPrice.Code} (${productWithHighestPrice.Price:F2})");
        }
    }
}
