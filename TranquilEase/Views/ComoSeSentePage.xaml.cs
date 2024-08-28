using TranquilEase.Models;
using TranquilEase.ViewModels;

namespace TranquilEase.Views
{
    public partial class ComoSeSentePage : ContentPage
    {
        DataBase dataBase = new DataBase();
        private ComoSeSenteViewModel viewModel;

        bool visibleHistoric = false;
        string userIdOutOfDesabaOfPage = "";
        string emotionOpotion = "";

        public ComoSeSentePage()
        {
            InitializeComponent();
            viewModel = new ViewModels.ComoSeSenteViewModel();
            BindingContext = viewModel;

            //Deixa o historico invisevel e o fazer sentimento visivel
            StackFazerEmocao.IsVisible = true;
            StackHistoricoEmocao.IsVisible = false;

            string authToken = Preferences.Get("auth_token", null);
            userIdOutOfDesabaOfPage = authToken;
        }

        private async void ShowHistoricoDesabafos(object sender, EventArgs e)
        {
            switch (visibleHistoric)
            {
                case false:
                    visibleHistoric = true;

                    StackFazerEmocao.IsVisible = false;
                    StackHistoricoEmocao.IsVisible = true;

                    List<ComoSeSente> ListDesabafos = await dataBase.ReturnAllSentimentoOfUser(userIdOutOfDesabaOfPage);

                    foreach (ComoSeSente i in ListDesabafos)
                    {
                        StackWithSentimento ReturnSatckWithentimento = new StackWithSentimento();
                        StackLayout satckWithSentimento = ReturnSatckWithentimento.ReturnStackSentimento(i, StackHistoricoEmocao);

                        StackHistoricoEmocao.Children.Add(satckWithSentimento);
                    }
                    break;

                case true:
                    visibleHistoric = false;

                    StackFazerEmocao.IsVisible = true;
                    StackHistoricoEmocao.IsVisible = false;

                    StackHistoricoEmocao.Children.Clear();
                    break;
            }
        }

        void OnColorsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Perform required operation

            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton != null)
            {
                emotionOpotion = selectedRadioButton.Content.ToString();

                if (label_coco != null)
                {
                    viewModel.EmocaoSelecionada = emotionOpotion;
                }
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
 
}
