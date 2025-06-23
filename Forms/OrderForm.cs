using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PharmacyProject.Models;
using PharmacyProject.Services;
using PharmacyProject.Exceptions;

namespace PharmacyProject
{
    public partial class OrderForm : Form
    {
        private const string PRINCIPAL_ADDRESS = "Calle de la Rosa n. 28";
        private const string SECONDARY_ADDRESS = "Calle Alcazabilla n. 3";
        private const string TYPE_EMPTY_OPTION = "Seleccionar...";

        private OrderService orderService;

        // Controles del formulario
        private Label lblTitle;
        private Label lblMedicineName;
        private Label lblMedicineType;
        private Label lblQuantity;
        private Label lblDistributor;
        private Label lblBranch;

        private TextBox txtMedicineName;
        private ComboBox cmbMedicineType;
        private TextBox txtQuantity;

        private RadioButton rbCofarma;
        private RadioButton rbEmpsephar;
        private RadioButton rbCemefar;
        private GroupBox gbDistributor;

        private CheckBox cbPrincipal;
        private CheckBox cbSecondary;
        private GroupBox gbBranches;

        private Button btnClear;
        private Button btnConfirm;

        public OrderForm()
        {
            orderService = new OrderService();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configuración del formulario
            this.Text = "Crear Nueva Orden";
            this.Size = new Size(600, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Título
            lblTitle = new Label();
            lblTitle.Text = "Crear Nueva Orden de Medicamento";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(50, 20);
            lblTitle.Size = new Size(500, 30);

            // Nombre del medicamento
            lblMedicineName = new Label();
            lblMedicineName.Text = "Nombre del Medicamento:";
            lblMedicineName.Location = new Point(50, 70);
            lblMedicineName.Size = new Size(150, 23);

            txtMedicineName = new TextBox();
            txtMedicineName.Location = new Point(220, 70);
            txtMedicineName.Size = new Size(300, 23);

            // Tipo de medicamento
            lblMedicineType = new Label();
            lblMedicineType.Text = "Tipo del Medicamento:";
            lblMedicineType.Location = new Point(50, 110);
            lblMedicineType.Size = new Size(150, 23);

            cmbMedicineType = new ComboBox();
            cmbMedicineType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedicineType.Items.AddRange(new string[]
            {
                TYPE_EMPTY_OPTION,
                "Analgésico",
                "Analéptico",
                "Anestésico",
                "Antiácido",
                "Antidepresivo",
                "Antibiótico"
            });
            cmbMedicineType.SelectedIndex = 0;
            cmbMedicineType.Location = new Point(220, 110);
            cmbMedicineType.Size = new Size(300, 23);

            // Cantidad
            lblQuantity = new Label();
            lblQuantity.Text = "Cantidad:";
            lblQuantity.Location = new Point(50, 150);
            lblQuantity.Size = new Size(150, 23);

            txtQuantity = new TextBox();
            txtQuantity.Location = new Point(220, 150);
            txtQuantity.Size = new Size(300, 23);

            // Distribuidor
            lblDistributor = new Label();
            lblDistributor.Text = "Distribuidor:";
            lblDistributor.Location = new Point(50, 190);
            lblDistributor.Size = new Size(150, 23);

            gbDistributor = new GroupBox();
            gbDistributor.Location = new Point(220, 180);
            gbDistributor.Size = new Size(300, 50);

            rbCofarma = new RadioButton();
            rbCofarma.Text = "Cofarma";
            rbCofarma.Location = new Point(10, 20);
            rbCofarma.Size = new Size(80, 20);

            rbEmpsephar = new RadioButton();
            rbEmpsephar.Text = "Empsephar";
            rbEmpsephar.Location = new Point(100, 20);
            rbEmpsephar.Size = new Size(90, 20);

            rbCemefar = new RadioButton();
            rbCemefar.Text = "Cemefar";
            rbCemefar.Location = new Point(200, 20);
            rbCemefar.Size = new Size(80, 20);

            gbDistributor.Controls.AddRange(new Control[] { rbCofarma, rbEmpsephar, rbCemefar });

            // Sucursales
            lblBranch = new Label();
            lblBranch.Text = "Sucursal:";
            lblBranch.Location = new Point(50, 250);
            lblBranch.Size = new Size(150, 23);

            gbBranches = new GroupBox();
            gbBranches.Location = new Point(220, 240);
            gbBranches.Size = new Size(300, 50);

            cbPrincipal = new CheckBox();
            cbPrincipal.Text = "Principal";
            cbPrincipal.Location = new Point(10, 20);
            cbPrincipal.Size = new Size(80, 20);

            cbSecondary = new CheckBox();
            cbSecondary.Text = "Secundaria";
            cbSecondary.Location = new Point(100, 20);
            cbSecondary.Size = new Size(90, 20);

            gbBranches.Controls.AddRange(new Control[] { cbPrincipal, cbSecondary });

            // Botones
            btnClear = new Button();
            btnClear.Text = "Limpiar";
            btnClear.Location = new Point(200, 330);
            btnClear.Size = new Size(100, 35);
            btnClear.BackColor = Color.LightGray;
            btnClear.Click += BtnClear_Click;

            btnConfirm = new Button();
            btnConfirm.Text = "Confirmar";
            btnConfirm.Location = new Point(320, 330);
            btnConfirm.Size = new Size(100, 35);
            btnConfirm.BackColor = Color.LightBlue;
            btnConfirm.Click += BtnConfirm_Click;

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[]
            {
                lblTitle, lblMedicineName, txtMedicineName,
                lblMedicineType, cmbMedicineType,
                lblQuantity, txtQuantity,
                lblDistributor, gbDistributor,
                lblBranch, gbBranches,
                btnClear, btnConfirm
            });

            this.ResumeLayout();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmOrder();
        }

        public void ClearForm()
        {
            txtMedicineName.Clear();
            cmbMedicineType.SelectedIndex = 0;
            txtQuantity.Clear();
            rbCofarma.Checked = false;
            rbEmpsephar.Checked = false;
            rbCemefar.Checked = false;
            cbPrincipal.Checked = false;
            cbSecondary.Checked = false;
        }

        private void ConfirmOrder()
        {
            try
            {
                Order order = GetOrder();
                orderService.ValidateOrder(order);

                // Abrir ventana de confirmación
                ConfirmationWindow confirmationWindow = new ConfirmationWindow(this, order, orderService);
                confirmationWindow.ShowDialog();
            }
            catch (OrderException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ShowError("Error confirmando orden: " + ex.Message);
            }
        }

        private Order GetOrder()
        {
            string name = txtMedicineName.Text.Trim();
            string type = cmbMedicineType.SelectedItem.ToString();
            string quantityText = txtQuantity.Text.Trim();

            string distributor = null;
            if (rbCofarma.Checked) distributor = "Cofarma";
            else if (rbEmpsephar.Checked) distributor = "Empsephar";
            else if (rbCemefar.Checked) distributor = "Cemefar";

            List<string> branches = new List<string>();
            if (cbPrincipal.Checked) branches.Add(PRINCIPAL_ADDRESS);
            if (cbSecondary.Checked) branches.Add(SECONDARY_ADDRESS);

            // Limpiar tipo si es la opción vacía
            if (type == TYPE_EMPTY_OPTION) type = "";
            if (string.IsNullOrWhiteSpace(quantityText)) quantityText = "0";

            Order order = new Order(name, type, 0, distributor, branches);

            try
            {
                order.SetQuantity(quantityText);
            }
            catch (FormatException)
            {
                throw new OrderException("La cantidad debe ser un número entero.");
            }

            return order;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}