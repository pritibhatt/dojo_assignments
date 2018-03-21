//Require Mongoose for Database Connection
var mongoose = require('mongoose');

//CREATING A SCHEMA FOR 
var AuthorSchema = new mongoose.Schema({
    name: String,
    
   }, {timestamps: true});
var Mongoose = mongoose.model('Author', AuthorSchema); 