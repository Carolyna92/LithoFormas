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
    public partial class Task_Update : ContentPage
    {
        public ObservableCollection<litho> items { get; set; }
        public static IMobileServiceTable<litho> Tabla;
        public ObservableCollection<autenticados> itms { get; set; }
        public static IMobileServiceTable<autenticados> tbl;
        string dependencia;
        string usuario;
        public static bool del;
        public Task_Update(object selectedItem)
        {
            var dato = selectedItem as litho;
            BindingContext = dato;
            InitializeComponent();
            id.Text = dato.Id;
            titulo_tarea.Text = dato.Titulo;
            Descripcion.Text = dato.Descripcion;
            PA.SelectedIndex= Convert.ToInt16(dato.Asignada);
            Prip.SelectedIndex = Convert.ToInt16(dato.Prioridad);
            Fecha_Entrega.Date = Convert.ToDateTime(dato.Fecha_Entrega);
            E.SelectedIndex = Convert.ToInt16(dato.Status);
            eliminados.IsToggled = dato.Deleted;
            bool el = dato.Deleted;
            //switch eliminados
            //Eliminar
            if (el == true)
            {
                del = true;
                eliminados.IsVisible = true;
                eliminados.IsEnabled = false;
                Eliminar.IsEnabled = false;
                Eliminar.IsVisible = false;
            }
            else
            {
                eliminados.IsVisible = false;
                eliminados.IsEnabled = false;
            }
            //Tareas();
        }

        private void Actualizar_Clicked(object sender, EventArgs e)
        {
            titulo_tarea.IsEnabled = true;
            Descripcion.IsEnabled = true;
            PA.IsEnabled = true;
            Prip.IsEnabled = true;
            Fecha_Entrega.IsEnabled = true;
            E.IsEnabled = true;
            Dependencia.IsEnabled = true;
            if (del == false)
            {
                eliminados.IsEnabled = false;
                eliminados.IsVisible = false;
            }
            else
            {
                if (del == true)
                {
                    eliminados.IsEnabled = true;
                    eliminados.IsVisible = true;
                }                
            }
            Actualizar.IsEnabled = false;
            Actualizar.IsVisible = false;
            Cancelar.IsEnabled = true;
            Cancelar.IsVisible = true;
            Enviar.IsEnabled = true;
            Enviar.IsVisible = true;
            Eliminar.IsEnabled = false;
            Eliminar.IsVisible = false;
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var Datos = new litho
            {
                Id = id.Text
            };
            await Master.Tabla.DeleteAsync(Datos);
        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            titulo_tarea.IsEnabled = false;
            Descripcion.IsEnabled = false;
            PA.IsEnabled = false;
            Prip.IsEnabled = false;
            Fecha_Entrega.IsEnabled = false;
            E.IsEnabled = false;
            eliminados.IsEnabled = false;
        }

        private async void Enviar_Clicked(object sender, EventArgs e)
        {
            if (titulo_tarea.Text != null)
            {
                if (Descripcion.Text != null)
                {
                    var Datos = new litho
                    {
                        Id = id.Text,
                        Titulo = titulo_tarea.Text,
                        Descripcion = Descripcion.Text,
                        //Nombre_Persona = Convert.ToString(PA.SelectedItem),
                        Prioridad = Convert.ToInt16(Prip.SelectedIndex),
                        Fecha_Entrega = Fecha_Entrega.Date,
                        Status = E.SelectedIndex,
                        Deleted = eliminados.IsToggled,
                        Dependencia = Convert.ToString(Dependencia.SelectedItem)
                    };
                    try
                    {
                        if (del==true)
                        {
                            await Master.Tabla.UndeleteAsync(Datos);
                        }
                        else
                        {
                            await Master.Tabla.UpdateAsync(Datos);
                        }
                    }catch(Exception ex)
                    {
                        await DisplayAlert("", "No se actualizó por: "+ex+"", "OK");
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
        public async void Tareas()
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