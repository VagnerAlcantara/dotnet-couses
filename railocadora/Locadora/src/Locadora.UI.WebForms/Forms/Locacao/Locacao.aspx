<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Locacao.aspx.cs" Title="Locações" Inherits="Locadora.UI.WebForms.Forms.Locacao.Locacao" MasterPageFile="~/Site.Master" %>

<asp:Content ID="principal" runat="server" ContentPlaceHolderID="MainContent">
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Cliente</h4>
            </div>
            <div class="panel-body">
                <fieldset disabled>
                    <asp:HiddenField ID="hfIdCliente" runat="server" />
                    <div class="form-group col-lg-6">
                        <label for="txtNomeCliente">Nome</label>
                        <asp:TextBox runat="server" CssClass="form-control input-small" ID="txtNomeCliente" aria-describedby="nomeClienteHelp" value="" />
                    </div>
                    <div class="form-group col-lg-6">
                        <label for="txtCpfCliente">CPF</label>
                        <asp:TextBox runat="server" CssClass="form-control input-small" ID="txtCpfCliente" aria-describedby="cpfClienteHelp" value="" />
                    </div>
                </fieldset>
                <div class="form-group col-lg-12 text-right">
                    <asp:Button CssClass="btn btn-default" Text="Alugar" ID="btnAlugar" runat="server" OnClick="btnAlugar_Click" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="panel-group">
        <div runat="server" id="msgErro" visible="false" class="alert alert-danger" role="alert"></div>
        <div runat="server" id="msgSucesso" visible="false" class="alert alert-success" role="alert"></div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Locações</h4>
            </div>
            <div class="panel-body">
                <asp:GridView ID="gdvLocacao" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="901px" OnRowCommand="gdvLocacao_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Id" />
                        <asp:BoundField DataField="titulo" HeaderText="Filme" />
                        <asp:BoundField DataField="DataRetirada" HeaderText="Data retirada" />
                        <asp:BoundField DataField="DataEntrega" HeaderText="Data entrega" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnRemoverLocacao" runat="server" CommandName="RemoverLocacao" Text="Remover" CssClass="btn btn-xs btn-danger"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <hr />
    <div class="form-group col-lg-15 text-right">
        <a class="btn btn-default" runat="server" href="~/Forms/Cliente/Index.aspx">Voltar</a>
    </div>
</asp:Content>

