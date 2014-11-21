$(function () {
    $('.LinkBorrado').click(function () {
        var respuesta = confirm('Esta seguro de que desea borrar el album? Todas sus canciones también serán eliminadas');
        return respuesta
    });
});