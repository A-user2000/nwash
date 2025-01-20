function UpdateTapData(form) {
    var formData = $(form).serializeArray();
    $.ajax({
        type: "POST",
        url: '../EditTap',
        data: formData,
        success: function (data) {
            if (data == "1") {
                alert("Data updated successfully");
            } else if (data == "0") {
                alert("No changes were made");
            } else {
                alert("Something went wrong. Please try again later");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function UpdateStructureData(form) {
    var formData = $(form).serializeArray();
    $.ajax({
        type: "POST",
        url: '../EditStructure',
        data: formData,
        success: function (data) {
            if (data == "1") {
                alert("Data updated successfully");
            } else if (data == "0") {
                alert("No changes were made");
            } else {
                alert("Something went wrong. Please try again later");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function UpdateRvtData(form) {
    var formData = $(form).serializeArray();
    $.ajax({
        type: "POST",
        url: '../EditReservoir',
        data: formData,
        success: function (data) {
            if (data == "1") {
                alert("Data updated successfully");
            } else if (data == "0") {
                alert("No changes were made");
            } else {
                alert("Something went wrong. Please try again later");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function UpdateWSData(form) {
    var formData = $(form).serializeArray();
    $.ajax({
        type: "POST",
        url: '../EditWaterSource',
        data: formData,
        success: function (data) {
            if (data == "1") {
                alert("Data updated successfully");
            } else if (data == "0") {
                alert("No changes were made");
            } else {
                alert("Something went wrong. Please try again later");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function UpdatePipeData(form) {
    var formData = $(form).serializeArray();
    $.ajax({
        type: "POST",
        url: '../EditPipe',
        data: formData,
        success: function (data) {
            if (data == "1") {
                alert("Data updated successfully");
            } else if (data == "0") {
                alert("No changes were made");
            } else {
                alert("Something went wrong. Please try again later");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function UpdateLeftoutTapData(form) {
    var formData = $(form).serializeArray();
    $.ajax({
        type: "POST",
        url: '../EditLeftoutTaps',
        data: formData,
        success: function (data) {
            if (data == "1") {
                alert("Data updated successfully");
            } else if (data == "0") {
                alert("No changes were made");
            } else {
                alert("Something went wrong. Please try again later");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}