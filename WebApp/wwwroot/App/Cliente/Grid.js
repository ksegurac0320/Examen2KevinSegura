"use strict";
//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
var ClienteGrid;
(function (ClienteGrid) {
    /*Mostrar el modal de confirmación*/
    function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar el registro?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando..");
                App.AxiosProvider.ClienteEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "El Registro se elimino correctamente", icon: "success" }).then(function () {
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
    ClienteGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(ClienteGrid || (ClienteGrid = {}));
//# sourceMappingURL=Grid.js.map