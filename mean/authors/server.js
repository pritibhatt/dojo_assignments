var express = require("express");
var bodyParser = require('body-parser');
var path = require('path');
var port = 8000;
var app = express();

app.use(express.static( __dirname + '/angular/dist' ));
//middleware
app.use(bodyParser.json())
 

// mongoose file
require('./server/config/mongoose.js');

// routes
require('./server/config/routes.js')(app);

app.all("*", (req,res,next) => {
    res.sendFile(path.resolve("./anular/dist/index.html"))
  });



let server = app.listen(port, () => console.log(`listening on port ${port}`));