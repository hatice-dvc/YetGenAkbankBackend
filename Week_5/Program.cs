using Week_5.Contexts;
using Week_5.Entities;

Console.WriteLine("Postgre SQL!");

ShopifyDbContext _context = new();

#region Add-Single

Product product1 = new("Zippo Gold Lighter", 0.02m, 2000m);

_context.Products.Add(product1);

_context.SaveChanges();

#endregion

#region Add-Multiple

List<Product> zippoProducts = new List<Product> 
{
    new Product("Zippo Classic Chrome Lighter", 0.03m, 2200m),
    new Product("Zippo Vintage Brass Lighter", 0.04m, 2500m),
    new Product("Zippo Armor High Polish Chrome Lighter", 0.03m, 2600m),
    new Product("Zippo Brushed Brass Lighter", 0.03m, 2400m),
    new Product("Zippo Black Ice Lighter", 0.03m, 2300m),
    new Product("Zippo Street Chrome Lighter", 0.02m, 2000m),
    new Product("Zippo Slim Venetian Lighter", 0.02m, 2100m),
    new Product("Zippo Windproof Lighter with Logo", 0.03m, 2250m),
    new Product("Zippo Satin Chrome Lighter", 0.02m, 2150m),
    new Product("Zippo High Polish Brass Lighter", 0.04m, 2700m),
    new Product("Zippo Vintage High Polish Brass Lighter", 0.04m, 2800m),
    new Product("Zippo Slim Brushed Chrome Lighter", 0.02m, 2050m),
    new Product("Zippo Matte Lighter with Zippo Logo", 0.03m, 2350m),
    new Product("Zippo Jack Daniel's Label Lighter", 0.03m, 2450m),
    new Product("Zippo Harley-Davidson Lighter", 0.03m, 2550m),
    new Product("Zippo Venetian High Polish Chrome Lighter", 0.04m, 2650m),
    new Product("Zippo American Flag Lighter", 0.03m, 2300m),
    new Product("Zippo Anne Stokes Dragon Lighter", 0.03m, 2400m),
    new Product("Zippo High Polish Chrome Lighter with Slashes", 0.03m, 2500m),
    new Product("Zippo Black Matte Lighter", 0.02m, 2200m),
};

_context.Products.AddRange(zippoProducts);

_context.SaveChanges();


#endregion

#region Read-Multiple

List<Product> products = _context.Products.Where(x => x.Price < 2500).OrderBy(x => x.Price).ToList();

foreach(var product in products)
{
    Console.WriteLine($"{product.Title} - {product.Price}");
}

#endregion

#region Read-Single

Product product2 = _context.Products.Where(x => x.Title.Contains("Black")).FirstOrDefault();

Console.WriteLine($"{product2.Title} - {product2.Price}");

#endregion