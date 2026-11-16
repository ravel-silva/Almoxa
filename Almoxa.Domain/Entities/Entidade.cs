using System;
using System.Collections.Generic;
using System.Text;

namespace Almoxa.Domain.Entities
{
    public class Entidade
    {
        public int Id { get; protected set; }

        public DateTime CriadeEM { get; protected set; }
        public DateTime? AtualizadoEM { get; protected set; }
    }
}
