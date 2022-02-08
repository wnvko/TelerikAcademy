var fs = require('fs'),
    data = {};

var files = fs.readdirSync(__dirname + '/types-data';

for (var i = 0, length = files.length; i < length; i += 1) {
    var typeData = require('./types-data/' + files[i]);
    data.typeData.name = typeData.data;
}

module.exports = data;
