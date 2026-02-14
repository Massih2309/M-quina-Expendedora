using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Máquina_Expendedora
{
    public partial class Form1 : Form
    {
        // CONEXION
        string conexion = @"Server=DESKTOP-BTKE2PV\SQLEXPRESS;Database=MaquinaExpendedoraDB;Trusted_Connection=True;";

        // VARIABLES GLOBALES (SOLO UNA VEZ)
        private decimal precioProducto = 0;
        private decimal dineroIngresado = 0;
        private int productoSeleccionadoId = 0;
        private string montoTexto = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbProducto.Visible = false;
            lblProcesando.Visible = false;

            lblMonto.Text = "$0.00";
            lblSobrante.Text = "$0.00";
            lblPrecio.Text = "$0.00";

            CargarProductos();  // Llamada al método para cargar los productos
        }




        // CUANDO SELECCIONAS PRODUCTO 1
        private void pb1_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 1;
            precioProducto = 30;

            pbSeleccionado.Image = pb1.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        // BOTONES NUMÉRICOS
        private void btn1_Click(object sender, EventArgs e)
        {
            dineroIngresado = dineroIngresado * 10 + 1;
            lblMonto.Text = "$" + dineroIngresado.ToString("0.00");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            dineroIngresado = dineroIngresado * 10 + 2;
            lblMonto.Text = "$" + dineroIngresado.ToString("0.00");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            dineroIngresado = dineroIngresado * 10 + 3;
            lblMonto.Text = "$" + dineroIngresado.ToString("0.00");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dineroIngresado >= precioProducto)
            {
                decimal sobrante = dineroIngresado - precioProducto;
                lblSobrante.Text = "$" + sobrante.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Dinero insuficiente");
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionadoId == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            if (dineroIngresado < precioProducto)
            {
                MessageBox.Show("Dinero insuficiente");
                return;
            }

            pbProducto.Value = 0;
            pbProducto.Visible = true;
            lblProcesando.Visible = true;

            Timer timer = new Timer();
            timer.Interval = 50;

            timer.Tick += (s, ev) =>
            {
                pbProducto.Value += 5;

                if (pbProducto.Value >= 100)
                {
                    timer.Stop();

                    pbProducto.Visible = false;
                    lblProcesando.Visible = false;

                    // Llamamos al método para actualizar la cantidad
                    ActualizarCantidadEnBD();

                    // Refrescamos el DataGridView
                    CargarProductos();

                    MessageBox.Show("Producto entregado");

                    dineroIngresado = 0;
                    montoTexto = "";
                    lblMonto.Text = "0.00";
                    lblSobrante.Text = "0.00";
                }
            };

            timer.Start();
        }

        private void pb2_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 2;
            precioProducto = 35;

            pbSeleccionado.Image = pb2.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb3_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 3;
            precioProducto = 28;

            pbSeleccionado.Image = pb3.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb4_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 4;
            precioProducto = 30;

            pbSeleccionado.Image = pb4.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb5_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 5;
            precioProducto = 25;

            pbSeleccionado.Image = pb5.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb6_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 6;
            precioProducto = 27;

            pbSeleccionado.Image = pb6.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb7_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 7;
            precioProducto = 26;

            pbSeleccionado.Image = pb7.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb8_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 8;
            precioProducto = 29;

            pbSeleccionado.Image = pb8.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb9_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 9;
            precioProducto = 20;

            pbSeleccionado.Image = pb9.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb10_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 10;
            precioProducto = 20;

            pbSeleccionado.Image = pb10.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb11_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 11;
            precioProducto = 20;

            pbSeleccionado.Image = pb11.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void pb12_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 12;
            precioProducto = 20;

            pbSeleccionado.Image = pb12.Image;
            lblPrecio.Text = "$" + precioProducto.ToString("0.00");
        }

        private void AgregarNumero(string numero)
        {
            {
                montoTexto += numero;

                if (decimal.TryParse(montoTexto, out decimal valor))
                {
                    dineroIngresado = valor;
                    lblMonto.Text = valor.ToString("0.00");
                }
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            AgregarNumero("0");
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            AgregarNumero("1");
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            AgregarNumero("2");
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            AgregarNumero("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AgregarNumero("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AgregarNumero("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AgregarNumero("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AgregarNumero("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AgregarNumero("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AgregarNumero("9");
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (productoSeleccionadoId == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            if (dineroIngresado >= precioProducto)
            {
                decimal sobrante = dineroIngresado - precioProducto;

                lblSobrante.Text = "$" + sobrante.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Dinero insuficiente");
            }
        }

        private void CargarProductos()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, ProductoNombre, Codigo, Precio, Cantidad FROM Productos_", con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvProductos.DataSource = dt;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto en la tabla");
                return;
            }

            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);

            int cantidadActual = Convert.ToInt32(
                dgvProductos.CurrentRow.Cells["Cantidad"].Value);

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Cantidad actual: " + cantidadActual +
                "\n\nIngrese cantidad a agregar (+) o quitar (-):",
                "Actualizar Producto",
                "0");

            if (!int.TryParse(input, out int cambio))
                return;

            int nuevaCantidad = cantidadActual + cambio;

            if (nuevaCantidad < 0)
                nuevaCantidad = 0;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Productos_ SET Cantidad = @Cantidad WHERE Id = @Id", con);

                cmd.Parameters.AddWithValue("@Cantidad", nuevaCantidad);
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cantidad actualizada correctamente");

            CargarProductos();
        }

        private void btnC_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarCantidadEnBD()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();

                // Actualiza la cantidad en la base de datos
                string query = "UPDATE Productos_ SET Cantidad = Cantidad - 1 WHERE Id = @Id AND Cantidad > 0";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", productoSeleccionadoId);

                int filasAfectadas = cmd.ExecuteNonQuery();

                // Si no se actualiza la cantidad, significa que el producto está agotado
                if (filasAfectadas == 0)
                {
                    MessageBox.Show("El producto está agotado.");
                }
            }
        }

    }
}
