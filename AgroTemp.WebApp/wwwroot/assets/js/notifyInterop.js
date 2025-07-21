window.notifyInterop = {
    notifySimple: function (type) {
        $.notify({
            icon: 'icon-bell',
            title: '',
            message: getMessage(type),
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

        function getMessage(type) {
            switch (type) {
                case "info": return "Informacja";
                case "success": return "Operacja zakończona sukcesem";
                case "warning": return "Uwaga!";
                case "danger": return "Błąd operacji";
                default: return "Powiadomienie";
            }
        }
    }
};

