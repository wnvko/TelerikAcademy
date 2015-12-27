var mongoose = require('mongoose');

module.exports.init = function () {
    var userSchema = new mongoose.Schema({
        username: { type : String },//, required: true },
        password: { type : String }//, required: true }
    });
    
    userSchema.statics.registerUser = function (user) {
        if (!(user && user.name && user.pass)) {
            console.log('User is not correctly defined. Should have name and pass');
        }
        
        var newUser = new User(user);
        newUser.name = user.name;
        newUser.pass = user.pass;
        newUser.save(function (err, addedUser) {
            if (err) {
                console.log(err);
            } else {
                return addedUser;
            }
        });
    }

    var User = mongoose.model('User', userSchema);
    console.log('User initialized...');
}