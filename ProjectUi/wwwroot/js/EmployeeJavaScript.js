
function sortTable(icon, columnIndex) {
    let table = document.getElementById("tble-data");
    let rows = Array.from(table.rows);
    let isAscending = icon.getAttribute("data-sort-order") === "asc";

    rows.sort((rowA, rowB) => {
        let cellA = rowA.cells[columnIndex].textContent.trim();
        let cellB = rowB.cells[columnIndex].textContent.trim();

        // Convert dates for sorting
        if (columnIndex === 6 || columnIndex === 7) {
            let dateA = Date.parse(cellA); // Convert string to timestamp
            let dateB = Date.parse(cellB);
            return isAscending ? dateA - dateB : dateB - dateA;
        }


        if (!isNaN(cellA) && !isNaN(cellB)) {
            return isAscending ? cellA - cellB : cellB - cellA;
        } else {
            return isAscending ? cellA.localeCompare(cellB) : cellB.localeCompare(cellA);
        }
    });

    // Toggle sorting order
    icon.setAttribute("data-sort-order", isAscending ? "desc" : "asc");

    // Change the icon
    let allIcons = document.querySelectorAll(".sort-icon svg");
    allIcons.forEach(svg => svg.classList.remove("bi-sort-up", "bi-sort-down"));

    if (isAscending) {
        icon.innerHTML = `<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-sort-up" viewBox="0 0 16 16">
                            <path d="M3.5 12.5a.5.5 0 0 1-1 0V3.707L1.354 4.854a.5.5 0 1 1-.708-.708l2-1.999.007-.007a.5.5 0 0 1 .7.006l2 2a.5.5 0 1 1-.707.708L3.5 3.707zm3.5-9a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5M7.5 6a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1zm0 3a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1zm0 3a.5.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1z"/>
                          </svg>`;
    } else {
        icon.innerHTML = `<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-sort-down" viewBox="0 0 16 16">
                            <path d="M3.5 2.5a.5.5 0 0 0-1 0v8.793l-1.146-1.147a.5.5 0 0 0-.708.708l2 1.999.007.007a.497.497 0 0 0 .7-.006l2-2a.5.5 0 0 0-.707-.708L3.5 11.293zm3.5 1a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5M7.5 6a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1zm0 3a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1zm0 3a.5.5.5 0 0 0 0 1h1a.5.5.5 0 0 0 0-1z"/>
                          </svg>`;
    }

    // Append sorted rows back to the table
    table.innerHTML = "";
    rows.forEach(row => table.appendChild(row));
}





$("#btnAdd").click(function () {
    $("#popDis").modal("show");
});



function HideModal() {
  
    $("#popDis").modal("hide");
}
$(document).ready(function () {
    $("#employeeForm").on("submit", function (e) {
        e.preventDefault();

        var formData = new FormData(this);

        $.ajax({
            url: '/Employee/Create',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.success) {
                    $("#successMessage").text(response.message).removeClass('d-none');
                    $("#errorMessage").addClass('d-none');
                    $('#popDis').modal('hide');
                    $("#employeeForm")[0].reset();
                    document.location.reload();
                } else {
                    $("#errorMessage").text(response.message).removeClass('d-none');
                    $("#successMessage").addClass('d-none');
                }
            },
            error: function () {
                $("#errorMessage").text("An error occurred while processing the request.").removeClass('d-none');
                $("#successMessage").addClass('d-none');
            }
        });
    });
});

function Search(x) {
    switch (x) {
        case "Dept":
            var data = document.getElementById("dept").value
            break
        case "Designation":
            var data = document.getElementById("designation").value
            break
    }
    $.ajax(
        {
            type: 'GET',
            url: '/Employee/Search',
            data: { 'SearchBY': x,'SearchValue':data},
            success:
                function (response) {
                    $("#tble-data").html(response);
                    var deptDAta = document.getElementById("dept");
                    deptDAta.reset();
                    var desigDAta = document.getElementById("designation");
                    desigDAta.reset();
                }
        });
}
function Edit(id) {
    $.ajax
        (
        {
            url: "/Employee/Edit?id=" + id,
            type: "get",
            contentType: 'application/josn;charset=utf=8',
            datatype: 'json',
            success: function (response) {
                if (response == null || response == undefined) {
                    alert("unable to read data");
                }
                else if (response.length == 0) {
                    alert("Data not avilable");
                }
                else {
                    $("#popDis").modal("show");
                   
                    $("#save").css('display', 'none');
                    $("#update").css('display', 'block');

                    $("#sno").val(response.sNo);
                   
                    $("#name").val(response.employeeName);
                    $("#empcode").val(response.employeeCode);
                    $("#dept").val(response.department);
                    $("#desig").val(response.designation);
                    $("#dob").val(response.dob);
                    $("#doj").val(response.dateOfJoin);
                    $("#jobtype").val(response.jobType);
                    $("#img").val(response.photo);
                }
                
                },
                error: function () {
                    alert("Unable to read data")
                }
            
        });
    
}
//$(document).ready(function () {
//    $("#employeeForm").submit(function (e) {
//        e.preventDefault(); // Prevent the default form submission
//        $("#errorMessage").hide().text("");

//        // Get the file from the file input
//        var fileInput = $("input[name='EmployeeImage']")[0];
//        if (fileInput.files.length === 0) {
//            $("#errorMessage").text("Please select an employee image.").show();
//            return;
//        }
//        var file = fileInput.files[0];

//        // Use FileReader to convert the file to a Base64 data URL
//        var reader = new FileReader();
//        reader.onload = function (event) {
//            var dataUrl = event.target.result; // This is the Base64 string

//            // Create an Image object to check the image dimensions
//            var img = new Image();
//            img.onload = function () {
//                var width = img.naturalWidth;
//                var height = img.naturalHeight;
//                var megapixels = (width * height) / 1000000;

//                // If image resolution is 1 MP or more, show an error
//                if (megapixels >= 1) {
//                    $("#errorMessage").text("Image quality is too high. Please upload an image less than 1 Megapixel.").show();
//                    return;
//                }

//                // Otherwise, set the hidden input with the Base64 string
//                $("input[name='ImageBase64']").val(dataUrl);

//                // Build FormData from the form element
//                var formData = new FormData($("#employeeForm")[0]);

//                // Send the form data via AJAX
//                $.ajax({
//                    url: '/Employee/Create',
//                    type: 'POST',
//                    data: formData,
//                    processData: false,  // Prevent jQuery from processing the data
//                    contentType: false,  // Prevent jQuery from setting contentType
//                    success: function (response) {
//                        if (response.success) {
//                            alert(response.message);
//                            $("#createModal").modal('hide');
//                            $("#employeeForm")[0].reset();
//                        } else {
//                            $("#errorMessage").text(response.message).show();
//                        }
//                    },
//                    error: function () {
//                        $("#errorMessage").text("An unexpected error occurred.").show();
//                    }
//                });
//            };
//            img.onerror = function () {
//                $("#errorMessage").text("Invalid image file.").show();
//            };
//            img.src = dataUrl;
//        };
//        reader.onerror = function () {
//            $("#errorMessage").text("Error reading the image file.").show();
//        };
//        reader.readAsDataURL(file);
//    });
//});