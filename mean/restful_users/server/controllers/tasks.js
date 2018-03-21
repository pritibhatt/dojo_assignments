//Database connection
var mongoose = require("mongoose");

//pulling in the model
var Task = mongoose.model('Task')

class TasksController{
    index(req, res){
        Task.find({}, function(err, tasks){
            if(err){
               res.json({err});
            }else{
                res.json({tasks});
            }
        })
    }
    create(req, res){
        Task.create(req.body, function(err, task){
            if(err){
                res.json({err});
             }else{
                 res.json({task});
             }
         })
    }
    show(req,res){
       Task.findById( req.params.id, function(err, task){
            if(err){
               console.log('err')
               res.json({error: 'task not found'});
            }else{
                res.json({task});
            }
            
        })
       
    }
    update(req, res){
        Task.findByIdAndUpdate(req.params.id, {$set: req.body}, {new: true}, function(err, task){
            if(err){
               res.json({err} );
             }else{
                 console.log("in express", task);
               res.json({task});
             }
         })
        
    }
    destroy(req, res){
        Task.findByIdAndRemove(req.params.id, function(err, task){
            if(err){
               res.json({err});
            }else{
               res.json({'sucess': 'sucessfully deleted'});
                
            }
            
        })
    }
}



module.exports = new TasksController();


