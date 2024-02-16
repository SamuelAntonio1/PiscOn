<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contatos.aspx.cs" Inherits="PsicOn.Web.Contatos" %>
<asp:Content ID="cntHead" ContentPlaceHolderID="cphHead" runat="server">
     <style type="text/css">
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        th, td {
            border: 1px solid white;
            padding: 10px;
            text-align: left;
        }

        .editar-icon {
            cursor: pointer;
            font-size: 20px; 
            width: 20px;
            height: 20px;
        }

        .editar-link {
            color: inherit; 
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="cntConteudo" ContentPlaceHolderID="cphConteudo" runat="server">
    <h1>Lista dos contatos cadastros</h1>
    <button id="btn-novo" onclick="incluirNovoRegistro()">Novo</button>
    <table id="tabela-dados">
        <thead>
            <tr>
                <th style="background-color: #333;">&nbsp;</th>
                <th style="background-color: #333;">Nome</th>
                <th style="background-color: #333;">E-mail</th>
                <th style="background-color: #333;">Celular</th>
                <th style="background-color: #333;">CPF</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var apiUrl = 'https://localhost:7091/contatos';

            $.ajax({
                url: apiUrl,
                method: 'GET',
                dataType: 'json',
                success: function (data) {
                    // Preencher a tabela com os dados recebidos
                    var tbody = $('#tabela-dados tbody');
                    tbody.empty();

                    $.each(data, function (index, item) {
                        var row = '<tr>' +
                            '<td style="width: 20px;"><a href="#" class="editar-link" data-indice="' + item.codigoContato + '"><i class="fas fa-edit editar-icon"></i></a></td>' +
                            '<td>' + item.nome + '</td>' +
                            '<td>' + item.email + '</td>' +
                            '<td>' + item.celular + '</td>' +
                            '<td>' + item.cpf + '</td>' +
                            '</tr>';
                        tbody.append(row);
                    });
                },
                error: function (error) {
                    console.error('Erro na chamada da API:', error);
                }
            });

            $(document).on('click', '.editar-link', function () {
                var codigo = $(this).data('indice');
                window.location.href = "ContatosForm.aspx?codigo=" + codigo;                
            });
        });

        function incluirNovoRegistro() {
            window.location.href = "ContatosForm.aspx"
        }
    </script>
</asp:Content>
