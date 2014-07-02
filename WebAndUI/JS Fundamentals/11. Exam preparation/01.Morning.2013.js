function Solver(input) {
    var answer = 1;
    var N = ~~input[0];

    for (var i = 1; i < N; i++) {
        if ((~~input[i]) > (~~input[i+1])) {
            answer++;
        }
    }

    return answer;
}