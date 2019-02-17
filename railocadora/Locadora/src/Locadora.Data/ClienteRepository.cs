using Locadora.Domain.Entities;
using Locadora.Domain.Interface.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Locadora.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private Connection _connection;

        public void Adicionar(Cliente entity)
        {
            try
            {
                using (_connection = new Connection())
                {

                    List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@id",  Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@cpf", Value = entity.Cpf, SqlDbType = SqlDbType.VarChar, Size = 15 },
                        new SqlParameter() { ParameterName = "@nome",Value = entity.Nome, SqlDbType = SqlDbType.VarChar, Size = 100 },
                        new SqlParameter() { ParameterName = "@datanascimento", Value = entity.DataNascimento},
                        new SqlParameter() { ParameterName = "@telefone", Value = entity.Telefone},
                        new SqlParameter() { ParameterName = "@email", Value = entity.Email },
                        new SqlParameter() { ParameterName = "@matricula", Value = entity.Matricula},
                        new SqlParameter() { ParameterName = "@ativo",  Value = entity.Ativo}
                    };

                    _connection.ExecuteProcedure("PROC_CLIENTE_INSERT", parameterList);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Cliente entity)
        {
            try
            {
                using (_connection = new Connection())
                {

                    List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@id",  Value= entity.Id, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@cpf", Value = entity.Cpf, SqlDbType = SqlDbType.VarChar, Size = 15 },
                        new SqlParameter() { ParameterName = "@nome",Value = entity.Nome, SqlDbType = SqlDbType.VarChar, Size = 100 },
                        new SqlParameter() { ParameterName = "@datanascimento", Value = entity.DataNascimento},
                        new SqlParameter() { ParameterName = "@telefone", Value = entity.Telefone},
                        new SqlParameter() { ParameterName = "@email", Value = entity.Email },
                        new SqlParameter() { ParameterName = "@matricula", Value = entity.Matricula},
                        new SqlParameter() { ParameterName = "@ativo",  Value = entity.Ativo}
                    };

                    _connection.ExecuteProcedure("PROC_CLIENTE_UPDATE", parameterList);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                using (_connection = new Connection())
                {
                    _connection.ExecuteProcedure("PROC_CLIENTE_DELETE", new SqlParameter() { ParameterName = "@id", Value = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inativar(int id)
        {
            try
            {
                Cliente cliente = this.Obter(id);

                cliente.Inativar();

                this.Alterar(cliente);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cliente Obter(int id)
        {
            try
            {
                using (_connection = new Connection())
                {
                    var dataTable = _connection.ExecuteReader("PROC_CLIENTE_SELECT_POR_ID", new SqlParameter() { ParameterName = "@id", Value = id });

                    var result = dataTable.AsEnumerable().Select(row => new Cliente(
                       row.Field<int>("ID"),
                       row.Field<int>("MATRICULA"),
                       row.Field<bool>("ATIVO"),
                       row.Field<string>("CPF"),
                       row.Field<int>("IDPESSOA"),
                       row.Field<string>("NOME"),
                       row.Field<DateTime>("DATANASCIMENTO"),
                       row.Field<string>("TELEFONE"),
                       row.Field<string>("EMAIL")
                       ));

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cliente Obter(string cpf)
        {
            try
            {
                using (_connection = new Connection())
                {
                    var dataTable = _connection.ExecuteReader("PROC_CLIENTE_SELECT_POR_CPF", new SqlParameter() { ParameterName = "@cpf", Value = cpf });

                    var result = dataTable.AsEnumerable().Select(row => new Cliente(
                       row.Field<int>("ID"),
                       row.Field<int>("MATRICULA"),
                       row.Field<bool>("ATIVO"),
                       row.Field<string>("CPF"),
                       row.Field<int>("IDPESSOA"),
                       row.Field<string>("NOME"),
                       row.Field<DateTime>("DATANASCIMENTO"),
                       row.Field<string>("TELEFONE"),
                       row.Field<string>("EMAIL")
                       ));

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        
    }
}
