namespace TranquilEase.Views;

public partial class PaginaDeLogin : ContentPage
{
	public PaginaDeLogin()
	{
		InitializeComponent();

        BindingContext = new ViewModels.LoginViweModel();


    }
}