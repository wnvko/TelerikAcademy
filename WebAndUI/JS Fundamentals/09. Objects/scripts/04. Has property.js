function hasProperty(obj, propertyToCheck) {
    var hasThisProperty = false;

    if (obj.hasOwnProperty(propertyToCheck)) {
        hasThisProperty = true;
    }

    return hasThisProperty;
}

myObject = {
    name: {
        fName: 'Pesho',
        lName: 'Petrov'
    },
    age: 23,
    other: 'non'
}

console.log(hasProperty(myObject, 'age'));
console.log(hasProperty(myObject, 'foo'));
