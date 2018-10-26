<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Sisca.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio Sesión...</title>

    <link href="../Imagenes/Logo_CSAC.jpg" rel="icon" type="image/x-icon"/>

    <style type="text/css">

    #Panel1 {
        background:#f8f8f8;
        border-left:1px solid #e2e0e0;
        border-right:1px solid #e2e0e0;
        border-top:1px solid #e2e0e0;
        border-bottom:1px solid #e2e0e0;
        }

    .btn {
        background:#f3f3f3;
        color:#000000;   
        border-radius:5px;   
    }

    .btn:hover {
        background: #eae8e8;
        border-radius:5px;   
        font-family: Arial, sans-serif;
        font-size: 12px;
        color:#000000;
        height: 25px;
    }

    .txt {
        background:#ffffff;
        margin-left: 0px;
        }

        .auto-style1 {
            width: 97px;
        }

        .auto-style2 {
            width: 97px;
            height: 28px;
        }

        .auto-style3 {
            height: 28px;
        }

        .auto-style4 {
            width: 222px;
            height: 189px;
        }

    table#TbLogin {
        vertical-align:central;
        position: relative;
        display: block;
        margin-left: auto;
        margin-right: auto;
        width: 60%;
        text-align: center;
     }

    table#Tbotones {
        vertical-align:central;
        position: relative;
        display: block;
        margin-left: auto;
        margin-right: auto;
        width: 60%;
        text-align: center;
    }

    </style>

    <meta http-equiv="Expires" content="0" />
    <meta http-equiv="Pragma" content="no-cache" />

    <script type="text/javascript">

        if (history.forward(1))
            location.replace(history.forward(1))
    </script>

    <script type="text/javascript">

        document.onkeydown = function (evt) {
            return (evt ? evt.which : event.keyCode) != 13;
        }
    </script>

</head>

<body>
    <p>
    </p>
    <form id="form1" runat="server">
    <div id="login">
        
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Height="348px" Width="513px" style="margin-top: 80px; margin-left: 440px;" DefaultButton="BtnIngresar">
            <br />
            <img src="../Imagenes/Logo_CSAC.jpg" class="auto-style4" />
            <br />
            <br />
            <br />
            <table id="TbLogin">
                <tr>
                    <td class="auto-style2"><asp:Label ID="LbUsuario" runat="server" Text="Usuario" Font-Size="14pt"></asp:Label></td>
                    <td class="auto-style3"><asp:Label ID="Lb5" runat="server" Text=":" Font-Size="14pt"></asp:Label></td>
                    <td class="auto-style3"><asp:TextBox ID="TxtUsuario" runat="server" ToolTip="Usuario" Font-Size="12pt" Width="170px" CssClass="txt" TabIndex="1" CausesValidation="True" AutoPostBack="True" OnTextChanged="TxtUsuario_TextChanged"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2"><asp:Label ID="LbContraseña" runat="server" Text="Contraseña" Font-Size="14pt"></asp:Label></td>
                    <td class="auto-style3"><asp:Label ID="Lb6" runat="server" Text=":" Font-Size="14pt"></asp:Label></td>
                    <td class="auto-style3"><asp:TextBox ID="TxtPass" runat="server" TextMode="Password" ToolTip="Contraseña" Font-Size="12pt" Width="170px" CssClass="txt" TabIndex="3" Enabled="False"></asp:TextBox></td>
                </tr>
              </table>
              <br />
 
            <br />
            <table id="Tbotones">
                <tr>
                    <td ><asp:LinkButton ID="LkBtn1" runat="server" PostBackUrl="http://www.csac.cl" TabIndex="13" OnClick="LinkButton1_Click">Volver Página Principal</asp:LinkButton></td>
                    <td ></td>
                    <td ><asp:Button ID="BtnIngresar" runat="server" Text="Iniciar Sesión" Height="30px" Width="172px" Font-Size="12pt" OnClick="BtnIngresar_Click" BorderColor="#E8E8E8" BorderStyle="Groove" CssClass="btn" TabIndex="11" /></td>
                </tr>
            </table>  

            <br />
        </asp:Panel>
       </div>

    </form>
</body>
</html>

