"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

connection.on("WriteOutput", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var outputMsg = msg + "\n"
    document.getElementById("dungeontextarea").value += outputMsg;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

function SubmitInput() {
    var input = document.getElementById("inputfield").value;
    connection.invoke("ProcessInput", input).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("inputfield").value = "";
}