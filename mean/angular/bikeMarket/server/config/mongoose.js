var mongoose = require('mongoose');
var fs = require('fs');
var path = require('path');

//Connect to DB
mongoose.connect('mongodb://localhost/bikeMarket');
mongoose.Promise = global.Promise;

var models_path = path.join(__dirname, './../models');
fs.readdirSync(models_path).forEach(function(file) {
  if(file.indexOf('.js') >= 0) {
      console.log(`loading ${file}...`);
    require(models_path + '/' + file);
  }
});