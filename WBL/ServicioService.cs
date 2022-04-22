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
    public interface IServicioService
    {
        Task<DBEntity> Create(ServicioEntity entity);
        Task<DBEntity> Delete(ServicioEntity entity);
        Task<IEnumerable<ServicioEntity>> Get();
        Task<IEnumerable<ServicioEntity>> GetLista();
        Task<ServicioEntity> GetById(ServicioEntity entity);
        Task<DBEntity> Update(ServicioEntity entity);

    }

    public class ServicioService : IServicioService
    {
        private readonly IDataAccess sql;
        public ServicioService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region METODOS CRUD
        // METODO GET
        public async Task<IEnumerable<ServicioEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ServicioEntity>("dbo.ServicioObtener");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<ServicioEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ServicioEntity>("dbo.ServicioListar");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO GETBYUD
        public async Task<ServicioEntity> GetById(ServicioEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ServicioEntity>("dbo.ServicioObtener", new { entity.IdServicio });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        //METODO CREATE
        public async Task<DBEntity> Create(ServicioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ServicioInsertar", new
                {
                    entity.NombreServicio,
                    entity.PlazoEntrega,
                    entity.CostoServicio,
                    entity.Estado,
                    entity.CuentaContable
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO UPDATE
        public async Task<DBEntity> Update(ServicioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ServicioActualizar", new
                {
                    entity.IdServicio,
                    entity.NombreServicio,
                    entity.PlazoEntrega,
                    entity.CostoServicio,
                    entity.Estado,
                    entity.CuentaContable
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO DELETE
        public async Task<DBEntity> Delete(ServicioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ServicioEliminar", new
                {
                    entity.IdServicio
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


    //*****************
}
