function alertContent(input) {
    var inputID = input.id;
    var labels = document.getElementsByTagName('label');
    var labelText;

    for (var i = 0, length = labels.length; i < length; i++) {
        if (labels[i].getAttribute('for') === inputID) {
            labelText = labels[i].innerText;
        }
    }

    alert('You enter in ' + labelText + ': ' + input.value);
}
