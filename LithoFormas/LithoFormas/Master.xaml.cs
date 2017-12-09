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
    public partial class Master : MasterDetailPage
    {
        public static IMobileServiceTable<litho> Tabla;
        public ObservableCollection<litho> Items { get; set; }
        public Master()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Default;
            }
            Tabla = Login.cliente.GetTable<litho>();
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                MasterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
                return;

            
            //var item = e.SelectedItem as MenuItem;
            //if (item == null)
            //    return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;
            //Detail = new NavigationPage(page);
            //IsPresented = false;
            //MasterPage.ListView.SelectedItem = null;
        }
    }
}