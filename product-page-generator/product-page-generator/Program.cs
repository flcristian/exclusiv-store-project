using System.Text.Json;
using product_page_generator.jsondata;
using product_page_generator.product.model;
using product_page_generator.product.service;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductService service = new ProductService();
        service.CreateAllHtmlPages();
    }
}