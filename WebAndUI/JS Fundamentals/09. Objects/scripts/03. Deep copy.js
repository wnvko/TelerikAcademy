function deepCopy(element) {

    if (typeof(element) !== 'object') {
        return element;
    }

    var clone = {};
    var propertyName = '';
    var propertyValue = '';

    for (var property in element) {
        propertyName = property;

        if (typeof (element[property]) === 'object') {
            propertyValue = deepCopy(element[property]);
        }

        propertyValue = element[property];
        clone[propertyName] = propertyValue;
    }

    return clone;
}

myObject = {
    name: {
        fName: 'Pesho',
        lName: 'Petrov'
    },
    age: 23,
    other: 'non'
}

myClone = deepCopy(myObject);
myClone.age = 32;

console.log(myObject);
console.log(myClone);

console.log(myObject.name);
console.log(myClone.name);

myInt = 23;
cloneInt = deepCopy(myInt);

console.log(myInt);
console.log(cloneInt);