using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LithoFormas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro_T : ContentPage
    {
        public ObservableCollection<litho> items { get; set; }
        public static IMobileServiceTable<litho> Tabla;
        public ObservableCollection<autenticados> itms { get; set; }
        public static IMobileServiceTable<autenticados> tbl;
        string dependencia;
        string asiganada;
        string usuario;
        public Registro_T()
        {
            InitializeComponent();
            
            E.SelectedIndex = 0;
            E.IsEnabled = false;
            Tabla = Login.cliente.GetTable<litho>();
            tbl = Login.cliente.GetTable<autenticados>();
            Tareas();
            //IDUser();
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (titulo_tarea.Text !=null)
            {
                if (Descripcion != null)
                {
                        if (Prip.SelectedItem != null)
                        { 
                            var datos = new litho
                            {
                                Titulo = titulo_tarea.Text,
                                Descripcion = Descripcion.Text,
                                //Nombre_Persona=Convert.ToInt16(PA.SelectedIndex),
                                Fecha_Entrega = Convert.ToDateTime(Fecha_Entrega.Date),
                                Prioridad =Convert.ToInt32(Prip.SelectedIndex),
                                Status=Convert.ToInt32(E.SelectedIndex),
                                Dependencia=Convert.ToString(Dependencia.SelectedItem)
                            };
                        try
                        {
                            await Master.Tabla.InsertAsync(datos);
                        }
                        catch(Exception ex)
                        {
                            await DisplayAlert("", "No se pudo ingresar por: " + ex + "","OK");
                        }
                        }
                        else
                        {
                            await DisplayAlert("", "Selecciona una prioridad", "OK");
                        }
                }
                else
                {
                    await DisplayAlert("", "Ingresa una descripcion", "OK");
                }
            }
            else
            {
                await DisplayAlert("", "Ingresa un titulo", "OK");
            }
        }
        private void titulo_tarea_TextChanged(object sender, TextChangedEventArgs e)
        {
            titulo_tarea.Text = titulo_tarea.Text.ToUpper();
        }

        private void Descripcion_TextChanged(object sender, TextChangedEventArgs e)
        {
            Descripcion.Text = Descripcion.Text.ToUpper();
        }

        private async void Tareas()
        {
            IEnumerable<litho> elementos = await Tabla.ToEnumerableAsync();
            items = new ObservableCollection<litho>(elementos);
            int cont = items.Count;
            var List = new List<string>();
            for (int i = 0; i < cont; i++)
            {
                List.Add(items[i].Titulo);
            }
            Dependencia.ItemsSource = List;
        }

        private void Dependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                dependencia = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private void Prip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async void IDUser()
        {
            IEnumerable<autenticados> elementos = await tbl.ToEnumerableAsync();
            itms = new ObservableCollection<autenticados>(elementos);
            string[] IDUser = new string[itms.Count()];
            int i = 0;
            foreach (var usuario in itms)
            {
                IDUser[i] = usuario.Nombre;
                i++;
            }
            PA.ItemsSource = IDUser;
            PA.SelectedIndex = 0;
        }

        private void PA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                usuario = (string)picker.ItemsSource[selectedIndex];
            }
        }
    }
}