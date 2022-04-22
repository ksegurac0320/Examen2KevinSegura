"use strict";
//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
var ClienteEdit;
(function (ClienteEdit) {
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
                    App.AxiosProvider.ClienteGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "El client se  se guardó con exito", icon: "success" })
                                .then(function () { return window.location.href = "Cliente/Grid"; });
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
    //**********************
})(ClienteEdit || (ClienteEdit = {}));
//# sourceMappingURL=Edit.js.map