﻿(function (send) {
    var number = 0;
    XMLHttpRequest.prototype.send = function (data) {
        number++;
        document.querySelector(".console").innerText += "Request #" + number + ": " + data.length + " / ";
        send.call(this, data);
    };
})(XMLHttpRequest.prototype.send);
(function (open) {
    XMLHttpRequest.prototype.open = function (method, url, async, user, pass) {
        this.addEventListener("readystatechange", function () {
            if (this.readyState === 4) {
                document.querySelector(".console").innerText += this.responseText.length + "\n";
                document.querySelector(".console").scrollTop = document.querySelector(".console").scrollHeight;
            }
        }, false);
        open.call(this, method, url, async, user, pass);
    };
})(XMLHttpRequest.prototype.open);