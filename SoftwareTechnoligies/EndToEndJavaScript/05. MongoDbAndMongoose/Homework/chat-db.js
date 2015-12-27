var mongoose = require('mongoose'),
    User,
    Message;

function init(conection) {
    mongoose.connect(conection);
    var db = mongoose.connection;
    require('./models/User').init();
    require('./models/Message').init();
    
    User = mongoose.model('User');
    Message = mongoose.model('Message');
    
    db.once('open', function (err) {
        if (err) {
            console.log(err);
        } else {
            console.log('Database is up and running...');
        }
    });
    
    db.on('error', function (err) {
        console.log(err);
    });
}

function registerUser(user) {
    User.registerUser(user);
}

function sendMessage(message) {
    Message.sendMessage(message);
}

function getMessages(query, cb) {
    Message.getMessages(query, cb);
}

module.exports = {
    init: init,
    registerUser: registerUser,
    sendMessage: sendMessage,
    getMessages: getMessages
}