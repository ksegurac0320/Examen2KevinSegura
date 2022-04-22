"use strict";
//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
var ServicioEdit;
(function (ServicioEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity
        },
        methods: {
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando...");
                    App.AxiosProvider.ServicioGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "El servicio se guardó con exito", icon: "success" })
                                .then(function () { return window.location.href = "Servicio/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
                else {
                    Toast.fire({ title: "Por favor complete los campos requeridos" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
    //**********************************
})(ServicioEdit || (ServicioEdit = {}));
//# sourceMappingURL=Edit.js.map