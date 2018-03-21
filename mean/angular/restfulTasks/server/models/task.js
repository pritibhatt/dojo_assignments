//Require Mongoose for Database Connection
var mongoose = require('mongoose');

//CREATING A SCHEMA FOR ANIMAL TABLE
var TaskSchema = new mongoose.Schema({
    title: String,
    description: {
        type: String,
        default: '',
    },
    completed: {
        type: Boolean,
        default: false,
    }
   }, {timestamps: true});
var Mongoose = mongoose.model('Task', TaskSchema); 