var mongoose = require('mongoose');
var fs = require('fs');
var path = require('path');
//connect to database
mongoose.connect('mongodb://localhost/login_reg_2');
mongoose.Promise = global.Promise;


var models_path = __dirname + '/../models';

fs.readdirSync(models_path).forEach(function (file) {
    if (file.indexOf('.js') >= 0) {
        // require the file (this runs the model file which registers the schema)
      console.log(`loading ${file}...`);     
      require(models_path + '/' + file);
    }
})