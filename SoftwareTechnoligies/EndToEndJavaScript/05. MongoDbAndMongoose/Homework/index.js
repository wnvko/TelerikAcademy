var chatDb = require('./chat-db.js'),
    pesho,
    gosho,
    connection = 'mongodb://localhost:27017/chat-system';

chatDb.init(connection);
var peshoUser = {
    name: 'Pesho',
    pass: 'Str0ng_0ne'
}

chatDb.registerUser(peshoUser);

var goshoUser = {
    name: 'Gosho',
    pass: 'qkata_parola'
}

chatDb.registerUser(goshoUser);

var message = {
    from: 'Pesho',
    to: 'Gosho',
    text: 'Was uppppppp!!!'
}

chatDb.sendMessage(message);

var query = {
    with: 'Pesho',
    and: 'Gosho'
};

chatDb.getMessages(query, function (data) { 
    console.log(data);
});