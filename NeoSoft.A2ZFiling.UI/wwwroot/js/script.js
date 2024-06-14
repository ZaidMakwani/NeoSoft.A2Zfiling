

$('#table2-tab').on('click', function () {
    console.log("table-2 tab")
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


$('#table3-tab').on('click', function () {
    console.log("table-3 tab")
        $.ajax({
            url: '/Company/GetAll',
            type: 'GET',
            success: function (data) {
                $('#companyDataPlaceholder').html(data);
            },
            error: function (xhr, status, error) {
                console.error("Error fetching company data: ", error);
                alert("Error fetching company data. Please try again.");
            }
        });
});


$('#table4-tab').on('click', function () {
    console.log("table-4 tab")
    $.ajax({
        url: '/Category/GetAll',
        type: 'GET',
        success: function (data) {
            $('#categoryDataPlaceholder').html(data);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching category data: ", error);
            alert("Error fetching category data. Please try again.");
        }
    });
});

$('#table5-tab').on('click', function () {
    console.log("table-5 tab")
    $.ajax({
        url: '/License/GetAll',
        type: 'GET',
        success: function (data) {
            $('#licenseDataPlaceholder').html(data);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching license data: ", error);
            alert("Error fetching license data. Please try again.");
        }
    });
});


$('#tableB-tab').on('click', function () {
    console.log("table-2 tab")
    $.ajax({
        url: '/Zone/GetAllZone',
        type: 'GET',
        success: function (data) {
            $('#zonePlaceholderssss').html(data);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching industry data: ", error);
            alert("Error fetching industry data. Please try again.");
        }
    });
});


$('#tableC-tab').on('click', function () {
    console.log("table-3 tab")
    $.ajax({
        url: '/City/GetAllCity',
        type: 'GET',
        success: function (data) {
            $('#cityPlaceholder').html(data);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching company data: ", error);
            alert("Error fetching company data. Please try again.");
        }
    });
});

