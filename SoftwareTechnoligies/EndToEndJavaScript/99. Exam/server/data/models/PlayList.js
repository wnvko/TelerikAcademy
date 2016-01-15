var mongoose = require('mongoose');

var requiredMessage = '{PATH} is required';

module.exports.init = function () {
    var playlistSchema = mongoose.Schema({
        title: { type: String, required: requiredMessage },
        description: { type: String, required: requiredMessage },
        createdOn: { type: Date, required: requiredMessage },
        creator: { type: String, required: requiredMessage },
        category: { type: String, required: requiredMessage },
        videos: [{
                name: String,
                link: String,
            }],
        rating: { type: Number, min: 1, max: 5 },
        votes: { type: Number, default: 0 },
        isPublic: { type: Boolean, default: false },
    });
    
    var PlayList = mongoose.model('PlayList', playlistSchema);
};


