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
        SqlConnection conexao;//variavel da conexao
        SqlCommand comando;// variavel dos comandos
        SqlDataAdapter da; // variavel da data adapter
        SqlDataReader dr; // variavel datareader

        string strSQL; // variavel para utilizar o comando sql



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
                // conexao com o banco
                conexao = new SqlConnection("Server=DESKTOP-R2ING0Q;Database=ClienteLoja;User Id=sa;Password=@thiago1337;");
                //comando insert na tabela
                strSQL = "INSERT INTO Table_Cliente (Nome,Numero) VALUES (@NOME,@NUMERO)";
                // instanciar o comando
                comando = new SqlCommand(strSQL, conexao);
                // adicionar direto os valores do txt para o banco
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);
                //abrir a conexao
                conexao.Open();
                //executar as instruções do sql
                comando.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                //caso de erro
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //fechar conexao com o banco e voltar as variaveis caso perdurem com estes comandos
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
                // comando sql de mostrar / exibir a table
                strSQL = "SELECT * FROM Table_Cliente";

                // dataset representa data em uma coluna formatada
                DataSet dataSet = new DataSet();
                // instanciar sqladapter(ponte entre dataset e sql para recuperar data)
                da = new SqlDataAdapter(strSQL,conexao);
                
                conexao.Open();
                // fill atualizara as linhasdo dataset
                da.Fill(dataSet);
                //datagridview ira apresentar os dados  setados em tabela
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
                // comando sql para editar ou alterar algo dentro da tabela
                strSQL = "UPDATE Table_Cliente SET NOME=@NOME, NUMERO = @NUMERO WHERE ID=@ID";
                // instancia do sqlcomand, mostrando que o strSQL vai ter como parametro
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
                // mostrar o dado representado pelo id
                strSQL = "SELECT * FROM Table_Cliente WHERE ID= @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);

                conexao.Open();
                //envia o comando e le com o datareader
                 dr = comando.ExecuteReader();
                // loop sobre enquanto o comndo sql ler tal coisa , avança pro proximo registro
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
                // comando deletar alguem da tabela no sql, configurado por ID
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
