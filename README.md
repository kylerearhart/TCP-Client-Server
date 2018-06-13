# TCP-Client-Server
This repo will include two applications written in C# that demonstrate a simple TCP Client sending a message to a TCP Server and the server being able to send a message back to the client. Resembling a two-way chat.

**Client ("Talker")**
>The client application will create a TCP Client and send a user-input message to a connected server.

**Server ("Listener")**
>The server application will create a TCP Listener in order to listen for any send requests from a client. It will receive the message sent by the client and display it to the console.
The server will then be able to send a message back to the client, which will be displayed on the client's console.
