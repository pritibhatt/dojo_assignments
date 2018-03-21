//Database connection
var mongoose = require("mongoose");

//pulling in the model
var Product = mongoose.model('Product')

class ProductController{
    index(req, res){
        Product.find({}, function(err, products){
            if(err){
               res.json({err});
            }else{
                res.json({products});
            }
        })
    }
    create(req, res){
        Product.create(req.body, function(err, product){
            if(err){
                res.json({err});
             }else{
                 res.json({product});
             }
         })
    }
    show(req,res){
        Product.findById( req.params.id, function(err, product){
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
        Product.findByIdAndUpdate(req.params.id, {$set: req.body}, {new: true}, function(err, product){
            if(err){
               res.json({err} );
             }else{
                 console.log("in express", product);
               res.json({product});
             }
         })
        
    }
    destroy(req, res){
        Product.findByIdAndRemove(req.params.id, function(err, product){
            if(err){
               res.json({err});
            }else{
               res.json({'sucess': 'sucessfully deleted'});
                
            }
            
        })
    }
}



module.exports = new ProductController();


