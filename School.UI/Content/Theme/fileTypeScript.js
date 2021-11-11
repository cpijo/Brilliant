// fileInput is an HTMLInputElement: <input type="file" id="myfileinput" multiple>
var fileInput = document.getElementById("myfileinput");

// files is a FileList object (similar to NodeList)
var files = fileInput.files;

// object for allowed media types
var accept = {
    binary: ["image/png", "image/jpeg"],
    text: ["text/plain", "text/css", "application/xml", "text/html"]
};

var file;

for (var i = 0; i < files.length; i++) {
    file = files[i];

    // if file type could be detected
    if (file !== null) {
        if (accept.binary.indexOf(file.type) > -1) {
            // file is a binary, which we accept
            var data = file.getAsBinary();
        } else if (accept.text.indexOf(file.type) > -1) {
            // file is of type text, which we accept
            var data1 = file.getAsText();
            // modify data with string methods
        }
    }
}


var imgSmall = $('#UserImageSlider-page .img-parent').children("img");

$('#UserImageSlider-page .small-pic-profile img').click(function () {
    var index = $("#UserImageSlider-page .small-pic-profile img").index(this);

    for (var i = 0; i < imgSmall.length; i++) {
        imgSmall[i].className = imgSmall[i].className.replace(" activeRed", "");
        if (index === i) {
            this.className += " activeRed";
            $(".activeRed").next().css({ "color": "red", "border": "2px solid green" });
        }
    }
    displaySlides(index);
});






    $(document).ready(function () {
        $("li").click(function () {
            alert($(this).index());
        });
    });
    var items = $('#UserImageSlider-page .small-pic-profile img').click(function () {
        current = items.index(this);
    alert(current);
});

    $('#UserImageSlider-page .small-pic-profile img').click(function () {
        var index = $("#UserImageSlider-page .small-pic-profile img").index(this);
});


       window.onload = function () {
        var p = document.getElementsByTagName('p');
        for (var i = 0; i < p.length; i++) {
        p[i].onclick = function () {
            alert(i); // i value is last one in loop
        }
    }
    }



    var form = document.querySelector('.signup').onsubmit = function (evt) {
        evt.preventDefault();

    //ajax_stuff_here
    };

    $('#signupForm').submit(function (event) {
        var form = this;

});



