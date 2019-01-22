<%@ Page Title="" Language="C#" MasterPageFile="~/MConfiguracion/MenuConfiguracion.master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Sisca.MConfiguracion.Creacion_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PrincipalPag" runat="server">
    <div id="Permisos">
        <div align="center" style="width: 718px">
            <asp:Label ID="TitAreaTrabajo" runat="server" Text="Usuarios" ></asp:Label>
        </div>
        <br />
        <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
                <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <fieldset id="FieldNuevoValorExtra" style="border-style: solid; border-color: white; height:391px; font-family: 'Arial Narrow'; background-color: white; margin-left: 18px; width: 992px;">
                            <div id="botones">
                                <table>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="Izq" style="width: 110px">Rut</td>
                                        <td class="Cto">:</td>
                                        <td><asp:TextBox ID="TBRut" runat="server" Width="62px" Enabled="False"></asp:TextBox></td>
                                        <td>-</td>
                                        <td><asp:TextBox ID="TBDVRut" runat="server" Width="16px" Enabled="False"></asp:TextBox></td>
                                        <td style="width: 120px"></td>
                                        <td><asp:ImageButton ID="IBtnEdicion"   runat="server" ImageUrl="~/Imagenes/Iconos/edit.ico"        AlternateText="Editar" OnClick="IBtnEdicion_Click" /></td>
                                        <td><asp:ImageButton ID="IBtnNuevo"     runat="server" ImageUrl="~/Imagenes/Iconos/filenew.ico"     AlternateText="Nuevo" OnClick="IBtnNuevo_Click"  /></td>
                                        <td><asp:ImageButton ID="IBtnElimina"   runat="server" ImageUrl="~/Imagenes/Iconos/editdelete.ico"  AlternateText="Elimina" Enabled="False" style="height: 16px" /></td>
                                        <td><asp:ImageButton ID="IBtnBuscar"    runat="server" ImageUrl="~/Imagenes/Iconos/search.ico"      AlternateText="Buscar" OnClick="IBtnBuscar_Click" /></td>
                                        <td><asp:ImageButton ID="IBtnImpresion" runat="server" ImageUrl="~/Imagenes/Iconos/fileprint.ico"   AlternateText="Impresión" OnClick="IBtnImpresion_Click" /></td>
                                        <td><asp:ImageButton ID="IBtnExcel"     runat="server" ImageUrl="~/Imagenes/MsOffice/01 Excel.ico"  AlternateText="Exportar a Excel" Height="22px" Width="23px" OnClick="IBtnExcel_Click" /></td>
                                        <td><asp:ImageButton ID="IBtnGrabar"    runat="server" ImageUrl="~/Imagenes/Iconos/filesave.ico"    AlternateText="Grabar" Enabled="False" OnClick="IBtnGrabar_Click" /></td>
                                        <td><asp:ImageButton ID="IBtnSinGrabar" runat="server" ImageUrl="~/Imagenes/Iconos/undo.ico"        AlternateText="No Graba" Enabled="False" OnClick="IBtnSinGrabar_Click" /></td>
                                        <td></td>
                                        <td></td>
                                        
                                        <td></td>
                                        <td><asp:ImageButton ID="IBtnPrimero"   runat="server" ImageUrl="~/Imagenes/Iconos/player_start.ico" AlternateText="Primer Registro"     style="height: 20px" OnClick="IBtnPrimero_Click" /></td>
                                        <td><asp:ImageButton ID="IBtnAnterior"  runat="server" ImageUrl="~/Imagenes/Iconos/1leftarrow.ico"   AlternateText="Registro Anterior"   style="height: 20px" OnClick="IBtnAnterior_Click" /></td>
                                        <td><asp:ImageButton ID="IBtnsiguiente" runat="server" ImageUrl="~/Imagenes/Iconos/1rightarrow.ico"  AlternateText="Registro Siguiente"  style="height: 20px" OnClick="IBtnsiguiente_Click" /></td>
                                        <td><asp:ImageButton ID="IBtnUltimo"    runat="server" ImageUrl="~/Imagenes/Iconos/player_end.ico"   AlternateText="Último Registro"     style="height: 20px" OnClick="IBtnUltimo_Click" /></td>
                                        <td></td>
                                    </tr>
                                </table>

                                <table style="width: 661px; height: 56px">
                                    <tr>
                                        <td class="Izq"  style="width: 110px">Nombre</td>
                                        <td class="Cto">:</td>
                                        <td><asp:TextBox ID="TBNombre" runat="server" Width="525px" style="margin-left: 0px" Enabled="False"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="Izq" style="width: 110px">Dirección</td>
                                        <td class="Cto">:</td>
                                        <td><asp:TextBox ID="TBDirecion" runat="server" Width="525px" Enabled="False"></asp:TextBox></td>
                                    </tr>
                                </table>

                                <table>
                                    <tr>
                                        <td class="Izq" style="width:110px">Region</td>
                                        <td class="Cto">:</td>
                                        <td style="width: 230px"><asp:DropDownList ID="DDListRegion" runat="server" style=" width: 230px " Enabled="False"></asp:DropDownList></td>
                                    </tr>
                                </table>

                                <table>
                                    <tr>
                                        <td class="Izq" style="width: 110px">Comuna</td>
                                        <td class="Cto">:</td>
                                        <td><asp:TextBox ID="TBComuna" runat="server" Width="100px" Enabled="False"></asp:TextBox></td>
                                        <td></td>
                                        <td class="Izq" style="width: 90px">Ciudad</td>
                                        <td class="Cto">:</td>
                                        <td><asp:TextBox ID="TBCiudad" runat="server" Width="110px" Enabled="False"></asp:TextBox></td>
                                        <td></td>
                                    </tr>

                                </table>
                                <table>
                                    <tr>
                                        <td class="Izq" style="width: 110px">Giro</td>
                                        <td class="Cto">:</td>
                                        <td><asp:TextBox ID="TBGiro" runat="server" Width="525px" Height="49px" TextMode="MultiLine" Enabled="False"></asp:TextBox></td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td class="Izq" style="width: 110px">Telefonos</td>
                                        <td class="Cto">:</td>
                                        <td><asp:TextBox ID="TBTelefono" runat="server"  Width="100px" Enabled="False"></asp:TextBox></td>
                                        <td class="Izq" style="width: 110px">Fax</td>
                                        <td><asp:TextBox ID="TBFax" runat="server"  Width="100px" Enabled="False"></asp:TextBox></td>
                                    </tr>
                                </table>
                              <table>
                                    <tr>
                                        <td class="Izq"  style="width: 110px">EMail</td>
                                        <td class="Cto">:</td>
                                        <td><asp:TextBox ID="TBEMail" runat="server" Width="525px" style="margin-left: 0px" Enabled="False"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="Izq"  style="width: 110px">Contacto</td>
                                        <td class="Cto">:</td>
                                        <td><asp:TextBox ID="TBContacto" runat="server" Width="525px" style="margin-left: 0px" Enabled="False"></asp:TextBox></td>
                                    </tr>
                                </table>
                                <table>
                                     <tr>
                                        <td class="Izq"  style="width: 110px">Tipo</td>
                                        <td ><asp:RadioButtonList ID="RBtListTipo" runat="server"  RepeatDirection="Horizontal" OnSelectedIndexChanged="RBtListTipo_SelectedIndexChanged" Enabled="False">
                                            <asp:ListItem Value="1">Suministros</asp:ListItem>
                                            <asp:ListItem Value="2">Servicios</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td class="Izq"  style="width: 110px">Requiere Orden de Compra</td>
                                        <td class="Cto">:</td>
                                        <td>
                                            <asp:CheckBox ID="CheckBoxOC" runat="server" Enabled="False" />
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 108px"><asp:Button ID="BtnGuardar" runat="server" Font-Names="Arial Narrow" Font-Size="12pt" Height="33px" Text="Guardar" Width="104px" OnClick="BtnGuardar_Click" BackColor="#EBEBEB" BorderStyle="Groove" style="margin-left: 0px" /></td>                                        
                                        <td></td>
                                    </tr>
                                </table>
                           </div>
                           
                        </fieldset>
                     </ContentTemplate>
<%--                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="BtnGuardar" EventName="Click" />
                    </Triggers>--%>
                 </asp:UpdatePanel>
        <br />
</div>
</asp:Content>
