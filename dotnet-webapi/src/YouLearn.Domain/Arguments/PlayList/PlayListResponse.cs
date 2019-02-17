using System;

namespace YouLearn.Domain.Arguments.PlayList
{
    public class PlayListResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator PlayListResponse(Entities.PlayList playList)
        {
            return new PlayListResponse() { Id = playList.Id, Nome = playList.Nome };
        }
    }
}
