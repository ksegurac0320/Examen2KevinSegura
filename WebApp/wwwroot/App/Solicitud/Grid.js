"use strict";
//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
var SolicitudGrid;
(function (SolicitudGrid) {
    /*Mostrar el modal de confirmación*/
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar la solicitud ", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando..");
                App.AxiosProvider.SolicitudEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "La solicitud se elimino correctamente", icon: "success" }).then(function () {
                            return window.location.reload();
                        });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    SolicitudGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(SolicitudGrid || (SolicitudGrid = {}));
//# sourceMappingURL=Grid.js.map