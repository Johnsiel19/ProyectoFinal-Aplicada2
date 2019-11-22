<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rEntradas.aspx.cs" Inherits="ProyectoFinal_Aplicada2.UI.Registros.rEntradas" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Entradas</div>

            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">

                    <div class="container">
                        <div class="form-group">
                            <label for="EntradaIdlabel" class="col-md-3 control-label input-sm" style="font-size: small">EntradasId</label>
                            <div class="col-md-1 ">
                                <asp:TextBox ID="EntradaIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="EntradaIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Producto no valido" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                            <div class="col-md-1 ">
                                <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" />
                            </div>
                        </div>

                        <%--FEcha--%>

                        <div class="form-group">
                            <label for="fechalabel" class="col-md-3 control-label input-sm">Fecha: </label>
                            <div class="col-md-3">
                                <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                        </div>




                        <%--Producto--%>
                        <div class="form-group">
                            <label for="Productolabel" class="col-md-3 control-label input-sm" style="font-size: small">Producto</label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="ProductoIdComboBox" class="form-control input-sm" Style="font-size: small"></asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="ProductoIdComboBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Proveedor es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </div>


                        <%--Entrada--%>
                        <div class="form-group">
                            <label for="Entradalabel" class="col-md-3 control-label input-sm" style="font-size: small">Entrada</label>
                            <div class="col-md-2">
                                <asp:TextBox ID="EntradaTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="EntradaTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>

                        </div>

                    </div>

                </div>
                <%--Botones--%>
                <div class="panel">
                    <div class="text-center">
                        <div class="form-group">
                            <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" />
                            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" />
                            <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>
            </div>
    </div>
</asp:Content>