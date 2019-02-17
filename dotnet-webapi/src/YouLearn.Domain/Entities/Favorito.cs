using System;
using YouLearn.Domain.Base;

namespace YouLearn.Domain.Entities
{
    public class Favorito : EntityBase
    {
        protected Favorito()
        {

        }
        public Favorito(Video video, Usuario usuario)
        {
            Video = video;
            Usuario = usuario;
        }

        public Video Video { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}
