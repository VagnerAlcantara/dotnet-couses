<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Title="Alterar Cliente" Inherits="Locadora.UI.WebForms.Forms.Cliente.Index" MasterPageFile="~/Site.Master" %>

<asp:Content ID="principal" runat="server" ContentPlaceHolderID="MainContent">
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Pesquisar</h4>
            </div>
            <div class="panel-body">
                <div runat="server" id="msgErro" visible="false" class="alert alert-danger" role="alert"></div>
                <div runat="server" id="msgSucesso" visible="false" class="alert alert-success" role="alert"></div>
                <div class="form-group col-lg-12">
                    <div class="form-group col-lg-2">
                        <b>CPF</b>
                        <asp:TextBox runat="server" TextMode="Number" required="required" MaxLength="15" CssClass="form-control input-small" ID="txtCpfCliente" aria-describedby="cpfClienteHelp" />
                    </div>
                    <div class="form-group col-lg-6 ">
                        <br>
                        <asp:Button Text="Pesquisar" CssClass="btn btn-default" runat="server" ID="btnPesquisar" OnClick="btnPesquisar_Click" />
                        <a class="btn btn-default" runat="server" href="~/Forms/Cliente/Cadastrar.aspx">Novo</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Resultado</h4>
            </div>
            <div class="panel-body">
                <asp:GridView ID="gdvClientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="901px" OnRowCommand="gdvClientes_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="nome" HeaderText="Nome" ControlStyle-CssClass="col">
                            <ControlStyle CssClass="col"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="id" HeaderText="Id" />
                        <asp:BoundField DataField="cpf" HeaderText="Cpf" />
                        <asp:BoundField DataField="email" HeaderText="E-mail" />
                        <asp:BoundField DataField="telefone" HeaderText="Telefone" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" CommandName="Editar" Text="Editar" CssClass="btn btn-xs btn-info"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "cpf")%>' />
                                <asp:Button ID="btnLocacao" runat="server" CommandName="Locacao" Text="Locação" CssClass="btn btn-xs btn-info"
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
    
</asp:Content>
