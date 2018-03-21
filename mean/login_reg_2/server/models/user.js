var mongoose = require("mongoose");
let bcrypt = require("bcrypt");
// var Schema = mongoose.Schema;

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
    
        password: { type: String, required: true, minlength: 4},
        birthdate: { type: Number, min: [18, "Maybe you need to be a little older"], required: true}
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