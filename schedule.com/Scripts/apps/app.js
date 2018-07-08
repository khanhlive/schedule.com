var SqlResultType = {
    Existed: -1,
    NotExisted: -2,
    OK: 1,
    Failed: 0,
    Exception: 2,
    None: 3
};

var ajax = {
    delete: function (url, key, successCallback) {
        $.ajax({
            url: url,
            contentType: 'application/json',
            //headers: header,
            type: 'DELETE',
            data: null,
            success: function (response) {
                toast.success('', 'Xóa thành công')
                console.log(response);
                if (successCallback) {
                    successCallback(response);
                }
            },
            error: function (err) {
                toast.error('', err.statusText);
            }
        })
    }
}

var toast = {
    info: function (title,message) {
        $.toast({
            heading: title,
            text: message,
            position: 'bottom-right',
            loaderBg: '#ff6849',
            icon: 'info',
            hideAfter: 3000,
            stack: 6
        });
    },
    warning: function (title, message) {
        $.toast({
            heading: title,
            text: message,
            position: 'bottom-right',
            loaderBg: '#ff6849',
            icon: 'warning',
            hideAfter: 3500,
            stack: 6
        });
    },
    success: function (title, message) {
        $.toast({
            heading: title,
            text: message,
            position: 'bottom-right',
            loaderBg: '#ff6849',
            icon: 'success',
            hideAfter: 3500,
            stack: 6
        });
    },
    error: function (title, message) {
        $.toast({
            heading: title,
            text: message,
            position: 'bottom-right',
            loaderBg: '#ff6849',
            icon: 'error',
            hideAfter: 3500

        });
    }
}