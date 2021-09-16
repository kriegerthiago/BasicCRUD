using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CadastroCRUDwinForm
{
    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;

        string strSQL;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Server=DESKTOP-R2ING0Q;Database=ClienteLoja;User Id=sa;Password=@thiago1337;");

                strSQL = "INSERT INTO Table_Cliente (Nome,Numero) VALUES (@NOME,@NUMERO)";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                conexao.Open();

                comando.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                comando = null; // Para poder instanciar de novo 
                conexao = null;
            }

        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Server=DESKTOP-R2ING0Q;Database=ClienteLoja;User Id=sa;Password=@thiago1337;");

                strSQL = "SELECT * FROM Table_Cliente";

                
                DataSet dataSet = new DataSet();

                da = new SqlDataAdapter(strSQL,conexao);
                
                conexao.Open();

                da.Fill(dataSet);

                dvgDados.DataSource = dataSet.Tables[0];

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                comando = null; // Para poder instanciar de novo 
                conexao = null;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Server=DESKTOP-R2ING0Q;Database=ClienteLoja;User Id=sa;Password=@thiago1337;");

                strSQL = "UPDATE Table_Cliente SET NOME=@NOME, NUMERO = @NUMERO WHERE ID=@ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                conexao.Open();

                comando.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                comando = null; // Para poder instanciar de novo 
                conexao = null;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Server=DESKTOP-R2ING0Q;Database=ClienteLoja;User Id=sa;Password=@thiago1337;");

                strSQL = "SELECT * FROM Table_Cliente WHERE ID= @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);

                conexao.Open();

                 dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txtNome.Text = (string)dr["NOME"];
                    txtNumero.Text = Convert.ToString(dr["NUMERO"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                comando = null; // Para poder instanciar de novo 
                conexao = null;
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Server=DESKTOP-R2ING0Q;Database=ClienteLoja;User Id=sa;Password=@thiago1337;");

                strSQL = "DELETE Table_Cliente WHERE ID=@ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                

                conexao.Open();

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                comando = null; // Para poder instanciar de novo 
                conexao = null;
            }
        }
    }
}
