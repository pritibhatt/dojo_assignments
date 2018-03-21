var express = require("express");
var bodyParser = require('body-parser');
var session = require('express-session');
var path = require("path");
let port = 8000;
var app = express();


app.use(express.static(path.join(__dirname, 'dist')));

//middlewares
app.use(bodyParser.json())


app.use(session({secret: 'codingdojorocks', resave: false, saveUninitialized: true})); 

//mongoose
require('./server/config/mongoose.js');

//routes
require('./server/config/routes.js')(app);

app.all("*", (req,res,next) => {
    res.sendFile(path.resolve("./angular/dist/index.html"))
  });

let server = app.listen(port, () => console.log(`listening on port ${port}`));



    
   

