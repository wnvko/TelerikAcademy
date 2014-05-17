function findEmailAddresses(input) {
    var emails = [];
    var position = 0;
    var identifierStart = 0;
    var hostEnd = 0;
    var domainEnd = 0;

    while (true) {
        position = input.indexOf('@', position + 1);
        if (position < 0) {
            break;
        }
        identifierStart = input.lastIndexOf(' ', position);
        hostEnd = input.indexOf('.', position);
        domainEnd = input.indexOf(' ', hostEnd);

        var currentIdentifier = input.substring(identifierStart + 1, position);
        var currentHost = input.substring(position + 1, hostEnd);
        var currentDomain = input.substring(hostEnd + 1, domainEnd);

        emails.push(currentIdentifier);
        emails.push('@');
        emails.push(currentHost);
        emails.push('.');
        emails.push(currentDomain);
        emails.push('\n');
    }

    return emails.join('');
}

var input = 'Cursus bibendum nonummy amet nam eget. pesho@gmail.com Aptent morbi tincidunt vitae id venenatis. Viverra ut amet. Vel volutpat aenean rhoncus rhoncus sem pede pellentesque amet etiam vestibulum elit. Integer id massa. Nunc potenti non elit leo sed. At sollicitudin nostrud. Phasellus ad ac elit sodales nascetur eu vivamus dapibus. Lacus senectus sodales. Ligula luctus fermentum semper nam amet vitae HACKO@web.com feugiat vivamus. Urna iaculis consectetuer. ivan.ivanov@yahoo.co.uk Nec vulputate arcu quis vel enim etiam quisque tempor. Tincidunt erat condimentum sed pulvinar sodales. Gravida lectus aliquam. Labore hendrerit vulputate sagittis mauris risus eu neque sit quam nec scelerisque. Arcu vankata_bash-maYstor4eto@abv.bg parturient ut dui cursus interdum. Nullam nunc rhoncus ante sit lectus. Mi mi nulla phasellus vehicula class vestibulum suspendisse viverra amet laoreet hendrerit. Praesent dictum felis. Semper tincidunt integer. Erat vel donec.';

var mails = findEmailAddresses(input);

console.log(input);
console.log(mails);