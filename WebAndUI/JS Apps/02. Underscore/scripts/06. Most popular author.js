/// <reference path="underscore.js" />
(function () {
    var Book = Object.create({
        init: function (name, author) {
            this.name = name;
            this.author = author;
            return this;
        },
        toString: function () {
            return this.name + ' by ' + this.author;
        }
    });

    var library = [
        Object.create(Book).init("The Hitchhiker's Guide to the Galaxy", 'Douglas Adams'),
        Object.create(Book).init('1984', 'George Orwell'),
        Object.create(Book).init('Wyrd Sisters', 'Terry Pratchett'),
        Object.create(Book).init('Pyramids', 'Terry Pratchett'),
        Object.create(Book).init('So Long, and Thanks for All the Fish', 'Douglas Adams'),
        Object.create(Book).init('The Colour of Magic', 'Terry Pratchett'),
        Object.create(Book).init('The Light Fantastic', 'Terry Pratchett'),
        Object.create(Book).init('Equal Rites', 'Terry Pratchett'),
        Object.create(Book).init('Life, the Universe and Everything', 'Douglas Adams'),
        Object.create(Book).init('Mort', 'Terry Pratchett'),
        Object.create(Book).init('The Restaurant at the End of the Universe', 'Douglas Adams'),
        Object.create(Book).init('Animal Farm', 'George Orwell'),
        Object.create(Book).init('Sourcery', 'Terry Pratchett'),
    ];

    console.log('All Books:');
    _.forEach(library, function (book) {
        console.log(book.toString());
    })

    var withChain = _.chain(library)
                     .countBy(function (book) {
                         return book.author;
                     })
                     .pairs()
                     .max(function (author) {
                         return author[1];
                     })
                     .value();
    console.log(withChain);

    var theMostPopular = _.max(_.pairs(_.countBy(library, function (book) {
        return book.author;
    })), function (author) {
        return author[1];
    });
    console.log(theMostPopular);
}());