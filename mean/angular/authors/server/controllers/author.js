//Database connection
var mongoose = require("mongoose");

//pulling in the model
var Author = mongoose.model('Author')

class AuthorController{
    index(req, res){
        Author.find({}, function(err, authors){
            if(err){
               res.json({err});
            }else{
                res.json({authors});
            }
        })
    }
    create(req, res){
        Author.create(req.body, function(err, author){
            if(err){
                res.json({err});
             }else{
                 res.json({author});
             }
         })
    }
    show(req,res){
       Author.findById( req.params.id, function(err, author){
            if(err){
               console.log('err')
               res.json({error: 'author not found'});
            }else{
                console.log(author);
                res.json({author});
            }
            
        })
       
    }
    update(req, res){
        Author.findByIdAndUpdate(req.params.id, {$set: req.body}, {new: true}, function(err, author){
            if(err){
               res.json({err} );
             }else{
                 console.log("in express", author);
               res.json({author});
             }
         })
        
    }
    destroy(req, res){
        Author.findByIdAndRemove(req.params.id, function(err, author){
            if(err){
               res.json({err});
            }else{
               res.json({'sucess': 'sucessfully deleted'});
                
            }
            
        })
    }
}



module.exports = new AuthorController();


