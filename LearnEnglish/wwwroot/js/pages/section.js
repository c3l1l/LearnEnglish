$(function() {
    $("#form_section_add").validate({
        rules: {
            Title: {
                required: true
            },
            ThemeId: {
                required: true
            }
        },
        messages: {
            Title: {
                required: "Section title is required..."
            },
            ThemeId: {
                required: "Please select a Theme..."
            }
        },
        errorElement: 'span',
        errorPlacement: function(error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function(element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function(element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        },

        submitHandler: function(form) {
            SectionAdd();
        }
    });
    $("#form_section_edit").validate({
        rules: {
            Title: {
                required: true
            },
            ThemeId: {
                required: true
            }
        },
        messages: {
            Title: {
                required: "Section title is required..."
            },
            ThemeId: {
                required: "Please select a Theme..."
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
            SectionEdit();
        }
    });
    $('#form_section_search').submit(function (event) {
       
        event.preventDefault();
        SectionSearch();
        return false;
    });
   
});
function SectionAdd() {
    BlockPage();
    var formData = $('#form_section_add').serialize();
    $.ajax({
        type: 'POST',
        url: '/Section/Add',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: formData,
        dataType: 'json',
        success: function (response) {

            if (response.result) {
                toastr.success(response.message);
                $('#section_card').show();
                SectionGet();
            }
            else {
                toastr.error(response.message);
                SectionGet();
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
function SectionGet() {
    $('#section_list tbody').html('');
    $('#section_list tbody').append();

    $.ajax({
        type: 'POST',
        url: '/Section/GetSection',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: '',
        dataType: 'json',
        success: function (response) {
            if (response.result) {
                var sectionRowCount = response.data.length;
                if (sectionRowCount == 0) {
                    $('#section_list tbody').append('No record has been added yet....');
                }
                else {
                    var sections = '';
                    $.each(response.data, function (index, row) {
                        var shortDate = ShortDate(row.createdDate);

                        sections += '<tr><td class="text-success font-weight-bold">'+row.themeTitle
                            + '</td><td>' + row.sectionId
                            + '</td><td>' + row.title
                            + '</td><td>' + row.rank
                            + '</td><td>' + shortDate
                            + '</td><td>' + '<a class="btn btn-success" href="/Section/Details/' + row.sectionId + '">Edit</a>  '
                            + '<button type = "button" class="btn btn-danger" onclick = "SectionDeleteConfirm(' + row.sectionId + ')" ><i class="fa fa-sm fa-trash-alt"></i> Delete</button >'
                            + '</td></tr>'
                    });
                    $('#section_list tbody').append(sections);
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
//function ThemeDeleteConfirm(sectionId) {
//    var message = sectionId;
//    Swal.fire({
//        title: 'Are you sure?',
//        text: "You won't be able to revert this!",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes, delete Section !'
//    }).then((result) => {
//        if (result.isConfirmed) {
//            ThemeDelete(sectionId);
//        }
//    });
//}
//function ThemeDelete(sectionId) {
//    var data = { "SectionId": sectionId }
//    $.ajax({
//        type: 'POST',
//        url: '/Section/Delete',
//        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
//        data: data,
//        dataType: 'json',
//        success: function (response) {
//            if (response.result) {
//                Swal.fire(
//                    'Deleted!',
//                    response.message,
//                    'success'
//                );
//                //ThemeGet();
//            } else {
//                Swal.fire(
//                    'Uyarı!',
//                    response.message,
//                    'error'
//                );
//            }
//        },
//        error: function (request, status, error) {
//            alert(request + status + error);
//        },
//        complete: function () {
//            UnBlockPage();
//            return false;
//        }
//    });
//}
function SectionEdit() {
    BlockPage();
    var sectionId = $('#section_section_id').text();
    var Title = $('#Title').val();
    var themeId = $('#ThemeId').val();
    var data = {
        "SectionId": sectionId,
        "Title": Title,
        "ThemeId": themeId
    };
   
    $.ajax({
        type: 'POST',
        url: '/Section/Edit',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: data,
        dataType: 'json',
        success: function (response) {
            if (response.result) {
                toastr.success(response.message);
                
                response.Message = "Section updated successfully";
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
function SectionDeleteConfirm(sectionId) {
    var message = sectionId;
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
            SectionDelete(sectionId);
        }
    });
}
function SectionDelete(sectionId) {
    var data = { "SectionId": sectionId }
    $.ajax({
        type: 'POST',
        url: '/Section/Delete',
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
                SectionGet();
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
function SectionSearch() {
    var searchString = $("#section_name").val();
    //alert(searchString);

    if (searchString != "") {
        var data = { "searchString": searchString }
        $.ajax({
            type: 'POST',
            url: '/Section/Search',
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: data,
            dataType: 'json',
            success: function (response) {
                if (response.result) {
                    $('#section_list tbody').html('');
                    $('#section_list tbody').append();

                    var sectionRowCount = response.data.length;
                    if (sectionRowCount == 0) {

                        $('#section_list tbody').append('Record not found !');
                        $("#section_list").css("border", "3px solid red");
                    }
                    else {
                        var sections = '';
                        $.each(response.data, function (index, row) {
                            var shortDate = ShortDate(row.createdDate);


                            sections += '<tr><td class="text-success font-weight-bold">' + row.themeTitle
                                + '</td><td>' + row.sectionId
                                + '</td><td>' + row.title
                                + '</td><td>' + row.rank
                                + '</td><td>' + shortDate
                                + '</td><td>' + '<a class="btn btn-success" href="/Section/Details/' + row.sectionId + '">Edit</a>  '
                                + '<button type = "button" class="btn btn-danger" onclick = "SectionDeleteConfirm(' + row.sectionId + ')" ><i class="fa fa-sm fa-trash-alt"></i> Delete</button >'
                                + '</td></tr>';
                        });
                        $('#section_list tbody').append(sections);
                        $("#section_list").css("border", "");
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
        $("#section_name").css("border", "3px solid red");
        $("#section_name").attr("placeholder", "Enter a section name !");
        SectionGet();
    }
}