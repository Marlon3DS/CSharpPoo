using System;
using System.Collections.Generic;

namespace ExercicioResolvido3
{
    class Pedido
    {
        public int Codigo { get; private set; }
        public DateTime Data { get; set; }
        public List<ItemPedido> Pedidos { get; set; }

        double ValorTotal()
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
