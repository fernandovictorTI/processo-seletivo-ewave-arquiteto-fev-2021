using FavoDeMel.Domain.Dto;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Querys.Comanda.Consultas
{
    public class ObterComandasQuery : Notifiable<Notification>, IRequest<IEnumerable<ComandaDto>>
    {
        public ObterComandasQuery(int pagina, int quantidade)
        {
            if (pagina <= 0)
                throw new ArgumentNullException("Pagina atual da paginação deve ser maior que 0.");

            if (quantidade <= 0)
                throw new ArgumentNullException("Quantidade atual da paginação deve ser maior que 0.");

            Pagina = pagina;
            Quantidade = quantidade;
        }

        public int Pagina { get; set; }
        public int Quantidade { get; set; }
    }
}
