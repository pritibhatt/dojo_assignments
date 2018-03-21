//Require Mongoose for Database Connection
var mongoose = require('mongoose');
var path = require('path');
//CREATING A SCHEMA FOR 
var ProductsSchema = new mongoose.Schema({
    name: {type: String, required: true, minlength: 3},
    qty: { type: Number, min: [1, "Price must be greater than zero"], required: true},
    price: Number,
    
   }, {timestamps: true});
var Mongoose = mongoose.model('Products', ProductsSchema); 