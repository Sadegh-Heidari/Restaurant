function Excute(Element) {
    var id = Element.getAttribute("data-val-id");
    var span = Element.getAttribute("data-val-status");
    var url = "/api/foodtype/" + span;
    $.ajax({
        type: "GET",
        url: url,
        data: "id=" + id,
        success: function (response) {
            if (response == true) {
                if (span == "Delete") {
                    Element.getAttribute("data-val-status", "Delete");
                    Element.firstElementChild.setAttribute("class", "bi bi-check-square-fill");

                    Element.setAttribute("class", "");
                    Element.setAttribute("class", "btn btn-outline-success ms-3 rounded-end");
                };
                if (span == "Active") {
                    Element.setAttribute("data-val-status", "Active");
                    Element.firstElementChild.setAttribute("class", "bi bi-trash-fill");

                    Element.setAttribute("class", "");
                    Element.setAttribute("class", "btn btn-outline-danger ms-3 rounded-end");
                }
            }
        }
    });


};