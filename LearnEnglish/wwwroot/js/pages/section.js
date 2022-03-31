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

})
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
                alert(response.result);
               
            }
            alert(response.result);

        },
        error: function (request, status, error) {
        },
        complete: function () {
            
            return false;
        }
    });

}