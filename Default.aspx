<%@ Page Title="" Language="C#" MasterPageFile="~/ControleDocumentosMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style4
        {
            text-align: center;
            width: 854px;
        }
        .style5
        {
            width: 854px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <table style="width: 90%">
            <tr>
                <td class="style5">
                    &nbsp;
                </td>
            </tr>
             <tr>
                <td style="text-align: left" class="style5">
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="Digite o RH: "></asp:Label>
                    <asp:TextBox ID="TxtPesquisa" runat="server" MaxLength="16"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" Text="Pesquisar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
             <tr>
                <td class="style5">
                &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="style5">
                    
                </td>
              
                  
               
            </tr>
            <tr>
               
            
                <td style="text-align: left" class="style5">
                    <asp:GridView ID="GridViewPesquisa" runat="server" EnableModelValidation="True">
                    </asp:GridView>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
