using System;

namespace FavoDeMel.Domain.Exceptions
{
    public class SituacaoValidaException : Exception
    {
        public SituacaoValidaException() : base($"A situação do pedido é obrigatoria.") { }
        public SituacaoValidaException(string message, Exception inner) : base(message, inner) { }
    }
}