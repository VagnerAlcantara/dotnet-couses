﻿using System.Collections.Generic;
using System.Linq;

namespace TesteImposto.Domain
{
    public abstract class BaseDomain
    {
        public BaseDomain()
        {
            Errors = new List<string>();
        }
        
        public bool IsValid { get { return !Errors.Any(); } }

        public List<string> Errors { get; private set; }

        internal void AddError(string erro)
        {
            Errors.Add(erro);
        }

        internal void AddError(IList<string> erros)
        {
            Errors.AddRange(erros);
        }
    }
}
