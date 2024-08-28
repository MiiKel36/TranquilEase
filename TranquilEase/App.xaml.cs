namespace TranquilEase;

public partial class App : Application
{
	public App()
	{
				InitializeComponent();
        string authToken = Preferences.Get("auth_token", null);
        MainPage = new NavigationPage(new Views.ChatComAIPage());

        /*
        // Recuperar o token de autenticação
        string authToken = Preferences.Get("auth_token", null);

        if (!string.IsNullOrEmpty(authToken))
        {
            MainPage = new NavigationPage(new Views.DesabafoPage());
        }
        else
        {
            MainPage = new NavigationPage(new Views.PaginaEscolhaLoginCadastro());
        }
        */

	}
}
