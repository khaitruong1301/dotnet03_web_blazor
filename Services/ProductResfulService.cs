using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
public class ProductResfulService
{
    public HttpClient _http;
    public List<ProductResfulModel>? lstProduct = new List<ProductResfulModel>();
    public string responseMessage = "";
    public ProductResfulService(HttpClient http)
    {
        _http = http;
    }
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();

    public async Task getAllProduct()
    {
        // Gọi API ở đây nếu cần
        lstProduct = await _http.GetFromJsonAsync<List<ProductResfulModel>>("https://svcy.myclass.vn/api/ProductApi/getall");
        Console.WriteLine($"{JsonSerializer.Serialize(lstProduct)}");
        //Gọi để giao diện cập nhật lại
        NotifyStateChanged();
    }

    public async Task<ProductResfulModel?> getProductById(string id)
    {
        // Gọi API ở đây nếu cần
        ProductResfulModel? res = await _http.GetFromJsonAsync<ProductResfulModel>($"https://svcy.myclass.vn/api/ProductApi/get/{id}");
        //Gọi để giao diện cập nhật lại
        NotifyStateChanged();
        return res;
    }

    public async Task<int> createProduct(ProductResfulModel prd)
    {
        var response = await _http.PostAsJsonAsync("https://svcy.myclass.vn/api/ProductApi/create", prd);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            //Thêm thành công 
            await getAllProduct();
            responseMessage = response.Content.ReadAsStringAsync().Result;
            NotifyStateChanged();
            return 1;
        }
        else
        {
            responseMessage = response.Content.ReadAsStringAsync().Result;
            NotifyStateChanged();
            return 2;
        }
    }


    public async Task<int> updateProduct(ProductResfulModel prdUpdate, string id)
    {
        var response = await _http.PutAsJsonAsync($"https://svcy.myclass.vn/api/ProductApi/update/{id}", prdUpdate);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            //Thêm thành công 
            await getAllProduct();
            responseMessage = response.Content.ReadAsStringAsync().Result;
            NotifyStateChanged();
            return 1;
        }
        else
        {
            responseMessage = response.Content.ReadAsStringAsync().Result;
            NotifyStateChanged();
            return 2;
        }
    }
    


    public async Task deleteProductById(string id)
    {
        // Gọi API ở đây nếu cần
        string? res = await _http.DeleteFromJsonAsync<string>($"https://svcy.myclass.vn/api/ProductApi/delete/{id}");

        //Gọi để giao diện cập nhật lại
        await getAllProduct();
    }


}
/*
    StatusCode: 
    200: resquest đến server và xử lý thành công - OK
    201: request đến server nhưng dữ liệu đã được tạo - created
    400: bad request request đến server (dữ liệu không hợp lệ để lấy giá trị về) -> getbyid = 1
    404: not found không tìm thấy link api đó hoặc tìm thấy dữ liệu
    401: unauthourized Không có quyền truy cập vào api đó
    403: forbiden Chưa đủ quyền truy cập vào api

    // Request (thông tin request - các giá trị FE gửi lên)
    // Response (thông tin response - các giá trị server trả về)
*/


