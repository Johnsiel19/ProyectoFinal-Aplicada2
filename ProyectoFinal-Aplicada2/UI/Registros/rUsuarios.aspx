<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoFinal_Aplicada2.UI.Registros.rUsuarios" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Usuarios</div>

    
                <div class="form-horizontal col-md-12" role="form">

                    <div class="container">
                        <div class="form-group">
                            <br />
                            <label for="UsuarioIdlabel" class="col-md-3 control-label input-sm" style="font-size: small">UsuarioId</label>
                            <div class="col-md-1 ">
                                <asp:TextBox ID="UsuarioIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="UsuarioIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Producto no valido" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                            <div class="col-md-1 ">
                                <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click"/>
                            </div>
                        </div>

                        <%--FEcha--%>

                        <div class="form-group">
                            <label for="fechalabel" class="col-md-3 control-label input-sm">Fecha </label>
                            <div class="col-md-3">
                                <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <%--Noombre--%>
                        <div class="form-group">
                            <label for="NombreLabel" class="col-md-3 control-label input-sm" style="font-size: small">Nombre</label>
                            <div class="col-md-5">
                                <asp:TextBox ID="NombreTextBox" runat="server" onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="Valida" runat="server" MaxLength="100" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </div>

                        <%--Correo--%>
                        <div class="form-group">
                            <label for="CorreoLabel" class="col-md-3 control-label input-sm" style="font-size: small">Correo</label>
                            <div class="col-md-5">
                                <asp:TextBox ID="CorreoTextBox" runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" MaxLength="100" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="CorreoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </div>




                        <%--NivelUsuario--%>
                        <div class="form-group">
                            <label for="NilvelUsuariolabel" class="col-md-3 control-label input-sm" style="font-size: small">NivelUsuario</label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="NivelUsuarioComboBox" class="form-control input-sm" Style="font-size: small">
                                    <asp:ListItem>Admin</asp:ListItem>
                                    <asp:ListItem>Usuario</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="NivelUsuarioComboBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Proveedor es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </div>

                     


                        <%--Usuario--%>
                        <div class="form-group">
                            <label for="UsuarioLabel" class="col-md-3 control-label input-sm" style="font-size: small">Usuario</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="UsuarioTextBox" runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" MaxLength="100" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="UsuarioTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </div>


                        <%--Clave--%>
                        <div class="form-group">
                            <label for="ClaveLabel"  class="col-md-3 control-label input-sm" style="font-size: small">Clave</label>
                            <div class="col-md-4">
                                <asp:TextBox type="password" ID="ClaveTextBox"  runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" MaxLength="100" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="ClaveTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </div>


                         <%--Confirmar--%>
                        <div class="form-group">
                            <label for="ConfirmarClaveLabel" class="col-md-3 control-label input-sm" style="font-size: small">Confirmar Clave</label>
                            <div class="col-md-4">
                                <asp:TextBox type="password" ID="ConfirmarClaveTextBox"  runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" MaxLength="100" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="ConfirmarClaveTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </div>


                    </div>

         
                <%--Botones--%>
                <div class="panel">
                    <div class="text-center">
                        <div class="form-group">
                            <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="NuevoButton_Click"  />
                            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="GuardarButton_Click"  />
                            <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click"  />
                        </div>
                    </div>
                </div>
            </div>
            </div>
    </div>
</asp:Content>