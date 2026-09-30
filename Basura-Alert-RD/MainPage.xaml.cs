using Basura_Alert_RD.ViewModels;

namespace Basura_Alert_RD;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}