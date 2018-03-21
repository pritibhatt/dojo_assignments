//Database connection
var mongoose = require("mongoose");

//pulling in the model
var Task = mongoose.model('Task')

class TasksController{
    index(req, res){
        Task.find({}, function(err, tasks){
            if(err){
               return res.json(err);
            }
            return res.json(tasks);
        })
    }
    create(req, res){
        Task.create(req.body, function(err, task){
            if(err){
               return res.json({err} );
            }
            return res.json(task);
        })
    }
    show(req,res){
       Task.findById( req.params.id, function(err, task){
            if(err){
               console.log('err')
                
                return res.json({error: 'task not found'});
            }
            
            return res.json(task);
        })
       
    }
    update(req, res){
        Task.findByIdAndUpdate(req.params.id, {$set: req.body}, {new: true}, function(err, task){
            if(err){
                return res.json({err} );
             }
             return res.json(task);
         })
        
    }
    destroy(req, res){
        Task.findByIdAndRemove(req.params.id, function(err, task){
            if(err){
                return res.json(err);
            }
            return res.json({'sucess': 'sucessfully deleted'});
            
        })
    }
}



module.exports = new TasksController();


