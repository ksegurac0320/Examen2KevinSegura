﻿namespace App.AxiosProvider{

    export const ClienteGuardar = (entity) => axios.post<DBEntity>("Cliente/Edit", entity).then(({ data }) => data);
    export const ClienteEliminar = (id) => axios.delete<DBEntity>("Cliente/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const SolicitudGuardar = (entity) => axios.post<DBEntity>("Solicitud/Edit", entity).then(({ data }) => data);
    export const SolicitudEliminar = (id) => axios.delete<DBEntity>("Solicitud/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const ServicioEliminar = (id) => axios.delete<DBEntity>("Servicio/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const ServicioGuardar = (entity) => axios.post<DBEntity>("Servicio/Edit", entity).then(({ data }) => data);
}




