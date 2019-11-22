<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rProveedores.aspx.cs" Inherits="ProyectoFinal_Aplicada2.UI.Registros.rProveedores" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Proveedores</div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

            <div class="container">
              <div class="form-group">
                <label for="Proveedorlabel" class="col-md-3 control-label input-sm" style="font-size: small">ProveedorId</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="ProveedorIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="ProveedorIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Producto no valido" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click"  />
                </div>
            </div>

              <%--Fecha--%>

                <div class="form-group">
                    <label for="fechalabel" class="col-md-3 control-label input-sm">Fecha </label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
            </div>
            <%--Nombre--%>
            <div class="form-group">
                <label for="NombreLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Nombre</label>
                <div class="col-md-4">
                    <asp:TextBox ID="NombreTextBox" runat="server"  onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>


                  <%-- Correp--%>
            <div class="form-group">
                <label for="CorreoLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Correo</label>
                <div class="col-md-2">
                    <asp:TextBox ID="CorreoTextBox" runat="server" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="CorreoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
'
                  <%--Telefono--%>
            <div class="form-group">
                <label for="TelefonoLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Telefono</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TelefonoTextBox" runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

                  <%--Celular--%>
            <div class="form-group">
                <label for="CelularLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Celular</label>
                <div class="col-md-2">
                    <asp:TextBox ID="CelularTextBox" runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="CelularTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
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
