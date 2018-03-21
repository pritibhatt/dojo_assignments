//Database connection
var mongoose = require("mongoose");
var path = require('path');
//pulling in the model
var Products = mongoose.model('Products')

class ProductsController{
    index(req, res){
        Products.find({}, function(err, products){
            if(err){
               res.json({err});
            }else{
                res.json({products});
            }
        })
    }
    create(req, res){
        Products.create(req.body, function(err, product){
            if(err){
                res.json({err});
             }else{
                 res.json({product});
             }
         })
    }
    show(req,res){
        Products.findById( req.params.id, function(err, product){
            if(err){
               console.log('err')
               res.json({error: 'author not found'});
            }else{
                console.log(product);
                res.json({product});
            }
            
        })
       
    }
    update(req, res){
        Products.findByIdAndUpdate(req.params.id, {$set: req.body}, {new: true}, function(err, product){
            if(err){
               res.json({err} );
             }else{
                 console.log("in express", product);
               res.json({product});
             }
         })
        
    }
    destroy(req, res){
        Products.findByIdAndRemove(req.params.id, function(err, product){
            if(err){
               res.json({err});
            }else{
               res.json({'sucess': 'sucessfully deleted'});
                
            }
            
        })
    }
}



module.exports = new ProductsController();


