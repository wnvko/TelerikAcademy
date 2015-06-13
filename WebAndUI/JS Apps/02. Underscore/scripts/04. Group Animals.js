/// <reference path="underscore.js" />
(function () {
    var Animal = Object.create({
        init: function (name, species, legsCount) {
            this.name = name;
            this.species = species;
            this.legsCount = legsCount;
            return this;
        },
        toString: function () {
            return this.name + ' has ' + this.legsCount + ' legs';
        }
    });

    var zoo = [
        Object.create(Animal).init('Cat', 'Mammal', 4),
        Object.create(Animal).init('Ant', 'Insect', 6),
        Object.create(Animal).init('Dog', 'Mammal', 4),
        Object.create(Animal).init('Octopus', 'Sea', 8),
        Object.create(Animal).init('Snake', 'Reptile', 0),
        Object.create(Animal).init('Snail', 'Reptile', 0),
        Object.create(Animal).init('Cangaroo', 'Marsupial', 2),
        Object.create(Animal).init('Human', 'Mammal', 2),
        Object.create(Animal).init('Spider', 'Insect', 8),
        Object.create(Animal).init('Mouse', 'Mammal', 4),
        Object.create(Animal).init('Bee', 'Insect', 6),
        Object.create(Animal).init('Butterfly', 'Insect', 6),
        Object.create(Animal).init('Ъentipede', 'Insect', 100),
    ];

    //console.log('All animals:');
    //_.forEach(zoo, function (animal) {
    //    console.log(animal.toString());
    //})

    //console.log('Animals by species and by legs:');
    //var bySpecies = _.groupBy(zoo, function (animal) {
    //    return animal.species;
    //});

    var sortedGroup = _
		.chain(zoo)
        .groupBy(function (animal) {
            return animal.species;
        })
        .pairs()
        .forEach(function (species) {
            _.chain(species[1])
             .sortBy(function (animal) {
                 return animal.legsCount;
             })
             .value();
            console.log(species);
        })
		.value();

    console.log(sortedGroup);
}());