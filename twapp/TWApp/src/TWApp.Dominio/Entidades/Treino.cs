using System;
using System.Collections.Generic;
using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.Entidades
{
    public class Treino : Entidade
    {
        public Atleta Atleta { get; private set; }
        public string Professor { get; private set; }
        public string Objetivo { get; private set; }
        public string Observacao { get; private set; }
        public DateTime Data { get; private set; }
        public ICollection<Exercicio> Exercicios { get; private set; }

        public Treino(Atleta atleta, string professor, string objetivo, string observacao, ICollection<Exercicio> exercicios)
        {
            Atleta = atleta;
            Professor = professor;
            Objetivo = objetivo;
            Observacao = observacao;
            Data = DateTime.Now;
            Exercicios = exercicios;
        }
    }
}
