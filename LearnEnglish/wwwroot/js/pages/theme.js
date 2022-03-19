$(function () {
    $('#theme_delete').submit(function (event) {
        alert('test');
        ThemeDelete();
    });
    $('#form_theme_add').submit(function (event) {
        event.preventDefault();
        ThemeAdd();
        return false;
    });


    //Toggle button status control
        //$('#theme_active_passive').change(function () {
        //    if ($(this).prop("checked") == true)
        //    {
        //        alert("on..");
        //    }
        //    else
        //    {
        //        alert("off..");
        //    }
        //})
})
function ThemeDelete() {
    alert("Theme delete");
}


function ThemeAdd(parameters) {
    var formData = $('#form_theme_add').serialize();
    
    $.ajax({
        type: 'POST',
        url: '/Theme/Add',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: formData,
        dataType: 'json',
        success: function(response) {
            alert(response.Sonuc);
            if (response.Sonuc) {
                ThemeGet();
                //basarili bir sekilde eklendiyse, Controllerdan gelen AjaxResponse ile kontrol ediyoruz.
                //Todo buraya basariliysa yapilacaklari ekle.
            }
            else { 
                //Todo buraya basarisiz ise yapilacaklari ekle
            }
        },
        error: function (request, status, error) {
            alert(request+status+error);
        },
        complete: function () {
            UnBlockPage();
            return false;
        }
    });
    alert('ajax bitti');

}
function ThemeGet() {
    alert("Theme get metodu calisti.");
}