$(document).ready(function () {
    var chat = $.connection.broadcastHub;

    chat.client.displayNotification = function (message) {
        $('#notifications').append('<li><strong>' + htmlEncode(message)
            + '</strong></li>');
    };
});

function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}