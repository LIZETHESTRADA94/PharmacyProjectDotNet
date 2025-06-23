using System;
using System.Text.RegularExpressions;
using PharmacyProject.Models;
using PharmacyProject.Exceptions;

namespace PharmacyProject.Services
{
    public class OrderService
    {
        public void ValidateOrder(Order order)
        {
            // Validar nombre del medicamento
            if (string.IsNullOrWhiteSpace(order.MedicineName) ||
                !Regex.IsMatch(order.MedicineName, @"^[a-zA-Z0-9 ]+$"))
            {
                throw new OrderException("Nombre de medicamento inválido.");
            }

            // Validar tipo de medicamento
            if (string.IsNullOrWhiteSpace(order.MedicineType))
            {
                throw new OrderException("Seleccione un tipo de medicamento.");
            }

            // Validar cantidad
            if (order.Quantity <= 0)
            {
                throw new OrderException("La cantidad debe ser un número positivo.");
            }

            // Validar distribuidor
            if (string.IsNullOrWhiteSpace(order.Distributor))
            {
                throw new OrderException("Seleccione un distribuidor.");
            }

            // Validar sucursales
            if (order.Branches == null || order.Branches.Count == 0)
            {
                throw new OrderException("Seleccione al menos una sucursal.");
            }
        }

        public void SendOrder(Order order)
        {
            // Simulación del envío del pedido
            Console.WriteLine("Pedido enviado.");
        }
    }
}
