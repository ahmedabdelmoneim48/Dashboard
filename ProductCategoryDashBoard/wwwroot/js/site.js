// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// wwwroot/js/site.js

// Create a connection to the SignalR hub
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/signalServer")  // This matches the server-side URL for SignalR
    .build();

// Start the connection
connection.start()
    .then(function () {
        console.log("Connected to SignalR hub!");
    })
    .catch(function (err) {
        console.error("Error connecting to SignalR:", err);
    });

// Listen for messages from the server
connection.on("ReceiveMessage", function (message) {
    console.log("Received message: " + message);
});

