//Require Mongoose for Database Connection
var mongoose = require('mongoose');

//CREATING A SCHEMA FOR 
var ProductSchema = new mongoose.Schema({
    name: {type: String,  minlength: 3},
    qty: { type: Number, min: [1, "Quantity must be greater than zero"] },
    description: {type: String,  minlength: 3},
    restaurant: {type: String,  minlength: 3},
    cuisine: {type: String,  minlength: 3},
    review: {}
   }, {timestamps: true});
var Mongoose = mongoose.model('Product', ProductSchema); 