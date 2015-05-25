function group(persons, property) {
    function compare(a, b) {
        if (isNaN(a[property])) {
            if (a[property] < b[property]) {
                return -1;
            } else {
                return 1;
            }
        } else {
            return a[property] - b[property];
        }
    }

    persons.sort(compare);
}

var persons = [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'Mosho', lastname: 'Vetrov', age: 23 },
    { firstname: 'Goro', lastname: 'Peshrov', age: 45 },
    { firstname: 'Posho', lastname: 'Hetrov', age: 18 },
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
];

for (var i = 0, length = persons.length; i < length; i++) {
    console.log(persons[i].firstname + ' ' + persons[i].lastname + ' ' + persons[i].age);
}

console.log('By age:')
group(persons, 'age');
for (var i = 0, length = persons.length; i < length; i++) {
    console.log(persons[i].firstname + ' ' + persons[i].lastname + ' ' + persons[i].age);
}

console.log('By first name:')
group(persons, 'firstname');
for (var i = 0, length = persons.length; i < length; i++) {
    console.log(persons[i].firstname + ' ' + persons[i].lastname + ' ' + persons[i].age);
}
