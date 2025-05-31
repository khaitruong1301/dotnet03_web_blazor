
namespace dotnet03_web_blazor.Services
{
    public class StateNumberService
    {
        public int number { get; set; } = 1;

        public void changeNumber(int quantity = 1)
        {
            number += quantity;
            //Gọi sự kiện này để giao diện cập nhật lại
            StateHasChange();
        }

        public event Action OnChange;

        public void StateHasChange() => OnChange?.Invoke();
    }
}

