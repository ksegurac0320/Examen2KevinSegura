"use strict";
//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
var ServicioGrid;
(function (ServicioGrid) {
    /*Mostrar el modal de confirmación*/
    function OnClickEliminar(id) {
        ComfirmAlert("¿Eliminar el servicio?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando..");
                App.AxiosProvider.ServicioEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "El servicio se elimino correctamente", icon: "success" }).then(function () {
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
    ServicioGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
    //*********************
})(ServicioGrid || (ServicioGrid = {}));
//# sourceMappingURL=Grid.js.map