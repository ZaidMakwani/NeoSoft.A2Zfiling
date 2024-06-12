
//$('#table1-tab').on('click', function () {
//    console.log("table-1 tab")
//    $.ajax({
//        url: '/LicenseType/GetAll',
//        type: 'GET',
//        success: function (data) {
//            $('#licenseTypeDataPlaceholder').html(data);
//        },
//        error: function (xhr, status, error) {
//            console.error("Error fetching license type data: ", error);
//            alert("Error fetching license type data. Please try again.");
//        }
//    });
//});


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

$('#table6-tab').on('click', function () {
    console.log("table-6 tab")
    $.ajax({
        url: '/Status/GetAll',
        type: 'GET',
        success: function (data) {
            $('#statusDataPlaceholder').html(data);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching status data: ", error);
            alert("Error fetching status data. Please try again.");
        }
    });
});

$('#table7-tab').on('click', function () {
    console.log("table-7 tab")
    $.ajax({
        url: '/SubStatus/GetAll',
        type: 'GET',
        success: function (data) {
            $('#subStatusDataPlaceholder').html(data);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching sub status data: ", error);
            alert("Error fetching sub status data. Please try again.");
        }
    });
});



