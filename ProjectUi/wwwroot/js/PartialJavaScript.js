$(document).ready(function () {
    var colors = ['#ffe8ff', '#f8fbcc', '#dbf9f3','#fadbd8'];
    $.each($('.booking-bar'), function () {
        var new_color = colors[Math.floor(Math.random() * colors.length)];
        $(this).css('background-color', new_color);
    });
    const topContainer = document.getElementById("topContainer");
    const bottomContainer = document.getElementById("bottomContainer");

    // Sync horizontal scrolling between top and bottom containers
    bottomContainer.addEventListener("scroll", function () {
        topContainer.scrollLeft = bottomContainer.scrollLeft;
    });
});