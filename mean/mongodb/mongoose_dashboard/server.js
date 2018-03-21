var express = require("express");
var bodyParser = require('body-parser');
var session = require('express-session');
var path = require("path");
let port = 8000;
var app = express();

//middlewares
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, "./static")));

app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

app.use(session({secret: 'codingdojorocks', resave: false, saveUninitialized: true})); 

//Connect to DB
var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/basic_mongoose');
mongoose.Promise = global.Promise;




//Model
var MongooseSchema = new mongoose.Schema({
    name: String,
   })
var Mongoose = mongoose.model('Mongoose', MongooseSchema); 



// Routes
app.get('/', function(req, res) {
    Mongoose.find({}, function(err, mongooses) {
        res.render('index', {all_mongooses: mongooses});
    })
})
app.get('/mongooses/new', function(all_mongoosesreq, res) {
    res.render('new');
})
app.post('/mongooses', function(req, res) {
    var mongoose = new Mongoose({
        name: req.body.Name,
    })
    mongoose.save(function(err) {
        if(err) {
          console.log('something went wrong');
        } else {
          console.log('successfully added a mongoose!');
          res.redirect('/');
        }
      })
})
app.get('/mongooses/:id', function(req, res) {
    Mongoose.findOne({_id: req.params.id}, function(err, mongoose) {
        res.render('show', {all_mongooses: mongoose});
    })
})

app.get('/mongooses/edit/:id', function(req, res) {
    Mongoose.findOne({_id: req.params.id}, function(err, mongoose) {
        res.render('update', {all_mongooses: mongoose});
    })
})

app.post('/mongooses/edit/:id', function(req, res) {
    Mongoose.update({_id: req.params.id}, {name: req.body.Name}, function(err, mongoose) {
        res.redirect("/mongooses/edit/"+req.params.id)
    })
})

app.get('/mongooses/delete/:id', function(req, res) {
    Mongoose.remove({_id: req.params.id}, function(err) {
        if(err) {
            console.log('something went wrong')
        } else {
            console.log("Mongoose deleted")
            res.redirect("/")
        }
    })
})
    
   
let server = app.listen(port, () => console.log(`listening on port ${port}`));

