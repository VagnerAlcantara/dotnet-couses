using System;
using System.Collections.Generic;
using TWApp.Compartilhado.Entidades;
using TWApp.Dominio.ObjetosDeValor;

namespace TWApp.Dominio.Entidades
{
    public class Atleta: Entidade
    {
        public Atleta(Nome nome, DateTime dataNascimento, Cpf cpf, Usuario usuario)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
        }

        public Nome Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Cpf Cpf { get; private set; }
        public Rg Rg { get; private set; }
        public virtual Contato Contato { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public virtual ICollection<Treino> Treinos { get; private set; }

        public void AdicionarRg(Rg rg)
        {
            Rg = rg;
        }
        public void AdicionarContato(Contato contato)
        {
            Contato = contato;
        }
        public void AdicionarEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
        public void AdicionarTreino(Treino treino)
        {
            Treinos.Add(treino);
        }
    }
}
