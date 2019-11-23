<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rCobros.aspx.cs" Inherits="ProyectoFinal_Aplicada2.UI.Registros.rPagos" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Cobros</div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

            <div class="container">
              <div class="form-group">
                <label for="Cobroslabel" class="col-md-3 control-label input-sm" style="font-size: small">CobroId</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="CobroIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="CobroIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Producto no valido" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click"  />
                </div>
            

              <%--FEcha--%>

               
                    <label for="fechalabel" class="col-md-2 control-label input-sm">Fecha: </label>
                        <div class="col-md-2">
                            <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
            </div>

                    <%--Venta--%>
           <div class="form-group">
                      <label for="Ventalabel" class="col-md-3 control-label input-sm" style="font-size: small" >VentaId</label>
                         <div class="col-md-1">
                            <asp:DropDownList   runat="server" AutoPostBack="true" ID="VentaIdTextbox" class="form-control input-sm" Style="font-size: small" OnSelectedIndexChanged="VentaIdTextbox_SelectedIndexChanged" ></asp:DropDownList>
                        </div>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="VentaIdTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Proveedor es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                     </div>
            <%--Cliente--%>
            <div class="form-group">
                <label for="ClienteIdLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Cliente</label>
                <div class="col-md-1">
                    <asp:TextBox ID="ClienteTextBox" ReadOnly="true" runat="server"  onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="ClienteTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
           

            
                <label for="ClienteIdLabel2" class="col-md-2 control-label input-sm" style="font-size: small" >Nombre</label>
                <div class="col-md-3">
                    <asp:TextBox ID="NombreClienteTextBox" ReadOnly="true" runat="server"  onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
              
            </div>

  

      
             <div class="form-group">


                  <%-- Monto Pagado--%>
                      <label for="MontoPagadolabel" class="col-md-2 control-label input-sm" style="font-size: small">Monto a Pagar</label>
                <div class="col-md-2">
                    <asp:TextBox ID="MontoPagadoTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="MontoPagadoTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
          

                   <%-- Monto Pendiente--%>
                <label for="MontoPendientelabel" class="col-md-3 control-label input-sm" style="font-size: small">Monto Pendiente</label>
                <div class="col-md-2">
                    <asp:TextBox ID="MontoPendienteTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="MontoPendienteTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
          
                
             
           
            </div>
         <%--Observacion--%>
            <div class="form-group">
                <label for="ObservacionLabel" class="col-md-3 control-label input-sm" style="font-size: small" >Observacion</label>
                <div class="col-md-6">
                    <asp:TextBox ID="ObservacionTextBox" runat="server"  onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="ObservacionTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
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