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
    public partial class Usuarios : ContentPage
    {
        public static IMobileServiceTable<autenticados> Tabla;
        public ObservableCollection<autenticados> Items { get; set; }
        string usuario;
        public Usuarios()
        {
            InitializeComponent();
            Tabla = Login.cliente.GetTable<autenticados>();
            IDUser();
        }

        private void b_id_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private async void IDUser()
        {
            IEnumerable<autenticados> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<autenticados>(elementos);
            string[] IDUser = new string[Items.Count()];
            string[] IDU = new string[Items.Count()];
            int i = 0;
            int iD = 0;
            foreach (var usuario in Items)
            {
                IDUser[i] = usuario.User_id;
                IDU[iD] = usuario.Id;
                i++;
                iD++;
            }
            user_id.ItemsSource = IDUser;
            user_id.SelectedIndex = 0;
            usuario_ID.Text = Convert.ToString(IDU);
            
        }

        private void user_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                usuario = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private void registrosLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void registrosLV_Refreshing(object sender, EventArgs e)
        {

        }

        private async void actualizar_Clicked(object sender, EventArgs e)
        {
            if (nombre.Text != null)
            {
                if (rol.SelectedItem != null)
                {
                    var Datos = new autenticados
                    {
                        Id= usuario_ID.Text,
                        Nombre = nombre.Text,
                        Rol = Convert.ToInt16(rol.SelectedIndex)
                    };
                    //await Tabla.UpdateAsync(Datos);
                }
                else
                {
                    await DisplayAlert("", "Seleccione un Rol","OK");
                }
            }
            else
            {
                await DisplayAlert("", "Ingrese un nombre", "OK");
            }
            
        }
    }
}