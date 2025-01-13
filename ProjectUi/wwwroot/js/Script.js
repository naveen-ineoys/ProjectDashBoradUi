$(document).ready(function () {

    //whenever the document load that the fillter contain is hidden so we use toggle to hide and show the container
    $(".search-bar").click(function () {
        $("#one").toggle();
    });
   

    //initialy loaded the current guest data so we call the findmonth 
    FindMonth();
    
    });




function FindMonth()
{
    //get the checked year and month
    var Year = $("input[name='year']:checked").val();
    var months = $("input[name='month']:checked").val();

     
    $.ajax(
        {
            type: 'GET',
            //pass the year and month to FindNumberOfDays action in controller
            url: '/Project/FindNumberOfDays',
            data: { 'year': Year, 'month': months },
            success:
                function (response) {
                    //dsiplay the sccuess response
                    $("#partial").html(response);
              }
        });  

};

