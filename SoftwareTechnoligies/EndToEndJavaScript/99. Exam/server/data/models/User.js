var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

var requiredMessage = '{PATH} is required';
var defaultAvatar = 'http://assets.vg247.com/current//2014/09/halo_the_master_chief_collection_2.jpg';

module.exports.init = function () {
    var userSchema = mongoose.Schema({
        username: {
            type: String, 
            required: requiredMessage, 
            unique: true,
            match: /^[A-Za-z0-9_.]+/,
            minlength: 6,
            maxlength: 20,
        },
        salt: String,
        hashPass: String,
        firstName: { type: String, required: requiredMessage },
        lastName: { type: String, required: requiredMessage },
        email: { type: String, required: requiredMessage },
        facebook: String,
        youtube: String,
        rating: { type: Number },
        playLists: [{
                title: String,
                friends: [{
                        id: String,
                    }],
            }],
        avatar: { type: String, default: defaultAvatar },
        givenRatings: { type: Number, default: 0 },
    });
    
    // for some strange reason default did not work for avatar. So I have added the code bellow
    userSchema.pre("save", function (next) {
        if (this.avatar.length == 0) {
            this.avatar = defaultAvatar;
        }
        
        next();
    });
    
    userSchema.method({
        authenticate: function (password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            }
            else {
                return false;
            }
        }
    });
    
    var User = mongoose.model('User', userSchema);
};


