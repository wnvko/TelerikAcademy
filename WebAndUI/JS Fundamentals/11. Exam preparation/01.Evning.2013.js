function Solver(input) {
    var answer = 0;
    var N = ~~input[0];
    var maxEndHere = 0;
    var maxSoFar = 0;
    var maxInput = -Infinity;

    for (var i = 1; i <= N; i++) {
        maxEndHere = Math.max(0, (maxEndHere + (~~input[i])));
        maxSoFar = Math.max(maxEndHere, maxSoFar);
        maxInput = Math.max(maxInput, (~~input[i]));
    }
    if (maxInput < 0) {
        answer = maxInput;
    } else {
        answer = maxSoFar;
    }

    return answer;
}

var input = [
     '9',
    '-9',
    '-8',
    '-8',
    '-7',
    '-6',
    '-5',
    '-1',
    '-7',
    '-6',

];

Solver(input);