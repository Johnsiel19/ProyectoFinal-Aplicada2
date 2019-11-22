<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="ProyectoFinal_Aplicada2.UI.Registros.rProductos" %>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Productos</div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

            <div class="container">
              <div class="form-group">
                <label for="ProductoIdlabel" class="col-md-3 control-label input-sm" style="font-size: small">ProductoId</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="ProductoIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="ProductoIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Producto no valido" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click"  />
                </div>
            </div>

              <%--FEcha--%>

                <div class="form-group">
                    <label for="fechalabel" class="col-md-3 control-label input-sm">Fecha: </label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
            </div>
            <%--Descripcion--%>
            <div class="form-group">
                <label for="DescripcionLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Descripcion</label>
                <div class="col-md-6">
                    <asp:TextBox ID="DescripcionTextBox" runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="DescripcionTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

        
                    
                
                  <%--Proveedor--%>
           <div class="form-group">
                      <label for="Analisis" class="col-md-3 control-label input-sm" style="font-size: small" >Proveedor</label>
                         <div class="col-md-4">
                            <asp:DropDownList   runat="server" AutoPostBack="true" ID="ProveedorIdTextbox" class="form-control input-sm" Style="font-size: small" ></asp:DropDownList>
                        </div>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="DescripcionTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Proveedor es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                     </div>


               <%-- Existencia--%>
                 <div class="form-group">
                <label for="Existencialabel" class="col-md-3 control-label input-sm" style="font-size: small">Existencia</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="ExistenciaTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                        </div>
          <%--Costo--%>
             <div class="form-group">
                <label for="Costolabel" class="col-md-3 control-label input-sm" style="font-size: small">Costo</label>
                <div class="col-md-2">
                    <asp:TextBox ID="CostoTextBox"  runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="CostoTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
          
            </div>




                 <%-- Precio--%>
             <div class="form-group">
                <label for="Preciolabel" class="col-md-3 control-label input-sm" style="font-size: small">Precio</label>
                <div class="col-md-2">
                    <asp:TextBox ID="PrecioTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="PrecioTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
          
            </div>

                 <%-- Itbis--%>
             <div class="form-group">
                <label for="Itebislabe;" class="col-md-3 control-label input-sm" style="font-size: small">ITBIS</label>
                <div class="col-md-2">
                    <asp:TextBox ID="ItbisTextBox"  runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="ItbisTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
          
            </div>
                
            </div>
            
            </div>
            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="NuevoButton_Click"   />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click"  />
                    </div>
                </div>
            </div>
        </div>
            </div>
    </div>
</asp:Content>