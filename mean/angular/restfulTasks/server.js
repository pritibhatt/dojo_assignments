var express = require("express");
var bodyParser = require('body-parser');
var port = 8000;
var app = express();
app.use(express.static(__dirname + '/restfulTasks/dist'));

//middleware
app.use(bodyParser.json())

// mongoose file
require('./server/config/mongoose.js');

// routes
require('./server/config/routes.js')(app);



let server = app.listen(port, () => console.log(`listening on port ${port}`));