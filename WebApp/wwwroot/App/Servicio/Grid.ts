﻿//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
namespace ServicioGrid {
    /*Mostrar el modal de confirmación*/
    export function OnClickEliminar(id) {

        ComfirmAlert("¿Eliminar el servicio?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(result => {
                if (result.isConfirmed) {
                    Loading.fire("Borrando..");

                    App.AxiosProvider.ServicioEliminar(id).then(data => {
                        Loading.close();

                        if (data.CodeError == 0) {
                            Toast.fire({ title: "El servicio se elimino correctamente", icon: "success" }).then(() =>
                                window.location.reload());
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" })
                        }

                    } )
                }
            });
    }
    $("#GridView").DataTable();


    //*********************
}