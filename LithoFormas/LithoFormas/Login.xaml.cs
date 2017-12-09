using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;

namespace LithoFormas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        public static MobileServiceClient cliente;
        public static MobileServiceUser usuario;
        public static IMobileServiceTable<autenticados> Tabla;
        public ObservableCollection<autenticados> Items { get; set; }
        public Login ()
		{
			InitializeComponent ();
            cliente = new MobileServiceClient(AzureConnection_LF.AzureURL);
            Tabla = cliente.GetTable<autenticados>();
        }

        public async void Log_in_Clicked(object sender, EventArgs e)
        {
            if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                usuario = await App.Authenticator.Authenticate();
                if (App.Authenticator != null)
                {
                    if (usuario != null)
                    {
                        string user = Convert.ToString(usuario.UserId);
                        var datos = new autenticados
                        {
                            User_id = Convert.ToString(user),
                        };
                        try
                        {
                            await Tabla.InsertAsync(datos);
                            await Navigation.PushAsync(new Master());
                        }
                        catch (Exception)
                        {

                        }
                        finally
                        {
                            await Navigation.PushAsync(new Master());
                        }
                        

                    }
                }
            }
            else
            {
                await DisplayAlert("Sin Conexion", "Comprobar la conexion a internet", "OK");
            }
        }
    }
}