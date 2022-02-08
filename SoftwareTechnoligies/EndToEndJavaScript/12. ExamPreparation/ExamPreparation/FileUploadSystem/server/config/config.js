var path = require('path');
var roothPath = path.normalize(__dirname + '/../../');

module.exports = {
    development: {
        roothPath: roothPath,
        db: 'mongodb://localhost:27017/fileuploadsystem',
        port: process.env.PORT || 3000
    }
};