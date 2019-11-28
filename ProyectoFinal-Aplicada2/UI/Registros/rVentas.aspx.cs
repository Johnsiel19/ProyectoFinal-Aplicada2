using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Aplicada2.UI.Registros
{
    public partial class rVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarClientes();
            ProductoDropDown_SelectedIndexChanged(sender, e);
           


            if (!Page.IsPostBack)
            {
                Limpiar();
                      
                ViewState["Ventas"] = new Ventas();
                BindGrid();

            }

            int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

            if (ID > 0)
            {
                RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
                var us = repositorio.Buscar(ID);

                if (us == null)
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "Registro No encontrado", "Error", "error");
                }
                else
                {
                    LlenaCampo(us);
                }
            }
         
        }

        private void Limpiar()
        {

            VentaIdTextBox.Text = "0";
            ClienteIdDropDown.Text = null;
            ProductoDropDown.Text = null;
            CantidadTextBox.Text = "0.00";
             PrecioTextBox.Text = "0.00";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            SubTotalTextBox.Text = "0.00";
            ItbisTextBox.Text = "0.00";
            TotalTextBox.Text = "0.00";
            
            Grid.DataSource = null;
            Grid.DataBind();

        }

        private Ventas LlenaClase()
        {

            Ventas venta = new Ventas();
          
            venta = (Ventas)ViewState["Ventas"];
            venta.VentaId = Convert.ToInt32(VentaIdTextBox.Text);
            venta.ClienteId = Convert.ToInt32( ClienteIdDropDown.SelectedValue);
            venta.Fecha = DateTime.Now;
            venta.Modo = ModoDropDownList.Text;
            venta.SubTotal = Convert.ToDecimal(SubTotalTextBox.Text);
            venta.Total = Convert.ToDecimal(TotalTextBox.Text);
            venta.Itbis = Convert.ToDecimal(ItbisTextBox.Text);
            venta.UsuarioId = 0;
           
             venta.Balance = Convert.ToDecimal(TotalTextBox.Text);
            return venta;

        }

        private void LlenaCampo(Ventas venta)
        {

            ((Ventas)ViewState["Ventas"]).Detalle = venta.Detalle;

            VentaIdTextBox.Text= venta.VentaId.ToString();
            ClienteIdDropDown.SelectedValue = venta.ClienteId.ToString();
            FechaTextBox.Text = venta.Fecha.ToString("yyyy-MM-dd");
            ModoDropDownList.Text = venta.Modo;
            TotalTextBox.Text = venta.Total.ToString();
            ItbisTextBox.Text = venta.Itbis.ToString();
            SubTotalTextBox.Text = venta.SubTotal.ToString();
           
          
            this.BindGrid();
        }
 

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();
            Ventas venta = db.Buscar(Convert.ToInt32(VentaIdTextBox.Text));
            return (venta != null);

        }


        private void CargarClientes()
        {
            if (!Page.IsPostBack)
            {
                RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();


                ClienteIdDropDown.DataSource = db.GetList(t => true);
                ClienteIdDropDown.DataValueField = "ClienteId";
                ClienteIdDropDown.DataTextField = "Nombre";
                ClienteIdDropDown.DataBind();

        
            }

        }
        private void CargarProductos()
        {
            if (!Page.IsPostBack)
            {
                RepositorioBase<Productos> db = new RepositorioBase<Productos>();


                ProductoDropDown.DataSource = db.GetList(t => true);
                ProductoDropDown.DataValueField = "ProductoId";
                ProductoDropDown.DataTextField = "Descripcion";
                ProductoDropDown.DataBind();

              
            }

        }

        protected void BindGrid()
        {
            if (ViewState["Ventas"] != null)
            {
                Grid.DataSource = ((Ventas)ViewState["Ventas"]).Detalle;
                Grid.DataBind();


            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Ventas  ventas;
            bool paso = false;
            RepositorioBase<Ventas> db= new RepositorioBase<Ventas>();
            if (Validar())
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El Campo Nombre no puede estar vacio", "Error", "error");
                return;
            }
            ventas = db.Buscar(Convert.ToInt32(VentaIdTextBox.Text));
       


            ventas = LlenaClase();


            if (VentaIdTextBox.Text == 0.ToString())
            {
                paso = VentaBLL.Guardar(ventas);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "Se ha podido modificar", "Error", "error");
                    return;
                }
                paso = VentaBLL.Modificar(ventas);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, " Se ha Guardado", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();


        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {


            if (Utilitarios.Utils.ToInt(VentaIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(VentaIdTextBox.Text);

                if (VentaBLL.Eliminar(id))
                {

                    Utilitarios.Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utilitarios.Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se pudo eliminar, Venta existe", "error", "error");
            }

        }

        public bool Validar()
        {
            bool paso = false;

            if (VentaIdTextBox.Text == string.Empty)
            {
                paso = true;
            }

            return paso;

        }


        public bool ValidarGrid()
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos producto = new Productos();
            int id = 0;
            int.TryParse(ProductoDropDown.SelectedValue, out id);



            if (producto != null)
            {

                producto = db.Buscar(id);

            }
     

            bool paso = false;

            if (ProductoDropDown.Text == "")
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Elija un producto", "error", "error");
                paso = true;
            }


            if (Convert.ToDecimal( PrecioTextBox.Text)  < Convert.ToDecimal(producto.Costo))
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El precio es menor al costo", "error", "error");
                paso = true;


            }

            if (producto.Existencia - Convert.ToDecimal( CantidadTextBox.Text)< 0)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "La exitencia del producto es insufuciente", "error", "error");
                paso = true;



            }
            if (ExisteEnGrid() == true)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Ese producto ya existe en el grid", "error", "error");
                paso = true;
            }
            if (Convert.ToDecimal( CantidadTextBox.Text) < 1)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "", "error", "error");
                paso = true;

            }

            return paso;


        }


        private bool ExisteEnGrid()
        {
            bool paso = false;
            Ventas venta = new Ventas();
            ViewState["Ventas"] = venta;


            if (Grid.Rows.Count > 0)
            {
               

                foreach (var item in venta.Detalle)
                {
                   if( item.ProductoId == Convert.ToInt32(ProductoDropDown.SelectedValue))
                    {
                        paso = true;
                    }

                }

            }


         


            return paso;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;

            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();
            Ventas venyas = new Ventas();
            int.TryParse(VentaIdTextBox.Text, out id);
            Limpiar();


            venyas = db.Buscar(id);

            if (venyas != null)
            {

                LlenaCampo(venyas);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro la venta", "Error", "error");

            }

        }

        
      
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos producto = new Productos();
       

           
            producto = db.Buscar(Convert.ToInt32(ProductoDropDown.Text));

            Ventas venta = new Ventas();

            venta = (Ventas)ViewState["Ventas"];


            decimal itbis = (producto.ProductoItbis * Convert.ToDecimal( 0.01));
          
            decimal monto = Convert.ToDecimal( PrecioTextBox.Text )* Convert.ToDecimal(CantidadTextBox.Text);
            decimal itbisTotal = monto * itbis;
          decimal importe = Convert.ToDecimal(monto )+ itbis;

           
             venta.Detalle.Add(new Entidades.VentasDetalle(0, 0,
                Convert.ToInt32(ProductoDropDown.SelectedValue),
                ProductoDropDown.SelectedItem.Text, Convert.ToDecimal(CantidadTextBox.Text), Convert.ToDecimal(PrecioTextBox.Text),itbisTotal, importe)) ;

            ViewState["Ventas"] = venta;

            this.BindGrid();

            Grid.Columns[1].Visible = false;
    

            decimal Subtotal = 0;
            decimal Itbis = 0;
            decimal total = 0;
            

            foreach (var item in venta.Detalle)
            {
                Subtotal = Subtotal + item.Importe;
                Itbis = Itbis + item.Itbis;
              

            }
            total = total + (Itbis + Subtotal);
            TotalTextBox.Text = total.ToString();

            SubTotalTextBox.Text = Subtotal.ToString();
            ItbisTextBox.Text = Itbis.ToString();
            ProductoDropDown.Text = null;
          
        }

        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Ventas venta = new Ventas();
            venta = (Ventas)ViewState["Ventas"];
            ViewState["Venta"] = venta.Detalle;

            int Fila = e.RowIndex;

            venta.Detalle.RemoveAt(Fila);
            this.BindGrid();


            decimal Subtotal = 0;
            decimal Itbis = 0;


            foreach (var item in venta.Detalle)
            {
                Subtotal = Subtotal + item.Importe;
                Itbis = Itbis + item.Itbis;
            }

            TotalTextBox.Text = (Subtotal + Itbis).ToString();

            SubTotalTextBox.Text = Subtotal.ToString();
            ItbisTextBox.Text = Itbis.ToString();

        }

        protected void ProductoDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos venta = new Productos();
            int.TryParse(ProductoDropDown.SelectedValue, out id);

            if(db.Buscar(id) != null)
            {
                venta = db.Buscar(id);

                PrecioTextBox.Text = Convert.ToString(venta.Precio);
                ExistencaTextBox.Text = Convert.ToString(venta.Existencia);

            }

            
       

        }
    }
}