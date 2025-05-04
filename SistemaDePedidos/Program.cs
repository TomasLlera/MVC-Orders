using System;
using Controllers;
using Repository;
using Models;
using System.IO;

namespace SistemaDePedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            OrderController oController = new OrderController();

            bool salida = false;
            do
            {
                int input = 0;
                Console.WriteLine("Ingrese una opcion");
                Console.WriteLine("Opcion 1: Cargar pedido");
                Console.WriteLine("Opcion 2: Mostrar pedido");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        oController.CreateOrder();
                        break;
                    case 2:
                        oController.ShowOrders();
                        break;
                

                }
            } while (!salida);
        }
    }
}
