using System.Text.Json;
using Microsoft.AspNetCore.SignalR;

public class RoomHub : Hub
{
    public RoomService _roomService { get; set; }

    public RoomHub(RoomService roomService)
    {
        _roomService = roomService;
    }

    public override async Task OnConnectedAsync() //Phương thức connect (gọi khi khởi động ứng dụng hoặc component)
    {

        Console.WriteLine($"[SignalR] Connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
        //Gọi hàm gửi dữ liệu về toàn client
        await Clients.All.SendAsync("SendToAllRoom", _roomService.getAllRoom());

    }
    //Phương thức disconnect (gọi khi dispose hoặc đóng ứng dụng)
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"[SignalR] Disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }

    public async Task AddRoomHub()
    {
        //Tạo room add vào roomlist
        _roomService.addRoom();
        //Sau khi thêm room xong thì sendall lại kết quả 
        await Clients.All.SendAsync("SendToAllRoom", _roomService.getAllRoom());
    }
}