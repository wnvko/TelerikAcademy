var playlists = require('../data/playlists'),
    constants = require('../common/constants');

var CONTROLLER_NAME = 'playlist';

module.exports = {
    getCreate: function (req, res) {
        
        res.render(CONTROLLER_NAME + '/create', {
            categories: constants.categories,
        });
    },
    getList : function (req, res) {
        var page = parseInt(req.query.page);
        var pageSize = parseInt(req.query.pageSize);
        
        playlists.getPlaylists(page, pageSize, req.user, function (err, data) {
            if (err) {
                console.log(err);
                return;
            }
            
            res.render(CONTROLLER_NAME + '/list', {
                data: data
            })
        })
    },
    postCreate: function (req, res) {
        var playlist = req.body;
        
        var user = req.user;
        playlists.create(
            playlist,
            user.username,
            function (err, playlist) {
                if (err) {
                    var data = {
                        categories: constants.categories,
                        errorMessage: err
                    };
                    res.render(CONTROLLER_NAME + '/create', data);
                }
                else {
                    res.redirect('/playlists/details/' + playlist._id);
                }
            })
    },
    deleteList: function (req, res) {
        var listId = req.query.id;
        playlists.deleteList(listId, function (err, erased) {
            if (err) {
                console.log('Something bad happened! This list should be still there!');
            }
            
            res.redirect('/');
        });
    },
    getVideosByListId : function (req, res) {
        var listId = req.query.id;
        if (!listId) {
            console.log('Something bad happened! This list should be still there!');
            return;
        }
        
        playlists.getVideosByListId(listId, function (err, data) {
            if (err) {
                console.log('Something bad happened! This list should be still there!');
            }
            
            res.render(CONTROLLER_NAME + '/videos', {
                data: data,
            });
        });
    },
    postVideoByListId : function (req, res) {
        var listId = req.query.id;
        if (!listId) {
            console.log('Something bad happened! This list should be still there!');
            return;
        }
        
        var video = req.body;

        playlists.addVideoByListId(listId, video, function (err, data) {
            if (err) {
                console.log('Something bad happened! This list should be still there!');
            }
            
            res.render(CONTROLLER_NAME + '/videos', {
                data: data,
            });
        });
    }
};