﻿//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
namespace SolicitudGrid {
    /*Mostrar el modal de confirmación*/
    export function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar la solicitud ", "Eliminar", "warning", '#3085d6', '#d33')
            .then(result => {
                if (result.isConfirmed) {
                    Loading.fire("Borrando..");

                    App.AxiosProvider.SolicitudEliminar(id).then(data => {
                        Loading.close();

                        if (data.CodeError == 0) {
                            Toast.fire({ title: "La solicitud se elimino correctamente", icon: "success" }).then(() =>
                                window.location.reload());
                        }
                        else
                        {
                            Toast.fire({ title: data.MsgError, icon: "error" })

                        }
                    })
                }
            });
    }
    $("#GridView").DataTable();
}