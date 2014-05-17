function reverseString(input) {
    var output = input.split('').reverse().join('');
    return output;
}

str = 'Do you know Pesho?';
console.log(str);

reversed = reverseString(str);
console.log(reversed);