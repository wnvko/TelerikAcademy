function findTheYoungestOne(persons) {
    var youngestPerson = persons[0];

    for (var i = 1, length = persons.length; i < length; i++) {
        if (persons[i].age < youngestPerson.age) {
            youngestPerson = persons[i];
        }
    }

    return youngestPerson;
}

var persons = [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'Mosho', lastname: 'Vetrov', age: 23 },
    { firstname: 'Goro', lastname: 'Peshrov', age: 45 },
    { firstname: 'Posho', lastname: 'Hetrov', age: 18 },
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
];

var youngestOne = findTheYoungestOne(persons);
console.log(youngestOne.firstname + ' ' + youngestOne.lastname);
