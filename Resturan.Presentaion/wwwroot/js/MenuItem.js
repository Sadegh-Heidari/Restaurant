function Excute(Element) {
    swal.fire({
        title: "Are you sure to want delete this item?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yep",
        cancelButtonText: "Nop",
        customClass: {
            confirmButton: 'btn btn-success m-2 rounded-start',
            cancelButton: 'btn btn-danger m-2 rounded-end'
        },
        buttonsStyling: false,
    }).then(res => {
        if (res.isConfirmed) {
            var tr = Element.parentNode.parentNode.parentNode;
            var id = Element.getAttribute("data-val-id");
            var span = Element.getAttribute("data-val-status");
            var url = "/api/menuitem/" + span;
            $.ajax({
                type: "GET",
                url: url,
                data: "id=" + id,
                success: function (response) {
                    if (response == true) {
                        var tbody = document.querySelector("tbody");
                        tr.remove();
                        if (tbody.innerText == "") {

                            var pagination = document.querySelector('#page');
                            pagination.remove();
                        }
                    }
                }
            });

        }
    })
};