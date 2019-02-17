<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alterar.aspx.cs" Title="Cliente" Inherits="Locadora.UI.WebForms.Forms.Cliente.Alterar" MasterPageFile="~/Site.Master" %>

<asp:Content ID="principal" runat="server" ContentPlaceHolderID="MainContent">

    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Dados Pessoais</h4>
            </div>
            <div class="panel-body">
                <div runat="server" id="msgErro" visible="false" class="alert alert-danger" role="alert"></div>
                <div runat="server" id="msgSucesso" visible="false" class="alert alert-success" role="alert"></div>
                <asp:HiddenField ID="hfIdCliente" runat="server" />    
                <div >
                    <label for="txtNomeCliente">Nome</label>
                    <asp:TextBox runat="server" required="required" MaxLength="100" CssClass="form-control input-small" ID="txtNomeCliente" aria-describedby="nomeClienteHelp" value="" />
                </div>
                <div>
                    <label for="txtCpfCliente">CPF</label>
                    <asp:TextBox runat="server" TextMode="Number" required="required" MaxLength="15" CssClass="form-control input-small" ID="txtCpfCliente" aria-describedby="cpfClienteHelp" value="" />
                </div>

                <div >
                    <label for="txtDataNascimento">Data Nascimento</label>
                    <asp:TextBox runat="server" MaxLength="15" CssClass="form-control input-small" ID="txtDataNascimento" aria-describedby="dataNascimentoHelp" value="" />
                </div>
                <div >
                    <label for="txtTelefoneCliente">Telefone</label>
                    <asp:TextBox runat="server" required="required" MaxLength="20" CssClass="form-control input-small" ID="txtTelefoneCliente" aria-describedby="telefoneClienteHelp" value="" />
                </div>
                <div >
                    <label for="txtEmailCliente">E-mail</label><br>
                    <asp:TextBox runat="server" TextMode="Email" required="required" MaxLength="100" CssClass="form-control input-small" ID="txtEmailCliente" aria-describedby="emailEmpresaHelp" value="" />
                </div>
                <div class="form-group col-lg-12 text-right">
                    <asp:Button CssClass="btn btn-default" Text="Salvar" ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="form-group col-lg-15 text-right">
        <asp:Button CssClass="btn btn-default" Text="Voltar" ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" />
    </div>
</asp:Content>
