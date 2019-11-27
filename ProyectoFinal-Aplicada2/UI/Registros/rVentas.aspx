<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="ProyectoFinal_Aplicada2.UI.Registros.rVentas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="panel panel-primary">
        <div class="panel-heading">Registro de Ventas</div>

        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">

            
                    <div class="form-group">
                        <label for="VentaLabel" class="col-md-2   control-label input-sm" style="font-size: small">VentaId</label>
                        <div class="col-md-2 ">
                            <asp:TextBox ID="VentaIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                        </div>
                        <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="VentaIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <div class="col-md-3 ">
                            <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click" />
                        </div>
                        <%--Fecha--%>
                        <label for="FechaTebox" class="col-md-2 control-label input-sm" style="font-size: small">Fecha</label>
                        <div class="col-md-2">
                            <asp:TextBox ID="FechaTextBox" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>

                        </div>
                    </div>


                    <%--Cliente--%>
                    <div class="form-group">
                        <label for="ClienteLabel" class="col-md-2 control-label input-sm" style="font-size: small">Cliente</label>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="ClienteIdDropDown" class="form-control input-sm" Style="font-size: small"></asp:DropDownList>
                        </div>
                        <label for="ModoLabel" class="col-md-4 control-label input-sm" style="font-size: small">Modo de Compra</label>
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="ModoDropDownList" class="form-control input-sm" Style="font-size: small">
                                <asp:ListItem>Contado</asp:ListItem>
                                <asp:ListItem>Credito</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="ModoDropDownList" ForeColor="Red" Display="Dynamic" ToolTip="Campo Proveedor es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </div>

                    <%--TipoAnalisisId--%>


                    <div class="form-group row">
                        <label for="Productolabel" class="col-md-2 control-label input-sm" style="font-size: small">Producto</label>
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="ProductoDropDown" CssClass="form-control input-sm" OnSelectedIndexChanged="ProductoDropDown_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                  
                        <%--Cantidad--%>
                 
                            <label for="Cantidadlabel" class="col-md-1 control-label input-sm" style="font-size: small">Cantidad</label>
                            <div class="col-md-1">
                                <asp:TextBox ID="CantidadTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="CantidadTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ></asp:RegularExpressionValidator>


                            <%--Existencia--%>
                 
                            <label for="Existencialabel" class="col-md-1 control-label input-sm" style="font-size: small">Existencia</label>
                            <div class="col-md-1">
                                <asp:TextBox ID="ExistencaTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                            </div>
                         




                            <%--Precio--%>

                            <label for="Preciolabel" class="col-md-1 control-label input-sm" style="font-size: small">Precio</label>
                            <div class="col-md-1">
                                <asp:TextBox ID="PrecioTextBox" ReadOnly="true"  runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                            </div>

                            <div class="col-md-1 ">
                                <asp:Button ID="AgregarButton" runat="server" Text="Agregar" class="btn btn-primary" OnClick="AgregarButton_Click" />
                            </div>
                      

                    </div>
                </div>

            </div>


   
        <%--GRID--%>
        <asp:GridView ID="Grid" CssClass=" col-md-offset-2 col-md-offset-2"  runat="server" AllowPaging="true" PageSize="10" ShowHeaderWhenEmpty="false" AutoGenerateDeleteButton="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="835px" AutoGenerateColumns="false" OnRowDeleting="Grid_RowDeleting">
            <Columns>
      

                 <asp:BoundField DataField="VentaDetalleId" HeaderText="Id" /><asp:BoundField />
              
                        <asp:BoundField DataField="ProductoId" HeaderText="ProductoId" /><asp:BoundField />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" /><asp:BoundField />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" /><asp:BoundField />
                         <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" /><asp:BoundField />
                        <asp:BoundField DataField="Itbis" HeaderText="Itbis" /><asp:BoundField />
                        <asp:BoundField DataField="Importe" HeaderText="Importe" /><asp:BoundField />

             



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

             <br />
        <%-- Subtotal--%>
        <div class="col-md-6 col-md-offset-7">
            <div class="form-group">
                <label for="SubTotalLabel" class="col-md-2 control-label input-sm" style="font-size: small">Sub Total</label>
                <div class="col-md-6">
                    <asp:TextBox ID="SubTotalTextBox"  ReadOnly="true" runat="server" onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="SubTotalTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
        </div>

                <%--Itbis--%>
        <div class="col-md-6 col-md-offset-7">
            <div class="form-group">
                <label for="ItbisLabel" class="col-md-2 control-label input-sm" style="font-size: small">Itbis</label>
                <div class="col-md-6">
                    <asp:TextBox ID="ItbisTextBox" ReadOnly="true"  runat="server" onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="ItbisTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
        </div>




        <%-- TOtal--%>
        <div class="col-md-6 col-md-offset-7">
            <div class="form-group">
                <label for="TotalTextBox" class="col-md-2 control-label input-sm" style="font-size: small">Total</label>
                <div class="col-md-6">
                    <asp:TextBox ID="TotalTextBox" ReadOnly="true" runat="server" onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="TotalTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <%--Botones--%>
        <div class="panel">
            <div class="text-center">
                <div class="form-group">
                    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="NuevoButton_Click" />
                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click" />
                </div>
            </div>
        </div>
    </div>

   
</asp:Content>