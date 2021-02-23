using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Test
{
    public static class HelperEntitiesStaticTest
    {
        public static IEnumerable<object[]> GuidsNullOrEmpty =>
        new List<object[]>
        {
            new object[] { Guid.Empty },
            new object[] { default(Guid) }
        };
    }

    public class HelperEntitiesTest
    {   
        public Guid GuidEmpty
        {
            get
            {
                return Guid.Empty;
            }
        }

        public Guid GuidNull
        {
            get
            {
                return default(Guid);
            }
        }

        public NomeVo Nome
        {
            get
            {
                return new NomeVo("Fernando Victor Pereira Santiago");
            }
        }

        public NomeVo NomeInvalido
        {
            get
            {
                return new NomeVo("F");
            }
        }

        public NomeVo NomeProduto
        {
            get
            {
                return new NomeVo("X-Tudo");
            }
        }

        public ComandaVo ComandaVo
        {
            get
            {
                return new ComandaVo(1);
            }
        }

        public Garcom Garcom
        {
            get
            {
                return new Garcom(this.Nome, "(65) 98414-3977");
            }
        }

        public Garcom GarcomInvalido
        {
            get
            {
                return new Garcom(this.NomeInvalido, "(65) 98414-3977123123123123");
            }
        }

        public Produto Produto
        {
            get
            {
                return new Produto(NomeProduto, 15.50m);
            }
        }

        public Comanda Comanda
        {
            get
            {
                return new Comanda(ComandaVo);
            }
        }

        public Cliente Cliente
        {
            get
            {
                return new Cliente(Nome);
            }
        }

        public Pedido Pedido
        {
            get
            {
                return new Pedido(Garcom, Comanda, Cliente);
            }
        }

        public List<ProdutoPedido> ProdutosPedido
        {
            get
            {
                return new List<ProdutoPedido>() { new ProdutoPedido(Guid.NewGuid(), 10) };
            }
        }
    }
}
