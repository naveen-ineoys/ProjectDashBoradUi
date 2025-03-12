
$(document).ready(function () {

    //whenever the document load that the fillter contain is hidden so we use toggle to hide and show the container
    SortAsce("guest");

});


function selectRadio(id) {
    document.getElementById(id).checked = true;
    SortAsce("guest");
}
function SortAsce(x) {

    switch (x) {
        case "guest":
            var div = document.getElementById('guest-up');
            var order = div.getAttribute('data-order');
            var value = div.getAttribute('data-value');
            document.getElementById('guest-up').style.display = 'none';
            document.getElementById('guest-down').style.display = 'block';
            break
        case "accommodation":
            var div = document.getElementById('acc-up');
            var order = div.getAttribute('data-order');
            var value = div.getAttribute('data-value');
            document.getElementById('acc-up').style.display = 'none';
            document.getElementById('acc-down').style.display = 'block';
            break
        case "stay":
            var div = document.getElementById('stay-up');
            var order = div.getAttribute('data-order');
            var value = div.getAttribute('data-value');
            document.getElementById('stay-up').style.display = 'none';
            document.getElementById('stay-down').style.display = 'block';
            break
    }
    // Find the checked radio button
    let checkedRadio = document.querySelector('input[name="status"]:checked');

    if (checkedRadio) {
        // Find the parent .status-div container
        let selectedContainer = checkedRadio.closest('.status-div');
        if (selectedContainer) {    
                      // Get the data-status value
            var statusValue = selectedContainer.getAttribute('data-status');
        }      
    }
    $.ajax(
        {
            type: 'GET',
            //pass the year and month to FindNumberOfDays action in controller
            url: '/FrontDesk/SortTheData',
            data: { 'SortByStatus': statusValue, 'SortOrder': order, 'Sortby': value  },
            success:
                function (response) {
                    //dsiplay the sccuess response
                   
                    $("#partial").html(response);
                }
        });
}

function SortDeasce(x)
{

    switch (x) {
        case "guest":
            var div = document.getElementById('guest-down');
            var order = div.getAttribute('data-order');
            var value = div.getAttribute('data-value');
            document.getElementById('guest-up').style.display = 'block';
            document.getElementById('guest-down').style.display = 'none';
            break
        case "accommodation":
            var div = document.getElementById('acc-down');
            var order = div.getAttribute('data-order');
            var value = div.getAttribute('data-value');
            document.getElementById('acc-up').style.display = 'block';
            document.getElementById('acc-down').style.display = 'none';
            break
        case "stay":
            var div = document.getElementById('stay-down');
            var order = div.getAttribute('data-order');
            var value = div.getAttribute('data-value');
            document.getElementById('stay-up').style.display = 'block';
            document.getElementById('stay-down').style.display = 'none';
            break
    }
    let checkedRadio = document.querySelector('input[name="status"]:checked');

    if (checkedRadio) {
        // Find the parent .status-div container
        let selectedContainer = checkedRadio.closest('.status-div');
        if (selectedContainer) {        
            // Get the data-status value
            var statusValue = selectedContainer.getAttribute('data-status');
        }

    }
    $.ajax(
        {
            type: 'GET',
            //pass the year and month to FindNumberOfDays action in controller
            url: '/FrontDesk/SortTheData',
            data: { 'SortByStatus': statusValue, 'SortOrder': order, 'Sortby': value },
            success:
                function (response) {
                    //dsiplay the sccuess response
                  
                    $("#partial").html(response);
                }
        });
}
document.addEventListener("DOMContentLoaded", function () {
    // Initialize the selected date with today's date
    let selectedDate = new Date();

    // Function to update the displayed date
    function updateDateDisplay() {
        const day = selectedDate.getDate().toString().padStart(2, '0');
        const month = selectedDate.toLocaleString('default', { month: 'short' });
        const year = selectedDate.getFullYear();
        const formattedDate = `${day}/${month}/${year}`;
        document.getElementById("currentDate").innerText = formattedDate;
        document.getElementById("dateName").innerText = weekday;
        document.getElementById("onlyDate").innerText = day;
        document.getElementById("monthName").innerText = month;
    }

    // Event listener for the previous date button
    document.getElementById("prevDate").addEventListener("click", function () {
        selectedDate.setDate(selectedDate.getDate() - 1);
        updateDateDisplay();
    });

    // Event listener for the next date button
    document.getElementById("nextDate").addEventListener("click", function () {
        selectedDate.setDate(selectedDate.getDate() + 1);
        updateDateDisplay();
    });

    // Initial display update
    updateDateDisplay();
});

