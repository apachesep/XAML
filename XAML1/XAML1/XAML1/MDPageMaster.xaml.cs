using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAML1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPageMaster : ContentPage
    {
        public ListView ListView;

        public MDPageMaster()
        {
            InitializeComponent();

            BindingContext = new MDPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MDPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPageMenuItem> MenuItems { get; set; }
            public MDPageMenuItem MenuItemSelected { get; set; }

            public MDPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPageMenuItem>(new[]
                {
                    new MDPageMenuItem { Id = 0, Title = "Profile", ImageName="Profile.png" },
                    new MDPageMenuItem { Id = 1, Title = "Speakers", ImageName="speakers.png" },
                    new MDPageMenuItem { Id = 2, Title = "Sponsors", ImageName="sponsors.png" },
                    new MDPageMenuItem { Id = 3, Title = "About", ImageName="about.png" },
                    new MDPageMenuItem { Id = 4, Title = "Ask for help", ImageName="askforhelp.png" },
                    new MDPageMenuItem { Id = 4, Title = "Sign Out", ImageName="signout.png", TitleColor = Color.FromHex("#EA2027") },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void OnMenuItem(object sender, TappedEventArgs e)
        {
            var bindingContextViewModel = BindingContext as MDPageMasterViewModel;

            var item = e.Parameter as MDPageMenuItem;
            MDPage mdPage = Application.Current.MainPage as MDPage;
            if (item.Title == "Profile")
            {
                var currentPage = ((mdPage.Detail as NavigationPage).CurrentPage) as ContentPage;
                currentPage.Navigation.PushAsync(new SpeakerPage());
            }
            else if (item.Title == "Speakers")
            {
                var currentPage = ((mdPage.Detail as NavigationPage).CurrentPage) as ContentPage;
                currentPage.Navigation.PushAsync(new SpeakersPage());
            }
            else
            {

            }
        }
    }
}