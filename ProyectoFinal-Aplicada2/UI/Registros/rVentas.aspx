<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="ProyectoFinal_Aplicada2.UI.Registros.rVentas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="panel panel-primary">
        <div class="panel-heading">Registro de Ventas</div>

        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">

                <div class="container">
                    <div class="form-group">
                        <label for="VentaLabel" class="col-md-1   control-label input-sm" style="font-size: small">VentaId</label>
                        <div class="col-md-2 ">
                            <asp:TextBox ID="VentaIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                        </div>
                        <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="VentaIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <div class="col-md-3 ">
                            <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" />
                        </div>
                        <%--Fecha--%>
                        <label for="FechaTebox" class="col-md-2 control-label input-sm" style="font-size: small">Fecha</label>
                        <div class="col-md-2">
                            <asp:TextBox ID="FechaTextBox" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>

                        </div>
                    </div>


                    <%--Cliente--%>
                    <div class="form-group">
                        <label for="ClienteLabel" class="col-md-1 control-label input-sm" style="font-size: small">Cliente</label>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="ClienteIdDropDown" class="form-control input-sm" Style="font-size: small"></asp:DropDownList>
                        </div>
                        <label for="ModoLabel" class="col-md-4 control-label input-sm" style="font-size: small">Modo de Compra</label>
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="ModoDropDownList" class="form-control input-sm" Style="font-size: small"></asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="ModoDropDownList" ForeColor="Red" Display="Dynamic" ToolTip="Campo Proveedor es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </div>

                    <%--TipoAnalisisId--%>


                    <div class="form-group row">
                        <label for="Productolabel" class="col-md-1 control-label input-sm" style="font-size: small">Producto</label>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="ProductoDropDown" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>

                        <div class="col-md-1">
                            <asp:LinkButton runat="server" ID="TiposModal" CausesValidation="false" CssClass="btn btn-info btn-md" data-toggle="modal" data-target="#rTiposAnalisis" Text="+"></asp:LinkButton>
                        </div>
                        <%--Cantidad--%>
                        <div class="form-group">
                            <label for="Cantidadlabel" class="col-md-1 control-label input-sm" style="font-size: small">Cantidad</label>
                            <div class="col-md-1">
                                <asp:TextBox ID="CantidadTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="CantidadTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>



                            <%--Precio--%>

                            <label for="Preciolabel" class="col-md-1 control-label input-sm" style="font-size: small">Precio</label>
                            <div class="col-md-1">
                                <asp:TextBox ID="PrecioTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="PrecioTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                            <div class="col-md-1 ">
                                <asp:Button ID="AgregarButton" runat="server" Text="Agregar" class="btn btn-primary" />
                            </div>
                        </div>

                    </div>
                </div>

            </div>


        </div>
        <%--GRID--%>
        <asp:GridView ID="Grid" CssClass=" col-md-offset-2 col-md-offset-2" runat="server" AllowPaging="true" PageSize="10" ShowHeaderWhenEmpty="false" AutoGenerateDeleteButton="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="767px" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="TipoAnalisisId" HeaderText="TipoAnalisisId" />
              
                <asp:BoundField DataField="Resultado" HeaderText="Resultado" />
               
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
             



            </Columns>
            <EmptyDataTemplate>
                <div style="text-align: center">No hay datos en el Grid.</div>
            </EmptyDataTemplate>
            <AlternatingRowStyle BackColor="White" />

            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>


        <%-- Precio--%>
        <div class="col-md-6 col-md-offset-6">
            <div class="form-group">
                <label for="MontoTextBox" class="col-md-2 control-label input-sm" style="font-size: small">Monto</label>
                <div class="col-md-6">
                    <asp:TextBox ID="MontoTextBox" ReadOnly="true" runat="server" onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="MontoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
        </div>


        <%-- Balance--%>
        <div class="col-md-6 col-md-offset-6">
            <div class="form-group">
                <label for="BalanceTextBox" class="col-md-2 control-label input-sm" style="font-size: small">Balance</label>
                <div class="col-md-6">
                    <asp:TextBox ID="BalanceTextBox" ReadOnly="true" runat="server" onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="BalanceTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
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

   
</asp:Content>