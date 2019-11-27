<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="cClientes.aspx.cs" Inherits="ProyectoFinal_Aplicada2.UI.Consultas.rClientes" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">Consulta de Clientes</div>
        <div class="panel-body">

            <%--Desde--%>
            <div class="form-group ">
                <label for="Desde" class="col-sm-1 col-md-offset-1  col-form-label">Desde</label>
                <div class="col-md-2">
                    <asp:TextBox type="date" runat="server" ID="DesdeFecha" Class="form-control input-sm"></asp:TextBox>
                </div>


                <%--Hasta--%>
                <label for="Hasta" class="col-sm-1 col-form-label">Hasta</label>
                <div class="col-md-2">
                    <asp:TextBox type="date" runat="server" ID="HastaFecha" Class="form-control input-sm"></asp:TextBox>
                </div>
                <label for="label" class="col-sm-1 col-form-label">PorFecha</label>
                <asp:CheckBox runat="server" CssClass="custom-checkbox" ID="FechaCheckBox1" />


            </div>
            <br />
            <div class="form-group ">
                <label for="Filtro" class="col-sm-1 col-md-offset-1 col-form-label">Filtro</label>
                <div class="col-md-2">
                    <asp:DropDownList ID="FiltroDropDown" runat="server" CssClass="form-control input-sm">
                        <asp:ListItem>Todo</asp:ListItem>
                        <asp:ListItem>ID</asp:ListItem>

                    </asp:DropDownList>
                </div>


                <label for="Criterio" class="col-sm-1  col-form-label">Criterio</label>
                <div class="col-md-3">
                    <asp:TextBox ID="CriterioTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="ConsultarButton" runat="server" Class="btn btn-primary input-sm" Text="Consultar" OnClick="ConsultarButton_Click" />

                </div>
            </div>

        </div>
        <asp:GridView ID="Grid" runat="server" class="table table-condensed table-responsive" AutoGenerateColumns="true" ShowHeaderWhenEmpty="True" DataKeyNames="ClienteId" CellPadding="4" ForeColor="Black" GridLines="None">
            <EmptyDataTemplate>
                <div style="text-align: center">No hay datos.</div>
            </EmptyDataTemplate>
            <AlternatingRowStyle BackColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:GridView>
        <br />

        <%--Imprimir--%>
        <div class="col-md-4">
            <asp:Button ID="ImprimirButton" runat="server" Class="btn btn-primary input-sm" Text="Imprimnir" />

        </div>



    </div>
</asp:Content>