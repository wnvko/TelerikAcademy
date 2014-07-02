var textColor = document.getElementById("font-color");

textColor.addEventListener('change', function () {
    var color = textColor.value;
    var textBox = document.getElementById("text");
    textBox.style.color = color;
})

var backgroundColor = document.getElementById("background-color");

backgroundColor.addEventListener('change', function () {
    var color = backgroundColor.value;
    var textBox = document.getElementById("text");
    textBox.style.backgroundColor = color;
})