<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Locadora.UI.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Locadora</h3>
        <p>Candidato: Vagner José de Alcantara Ferreira</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <p><b>Entrega com a implementação dos seguintes itens</b></p>
            
            <ul>
                <li>Pesquisa, inclusão e edição de cliente</li>
                <li>Lista com itens locados para o cliente</li>
                <li>Filtro de filmes na página de locação </li>
            </ul>
            <p>Obs.: Não foi possível concluir todos os itens solicitados no teste por falta de tempo.</p>
        </div>
        <div class="col-md-4">
            <p><b>Estrutura</b></p>
            <p>Foram criadas tabelas e procedures para consistência de dados para as entidades, não houve tempo de utilizar todas</p>
            <ul>
                <li>Cliente</li>
                <li>Locação</li>
                <li>Usuário</li>
                <li>Filme</li>
                <li>Endereço</li>
                <li>Perfil(do Usuário)</li>
            </ul>
            <p>Obs.: Existe uma pasta com os scripts utilizados para criação de banco, tabelas e procedures em: ..\src\Locadora.Data\scripts\</p>
        </div>
        <div class="col-md-4">
            <p><b>Teste caminho feliz</b></p>
            <ul>
                <li>Vá ao menu cliente</li>
                <li>Clique no botão "Novo" e cadastre um novo cliente</li>
                <li>Informe o cpf do cliente cadastrado para pesquisar (usuário cadastrado para teste completo, cpf: 35426992843> </li>
                <li>Clique no botão "Editar" dentro do grid e edite os dados do cliente</li>
                <li>Na tela de busca por cliente, informe o cpf, busque-o e entre na opção "Locação", será exibido na tela um cabeçalho referente ao cliente e suas locações </li>
                <li>Clique no botão "Alugar", será exibido na tela um cabeçalho referente ao cliente e alguns filmes pré-carregados com a opção de filtro, selecione os filmes desejados na lista e clique em salvar para realizar a locação.</li>
            </ul>
        </div>
    </div>

</asp:Content>
