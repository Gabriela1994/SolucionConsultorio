$(document).ready(function () {
    $('#especialidad').change(function () {
        var especialidadId = $(this).val();
        if (especialidadId) {
            $.ajax({
                url: '/Turnos/Profesionales',
                type: 'GET',
                data: { especialidadId: especialidadId },
                success: function (result) {
                    $('#profesionales-container').html(result);
                }
            });
        } else {
            $('#profesionales-container').html('');
        }
    }); // Aquí cerramos correctamente la función de cambio
}); // Aquí cerramos correctamente la función ready

$(document).ready(function(){
    $('#buscarBtn').click(function () {
        var dni = $('#dnipaciente').val().trim(); // Obtiene el valor del input y lo limpia de espacios en blanco
        if (dni) {
            $.ajax({
                url: '/Pacientes/EncontrarPaciente',
                type: 'GET',
                data: { dni: dni },
                success: function (result) {
                    $('#data-paciente').html(result);
                }
            });
        } else {
            $('#profesionales-container').html('');
        }
    }); // Aquí cerramos correctamente la función click
});