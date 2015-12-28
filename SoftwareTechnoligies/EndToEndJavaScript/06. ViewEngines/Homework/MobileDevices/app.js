var http = require('http'),
    fs = require('fs'),
    jade = require('jade'),
    path = require('path'),
    common = require('./common/common.js');

var PORT = 1234,
    MAIN_PAGE_JADE_PATH = './templates/main.jade',
    PHONES_PAGE_JADE_PATH = './templates/phones.jade',
    TABLETS_PAGE_JADE_PATH = './templates/tablets.jade',
    WEARABLE_PAGE_JADE_PATH = './templates/wearables.jade';

http.createServer(myServerListener).listen(PORT);

function myServerListener(req, res) {
    if (req.url === '/' || req.url === '/home') {
        parseHtml(MAIN_PAGE_JADE_PATH, common.mainModel, res, loadPage);
    } else if (req.url === '/phones') {
        parseHtml(PHONES_PAGE_JADE_PATH, common.phonesModel, res, loadPage);
    } else if (req.url === '/tablets') {
        parseHtml(TABLETS_PAGE_JADE_PATH, common.tabletsModel, res, loadPage);
    } else if (req.url === '/wearables') {
        parseHtml(WEARABLE_PAGE_JADE_PATH, common.wearablesModel, res, loadPage);
    }
}

function parseHtml(templateFilePath, model, res, cb) {
    fs.readFile(templateFilePath, 'utf-8', function (err, data) {
        if (err) {
            console.log(err);
            return null;
        }
        
        cb(jade.compile(data, {
            pretty: true,
            filename : path.join(__dirname, templateFilePath)
        }), model, res);
    });
}

function loadPage(result, model, res) {
    var mainHtml = result(model);
    if (!mainHtml) {
        res.writeHead(404, {
            'Content-Type' : 'text/html'
        });
        res.write(http.STATUS_CODES[404]);
        res.end();
    } else {
        res.writeHead(200, {
            'Content-Type' : 'text/html'
        });
        
        res.write(mainHtml);
        res.end();
    }
}
