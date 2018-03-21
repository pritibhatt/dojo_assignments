//getting Model information and controller information
var Author = require('../controllers/author')


//import controllers
module.exports = function(app){
        app.get('/authors', Author.index);
        app.post('/authors', Author.create);
        app.get('/authors/:id', Author.show);
        app.put('/authors/:id', Author.update);
        app.delete('/authors/:id', Author.destroy);
}