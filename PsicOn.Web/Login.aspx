<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PsicOn.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PsicOn - Login</title>
    
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

    <style type="text/css">
        body {
            background-color: black;
            color: white;
            font-family: Arial, sans-serif;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            margin: 0;
        }

        h1 {
            color: #61dafb; /* Azul claro, semelhante à cor do React */
            text-align: center;
        }

        form {
            width: 300px;
            padding: 20px;
            background-color: #333;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
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

        button {
            background-color: #61dafb; /* Azul claro, semelhante à cor do React */
            color: black;
            padding: 10px;
            border: none;
            cursor: pointer;
            width: 100%;
        }
    </style>
</head>
<body>

    <form>
        <h1>Login</h1>

        <label for="username">Usuário:</label>
        <input type="text" id="username" name="username" required />

        <label for="password">Senha:</label>
        <input type="password" id="password" name="password" required />

        <button type="button" onclick="login()">Entrar</button>
    </form>

    <script type="text/javascript">
        function login() {
            var username = document.getElementById('username').value;
            var password = document.getElementById('password').value;

            if (username == "" || password == "") {
                alert("É obrigatório o preenchimento dos campos usuário e senha!");
                return;
            }

            window.location.href = "Contatos.aspx";
        }
    </script>

</body>
</html>
