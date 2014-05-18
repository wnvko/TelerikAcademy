function clickButton(event, argumnets) {
    var myWindow = window;
    var browserType = myWindow.navigator.appCodeName;
    var isMozilla = browserType === "Mozilla";

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}