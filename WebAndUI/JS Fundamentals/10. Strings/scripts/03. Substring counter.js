function substringCounter(input, lookup) {
    var count = input.toLowerCase().split(lookup).length - 1;
    return count;
}

var testString = "The result is: 9. We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
var lookUpString = 'in';

var count = substringCounter(testString, lookUpString);

console.log(testString);
console.log(lookUpString + ' meets ' + count + ' times.');