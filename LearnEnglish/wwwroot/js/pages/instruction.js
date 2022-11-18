$(document).ready(function () {
    $('#summernote').summernote();
    $("#instruction_detail").validate({
        rules: {
            instruction_id: {
                required: true
            },
            summernote: {
                required: true
            }
        },
        messages: {
            Name: {
                required: "Content area is required..."
            },
            SectionId: {
                required: "Instruction Id gereklidir."
            },
            CategoryType: {
                required: "Please select a Content Type..."
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            alert("Validasyon basarisiz.");
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        },

        submitHandler: function (form) {
            alert("Validasyon basarilı.");

            InstructionDetailAdd();
        }
    });
    $("#sound_update").submit(function (e) {
        e.preventDefault();
        alert();
        return false;
    });
    
});
function InstructionDetailAdd() {
    BlockPage();
    var Info = $("#summernote").val();
    var InstructionId = $("#instruction_id").val();
    var data = { "RichText": Info, "Id": InstructionId };
    $.ajax({
        type: "Post",
        url: "/Instruction/Add",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: data,
        dataType: "json",
        success: function (response) {
            if (response.result) {
                toastr.success(response.message);
                $("#content_card").show();
                InstructionDetailGet(InstructionId);
            }
            else {
                toastr.error(response.message);
            }
        },
        error: function (request, status, error) {
            alert(request + status + error);
        },
        complete: function () {
            return false;
        }

    });
    UnBlockPage();
}
function InstructionDetailGet(InstructionId) {
    $('#content_list tbody').html('');
    $('#content_list tbody').append();
    var data= {"Id":InstructionId }
    $.ajax({
        type: "Post",
        url: "/Instruction/GetDetails",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: data,
        dataType: 'json',
        success: function (response) {

            if (response.result) {
                var dataRowCount = response.data.length;
                if (dataRowCount == 0) {
                    $("content_list tbody").append("No record has been added yet....");
                }
                else {
                    var detailsData = '';
                    $.each(response.data, function (index, element) {
                        var shortDate = ShortDate(element.createdDate);
                        detailsData += '<tr><td class="text-success font-weight-bold">' + element.info
                            + '</td><td>' + element.rank
                            + '</td><td>' + shortDate
                            + '</td><td>' + '<a class="btn btn-success" href="/Instructions/Details/' + element.InstructionDetailId + '">Edit</a>  '
                            + '<button type = "button" class="btn btn-danger" onclick = "SectionDeleteConfirm(' + element.InstructionDetailId + ')" ><i class="fa fa-sm fa-trash-alt"></i> Delete</button >'
                            + '</td></tr>'
                    });
                    $("#content_list tbody").append(detailsData);
                }
            }
        },
        error: function (request, status, error) {
        },
        complete: function () {
            return false;
        }
    });
}
function ShortDate(longDate) {
    var createdDate = new Date(longDate);
    var d = createdDate.getDate();
    var m = createdDate.getMonth();
    m += 1;  // JavaScript months are 0-11
    var y = createdDate.getFullYear();
    var shortDate = (d + "." + m + "." + y);
    return shortDate;
}