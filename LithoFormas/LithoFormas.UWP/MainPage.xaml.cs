using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace LithoFormas.UWP
{
    public sealed partial class MainPage : LithoFormas_SQLAzure
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            try
            {
                usuario = await LithoFormas.Login.cliente.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount,"lithoformas.azurewebsites.net");
                if (usuario != null)  /* La variable usuario no esta vacia, si no esta vacia ejecuta lo que esta dentro del if*/
                {
                    await new MessageDialog(usuario.UserId, "Bienvenido").ShowAsync();
                    //PRIMERO MENSAJE Y DESPUES EL TITULO
                }
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message, "Error").ShowAsync();
            }
            return usuario;
        }

        public async Task<bool> LogoutAsync()
        {
            usuario = null;
            await LithoFormas.Login.cliente.LogoutAsync();
            return true;
        }

        public MainPage()
        {
            this.InitializeComponent();
            LithoFormas.App.Init((LithoFormas_SQLAzure)this);
            LoadApplication(new LithoFormas.App());
        }
    }
}

