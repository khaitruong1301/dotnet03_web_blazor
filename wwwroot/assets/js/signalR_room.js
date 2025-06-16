
window.main = () => {
    console.log(signalR);
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/roomHub")
        .build();
    connection.on("SendToAllRoom", (lstRoomFromHub) => {
        console.log("📥 Rooms from hub:", lstRoomFromHub);
    });
    connection.start()
        .then(() => console.log("✅ Connected to SignalR"))
        .catch(err => console.error("❌ Connection error:", err));
}
window.renderHTML = function(){
    console.log('123');
}

window.tinhTong = function(a,b){
    return a+ b;
}