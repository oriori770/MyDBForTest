using Microsoft.Data.SqlClient;
using System.Data;


namespace MyDBForTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public async void LoadDBAync(string query)
        {
            string connectionString = "Server=DESKTOP-8UL1N63;Database=test;User Id=sa;Password=1234;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    string SqlQuery = $"SELECT * FROM Table_1 where name = @query";
                    SqlCommand command = new SqlCommand(SqlQuery, connection);
                    command.Parameters.AddWithValue("@query", query);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                }
            }
        }

        public async void LoadDBAync2()
        {
            string connectionString = "Server=DESKTOP-8UL1N63;Database=test;User Id=sa;Password=1234;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    string SqlQuery = $"SELECT * FROM Table_1";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, connection);
                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string query = textBox1.Text;
            LoadDBAync(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDBAync2();
        }
    }
}
