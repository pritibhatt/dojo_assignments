var express = require("express");
var bodyParser = require('body-parser');
var session = require('express-session');
var bcrypt = require('bcrypt');
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
var UserSchema = new mongoose.Schema({
    first_name: { type: String, required: true, minlength: 2},
    last_name: { type: String, required: true, minlength: 2},
    email: {type: String, unique: true,
        validate: {
        validator: function( email ) {
        var re = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return re.test(email)
        },
        message: "Not a valid email address"
        },
        required: [true, "Email required"]
},
    last_name: { type: String, required: true, minlength: 2},
    password: { type: String, required: true, minlength: 4},
    // birthday: { type: Number, min: [18, "Maybe you need to be a little older"], required: true}
   }, {timestamps: true});
   UserSchema.pre('save', function(next) {
       
        console.log(this.password);      
        bcrypt.hash(this.password, 10).then(hash => {
             // Store hash in your password DB.
             this.password = hash;
             console.log(hash);
             console.log(this.password);
             next();
        })
               
                
            
       
        
   })

  var User = mongoose.model('User', UserSchema); 



//  Routes
app.get('/', function (req, res){
    User.find({}, function (err, users) {
        if (err) {
            console.log('something went wrong');
        } else {
            res.render("index", { users: users });
            
        }
    })
});
    
app.post('/register', function (req, res) {
    console.log("POST DATA", req.body);
   if(req.body.password != req.body.confirm){
       let errors = [{'message': ''}];
       errors[0]['message'] = 'Passwords do not match';
       res.render('index', {errorsRegister: errors});
   } 
       var newUser = new User ({
           first_name: req.body.firstName,
           last_name: req.body.lastName,
           email: req.body.email,
           password: req.body.password
       });
       newUser.save(function(err) {
           if(err) {
               console.log(err, 'something went wrong');
               res.redirect('/')
           } else {
                
                    console.log('successfully added a User!!');
                    res.redirect("/");
                }  
           })
        })     
        

app.post('/login', function(req, res) {
    User.findOne({email: req.body.emailLogin}, function(error, user){
        if(error){
            console.log("Email is not in  database");
            res.redirect('/')
        }
        if(user == null){
            console.log("Email is not in  database");
            res.redirect('/')
        
        } else {
            console.log(user.password)
            bcrypt.compare(req.body.passwordLogin, user.password)
            .then(results => {
                console.log(results)
                if(results == true){
                    res.render("success", { user });
                }
                else{
                    res.redirect('/')
                }

            })
            //catches system errors(ie database issues or query issues or code logic)
            .catch(err =>  {
                console.log("Incorrect password.");
                console.log(err);
                err.push("Incorrect password.");
                res.redirect('/');
            })
            
            
        }
    })
})






    
   
let server = app.listen(port, () => console.log(`listening on port ${port}`));

