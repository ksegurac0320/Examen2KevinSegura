//Kevin Segura Calvo Examen 2 UTC Progra 6 Viernes
using Entity;
using BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ISolicitudService
    {
        Task<DBEntity> Create(SolicitudEntity entity);
        Task<DBEntity> Delete(SolicitudEntity entity);
        Task<IEnumerable<SolicitudEntity>> Get();
        Task<SolicitudEntity> GetById(SolicitudEntity entity);
        Task<DBEntity> Update(SolicitudEntity entity);
    }

    public class SolicitudService : ISolicitudService
    {
        private readonly IDataAccess sql;
        public SolicitudService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region METODOS CRUD
        // METODO GET
        public async Task<IEnumerable<SolicitudEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<SolicitudEntity, ClienteEntity, ServicioEntity>("dbo.SolicitudObtener", "IdSolicitud,IdCliente,IdServicio");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<IEnumerable<SolicitudEntity>> GetLista() //REVISAR
        {
            try
            {
                var result = sql.QueryAsync<SolicitudEntity>("dbo.SolicitudLista");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO GETBYID
        public async Task<SolicitudEntity> GetById(SolicitudEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<SolicitudEntity>("dbo.SolicitudObtener", new { entity.IdSolicitud });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO CREATE
        public async Task<DBEntity> Create(SolicitudEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.SolicitudInsertar", new
                {
                    entity.IdCliente,
                    entity.IdServicio,
                    entity.Cantidad,
                    entity.Monto,
                    entity.FechaEntrega,
                    entity.UsuarioEntrega,
                    entity.Observaciones,
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO UPDATE
        public async Task<DBEntity> Update(SolicitudEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.SolicitudActualizar", new
                {
                    entity.IdSolicitud,
                    entity.IdCliente,
                    entity.IdServicio,
                    entity.Cantidad,
                    entity.Monto,
                    entity.FechaEntrega,
                    entity.UsuarioEntrega,
                    entity.Observaciones,
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO DELETE

        public async Task<DBEntity> Delete(SolicitudEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.SolicitudEliminar", new
                {
                    entity.IdSolicitud
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }

    //********************
}