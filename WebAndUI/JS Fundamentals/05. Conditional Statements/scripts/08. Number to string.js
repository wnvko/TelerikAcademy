var inputDigit;

function setTextBoxOnFocus() {
    var textBox = document.getElementById('tb-number');
    textBox.focus();
    textBox.select();
}

setTextBoxOnFocus();

function takeValue() {
    inputDigit = document.getElementById('tb-number').value;
    sayNumber();
    setTextBoxOnFocus();
}

function takeValueOnEnter(e) {
    if (e.keyCode == 13) {
        takeValue();
    }
}

//this is direct copy from my programm from C# part 1, 5th homework, problem 11 
function sayNumber() {
    inputDigit = parseInt(inputDigit);
    if (inputDigit > 999 || inputDigit < 0) {
        inputDigit = -1; //will write an error in the output
    }

    var userNumber100 = parseInt(inputDigit / 100);
    var userNumber10 = parseInt((inputDigit - 100 * userNumber100) / 10);
    var userNumber1 = parseInt(inputDigit - userNumber100 * 100 - userNumber10 * 10);
    var sayUserNumber100 = "";
    var sayUserNumber10 = "";
    var sayUserNumber1 = "";

    //set the hundreds of the number
    switch (userNumber100) {
        case 0: sayUserNumber100 = ""; break;
        case 1: sayUserNumber100 = "one hundred"; break;
        case 2: sayUserNumber100 = "two hundreds"; break;
        case 3: sayUserNumber100 = "three hundreds"; break;
        case 4: sayUserNumber100 = "four hundreds"; break;
        case 5: sayUserNumber100 = "five hundreds"; break;
        case 6: sayUserNumber100 = "six hundreds"; break;
        case 7: sayUserNumber100 = "seven hundreds"; break;
        case 8: sayUserNumber100 = "eight hundreds"; break;
        case 9: sayUserNumber100 = "nine hundreds"; break;
        default: break;
    }

    //set the tens of the number
    switch (userNumber10) {
        case 0: sayUserNumber10 = ""; break;
        case 1:            {
                switch (userNumber1) {
                    case 0: sayUserNumber10 = "ten"; break;
                    case 1: sayUserNumber10 = "eleven"; break;
                    case 2: sayUserNumber10 = "twelve"; break;
                    case 3: sayUserNumber10 = "thirteen"; break;
                    case 4: sayUserNumber10 = "fourteen"; break;
                    case 5: sayUserNumber10 = "fifteen"; break;
                    case 6: sayUserNumber10 = "sixteen"; break;
                    case 7: sayUserNumber10 = "seventeen"; break;
                    case 8: sayUserNumber10 = "eighteen"; break;
                    case 9: sayUserNumber10 = "nineteen"; break;
                    default: break;
                }
            } break;
        case 2: sayUserNumber10 = "twenty"; break;
        case 3: sayUserNumber10 = "thirty"; break;
        case 4: sayUserNumber10 = "fourty"; break;
        case 5: sayUserNumber10 = "fifty"; break;
        case 6: sayUserNumber10 = "sixty"; break;
        case 7: sayUserNumber10 = "seventy"; break;
        case 8: sayUserNumber10 = "eighty"; break;
        case 9: sayUserNumber10 = "ninety"; break;
        default: break;
    }

    //set the ones of the number
    switch (userNumber1) {
        case 0: sayUserNumber1 = "zero"; break;
        case 1: sayUserNumber1 = "one"; break;
        case 2: sayUserNumber1 = "two"; break;
        case 3: sayUserNumber1 = "three"; break;
        case 4: sayUserNumber1 = "four"; break;
        case 5: sayUserNumber1 = "five"; break;
        case 6: sayUserNumber1 = "six"; break;
        case 7: sayUserNumber1 = "seven"; break;
        case 8: sayUserNumber1 = "eight"; break;
        case 9: sayUserNumber1 = "nine"; break;
        default: break;
    }

    //check if tens are from 10 to 19
    if (userNumber10 == 1) {
        userNumber1 = 0;
    }

    if (userNumber100 > 0) {
        if (userNumber10 > 0) {
            if (userNumber1 > 0) {
                jsConsole.writeLine("Say: " + sayUserNumber100 + " and " + sayUserNumber10 + "-" + sayUserNumber1);
            } else {
                jsConsole.writeLine("Say: " + sayUserNumber100 + " and " + sayUserNumber10);
            }
        } else {
            if (userNumber1 > 0) {
                jsConsole.writeLine("Say: " + sayUserNumber100 + " and " + sayUserNumber1);
            } else {
                jsConsole.writeLine("Say: " + sayUserNumber100);
            }
        }
    } else {
        if (userNumber10 > 0) {
            if (userNumber1 > 0) {
                jsConsole.writeLine("Say: " + sayUserNumber10 + "-" + sayUserNumber1);
            } else {
                jsConsole.writeLine("Say: " + sayUserNumber10);
            }
        } else {
            if (userNumber1 >= 0) {
                jsConsole.writeLine("Say: " + sayUserNumber1);
            } else {
                jsConsole.writeLine("Your number is not from 0 to 999");
            }
        }
    }
}