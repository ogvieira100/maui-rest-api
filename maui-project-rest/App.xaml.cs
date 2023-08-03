using maui_project_rest.MVVM.View;

namespace maui_project_rest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MenuView());
        }
    }
}