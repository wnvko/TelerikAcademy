var mongoose = require('mongoose'),
    Schema = mongoose.Schema;

var PersonSchema = new Schema({
    name: String
});

console.log('In the schema: Person');
mongoose.model('Person', PersonSchema);