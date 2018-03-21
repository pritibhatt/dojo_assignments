//getting Model information and controller information
var User = require('../controllers/user')


//import controllers
module.exports = function(app){
        // app.get('/user', User.index);
        app.post('/register', function (req, res) {
            console.log("POST DATA", req.body);
        });
        // app.post('/login', User.login);
        
        // app.get('/authors/:id', Author.show);
        // app.put('/authors/:id', Author.update);
        // app.delete('/authors/:id', Author.destroy);
}