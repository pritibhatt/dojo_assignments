var express = require("express");
var bodyParser = require('body-parser');
var session = require('express-session');
var path = require("path");
let port = 8000;
var app = express();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, "./static")));
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');
app.use(session({secret: 'codingdojorocks'}));  

let server = app.listen(port, () => console.log(`listening on port ${port}`));

app.get('/', (req, res) => {
   
    res.render("index");
})

var io = require('socket.io').listen(server);
var count = 0;
io.sockets.on('connection', function (socket) {
    console.log("Client is connected!");
    console.log("Client id is: ", socket.id);
    var count = 0;
    // all the server socket code goes in here
    socket.on("counter_clicked", function (data) {
        count += 1;
        io.emit('server_response', { response: "the client is listening", count: count});
    });
    socket.on("reset_count", function (data) {
        count = 0;
        io.emit("server_response", {count: count});
    });
});

 
