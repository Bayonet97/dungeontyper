"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;

    document.getElementById("dungeontextarea").value += encodedMsg;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

function SumbitInput() {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("inputfield").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}