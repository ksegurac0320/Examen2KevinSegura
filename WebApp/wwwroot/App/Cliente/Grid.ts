//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
namespace ClienteGrid {
    /*Mostrar el modal de confirmación*/
    export function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar el registro?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(result => {
                if (result.isConfirmed)
                {
                    Loading.fire("Borrando..");
                    App.AxiosProvider.ClienteEliminar(id).then(data => {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "El Registro se elimino correctamente", icon: "success" }).then(() =>
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