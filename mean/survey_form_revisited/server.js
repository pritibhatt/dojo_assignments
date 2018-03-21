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

    //listener
    socket.on('posting_form', (data) => {
        console.log('received event from client');
        //emit
    io.emit('updated_message', {msg: `You emitted following information to the server: {Name: ${data.user}, Dojo Location: ${data.location}, Favorite Language: ${data.language}, Comments: ${data.comments}} <br><br> Your lucky number emitted by the server is ${data.random_number}.`});
    
    })
    
})
 

