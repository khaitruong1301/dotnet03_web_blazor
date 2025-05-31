using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

public class BurgerStateService(Burger burgerIntance) //C#12
{
    public Burger burger = burgerIntance;


    public void addTopping(string name, int quantity)
    {
        //Lấy ra topping để cập nhật số lượng 
        Topping? topping = burger.toppings.Find(t => t.name == name);
        topping.quantity += quantity;
        //Cập nhật lại giao diện
        NotifyStateChanged();
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();


}




// public BurgerStateService(Burger burderDI)
// {
//     burger = burderDI;
//     //Nếu constructor chỉ dùng cho DI không có thêm định nghĩa nào, có thể dùng cách viết ngắn gọn C#13
// }
