$(document).ready(function () {
    var chat = $.connection.broadcastHub;

    chat.client.displayNotification = function (message) {
        var $newnotify = $("<button></button>").text(message);
        $newnotify.css("display", "none");
        $newnotify.addClass("");
        $("#notifications").append($newnotify);
        $newnotify.fadeIn(1000);
        $newnotify.click(function () {
            $(this).fadeOut(1000, function () { $(this).remove() });
        });
        window.setTimeout(function(){
            $($newnotify).fadeOut(1000, function () { $(this).remove() })
        }, 10000);
    };

    $.connection.hub.start();
});