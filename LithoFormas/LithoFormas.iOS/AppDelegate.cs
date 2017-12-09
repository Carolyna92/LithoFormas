﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;


namespace LithoFormas.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, LithoFormas_SQLAzure
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            var message = string.Empty;
            try
            {
                usuario = await LithoFormas.Login.cliente.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.MicrosoftAccount, "lithoformas.azurewebsites.net");
                if(usuario != null)
                {
                    message = string.Format("Iniciando sesion {0].", usuario.UserId);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            IUIAlertViewDelegate iUAlert = null;
            UIAlertView avAlert = new UIAlertView("Resultado de autenticacion", message, iUAlert, null, "OK", null);
            avAlert.Show();
            return usuario;

        }
        public async Task<bool> LogoutAsync()
        {
            foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
            {
               NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
            }
            await LithoFormas.Login.cliente.LogoutAsync();
            return true;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            App.Init(this);
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

       
    }
}
