var PlayList = require('mongoose').model('PlayList'),
    constants = require('../common/constants');

var cache = {
    expires: undefined,
    data: undefined
};

module.exports = {
    create: function (playlist, user, callback) {
        if (constants.categories.indexOf(playlist.category) < 0) {
            callback('Invalid category!');
            return;
        }
        
        if (playlist.isPublic) {
            playlist.isPublic = true;
        } else {
            playlist.isPublic = false;
        }
        
        playlist.creator = user;
        playlist.createdOn = new Date();
        
        PlayList.create(playlist, callback);
    },
    getPlaylists: function (page, pageSize, user, callback) {
        page = page || 1;
        pageSize = pageSize || 10;
        
        if (page == 1 && cache.expires && cache.expires < new Date()) {
            callback(null, cache.data);
            return;
        }
        
        if (!user) {
            PlayList
            .find({ 'isPublic' : 'true' })
            .sort({ 'createdOn' : 'desc' })
            .limit(pageSize)
            .skip((page - 1) * pageSize)
            .exec(function (err, foundLists) {
                if (err) {
                    callback(err);
                    return;
                }
                
                PlayList.count().exec(function (err, numberOfLists) {
                    if (err) {
                        callback(err);
                        return;
                    }
                    
                    var data = {
                        lists: foundLists,
                        currentPage: page,
                        pageSize: pageSize,
                        total: numberOfLists,
                        user: user,
                    };
                    
                    cache.data = data;
                    var expires = new Date();
                    expires.setMinutes(expires.getMinutes() + 10);
                    cache.expires = expires;
                    
                    callback(err, data);
                });
            })
        } else {
            PlayList
            .find({
                $or: [{
                        'isPublic' : 'true'
                    }, {
                        'creator': user.username
                    }]
            })
            .sort({ 'createdOn' : 'desc' })
            .limit(pageSize)
            .skip((page - 1) * pageSize)
            .exec(function (err, foundLists) {
                if (err) {
                    callback(err);
                    return;
                }
                
                PlayList.count().exec(function (err, numberOfLists) {
                    if (err) {
                        callback(err);
                        return;
                    }
                    
                    var data = {
                        lists: foundLists,
                        currentPage: page,
                        pageSize: pageSize,
                        total: numberOfLists,
                        user: user,
                    };
                    
                    cache.data = data;
                    var expires = new Date();
                    expires.setMinutes(expires.getMinutes() + 10);
                    cache.expires = expires;
                    
                    callback(err, data);
                });
            })
        }
    },
    deleteList: function (id, callbak) {
        if (!id) {
            callbak("Id cannot be empty", null);
        }
        
        PlayList.remove({ '_id': id }, function (err) {
            if (err) {
                callbak(err);
            } else {
                callbak(null, true);
            }
        });
    },
    getVideosByListId: function (id, callbak) {
        if (!id) {
            callbak("Id cannot be empty", null);
        }
        
        PlayList.findOne({ '_id': id }, function (err, list) {
            if (err) {
                callbak(err);
            } else {
                callbak(null, {
                    title: list.title,
                    videos: list.videos,
                });
            }
        });
    },
    addVideoByListId: function (id, video, callback) {
        if (!id) {
            callbak("Id cannot be empty", null);
        }
        
        if (!video) {
            callbak("Video cannot be empty", null);
        }
        
        PlayList.findOne({ '_id': id }, function (err, list) {
            if (err) {
                callbak(err);
            } else {
                list.videos.push(video);
                list.save(function (err) {
                    if (err) {
                        return err;
                    }
                    
                    return {
                        title: list.title,
                        videos: list.videos,
                    }
                });
            }
        });

    },
};