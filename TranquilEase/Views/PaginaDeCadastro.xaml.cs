namespace TranquilEase.Views;

public partial class PaginaDeCadastro : ContentPage
{
	public PaginaDeCadastro()
	{
		InitializeComponent();

		BindingContext = new ViewModels.CadastroViewModel();
	}
}