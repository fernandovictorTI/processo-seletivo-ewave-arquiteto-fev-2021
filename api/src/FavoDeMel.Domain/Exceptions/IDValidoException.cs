using System;

namespace FavoDeMel.Domain.Exceptions
{
    public class IDValidoException : Exception
    {
        public IDValidoException(string nameOfIdObjeto) : base($"O id do {nameOfIdObjeto} deve ser válido.") { }
        public IDValidoException(string message, Exception inner) : base(message, inner) { }
    }
}