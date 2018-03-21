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

var QuoteSchema = new mongoose.Schema({
    name:  { type: String, required: true, minlength: 2},
    quote: { type: String, required: true, minlength: 5 },
    
}, {timestamps: true });

   
   var Quote = mongoose.model('Quote') 

   app.get('/', function (req, res){
         res.render('index');
    })    
    mongoose.model('Quote', QuoteSchema); 
    app.get('/quotes', function(req, res) {
        Quote.find({}, (err, quotes) => {
            if(err){
                console.log("something went wrong");
                console.log(err);
                res.render("index", {title: "there are errors", errors: err});
                
            }
            else{
                console.log('getting quotes');
                console.log(quotes);
                res.render('results', {all_quotes: quotes});
            }
        })
    })

   app.post('/quotes', function(req, res) {
    console.log("POST DATA", req.body);
    // the .save() way   
     var quote = new Quote({name: req.body.name, quote: req.body.quote})

     quote.save(function(err){
            if(err){
                console.log("something went wrong");
                console.log(err);
                res.render("index", {title: "there are errors", errors: Quote.errors});
            }
            else {
                console.log("quote created");
                res.redirect('/quotes');
            }
        });
     })      
    
   
let server = app.listen(port, () => console.log(`listening on port ${port}`));

