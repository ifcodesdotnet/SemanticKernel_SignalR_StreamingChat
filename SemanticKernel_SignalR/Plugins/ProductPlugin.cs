
using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SemanticKernel_SignalR.Plugins;
public class ProductPlugin(HttpClient httpClient)
{
    [KernelFunction("bestSellingProducts")]
    [Description("Retrieves the best-selling products.")]
    [return: Description("Returns the best-selling products as JSON.")]
    public async Task<string> BestSellingProducts()
    {
        var response = await httpClient.GetAsync("https://localhost:5152/best-selling-products");
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }
}
