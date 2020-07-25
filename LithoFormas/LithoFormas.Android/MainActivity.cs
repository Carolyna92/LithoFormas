
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Android.Webkit;
using System;

namespace LithoFormas.Droid
{
    [Activity(Label = "LithoFormas", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, LithoFormas_SQLAzure
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            var message = string.Empty;
            try
            {
                usuario = await LithoFormas.Login.cliente.LoginAsync(this, MobileServiceAuthenticationProvider.MicrosoftAccount, "lithoformas.azurewebsites.net");
                if (usuario != null)
                {
                    message = string.Format("Iniciando Sesion{0].", usuario.UserId);

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("");
            builder.Create().Show();
            return usuario;
        }
        public async Task<bool> LogoutAsync()
        {
            CookieManager.Instance.RemoveAllCookie();
            await LithoFormas.Login.cliente.LogoutAsync();
            return true;
        }


        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            App.Init((LithoFormas_SQLAzure)this);
            LoadApplication(new App());
        }
    }
}

