using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Views
{
    public static class OrderView
    {
        public static void ShowProducts(List<Product> list)
        {
            ProductView.ShowProductList(list);
        }

        public static void ShowClient(Client client)
        {
            ClientView.ShowClient(client);
        }
    }
}
