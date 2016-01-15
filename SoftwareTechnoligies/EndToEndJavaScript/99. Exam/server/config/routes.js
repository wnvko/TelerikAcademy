var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function (app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);
    
    app.get('/profile', auth.isAuthenticated, controllers.users.getProfile);
    
    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    
    app.get('/logout', auth.logout);
    
    app.get('/playlist/create', auth.isAuthenticated, controllers.playlists.getCreate);
    app.post('/playlist/create', auth.isAuthenticated, controllers.playlists.postCreate);
    
    app.get('/playlist/edit', auth.isAuthenticated, controllers.playlists.getVideosByListId);
    app.post('/playlist/edit', auth.isAuthenticated, controllers.playlists.postVideoByListId);
    
    app.get('/playlist/delete', auth.isAuthenticated, controllers.playlists.deleteList);

    app.get('/playlist/list', controllers.playlists.getList);
    
    app.get('/', controllers.playlists.getList);
    
    app.get('*', function (req, res) {
        res.redirect('/');
    });
};