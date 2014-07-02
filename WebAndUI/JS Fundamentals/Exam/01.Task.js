function Solve(input) {
    var answer = 0;
    var amount = parseInt(input[0]);
    var C1 = parseInt(input[1]);
    var C2 = parseInt(input[2]);
    var C3 = parseInt(input[3]);
    var C1remain = 0;
    var C2remain = 0;
    var C3remain = 0;
    var minRemain = 1;

    while (amount >= 0) {
        

        if (C1 <= amount) {
            C1remain = amount % C1;
        } else {
            C1remain = 8000;
        }

        if (C2 <= amount) {
            C2remain = amount % C2;
        } else {
            C2remain = 8000;
        }

        if (C3 <= amount) {
            C3remain = amount % C3;
        } else {
            C3remain = 8000;
        }

        var minRemain = Math.min(C1remain, C2remain, C3remain)
        if (minRemain === 8000) {
            break;
        }

        if (C1remain === minRemain) {
            answer += C1;
            amount -= C1;
        }

        if (C2remain === minRemain) {
            answer += C2;
            amount -= C2;
        }

        if (C3remain === minRemain) {
            answer += C3;
            amount -= C3;
        }
    }

    return answer;
}

input = [
    '110',
    '19',
    '29',
    '39'
];

console.log(Solve(input));