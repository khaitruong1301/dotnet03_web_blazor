window.main = async () => {


    console.log(signalR);
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5210/roomhub")
        .build();

    connection.start()
        .then(() => console.log("✅ Connected to SignalR"))
        .catch(err => console.error("❌ Connection error:", err));

    connection.on("SendToAllRoom", (lstRoomFromHub) => {
        console.log("📥 Rooms from hub:", lstRoomFromHub);
        let strHTML = '';
        for(let room of lstRoomFromHub){
            strHTML += `
                <li>${room.roomName}</li>
            `
        }
        document.querySelector('#room').innerHTML = strHTML;
        console.log(document.querySelector('#room'))
    });
}
// main();

window.renderHTML = function(){
    console.log('123');
}

window.tinhTong = function(a,b){
    return a+ b;
}