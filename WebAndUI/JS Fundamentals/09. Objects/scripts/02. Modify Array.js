Array.prototype.remove = function (element) {
    while (true) {
        var index = this.indexOf(element);
        if (index > -1) {
            this.splice(index, 1);
        } else {
            break;
        }
    }
}

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
console.log(arr);
arr.remove(1);
console.log(arr);