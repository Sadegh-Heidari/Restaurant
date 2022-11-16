var wrapp = document.getElementById("wrapper");
wrapp.addEventListener("click",(event) => {
    if (event.target.localName == "button" || event.target.parentElement.localName == "button") {
        var id = event.target.getAttribute("data-val-id");
        var span = event.target.getAttribute("data-val-status");
        var url = "/api/category/" + span;
        $.ajax({
            type: "GET",
            url: url,
            data: "id=" + id,
            success: function (response) {
                if (response == true) {
                    if (span == "Delete") {
                        if (event.target.localName == "button") {
                            event.target.setAttribute("data-val-status", "Delete");
                            event.target.firstElementChild.setAttribute("class", "bi bi-check-square-fill");
                            event.target.setAttribute("class", "");
                            event.target.setAttribute("class", "btn btn-outline-success ms-3 rounded-end");
                        }
                        else if (event.target.parentElement.localName == "button") {
                            event.target.parentElement.setAttribute("data-val-status", "Delete");
                            event.target.parentElement.firstElementChild.setAttribute("class", "bi bi-check-square-fill");
                            event.target.parentElement.setAttribute("class", "");
                            event.target.parentElement.setAttribute("class", "btn btn-outline-success ms-3 rounded-end");
                        }
                    }
                    if (span == "Active") {
                        if (event.target.localName == "button") {
                            event.target.setAttribute("data-val-status", "Active");
                            event.target.firstElementChild.setAttribute("class", "bi bi-trash-fill");
                            event.target.setAttribute("class", "");
                            event.target.setAttribute("class", "btn btn-outline-danger ms-3 rounded-end");
                        }
                        else if (event.target.parentElement.localName == "button") {
                            event.target.parentElement.setAttribute("data-val-status", "Active");
                            event.target.parentElement.firstElementChild.setAttribute("class", "bi bi-trash-fill");
                            event.target.parentElement.setAttribute("class", "");
                            event.target.parentElement.setAttribute("class", "btn btn-outline-danger ms-3 rounded-end");
                        }
                    }
                }
            }
        });

    }
});
