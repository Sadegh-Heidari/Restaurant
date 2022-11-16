var wrap = document.getElementById("wrapper");
wrap.addEventListener("click", (event) => {
    if (event.target.parentElement.localName == "button" || event.target.localName == "button") {
        swal.fire({
            title: "Are you sure to want delete this User?",
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
                var id = event.target.id;

                var tr = "";
                if (event.target.parentElement.localName == "div") {
                    tr = event.target.parentNode.parentNode.parentNode;
                } else if (event.target.parentElement.localName == "button") {
                    tr = event.target.parentNode.parentNode.parentNode.parentNode;
                }
                var url = "/api/User/Deleteuser/";
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
                        if (response == false) {
                            swal.fire({
                                title: "User can not deleted.Please try Again",
                                icon: "error",
                                button: "ok",
                            });
                        }
                    }
                });

            }
        })
    }
    
});
