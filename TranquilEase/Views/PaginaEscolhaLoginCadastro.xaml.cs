using System.Diagnostics;

namespace TranquilEase.Views;

public partial class PaginaEscolhaLoginCadastro : ContentPage
{
	public PaginaEscolhaLoginCadastro()
	{
		InitializeComponent();
    }
    public async void ChangePageToCadastro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaDeCadastro());       
    }
    public async void ChangePageToLogin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaDeLogin());
    }

}