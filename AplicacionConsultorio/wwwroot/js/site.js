$(document).ready(function () {
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


const myModal = document.getElementById('staticBackdrop')
const myInput = document.getElementById('dnipaciente')
const prueba = document.getElementById('modal-prueba')

function validarInput() {
    if (myInput.value.trim() === '') {
        alert('Por favor ingrese un valor en el campo.');
    } else {
        const insertar_modal = document.createElement("div")

        insertar_modal.innerHTML = `
                <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="staticBackdropLabel">Paciente encontrado:</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div id="data-paciente" class="container-md">

                                <!-- Aquí se mostrará los datos del paciente -->
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>`

        prueba.appendChild(insertar_modal);
    }
};