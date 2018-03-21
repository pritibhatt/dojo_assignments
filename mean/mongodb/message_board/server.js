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




//Post Model
var Schema = mongoose.Schema;
var PostSchema = new mongoose.Schema({
 text: { type: String, required: true }, 
 comments: [{type: Schema.Types.ObjectId, ref: 'Comment'}]
}, { timestamps: true });

//Comment Model
var CommentSchema = new mongoose.Schema({
    // since this is a reference to a different document, the _ is the naming convention!
    _post: {type: Schema.Types.ObjectId, ref: 'Post'},
    text: { type: String, required: true },
   }, {timestamps: true });
   
// Routes
app.get('/', function(req, res) {
    Message.find({ })   //this allows for us to show all the messages and its comments with it//shorter way of doing the nested find functions
        .populate('comments')
        .exec(function (err, messages) {
            res.render('index', { messages: messages});
        });
})

//Post route to handle form for messages
app.post('/messages', function(req, res) {
    var message = new Mongoose({
        name: req.body.Name,
        message: req.body.message
    })
    message.save(function(err) {
        if(err) {
          console.log('something went wrong');
        } else {
          console.log('successfully added a mongoose!');
          res.redirect('/');
        }
      })
})

//Post route to handle form for comments
app.post('/comments', function(req, res) {
    var comment = new Mongoose({
        name: req.body.Name,
        comment: req.body.comment
    })
    Message.findOne({_id : req.body.message}, function(err, currentMessage){ //finding one message// the message in req.body.message is from the comments form with the hidden input !!
        comment._message = currentMessage; //setting that one message we just queried for to the message field when creating a comment //currentMessage is tied to this comment by using the hidden field input on the comment form! Passing the message id in the hidden form of the comment connects them
        comment.save(function(err) {
        if(err) {
          console.log('something went wrong');
          res.render('index', { errors: comment.errors })
        }
        currentMessage.comments.push(comment); 
        currentMessage.save(function (messErr){
            res.redirect('/');
        })
        console.log(commentInstance.name, commentInstance.comment, commentInstance.currentMessage);
         
      })
})
});


let server = app.listen(port, () => console.log(`listening on port ${port}`));