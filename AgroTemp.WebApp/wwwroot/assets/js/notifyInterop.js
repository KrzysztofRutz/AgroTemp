window.notifyInterop = {
    notifySimple: function (type, messageFromApp) {
        $.notify({
            icon: 'icon-bell',
            title: '',
            message: getMessage(type, messageFromApp),
            url: '',
            target: '_blank'
        }, {
            element: 'body',
            type: type,
            allow_dismiss: true,
            placement: {
                from: "top",
                align: "right"
            },
            offset: 20,
            spacing: 10,
            z_index: 1031,
            delay: 5000,
            timer: 1000,
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
            icon_type: 'class'
        });

        function getMessage(type, messageFromApp) {
            switch (type) {
                case "info": return messageFromApp;
                case "success": return messageFromApp;
                case "warning": return messageFromApp;
                case "danger": return messageFromApp;
                default: return messageFromApp;
            }
        }
    }
};

