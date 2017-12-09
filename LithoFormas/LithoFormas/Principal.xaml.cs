using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LithoFormas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {

        public ListView ListView { get { return listView; } }

        public Principal()
        {
            InitializeComponent();
            var masterPageItems = new List<MenuItem>();
            masterPageItems.Add(new MenuItem
            {
                Title = "Inicio",
                IconSource = "casa.png",
                TargetType = typeof(Ver_Registros)
            });
            masterPageItems.Add(new MenuItem
            {
                Title = "Tareas Eliminadas",
                IconSource = "eliminar.png",
                TargetType = typeof(Ver_eliminados)
            });
            masterPageItems.Add(new MenuItem
            {
                Title = "Crear Tarea",
                IconSource = "anadir.png",
                TargetType = typeof(Registro_T)
            });
            masterPageItems.Add(new MenuItem
            {
                Title = "Usuarios",
                IconSource = "usuario.png",
                TargetType = typeof(Usuarios)
            });
            listView.ItemsSource = masterPageItems;
        }

        public async void logout_Clicked(object sender, EventArgs e)
        {
            bool loggedOut = false;

            if (App.Authenticator != null)
            {
                loggedOut = await App.Authenticator.LogoutAsync();
                await Navigation.PushAsync(new Login());
            }
        }
    }
}