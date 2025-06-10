

public class RoomModel
{
    public int id { get; set; }
    public string roomName { get; set; }

    public RoomModel()
    {

    }
    public RoomModel(int inputId)
    {
        id = inputId;
        roomName = $"Room {id}";
    }
}