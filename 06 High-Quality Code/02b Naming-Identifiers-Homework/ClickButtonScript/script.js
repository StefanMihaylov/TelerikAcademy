function clickOn(event) {
    var myWindow = window,
        browserName = myWindow.navigator.appCodeName,
        isMozilla = (browserName === "Mozilla");

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
