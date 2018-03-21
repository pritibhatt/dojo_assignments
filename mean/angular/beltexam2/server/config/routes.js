//getting Model information and controller information
var Products = require('../controllers/products')
var path = require('path');

//import controllers
module.exports = function(app){
        app.get('/products', Products.index);
        app.post('/products', Products.create);
        app.get('/products/:id', Products.show);
        app.put('/products/:id', Products.update);
        app.delete('/products/:id', Products.destroy);
}