
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class ProductStateService(HttpClient http)
{
    public List<ProductViewModel> lstProduct = new List<ProductViewModel>();

    public ProductDetailViewModel prodDetail = new ProductDetailViewModel();

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    public async Task GetAllProductApiStore(string k="")
    {
        try
        {
            string url = "https://apistore.cybersoft.edu.vn/api/Product";
            if (!string.IsNullOrEmpty(k))
            {
                url = $"https://apistore.cybersoft.edu.vn/api/Product?keyword={k}";
            }
            ResponseApiType<List<ProductViewModel>>? data = await http.GetFromJsonAsync<ResponseApiType<List<ProductViewModel>>>(url);
            lstProduct = data.content;
            // Console.WriteLine($@"{JsonSerializer.Serialize(data)}");
            //Render lại giao diện
            NotifyStateChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GET failed: {ex.Message}");
        }
    }
    
    public async Task GetProductById(int id=0)
    {
        try
        {
            ResponseApiType<ProductDetailViewModel>? data = await http.GetFromJsonAsync<ResponseApiType<ProductDetailViewModel>>($"https://apistore.cybersoft.edu.vn/api/Product/getbyid?id={id}");
            //Cập nhật state view model
            prodDetail = data.content;
            //Cập nhật lại giao diện 
            NotifyStateChanged();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"GET failed: {ex.Message}");
        
        }
    }


}