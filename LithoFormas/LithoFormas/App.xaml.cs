
using Xamarin.Forms;
using Microsoft.Identity.Client;

namespace LithoFormas
{
    public partial class App : Application
    {
        public static PublicClientApplication IdentityClientApp = null;
        public static UIParent UiParent = null;

        public static string ClientID = "d86708cf-239f-4988-b650-98e9dc5b80cd";
        public static string[] Scopes = { "https://graph.microsoft.com/User.Read",
                                          "https://graph.microsoft.com/Calendars.Read",
                                          "https://graph.microsoft.com/Contacts.Read",
                                          "https://graph.microsoft.com/User.ReadBasic.All ",
                                          "https://graph.microsoft.com/Mail.Send" };
        public static LithoFormas_SQLAzure Authenticator { get; private set; }
        public static void Init(LithoFormas_SQLAzure authenticator)
        {
            Authenticator = authenticator;
        }
        public App()
        {
            InitializeComponent();
            //IdentityClientApp = new PublicClientApplication(ClientID);
            MainPage = new NavigationPage(new LithoFormas.Login());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
