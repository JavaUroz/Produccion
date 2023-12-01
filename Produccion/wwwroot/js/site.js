$(document).ready(function () {
    $('#table').DataTable({
        "language": {
            "url": '//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json' // Opcional: Traducción al español
        },
        "searching": "true",
        "ordering": true,
        "order": [[0, 'desc']],
    });
});

$(document).ready(function () {
    $('#mi-selector').select2();
});