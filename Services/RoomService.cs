
public class RoomService
{
    public static List<RoomModel> lstRoom = DBRoom.RoomList;
    public List<RoomModel> getAllRoom()
    {
        return lstRoom;
    }
    public void addRoom()
    {
        RoomModel roomModel = new RoomModel(lstRoom.Count + 1);
        lstRoom.Add(roomModel);
    }
 



}