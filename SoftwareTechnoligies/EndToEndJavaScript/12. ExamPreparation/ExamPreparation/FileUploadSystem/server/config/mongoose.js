var mongoose = require('mongoose');

module.exports = function (config) {
    mongoose.connect(config.db);
    var db = mongoose.connection;
    
    db.once('open', function (err) {
        if (err) {
            console.log('Database could not be opend: ' + err);
            return;
        }
        
        console.log('Database is up and running...');
    });
    
    db.on('error', function (err) {
        console.log('Database error: ' + err);
    });
    
    require('../data/models/User').init();
};