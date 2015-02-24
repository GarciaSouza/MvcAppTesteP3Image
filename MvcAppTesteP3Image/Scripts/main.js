
function changeTitle(title) {
    $("div.action-container h2:first-child").html(title);
}

function showWarning(message) {
    $("div.action-container").append("<div><h3 class=\"bg-warning\">" + message + "</h3></div>");
}

