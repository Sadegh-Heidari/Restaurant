var wrapp = document.getElementById("wrapper");
wrapp.addEventListener("click", (event) => {
    if (event.target.parentElement.localName == "button" || event.target.localName == "button") {
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
                var target = event.target.id;
                var tr = "";
                if (event.target.parentElement.localName == "div") {
                    tr = event.target.parentElement.parentElement.parentElement;
                }
                else if (event.target.parentElement.localName == "button") {
                    tr = event.target.parentElement.parentElement.parentElement.parentElement;
                }
                var url = "/api/menuitem/delete";
                $.ajax({
                    type: "GET",
                    url: url,
                    data: "id=" + target,
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
    }
    
});