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

app.use(session({secret: 'codingdojorocks', resave: false, saveUninitialized: true})); 

var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/basic_mongoose');
mongoose.Promise = global.Promise;

var UserSchema = new mongoose.Schema({
    first_name:  { type: String, required: true, minlength: 6},
    last_name: { type: String, required: true, maxlength: 20 },
    age: { type: Number, min: 1, max: 150 },
    email: { type: String, required: true }
}, {timestamps: true });

   mongoose.model('User', UserSchema); // We are setting this Schema in our Models as 'User'
   var User = mongoose.model('User') // We are retrieving this Schema from our Models, named 'User'

   app.get('/', function (req, res){
    User.find({}, (err, users) => {
        if(err){
            console.log(err);
        }
        else {
            res.render('index', {users: users})
        }
    })    
    })

   app.post('/users', function(req, res) {
    console.log(req.body);
    let user = new User()
    // the .save() way    
    // user.name = req.body.name;
    // user.email = req.body.emai;
    // user.age = req.body.age;
    // user.password = req.body.password;
    // return res.redirect('/');
    
    //the .create() way
    User.create(req.body, (err, user) =>{
        if(err){
            console.log(err);
        }else{
            return res.redirect('/');
        }
    })
    
})

let server = app.listen(port, () => console.log(`listening on port ${port}`));


// // Add User Request 
// app.post('/users', function(req, res) {
//     console.log("POST DATA", req.body);
//     // This is where we would add the user from req.body to the database.
//     res.redirect('/');
// })