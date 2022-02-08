var mongoose = require('mongoose');
var Person = mongoose.model('Person');
var Promise = require('bluebird');

function save(person) {
    var promise = new Promise(function (resolve, reject) {
        var dbPerson = new Person(person);
        dbPerson.save(function (err, dbData) {
            if (err) {
                reject(err);
                return;
            }
            
            resolve(dbData);
        });
    });
    
    return promise;
}

function getById(id) {
    var promise = new Promise(function (resolve, reject) {
        Person.findById(id, function (err, person) {
            if (err) {
                reject(err);
                return
            }
            
            resolve(person);
        });
    });
    
    return promise;
}

function getAll() {
    var promise = new Promise(function (resolve, reject) {
        Person.find({}, function (err, people) {
            if (err) {
                reject(err);
                return
            }
            
            resolve(people);
        });
    });
    
    return promise;
}

module.exports = {
    name : 'people',
    data: {
        save: save,
        all: getAll,
        byId: getById
    }
};