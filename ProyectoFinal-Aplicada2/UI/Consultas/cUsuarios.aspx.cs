﻿using BLL;
using Entidades;
using ProyectoFinal_Aplicada2.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Aplicada2.UI.Consultas
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                HastaFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");


            }

        }

        public List<Usuarios> lista = new List<Usuarios>();
        protected void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtros = x => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> lista = new List<Usuarios>();

            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            int criterio = Utils.ToInt(CriterioTextBox.Text);
            switch (FiltroDropDown.SelectedIndex)
            {
                case 0:
                    filtros = x => true;
                    break; //todo
                case 1:
                    filtros = c => c.UsuarioId == criterio;
                    break; //ID
                case 3:
                    filtros = c => c.Nombre.Contains(CriterioTextBox.Text);
                    break;
                case 4:
                    filtros = c => c.Email.Contains(CriterioTextBox.Text);
                    break;
                case 5:
                    filtros = c => c.NivelUsuario.Contains(CriterioTextBox.Text);
                    break;
                case 6:
                    filtros = c => c.Usuario.Contains(CriterioTextBox.Text);
                    break;

            }
            if (FechaCheckBox1.Checked == true)
            {
                lista = repositorio.GetList(filtros).Where(x => x.FechaIngreso.Date >= Desde && x.FechaIngreso.Date <= Hasta).ToList();
            }
            else
            {
                lista = repositorio.GetList(filtros);
            }
            Grid.DataSource = lista;
            Grid.DataBind();

        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\UI\Reportes\UsuarioReporte.aspx");
        }
    }
}