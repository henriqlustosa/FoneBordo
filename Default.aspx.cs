using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;


public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        // select ID,Nome,Obs,Data from Dados_Documentos inner join Funcionario on RF_Funcionario= RF where RF_Funcionario=130273
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FoneBordoConnectionString"].ToString()))
        {
            try
            {
                //int NumRhF = Convert.ToInt32(TxtPesquisa.Text);
                string NumRhF = TxtPesquisa.Text;
                string strQuery = "";
                                                   
                  //  strQuery = "SELECT PACIENTE,RH,OBSERVACAO_HOSPUB,TELEFONE1,TELEFONE2,TELEFONE3,TELEFONE4 FROM [FoneBordo].[dbo].[Fones] where RH = " + NumRhF + " ";
                strQuery = "SELECT PACIENTE,RH,ISNULL(OBSERVACAO_HOSPUB,'VAZIO'),ISNULL(TELEFONE1,'SEM'),ISNULL(TELEFONE2,'SEM'),ISNULL(TELEFONE3,'SEM'),ISNULL(TELEFONE4,'SEM') FROM [FoneBordo].[dbo].[Fones] where RH = " + NumRhF + " ";
           
                SqlCommand commd = new SqlCommand(strQuery, com);
                com.Open();
                SqlDataReader dr = commd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Columns.Add("PACIENTE", System.Type.GetType("System.String"));
                dt.Columns.Add("RH", System.Type.GetType("System.String"));
                dt.Columns.Add("FONE 1", System.Type.GetType("System.String"));
                dt.Columns.Add("FONE 2", System.Type.GetType("System.String"));
                dt.Columns.Add("FONE 3", System.Type.GetType("System.String"));
                dt.Columns.Add("FONE 4", System.Type.GetType("System.String"));
                dt.Columns.Add("OBSERVAÇÃO:", System.Type.GetType("System.String"));


                while (dr.Read())
                {
                    string Paciente = dr.GetString(0);                   
                    string RH = dr.GetString(1);   
                    string Obs = dr.GetString(2);                   
                    string Fone1 = dr.GetString(3);
                    string Fone2 = dr.GetString(4);
                    string Fone3 = dr.GetString(5);
                    string Fone4 = dr.GetString(6);
                   

                    dt.Rows.Add(new String[] { Paciente, RH, Fone1, Fone2, Fone3, Fone4, Obs });
                }
                com.Close();

                GridViewPesquisa.DataSource = dt;
                GridViewPesquisa.DataBind();
                if (GridViewPesquisa.Rows.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Não há Registro para esse RH!');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Registro Não encontrado!');", true);

                string erro = ex.Message;
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", erro, true);
            }
        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //    /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
        //       server control at run time. */

    }


}

