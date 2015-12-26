var http = require('http'),
    fs = require('fs'),
    formidable = require('formidable'),
    util = require('util');

var PORT = '1234',
    // this project was build under VS 2015. For some reason next line works under when started under Command Prompt
    INDEX_HTML = '../client/index.html',
    // and next line is working when you start it under VS 2015
    //INDEX_HTML = './client/index.html',
    UPLOAD_FOLDER = './downloads';

http.createServer(myServerListener).listen(PORT);

function myServerListener(req, res) {
    if (req.url === '/') {
        fs.readFile(INDEX_HTML, loadMainPage);
    }
    else if (req.url === '/upload' && req.method.toLowerCase() === 'post') {
        uploadFiles();
    }
    else if (req.url.indexOf('downloads') > -1 && req.method.toLowerCase() === 'get') {
        fs.readFile('./' + req.url, downloadFiles);
    }
    
    
    function loadMainPage(err, data) {
        if (err) {
            res.writeHead(404, {
                'Content-Type' : 'text/html'
            });
            res.write(http.STATUS_CODES[404]);
            res.end();
        }
        else {
            res.writeHead(200, {
                'Content-Type' : 'text/html'
            });
            
            res.write(data);
            res.end();
        }
    }
    
    function uploadFiles() {
        if (!fs.existsSync(UPLOAD_FOLDER)) {
            fs.mkdirSync(UPLOAD_FOLDER)
        }
        
        var form = new formidable.IncomingForm();
        form.uploadDir = UPLOAD_FOLDER;
        form.keepExtensions = true;
        form.multiples = false;
        form.type = 'multipart';
        form.encoding = 'utf-8';
        
        form.on('error', function (err) {
            res.writeHead(404, {
                'Content-Type' : 'text/html'
            });
            res.write(http.STATUS_CODES[404]);
            res.end();
        });
        
        var fileNames = [],
            filePaths = [];
        
        form.on('file', function (name, file) {
            fileNames.push(file.name);
            filePaths.push(file.path);
        });
        
        form.parse(req, function (err, fields, files) {
            res.writeHead(200, {
                'Content-Type' : 'text/html'
            });
            res.write('Received upload:</br>');
            
            var length = fileNames.length;
            for (var index = 0; index < length; index++) {
                res.write('<div><a href="http://localhost:' + PORT + '\\' + filePaths[index] + '">' + fileNames[index] + '</a></div>');
            };
            
            res.end();
        });
    }
    
    function downloadFiles(err, data) {
        if (err) {
            res.writeHead(404, {
                'Content-Type' : 'text/html'
            });
            
            res.write(http.STATUS_CODES[404]);
            res.end();
        } else {
            res.writeHead(200, {
                'Content-Type' : 'application/octet-stream'
            });
            
            res.write(data);
            res.end();
        }
    }
}

console.log("Server started and listening on port " + PORT);