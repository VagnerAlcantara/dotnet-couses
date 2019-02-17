using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface ILogRepository 
    {
        Log Adicionar(Log log);
        IEnumerable<Log> Buscar(Expression<Func<Log, bool>> predicate);
        IEnumerable<Log> ObterTodos();
        IEnumerable<LogAcao> ObterAcao(Expression<Func<LogAcao, bool>> predicate);
        IEnumerable<LogAcao> ObterTodosAcao();
        LogAcao ObterAcaoPorId(int id);
        IEnumerable<Log> Filtrar(Log log);
    }
}
