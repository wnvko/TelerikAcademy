function findPalindromes(input) {
    var palindromes = [];
    var words = input.split(' ');

    for (var word in words) {
        var len = words[word].length;
        var isPalindrom = true;
        for (var i = 0; i < len / 2; i++) {
            if (words[word][i] !== words[word][len - i - 1]) {
                isPalindrom = false;
                break;
            }
        }

        if (isPalindrom) {
            palindromes.push(words[word]);
        }
    }

    return palindromes.join(' ');
}

var input = 'Cursus bibendum nonummy amet nam eget. level Aptent morbi tincidunt vitae id venenatis. Viverra ut amet. Vel volutpat aenean rhoncus rhoncus sem pede pellentesque amet etiam vestibulum elit. Integer id massa. Nunc potenti non elit leo sed. At sollicitudin nostrud. Phasellus ad ac elit sodales nascetur eu vivamus dapibus. Lacus senectus sodales. Ligula luctus fermentum semper nam amet vitae radar feugiat vivamus. Urna iaculis consectetuer. reviver Nec vulputate arcu quis vel enim etiam quisque tempor. Tincidunt erat condimentum sed pulvinar sodales. Gravida lectus aliquam. Labore hendrerit vulputate sagittis mauris risus eu neque sit quam nec scelerisque. Arcu racecar parturient ut dui cursus interdum. Nullam nunc rhoncus ante sit lectus. Mi mi nulla phasellus vehicula class vestibulum suspendisse viverra amet laoreet hendrerit. Praesent dictum felis. Semper tincidunt integer. Erat vel donec.';

var palindromes = findPalindromes(input);

console.log(input);
console.log(palindromes);