var express = require("express");
var app = express();
app.use(express.static(__dirname + "/static"));
app.set('views', __dirname + '/views'); 
app.set('view engine', 'ejs');
var bodyParser = require('body-parser');
// app.use(sessionY({secret: 'codingdojorocks'}));  // string for encryption for session need to install npm express-session
// use it!
app.use(bodyParser.urlencoded({extended: true}));
// app.get('/', function(request, response) {
//     // response.send("<h1>Hello Express</h1>");
//      // hard-coded user data
//      var users_array = [
//         {name: "Michael", email: "michael@codingdojo.com"}, 
//         {name: "Jay", email: "jay@codingdojo.com"}, 
//         {name: "Brendan", email: "brendan@codingdojo.com"}, 
//         {name: "Andrew", email: "andrew@codingdojo.com"}
//     ];
//     response.render('users', {users: users_array});
//     // response.render("main.html");
//   })
  app.get('/', function (req, res){
    res.render('index', {title: "my Express project"});
  });
  // route to process new user form data:
  app.post('/users', function (req, res){
    //code to add user to db goes here!
    console.log("POST DATA \n\n", req.body);
    // req.session.name = req.body.name; // to access session.
    // console.log(req.session.name);
    res.redirect('/');
  })
  app.get("/users/:id", function (req, res){
    console.log("The user id requested is:", req.params.id);
    // just to illustrate that req.params is usable here:
    res.send("You requested the user with id: " + req.params.id);
    // code to get user from db goes here, etc...
});
  // Tell the express app to listen on port 8000
app.listen(8000, function() {
    console.log("listening on port 8000");
  })
  