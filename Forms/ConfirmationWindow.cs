using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PharmacyProject.Models;
using PharmacyProject.Services;

namespace PharmacyProject
{
    public partial class ConfirmationWindow : Form
    {
        private Order order;
        private OrderService orderService;
        private OrderForm orderForm;

        private Label lblInfo;
        private Label lblBranches;
        private Button btnCancel;
        private Button btnSend;

        public ConfirmationWindow(OrderForm orderForm, Order order, OrderService orderService)
        {
            this.orderForm = orderForm;
            this.order = order;
            this.orderService = orderService;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configuración de la ventana
            this.Text = $"Pedido al distribuidor {order.Distributor}";
            this.Size = new Size(450, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Información del pedido
            string info = $"{order.Quantity} unidades del {order.MedicineType.ToLower()} {order.MedicineName}";
            lblInfo = new Label();
            lblInfo.Text = info;
            lblInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.Location = new Point(20, 30);
            lblInfo.Size = new Size(400, 30);

            // Información de sucursales
            string branchText = "Para la farmacia situada en " + string.Join(" y ", order.Branches);
            lblBranches = new Label();
            lblBranches.Text = branchText;
            lblBranches.TextAlign = ContentAlignment.MiddleCenter;
            lblBranches.Location = new Point(20, 70);
            lblBranches.Size = new Size(400, 40);

            // Botones
            btnCancel = new Button();
            btnCancel.Text = "Cancelar";
            btnCancel.Location = new Point(120, 120);
            btnCancel.Size = new Size(100, 30);
            btnCancel.Click += BtnCancel_Click;

            btnSend = new Button();
            btnSend.Text = "Enviar Pedido";
            btnSend.Location = new Point(240, 120);
            btnSend.Size = new Size(100, 30);
            btnSend.BackColor = Color.LightGreen;
            btnSend.Click += BtnSend_Click;

            // Agregar controles
            this.Controls.AddRange(new Control[]
            {
                lblInfo, lblBranches, btnCancel, btnSend
            });

            this.ResumeLayout();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            SendOrder();
        }

        private void SendOrder()
        {
            orderService.SendOrder(order);
            ShowConfirmation();
            orderForm.ClearForm();
            this.Close();
        }

        private void ShowConfirmation()
        {
            MessageBox.Show("Su pedido ha sido enviado exitosamente.",
                          "Pedido enviado",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
    }
}
