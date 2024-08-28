using TranquilEase.Models;

namespace TranquilEase.Views;

public partial class DesabafoPage : ContentPage
{
    DataBase dataBase = new DataBase();

    bool visibleHistoric = false;
    string userIdOutOfDesabaOfPage = "";
   

	//Apagar idUser, serve apenas apra teste
	public DesabafoPage(string idUser)
	{
		InitializeComponent();

        userIdOutOfDesabaOfPage = idUser;

        label_coco.Text = idUser;
		BindingContext = new ViewModels.DesabafoViewModel();

        //Deixa o historico invisevel e o fazer desabafo visivel
        StackFazerDesabafo.IsVisible = true;
        StackHistoricoDesabafo.IsVisible = false;

    }

    private async void ShowHistoricoDesabafos(object sender, EventArgs e)
    {
        switch (visibleHistoric)
        {
            case false:
                visibleHistoric = true;

                StackFazerDesabafo.IsVisible = false;
                StackHistoricoDesabafo.IsVisible = true;

                List<Desabafo> ListDesabafos = await dataBase.ReturnAllDesabafosOfUser(userIdOutOfDesabaOfPage);

                foreach (Desabafo i in ListDesabafos)
                {
                    StackWithDesabafos ReturnSatckWithDesabafo = new StackWithDesabafos();
                    StackLayout satckWithDesabafo = ReturnSatckWithDesabafo.ReturnStackDesabafo(i, StackHistoricoDesabafo);

                    StackHistoricoDesabafo.Children.Add(satckWithDesabafo);
                }
                break;

            case true:
                visibleHistoric = false;

                StackFazerDesabafo.IsVisible = true;
                StackHistoricoDesabafo.IsVisible = false;

                StackHistoricoDesabafo.Children.Clear();
                break;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Remover o token de autenticação
        Preferences.Remove("auth_token");

        Navigation.InsertPageBefore(new PaginaEscolhaLoginCadastro(), Navigation.NavigationStack.First());
        await Navigation.PopToRootAsync();

       
    }
}