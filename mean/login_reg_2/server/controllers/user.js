//get the model
var mongoose = require('mongoose');
var bcrypt = require('bcrypt');
var session = require('express-session');
var User = mongoose.model('User');
var path =require('path');
class UserController {
    index(req, res){
    User.find({}, function (err, users) {
        if (err) {
            console.log('something went wrong');
        } else {
            res.render("index", { users: users });
            
        }
     })
    } 
    create(req, res){
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
    }
    login(req, res){
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
    } 
}

 

module.exports = new UserController();