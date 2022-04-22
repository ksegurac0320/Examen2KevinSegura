//Kevin Segura Calvo Examen 2 UTC Progra 6 Viernes
using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IClienteService
    {
        Task<DBEntity> Create(ClienteEntity entity);
        Task<DBEntity> Delete(ClienteEntity entity);
        Task<IEnumerable<ClienteEntity>> Get();
        Task<IEnumerable<ClienteEntity>> GetLista();
        Task<ClienteEntity> GetById(ClienteEntity entity);
        Task<DBEntity> Update(ClienteEntity entity);

    }

    public class ClienteService : IClienteService
    {
        private readonly IDataAccess sql;

        public ClienteService(IDataAccess _sql)
        {
            sql = _sql;
        }


        #region METODOS CRUD
        // METODO GET
        public async Task<IEnumerable<ClienteEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity>("dbo.ClienteObtener");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }
        

        //METODO GETBYID
        public async Task<ClienteEntity> GetById(ClienteEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ClienteEntity>("dbo.ClienteObtener", new { entity.IdCliente });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO CREATE
        public async Task<DBEntity> Create(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClienteInsertar", new
                {
                    entity.Identificacion,
                    entity.IdTipoIdentificacion,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.FechaNacimiento,
                    entity.Nacionalidad,
                    entity.FechaDefuncion,
                    entity.Genero,
                    entity.NombreApellidosPadre,
                    entity.NombreApellidosMadre,
                    entity.Pasaporte,
                    entity.CuentaIBAN,
                    entity.CorreoNotifica

                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        //METODO UPDATE
        public async Task<DBEntity> Update(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClienteActualizar", new
                {
                    entity.IdCliente,
                    entity.Identificacion,
                    entity.IdTipoIdentificacion,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.FechaNacimiento,
                    entity.Nacionalidad,
                    entity.FechaDefuncion,
                    entity.Genero,
                    entity.NombreApellidosPadre,
                    entity.NombreApellidosMadre,
                    entity.Pasaporte,
                    entity.CuentaIBAN,
                    entity.CorreoNotifica
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //METODO DELETE
        public async Task<DBEntity> Delete(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClienteEliminar", new
                {
                    entity.IdCliente
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public async Task<IEnumerable<ClienteEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity>("dbo.ClienteListar");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


    /***************************************/
}
