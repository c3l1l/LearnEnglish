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
            CategoryAdd();
        }
    });
    $("#form_category_edit").validate({
        rules: {
            Name: {
                required: true
            },
            SectionId: {
                required: true
            }
        },
        messages: {
            Name: {
                required: "Category name is required..."
            },
            SectionId: {
                required: "Please select a Section..."
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
            //var categoryId = $('#category_category_id').text();
            //var Name = $('#Name').val();
            //var sectionId = $('#SectionId').val();
            //var data = {
            //    "CategoryId": categoryId,
            //    "Name": Name,
            //    "SectionId": SectionId
            //};
            //alert(data);
            CategoryEdit();
        }
    });
    $('#form_category_search').submit(function (event) {

        event.preventDefault();
        CategorySearch();
        return false;
    });
    $(".sortable").sortable();
    $(".sortable").on("sortupdate", function (event, ui) {
        BlockPage();
        var rank = $(this).sortable("serialize");       
        var data = {"Rank":rank}
        $.ajax({
            type: 'POST',
            url: '/Category/RankSetter',
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: data,
            dataType: 'json',
            success: function (response) {

                if (response.result) {
                    toastr.success(response.message);                       
                }
                else {
                    toastr.error(response.message);
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

    });
});

function CategoryAdd() {
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
function CategoryEdit() {
    BlockPage();
    var categoryId = $('#category_category_id').text();
    var Name = $('#Name').val();
    var sectionId = $('#SectionId').val();
    var categoryType = $('#CategoryType').val();
    var data = {
        "CategoryId": categoryId,
        "Name": Name,
        "SectionId": sectionId,
        "CategoryType":categoryType
    };
    alert(data);

    $.ajax({
        type: 'POST',
        url: '/Category/Edit',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: data,
        dataType: 'json',
        success: function (response) {
            if (response.result) {
                toastr.success(response.message);

                response.Message = "Category updated successfully";
            }
            else {
                toastr.error(response.message);
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
        url: '/Category/GetCategory',
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
                            + '</td><td>' + '<a class="btn btn-success" href="/Category/Details/' + row.categoryId + '">Edit</a>  '
                            + '<button type = "button" class="btn btn-danger" onclick = "CategoryDeleteConfirm(' + row.categoryId + ')" ><i class="fa fa-sm fa-trash-alt"></i> Delete</button >'
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
function CategoryDeleteConfirm(categoryId) {
    var message = categoryId;
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete Section !'
    }).then((result) => {
        if (result.isConfirmed) {
            CategoryDelete(categoryId);
        }
    });
}
function CategoryDelete(categoryId) {
    var data = { "CategoryId": categoryId }
    $.ajax({
        type: 'POST',
        url: '/Category/Delete',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: data,
        dataType: 'json',
        success: function (response) {
            if (response.result) {
                Swal.fire(
                    'Deleted!',
                    response.message,
                    'success'
                );
                CategoryGet();
            } else {
                Swal.fire(
                    'Uyarı!',
                    response.message,
                    'error'
                );
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
function CategorySearch() {
    var searchString = $("#category_name").val();
    if (searchString != "") {
        var data = { "searchString": searchString }
        $.ajax({
            type: 'POST',
            url: '/Category/Search',
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: data,
            dataType: 'json',
            success: function (response) {
                if (response.result) {
                    $('#category_list tbody').html('');
                    $('#category_list tbody').append();

                    var categoryRowCount = response.data.length;
                    if (categoryRowCount == 0) {

                        $('#category_list tbody').append('Record not found !');
                        $("#category_list").css("border", "3px solid red");
                    }
                    else {
                        var categories = '';
                        $.each(response.data, function (index, row) {
                            var shortDate = ShortDate(row.createdDate);


                            categories += '<tr><td class="text-success font-weight-bold">' + row.themeTitle
                                + '</td><td>' + row.categoryId
                                + '</td><td>' + row.name
                                + '</td><td>' + row.rank
                                + '</td><td>' + shortDate
                                + '</td><td>' + '<a class="btn btn-success" href="/Category/Details/' + row.categoryId + '">Edit</a>  '
                                + '<button type = "button" class="btn btn-danger" onclick = "CategoryDeleteConfirm(' + row.categoryId + ')" ><i class="fa fa-sm fa-trash-alt"></i> Delete</button >'
                                + '</td></tr>';
                        });
                        $('#category_list tbody').append(categories);
                        $("#category_list").css("border", "");
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
    else {
        $("#category_name").css("border", "3px solid red");
        $("#category_name").attr("placeholder", "Enter a section name !");
        CategoryGet();
    }
}