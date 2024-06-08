





$('#table2-tab').on('click', function () {
    $.ajax({
        url: '/Industry/GetAll',
        type: 'GET',
        success: function (data) {
            $('#industryDataPlaceholder').html(data);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching industry data: ", error);
            alert("Error fetching industry data. Please try again.");
        }
    });
});


