using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _6toDAES4
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        private string connectionString = "Data Source=LAB1504-28\\SQLEXPRESS;Initial Catalog=Neptuno;User Id=userSharon;Password=123456";

        public Inicio()
        {
            InitializeComponent();
        }

        private void Proveedores_Click(object sender, RoutedEventArgs e)
        {
            MostrarDatosEnDataGrid("USP_ListarProveedores");
        }

        private void Productos_Click(object sender, RoutedEventArgs e)
        {
            MostrarDatosEnDataGrid("USP_ListarProductos");
        }

        private void MostrarDatosEnDataGrid(string storedProcedure)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        ResultadosDataGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos: " + ex.Message);
            }
        }
    }
}
