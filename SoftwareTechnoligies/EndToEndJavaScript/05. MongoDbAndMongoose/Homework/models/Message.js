var mongoose = require('mongoose'),
    userSchema = mongoose.model('User').schema,
    user = mongoose.model('User');

module.exports.init = function () {
    var messageSchema = new mongoose.Schema({
        from: userSchema,
        to: userSchema,
        text: String
    });
    
    messageSchema.statics.sendMessage = function (message) {
        if (!(message && message.from && message.to && message.text)) {
            console.log('Message is not correctly defined. Should have to, from and text');
        }
        
        var sender = findUserByName(message.to),
            receiver= findUserByName(message.from);
        
        var newMessage = new Message();
        newMessage.from = sender;
        newMessage.to = receiver;
        newMessage.text = message.text;
        newMessage.save(function (err, data) {
            if (err) {
                console.log(err);
            } else {
                return data;  
            }
        });
    }
    
    messageSchema.statics.getMessages = function (query, cb){
        var sender = findUserByName(query.with),
            receiver = findUserByName(query.and);

        Message
            .find()
            .where('from').equals(sender)
            .where('to').equals(receiver)
            .exec(cb);
    }
    
    var Message = mongoose.model('Message', messageSchema);
    console.log('Message initialized...');
}

function findUserByName(name) {
    user.findOne({ name: name }, function (err, data) {
        if (err) {
            console.log(err);
        } else {
            return data;
        }
    });
}