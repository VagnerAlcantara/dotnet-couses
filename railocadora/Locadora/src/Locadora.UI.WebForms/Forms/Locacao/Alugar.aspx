<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alugar.aspx.cs" Title="Alugar" Inherits="Locadora.UI.WebForms.Forms.Locacao.Alugar" MasterPageFile="~/Site.Master" %>

<asp:Content ID="principal" runat="server" ContentPlaceHolderID="MainContent">
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Cliente</h4>
            </div>
            <div class="panel-body">
                <div runat="server" id="msgErro" visible="false" class="alert alert-danger" role="alert"></div>
                <div runat="server" id="msgSucesso" visible="false" class="alert alert-success" role="alert"></div>
                <fieldset disabled>
                    <asp:HiddenField ID="hfIdCliente" runat="server" />
                    <div class="form-group col-lg-8">
                        <label for="txtNomeCliente">Nome</label>
                        <asp:TextBox runat="server" CssClass="form-control input-small" ID="txtNomeCliente" aria-describedby="nomeClienteHelp" value="" />
                    </div>
                    <div class="form-group col-lg-4">
                        <label for="txtCpfCliente">CPF</label>
                        <asp:TextBox runat="server" CssClass="form-control input-small" ID="txtCpfCliente" aria-describedby="cpfClienteHelp" value="" />
                    </div>
                </fieldset>
            </div>

        </div>
    </div>
    <hr />
    <div class="panel-group">

        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group col-lg-8">
                    <label for="txtTituloFilme">Título</label>
                    <asp:TextBox runat="server" CssClass="form-control input-small" MaxLength="150" ID="txtTituloFilme" aria-describedby="nomeClienteHelp" value="" />
                </div>
                <div class="form-group col-lg-6 ">
                    <asp:Button Text="Pesquisar" CssClass="btn btn-default" runat="server" ID="btnPesquisar" OnClick="btnPesquisar_Click" />
                </div>
            </div>
            <div class="panel-heading">
                <h4>Locações</h4>
            </div>
            <div class="panel-body">
                <asp:GridView ID="gdvFilme" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1035px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="Id" />
                        <asp:BoundField DataField="Titulo" HeaderText="Título" />
                        <asp:BoundField DataField="Ano" HeaderText="Ano de lançamento" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />

                <div class="form-group col-lg-15 text-right">
                    <asp:Button CssClass="btn btn-default" Text="Salvar" ID="btnAlugarSelecionado" runat="server" OnClick="btnAlugarSelecionado_Click" />
                </div>
            </div>
        </div>
        <br />

    </div>
    <hr />
    <div class="form-group col-lg-15 text-right">
        <asp:Button CssClass="btn btn-default" Text="Voltar" ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" />
    </div>
</asp:Content>


