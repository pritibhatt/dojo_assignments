//Getting Model information and controller information
var User = require('../controllers/user')
var path = require('path');
module.exports = function(app) {
    app.get('/user', User.index);
    app.post('/register', User.create);
    app.post('/login', User.login);
    // app.get('/authors/:id', Author.show);
    // app.put('/authors/:id', Author.update);
    // app.delete('/authors/:id', Author.destroy);
    

}