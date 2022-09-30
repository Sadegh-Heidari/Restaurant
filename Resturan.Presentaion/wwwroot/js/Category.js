
function Excute(Element) {
    var id = Element.getAttribute("data-val-id");
    var span = Element.getAttribute("data-val-status");
    var url = "/api/category/" + span;
    $.ajax({
        type: "GET",
        url: url,
        data: "id=" + id,
        success: function (response) {
            if (response == true) {
                if (span == "Delete") {
                    Element.getAttribute("data-val-status", "Delete");
                    Element.setAttribute("class", "");
                    Element.setAttribute("class", "btn btn-outline-success ms-3 rounded-end");
                    Element.firstElementChild.setAttribute("class", "bi bi-check-square-fill");
                }
                if (span == "Active") {
                    
                    Element.setAttribute("data-val-status", "Active");
                    Element.setAttribute("class", "");
                    Element.setAttribute("class", "btn btn-outline-danger ms-3 rounded-end");
                    Element.firstElementChild.setAttribute("class", "bi bi-trash-fill");
                }
            }
        }
    });


};
//if (span == "Active") {
//    $.ajax({
//        type: "GET",
//        url: "/api/category/delete",
//        data: "id=" + id,
//        success: function (response) {
//            if (response == true) {
//                Element.getAttribute("data-val-status", "Delete");
//                Element.setAttribute("class", "");
//                Element.setAttribute("class", "btn btn-outline-success ms-3 rounded-end");
//                Element.firstElementChild.setAttribute("class", "bi bi-check-square-fill");
//            }
//        }
//    });
//}