<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContatosForm.aspx.cs" Inherits="PsicOn.Web.ContatosForm" %>
<asp:Content ID="cntHead" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        form {
            width: 600px;
            padding: 20px;
            background-color: #333;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
            display: flex;
            flex-direction: column;
        }
        label {
            display: block;
            margin-bottom: 10px;
        }
        input {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            box-sizing: border-box;
        }

    </style>
</asp:Content>
<asp:Content ID="cntConteudo" ContentPlaceHolderID="cphConteudo" runat="server">
    <h1>Contatos > Editar informações</h1>

    <form id="formulario">
        <label for="nome">Nome:</label>
        <input type="text" id="nome" name="nome" required>

        <label for="email">E-mail:</label>
        <input type="email" id="email" name="email" required>

        <label for="celular">Celular:</label>
        <input type="text" id="celular" name="celular" required>

        <label for="cpf">CPF:</label>
        <input type="text" id="cpf" name="cpf" required>

        <div style="margin-top: 10px;">
            <button id="btn-salvar" type="button" onclick="salvar()">Salvar</button>
            <button id="btn-excluir" type="button" onclick="excluir()">Excluir</button>
            <button id="btn-cancelar" type="button" onclick="cancelar()">Cancelar</button>
        </div>
    </form>
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="server">
    <script type="text/javascript">
        var apiUrl = 'https://localhost:7091/contatos';
        var codigo = lerParametroUrl("codigo");
        var operacaoUpdate = false;

        $(document).ready(function () {
            if (codigo !== undefined && codigo !== "" && codigo !== null) {
                $.ajax({
                    url: apiUrl + "/" + codigo,
                    method: 'GET',
                    success: function (data) {
                        console.log('Resposta da API:', data);
                        $('#nome').val(data.nome);
                        $('#email').val(data.email);
                        $('#celular').val(data.celular);
                        $('#cpf').val(data.cpf);
                    },
                    error: function (error) {
                        alert("Não foi possível completar a sua solicitação, ocorreram erros! Entre em contato com a equipe de suporte!");
                    }
                });

                operacaoUpdate = true;
            }
            else {
                codigo = 0;
            }

        });

        function salvar() {
            var dados = {
                codigo: codigo,
                nome: $('#nome').val(),
                email: $('#email').val(),
                celular: $('#celular').val(),
                cpf: $('#cpf').val()
            };

            $.ajax({
                url: apiUrl,
                method: (operacaoUpdate ? 'PUT' : 'POST'),
                contentType: 'application/json',
                data: JSON.stringify(dados),
                success: function (response) {
                    alert("O registro foi salvo com sucesso!");
                    navegarLista();
                },
                error: function (error) {
                    alert("Não foi possível completar a sua solicitação, ocorreram erros! Entre em contato com a equipe de suporte!");
                }
            });
        }

        function excluir() {
            var confirmacao = confirm("Você tem certeza que deseja excluir esse registro?");

            if (confirmacao) {
                $.ajax({
                    url: apiUrl + "/" + codigo,
                    method: 'DELETE',
                    success: function (data) {
                        alert("O registro foi EXCLUÍDO com sucesso!");
                        navegarLista();
                    },
                    error: function (error) {
                        alert("Não foi possível completar a sua solicitação, ocorreram erros! Entre em contato com a equipe de suporte!");
                    }
                });
            }
        }

        function cancelar() {
            
            navegarLista();
        }

        function navegarLista() {
            window.location.href = "Contatos.aspx";
        }
    </script>
</asp:Content>
