<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rClientes.aspx.cs" Inherits="ProyectoFinal_Aplicada2.UI.Registros.rClientes" %>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Clientes</div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

         
              <div class="form-group">
                <label for="ClienteIdlabel" class="col-md-3 control-label input-sm" style="font-size: small">ClienteId</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="ClienteIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="ClienteIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Producto no valido" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click1"  />
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
                <div class="col-md-5">
                    <asp:TextBox ID="NombreTextBox" runat="server"  onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" MaxLength="100" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>


                    <%--Cedula--%>
            <div class="form-group">
                <label for="CedulaLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Cedula</label>
                <div class="col-md-4">
                    <asp:TextBox ID="CedulaTextBox" runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" MaxLength="100" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="CedulaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

       


                  <%-- Correp--%>
            <div class="form-group">
                <label for="CorreoLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Correo</label>
                <div class="col-md-4">
                    <asp:TextBox ID="CorreoTextBox" runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" MaxLength="100" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="CorreoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

                  <%--Telefono--%>
            <div class="form-group">
                <label for="TelefonoLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Telefono</label>
                <div class="col-md-4">
                    <asp:TextBox ID="TelefonoTextBox" runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" MaxLength="100" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

                  <%--Celular--%>
            <div class="form-group">
                <label for="CelularLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Celular</label>
                <div class="col-md-4">
                    <asp:TextBox ID="CelularTextBox" runat="server"   class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" MaxLength="100" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="CelularTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
                   <%--BALANCE--%>
            <div class="form-group">
                <label for="BalanceLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Balance</label>
                <div class="col-md-2">
                    <asp:TextBox ID="BalanceTextBox"  runat="server" ReadOnly="true" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="BalanceTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

                           <%--BALANCE--%>
            <div class="form-group">
                <label for="DireccionLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Direccion</label>
                <div class="col-md-5">
                    <asp:TextBox ID="DireccionTextBox"  runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="DireccionTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>


        
        
                
            </div>
            
          
            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="NuevoButton_Click1"   />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="GuardarButton_Click1" />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click1"  />
                    </div>
                </div>
            </div>
        </div>
            </div>
    </div>
</asp:Content>