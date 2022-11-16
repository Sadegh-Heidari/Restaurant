var show = document.querySelector("input[type=file]");
show.addEventListener("change",(event) => {
    var preview = document.querySelector('img');
    var file = document.querySelector('input[type=file]').files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
        preview.setAttribute("style", "border-radius:5px; border:1px solid #bbb9b9");

    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
});
