var fs = require('fs');

fs.readdir(__dirname + '/models', function (err, files) {
    if (err) {
        throw err;
    }
    
    for (var i = 0, length = files.length; i < length; i += 1) {
        require('./models/' + files[i]);
    }
})