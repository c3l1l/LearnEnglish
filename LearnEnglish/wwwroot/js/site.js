function BlockPage() {
    $.blockUI({
        css: {
            border: 'none',
            padding: '10px',
            backgroundColor: '#000000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff',
            "z-index": 1200
        },
        baseZ: 1180,
        message: 'Please, wait....'
    });
}

function UnBlockPage() {
    $.unblockUI();
}