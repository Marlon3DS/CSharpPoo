using System;
using System.Collections.Generic;

namespace ExercicioResolvido3
{
    class Pedido
    {
        public int Codigo { get; private set; }
        public DateTime Data { get; set; }
        public List<ItemPedido> Pedidos { get; set; }

        public Pedido(int codigo, DateTime data, List<ItemPedido> pedidos)
        {
            Codigo = codigo;
            Data = data;
            Pedidos = pedidos;
        }

        public double ValorTotal()
        {
            double total = 0;
            foreach (ItemPedido item in Pedidos)
            {
                total += item.SubTotal(); 
            }
            return total;
        }
    }
}
