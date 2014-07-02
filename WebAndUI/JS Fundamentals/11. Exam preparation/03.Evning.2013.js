function Solve(input) {
    var answer = 0;
    var expression = '';
    var variables = [];
    var currentVariable = '';

    for (var row = 0, length = input.length; row < length; row++) {
        var innerExpressionValue = 0;
        var isExpression = false;
        var isCalculatingVariable = false;
        expression = input[row].split(' ').filter(function (n) { return n !== '' }).join(' ');

        for (var index = 0; index < expression.length; index++) {

            //check if def is on
            if (index === 0 && expression.substring(index, 4) === 'def ') {
                index = expression.indexOf(' ') + 1;
                isExpression = true;
            }

            //log variables names
            if (isExpression) {
                var variableEndAt = expression.indexOf(' ', index);
                currentVariable = expression.substring(index, variableEndAt);
                index = variableEndAt;
                isExpression = false;
                isCalculatingVariable = true;
            } else {
                // calculate inner expression
                if (expression[index] === '[') {

                    var innerArray = innerValue(expression, index).split(', ');
                    if (isCalculatingVariable) {
                        innerExpressionValue = [];
                        for (var i = 0; i < innerArray.length; i++) {
                            innerExpressionValue.push(innerArray[i] | 0);
                        }
                        break;
                    }

                    if (isNaN(innerArray[0])) {
                        innerExpressionValue = variables[innerArray[0]] | 0;

                    } else {
                        innerExpressionValue = parseInt(innerArray[0]);
                    }

                    break;
                } else {
                    innerExpressionValue = calculate(expression, index);
                    break;
                }
            }
        }
        if (isCalculatingVariable) {
            variables[currentVariable] = innerExpressionValue;
            isCalculatingVariable = false;
        } else {
            answer = innerExpressionValue;
        }
    }

    return answer;

    function calculate(expression, index) {
        var innerArray = innerValue(expression, index).split(', ');
        if (expression.substring(index, index + 3) === 'sum') {
            var result = 0;
            for (var i = 0; i < innerArray.length; i++) {
                if (isNaN(innerArray[i])) {
                    if (typeof(variables[innerArray[i]]) !== 'number') {
                        result += (variables[innerArray[i]].reduce(function (pv, cv) { return (pv | 0) + (cv | 0); }, 0)) | 0;
                    } else {
                        result += variables[innerArray[i]];
                    }
                } else {
                    result += parseInt(innerArray[i]);
                }
            }

            return result | 0;
        } else if (expression.substring(index, index + 3) === 'min') {
            var result = +Infinity;
            for (var i = 0; i < innerArray.length; i++) {
                if (isNaN(innerArray[i])) {
                    if (isNaN(variables[innerArray[i]])) {
                        if (Math.min.apply(Math, variables[innerArray[i]]) < result) {
                            result = Math.min.apply(Math, variables[innerArray[i]]);
                        }
                    } else {
                        if (variables[innerArray[i]] < result) {
                            result = variables[innerArray[i]];
                        }
                    }
                } else {
                    if (parseInt(innerArray[i]) < result) {
                        result = parseInt(innerArray[i]);
                    }
                }
            }

            return result | 0;
        } else if (expression.substring(index, index + 3) === 'max') {
            var result = -Infinity;
            for (var i = 0; i < innerArray.length; i++) {
                if (isNaN(innerArray[i])) {
                    if (isNaN(variables[innerArray[i]])) {
                        if (Math.max.apply(Math, variables[innerArray[i]]) > result) {
                            result = Math.max.apply(Math, variables[innerArray[i]]);
                        }
                    } else {
                        if (variables[innerArray[i]] > result) {
                            result = variables[innerArray[i]];
                        }
                    }
                } else {
                    if (parseInt(innerArray[i]) > result) {
                        result = parseInt(innerArray[i]);
                    }
                }
            }

            return result | 0;
        } else if (expression.substring(index, index + 3) === 'avg') {
            var result = 0;
            for (var i = 0; i < innerArray.length; i++) {
                if (isNaN(innerArray[i])) {
                    if (isNaN(variables[innerArray[i]])) {
                        result += (variables[innerArray[i]].reduce(function (pv, cv) { return (pv | 0) + (cv | 0); }, 0)) | 0;
                    } else {
                        result += variables[innerArray[i]];
                    }
                } else {
                    result += parseInt(innerArray[i]);
                }
            }

            result = (result / innerArray.length) | 0;
            return result | 0;
        }
    }

    function innerValue(expression, index) {
        var start = expression.indexOf('[', index) + 1;
        var end = expression.indexOf(']', start);
        var toCalculate = expression.substring(start, end);
        return toCalculate;
    }
}

input = [
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]',
];

Solve(input);