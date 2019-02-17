using GerenciadorUsuarioService.Dominio.Interfaces;
using GerenciadorUsuarioService.Infra.SQL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using  GerenciadorUsuarioService.Infra.SQL.SqlCommand;
using System.ComponentModel;
using GerenciadorUsuarioService.Dominio.Entidades;
using System.Collections;

namespace GerenciadorUsuarioService.Infra.SQL.Repository
{
    public class LogRepository : ILogRepository
    {
        public Dominio.Entidades.Log Adicionar(Dominio.Entidades.Log log)
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionGestaoCorp())
                {
                    log.Id = cn.Query<int>(new LogSqlCommand().GetCommandInsert(log)).Single<int>();

                    foreach (var campo in log.cLogCampos)
                    {
                        campo.IdLog = log.Id;
                        cn.Query<int>(new LogSqlCommand().GetCommandInsertCamposAlterados(campo)).Single<int>();
                    }

                    return log;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar Log: " + ex.Message);
            }
        }

        public IEnumerable<Dominio.Entidades.Log> Buscar(System.Linq.Expressions.Expression<Func<Dominio.Entidades.Log, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dominio.Entidades.Log> ObterTodos()
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionGestaoCorp())
                {
                    return cn.Query<Dominio.Entidades.Log>(new LogSqlCommand().GetCommandSelectAll());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter todos os logs: " + ex.Message);
            }
        }

        public IEnumerable<Dominio.Entidades.Log> Filtrar(Dominio.Entidades.Log log)
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionGestaoCorp())
                {
                    var resultLog = cn.Query<Dominio.Entidades.Log>(new LogSqlCommand().GetCommandFilter(log));
      
                    foreach (var l in resultLog.Where(s => s.Id == log.Id))
                    {
                        l.cLogCampos = cn.Query<Dominio.Entidades.LogCamposAlterados>(new LogSqlCommand().GetCommandCamposAlteradosByIdLog(log.Id)).ToList();
                    }
                    return resultLog;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao filtrar logs: " + ex.Message);
            }
        }
        public IEnumerable<LogAcao> Filtrar(LogAcao acao)
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionGestaoCorp())
                {
                    return cn.Query<Dominio.Entidades.LogAcao>(new LogAcaoSqlCommand().GetCommandFilter(acao));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao filtrar logs: " + ex.Message);
            }
        }

        public IEnumerable<Dominio.Entidades.LogAcao> ObterAcao(System.Linq.Expressions.Expression<Func<Dominio.Entidades.LogAcao, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dominio.Entidades.LogAcao> ObterTodosAcao()
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionGestaoCorp())
                {
                    return cn.Query<Dominio.Entidades.LogAcao>(new LogAcaoSqlCommand().GetCommandSelectAll());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter todas as ações do log: " + ex.Message);
            }
        }

        public LogAcao ObterAcaoPorId(int id)
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionGestaoCorp())
                {
                    return cn.Query<Dominio.Entidades.LogAcao>(new LogAcaoSqlCommand().GetCommandSelectById(id)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter ações por nome: " + ex.Message);
            }
        }

     

    }
}
