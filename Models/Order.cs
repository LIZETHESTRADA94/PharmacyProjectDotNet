using System;
using System.Collections.Generic;

namespace PharmacyProject.Models
{
    public class Order
    {
        public string MedicineName { get; set; }
        public string MedicineType { get; set; }
        public int Quantity { get; set; }
        public string Distributor { get; set; }
        public List<string> Branches { get; set; }

        public Order()
        {
            Branches = new List<string>();
        }

        public Order(string medicineName, string medicineType, int quantity, string distributor, List<string> branches)
        {
            MedicineName = medicineName;
            MedicineType = medicineType;
            Quantity = quantity;
            Distributor = distributor;
            Branches = branches ?? new List<string>();
        }

        public void SetQuantity(string quantityText)
        {
            if (!int.TryParse(quantityText, out int result))
            {
                throw new FormatException("La cantidad debe ser un número entero.");
            }
            Quantity = result;
        }
    }
}
