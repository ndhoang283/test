function errorHandler ( err, req, res, next) {
    if(err.name === 'UnauthorizedError') {  //authorized error
       return res.status(401).json({message: "The user is not authorized"})
    }
    if(err.name === 'ValidationError'){      //validation error
        return res.status(400).json({message: err})
    }

    return res.status(500).json(err);   // default server error
}

module.exports = errorHandler;