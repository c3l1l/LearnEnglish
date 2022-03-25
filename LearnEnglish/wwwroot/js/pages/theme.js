
var form_theme_add = null;
$(function ()
{
    $("#form_theme_add").validate({
        rules: {
            theme_title: {
                required: true
            },
            Level: {
                required: true
            }
        },
        messages: {
            theme_title: {
                required: "Theme title is required..."
            },
            Level: {
                required: "Please select a Level..."
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
            ThemeAdd();
        }
    });
    $("#form_theme_edit").validate({
        rules: {
            theme_title: {
                required: true
            },
            Level: {
                required: true
            }
        },
        messages: {
            theme_title: {
                required: "Theme title is required..."
            },
            Level: {
                required: "Please select a Level..."
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
            ThemeEdit();
        }
    });
    $(document).on("change",".form_is_active_change",function () {
        if ($(this).prop("checked")) {
            IsActiveStateChange($(this).attr("id"),1);
        } else {
            IsActiveStateChange($(this).attr("id"),0);
        }
    });
});

function ThemeDeleteConfirm(themeId) {
    var message = themeId;
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete Theme!'
    }).then((result) => {
        if (result.isConfirmed) {
            ThemeDelete(themeId);
        }
    })
}
function ThemeDelete(themeId) {
    var data = { "ThemeId": themeId }
    $.ajax({
        type: 'POST',
        url: '/Theme/Delete',
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
                //todo ThemeGet ile yeni liste alinacak....
                ThemeGet();
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
function ThemeAdd(parameters) {
    BlockPage();
    var formData = $('#form_theme_add').serialize();
    $.ajax({
        type: 'POST',
        url: '/Theme/Add',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: formData,
        dataType: 'json',
        success: function (response) {

            if (response.result) {
                toastr.success(response.message);
                $('#theme_card').show();
                ThemeGet();
            }
            else {
                toastr.error(response.message);
                ThemeGet();
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

function ThemeEdit() {
    BlockPage();
    var themeId = $('#theme_theme_id').text();
   // var isActive = ($('#theme_active_passive').val()==="on"?1:0);
    var isActive = $('#theme_active_passive').val();
    alert(isActive);
    var data = {
        "ThemeId": themeId,
        "Title": $('#theme_title').val(),
        "IsActive": isActive,
        "Level": $('#Level').val()
    };
    
    $.ajax({
        type: 'POST',
        url: '/Theme/Edit',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: data,
        dataType: 'json',
        success: function (response) {

            if (response.result) {
                toastr.success(response.message);
                $('#theme_card').show();
                response.Message = "Theme added successfully";
               
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

function ThemeGet() {
    $('#theme_list tbody').html('');

    $('#theme_list tbody').append();

    $.ajax({
        type: 'POST',
        url: '/Theme/GetTheme',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: '',
        dataType: 'json',
        success: function (response) {
            if (response.result) {
                var themeRowCount = response.data.length;
                if (themeRowCount == 0) {
                    $('#theme_list tbody').append('No record has been added yet....');
                }
                else {
                    var themes = '';
                    $.each(response.data, function (index, row) {
                        var shortDate = ShortDate(row.createdDate);
                        
                        themes += '<tr><td class="text-success font-weight-bold">' + response.levelStringList[row.level]//row.level
                            + '</td><td>' + row.themeId
                            + '</td><td>' + row.title
                            + '</td><td>' + row.rank
                            + '</td><td>' + '<input id="'+row.themeId+'" class="form_is_active_change" type="checkbox" data-onstyle="info" data-on="Active" data-off="Passive" '+((row.isActive===1)?"checked":"")+' >'
                            + '</td><td>' + shortDate
                            + '</td><td>' + ' <a class="btn btn-success" href="/Theme/Details/'+row.themeId + '">Edit</a><button type = "button" class="btn btn-danger" onclick = "ThemeDeleteConfirm(' + row.themeId + ')" ><i class="fa fa-sm fa-trash-alt"></i> Delete</button >'
                            + '</td></tr>'
                    });
                    $('#theme_list tbody').append(themes);
                }
            }
        },
        error: function (request, status, error) {
        },
        complete: function () {
            ToggleAdd();
            return false;
        }
    });
   

}
function IsActiveStateChange(themeId, isActiveState) {
    BlockPage();
    var data={"themeId":themeId,"isActive":isActiveState}
    $.ajax({
        type: 'POST',
        url: '/Theme/IsActiveStateChange',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: data,
        dataType: 'json',
        success: function (response) {

            if (response.result) {
                toastr.warning(response.message);
                $('#theme_card').show();
                ThemeGet();
            }
            else {
                toastr.error(response.message);
                ThemeGet();
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
function ShortDate(longDate) {
    var createdDate = new Date(longDate);
    var d = createdDate.getDate();
    var m = createdDate.getMonth();
    m += 1;  // JavaScript months are 0-11
    var y = createdDate.getFullYear();
    var shortDate = (d + "." + m + "." + y);
    return shortDate;
}
function ToggleAdd() {
    $('.form_is_active_change').bootstrapToggle();
}
