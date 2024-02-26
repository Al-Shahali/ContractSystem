"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/ContractHub", {
    accessTokenFactory: () => "testAccessToken"
}).build();

connection.on("Connected", function (MyConnectionID) {
    var Userid = $('#UserId').val();
    console.log(MyConnectionID);
   
   
});

connection.start().then(function () {
    console.log('connection start');
}).catch(function (err) {
    return console.error(err.toString());
});