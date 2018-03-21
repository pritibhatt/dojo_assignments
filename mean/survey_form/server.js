// require express
var express = require("express");
// path module -- try to figure out where and why we use this
var path = require("path");
// create the express app
var app = express();
var bodyParser = require('body-parser'); //form request for post you can acces data at form body. line 20
// use it!
app.use(bodyParser.urlencoded({ extended: true }));
// static content
app.use(express.static(path.join(__dirname, "./static")));
// for session
var session = require('express-session');
app.use(session({secret: 'codingdojorocks'}));  // string for encryption

// setting up ejs and our views folder
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');
// root route to render the index.ejs view
app.get('/', function(req, res) {
    res.render("index");
})

app.post('/result', function(req, res) {
       
    res.render("result", {session: req.session, name: req.body.name, dojo_location: req.body.dojo_location, favorite_languages: req.body.favorite_languages, comments: req.body.comments });
})

// tell the express app to listen on port 8000
app.listen(8000, function() {
 console.log("listening on port 8000");
});
