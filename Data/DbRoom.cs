
public class DBRoom
{
    public static List<RoomModel> RoomList = new List<RoomModel>();
    static DBRoom()
    {
        for (int i = 0; i <= 10; i++)
        {
            RoomModel room = new RoomModel(i);
            RoomList.Add(room);
        }
    }
}