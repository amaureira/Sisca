<%@ Page Title="Menu Configuración" Language="C#" MasterPageFile="~/Pagina.Master" AutoEventWireup="true" CodeBehind="Menu_Configuracion.aspx.cs" Inherits="Sisca.MConfiguracion.Menu_Configuracion" %>
<%@ OutputCache Location="None"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PrincipalPag" runat="server">

    <style type="text/css">

        #MenuParametros{
            background:#ffffff;
            margin-right:-400px;
            margin-left: -20px;
        }

        #menu{
            width: 165px;
            margin-left: 0px;
            height: 343px;
            margin-top: 0px;
        }

        #TMenu{
            width: 230px;
            margin-left: 22px;
        }



</style>

<div id="MenuParametros">
    <div id="menu">
        <h4 Id="TMenu" ><asp:Label ID="LblTMenu" runat="server" Font-Size="13pt" Font-Bold="False" Font-Names="Arial">Parametros</asp:Label></h4>
        <asp:Button ID="Btn01" runat="server" Text="Usuarios" Height="31px" style="margin-top: 0px" Width="145px" BackColor="#EBEBEB" Font-Size="11pt" OnClick="Btn01_Click" Font-Names="Arial Narrow" BorderStyle="Groove" BorderColor="White" Enabled="false"/>
        <asp:Button ID="Btn02" runat="server" Text="Permisos" Height="32px" style="margin-top: 0px" Width="145px" BackColor="#EBEBEB" Font-Size="11pt" OnClick="Btn02_Click" Font-Names="Arial Narrow" BorderStyle="Groove" BorderColor="White" Enabled="false"/>
        <asp:Button ID="Btn03" runat="server" Text="Fechas"   Height="32px" style="margin-top: 0px" Width="145px" BackColor="#EBEBEB" Font-Size="11pt" OnClick="Btn03_Click" Font-Names="Arial Narrow" BorderStyle="Groove" BorderColor="White" Enabled="false"/>
        <asp:Button ID="Btn04" runat="server" Text="Feriados" Height="32px" style="margin-top: 0px" Width="145px" BackColor="#EBEBEB" Font-Size="11pt" OnClick="Btn04_Click" Font-Names="Arial Narrow" BorderStyle="Groove" BorderColor="White" Enabled="false"/>
        <asp:Button ID="Btn05" runat="server" Text="Usuarios" Height="32px" style="margin-top: 0px" Width="145px" BackColor="#EBEBEB" Font-Size="11pt" OnClick="Btn05_Click" Font-Names="Arial Narrow" BorderStyle="Groove" BorderColor="White" Enabled="false"/>
    </div>
</div>
</asp:Content>
