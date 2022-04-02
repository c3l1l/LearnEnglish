$(function() {
    $("#form_category_add").validate({
        rules: {
            Name: {
                required: true
            },
            SectionId: {
                required: true
            },
            CategoryType: {
                required:true
            }
        },
        messages: {
            Name: {
                required: "Category name is required..."
            },
        SectionId: {
                required: "Please select a Section..."
            },
           CategoryType: {
                required: "Please select a Category Type..."
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
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
            SectionAdd();
        }
    });
});

function SectionAdd() {
    BlockPage();
    var formData = $('#form_category_add').serialize();
    $.ajax({
        type: 'POST',
        url: '/Category/Add',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: formData,
        dataType: 'json',
        success: function (response) {

            if (response.result) {
                toastr.success(response.message);
                $('#category_card').show();
                CategoryGet();
            }
            else {
                toastr.error(response.message);
                CategoryGet();

            }
        },
        error: function (request, status, error) {
            alert(request + status + error);
        },
        complete: function () {
            UnBlockPage();
            return false;
        }
    });
}

function CategoryGet() {
    $('#category_list tbody').html('');
    $('#category_list tbody').append();

    $.ajax({
        type: 'POST',
        url: '/Category/GetSection',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: '',
        dataType: 'json',
        success: function (response) {
            if (response.result) {
                var categoryRowCount = response.data.length;
                if (categoryRowCount == 0) {
                    $('#category_list tbody').append('No record has been added yet....');
                }
                else {
                    var categories = '';
                    $.each(response.data, function (index, row) {
                        var shortDate = ShortDate(row.createdDate);

                        categories += '<tr><td class="text-success font-weight-bold">' + row.sectionTitle
                            + '</td><td>' + row.categoryId
                            + '</td><td>' + row.categoryName
                            + '</td><td>' + row.categoryType
                            + '</td><td>' + row.rank
                            + '</td><td>' + shortDate
                            + '</td><td>' + '<a class="btn btn-success" href="/Category/Details/' + row.CategoryId + '">Edit</a>  '
                            + '<button type = "button" class="btn btn-danger" onclick = "CategoryDeleteConfirm(' + row.CategoryId + ')" ><i class="fa fa-sm fa-trash-alt"></i> Delete</button >'
                            + '</td></tr>'
                    });
                    $('#category_list tbody').append(categories);
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
