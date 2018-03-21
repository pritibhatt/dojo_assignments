//getting Model information and controller information
var Product = require('../controllers/product')


//import controllers
module.exports = function(app){
        app.get('/products', Product.index);
        app.post('/products', Product.create);
        app.get('/products/:id', Product.show);
        app.put('/products/:id', Product.update);
        app.delete('/products/:id', Product.destroy);
}