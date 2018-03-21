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

io.sockets.on('connection', (socket) => {
    console.log('socket connection!!');
    console.log(`socket id: ${socket.id}`);
    //listener
    socket.on( "button_clicked", function(data){
        // console.log(data);
    //emit
    io.emit('button_response', {msg: 'Somebody clicked a button'})
    })
    //listener
    socket.on('form_submission', (data) => {
        console.log('received event from client');
        //emit
      io.emit('form_response', {msg: `${data.user} filled out form`});
    })
})
 

