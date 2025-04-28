using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Models;
using Views;

namespace Controllers
{
    class OrderController
    {
        private ClientController cController;
        private ProductController pController;

        public OrderController()
        {
            this.cController = new ClientController();
            this.pController = new ProductController();
        }

        public void CreateOrder()
        {
            Order temp = new Order();
            temp.client = cController.LoadClient();
            temp.setProductList(pController.LoadProductList());
        }
        public void ShowOrder()
        {
            cController.ShowClient(temp.client);
            pController.ShowProductList(temp.getProductList());
        }
        public void ModificOrder()
        {

        }
    }
}
