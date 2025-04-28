using System;
using Controllers;
using Models;
using Views;

namespace SistemaDePedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            OrderController orderController = new OrderController();
            ProductController productController = new ProductController();
            ClientController clientController = new ClientController();

            bool salida = false;
            do
            {
                console.WriteLine("1. Crear pedidos.");
                console.WriteLine("2. Mostrar pedidos.");
                console.WriteLine("3. Modificar pedido.");
                console.WriteLine("4. Eliminar pedido.");
                console.WriteLine("5. Salir.");
                char opc = console.ReadKey().Keychar;
                console.clear();
                switch (opc)
                {
                    case '1'=
                        orderController.CreateOrder();
                        break;
                    case "2":
                        orderController.ShowOrder();
                        break;
                }
            } while (!salida);
        }
    }
}
