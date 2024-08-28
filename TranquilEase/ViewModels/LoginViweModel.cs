using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranquilEase.Models;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using TranquilEase.Views;
using Microsoft.Maui.Controls;

namespace TranquilEase.ViewModels
{   
    internal class LoginViweModel : INotifyPropertyChanged
    {

        Usuario _Usuario = new Usuario();
        DataBase _DataBase = new DataBase();


        //Mensagem de debug
        string _mensagemParaOFront = "";

        public string MensagemParaOFront
        {
            get { return _mensagemParaOFront; }
            set
            {
                _mensagemParaOFront = value;
                OnPropertyChanged(nameof(MensagemParaOFront));
            }
        }
       
        //cria envento de identificador para ver se alguma prorpiedade foi modificada
        public event PropertyChangedEventHandler PropertyChanged;

        //Função que pega o nome da propertty que mudou e avisa para a viw modificar o valor
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Valores do usuario que a view pode modificar
        public string Senha { get; set; }
        public string Email { get; set; }

        //Transaforma a função efetuar login compativel a se colocar em um botão
        public ICommand SalvarCommand => new Command(efetuarLogin);

        public async void efetuarLogin()
        {
            try
            {
                MensagemParaOFront = $"procurando... ";

                _Usuario.senha = Senha;
                _Usuario.email = Email;

                string userId = await _DataBase.ReturnIfAccountExist(_Usuario);

                if(userId == "email_nao_encontrado")
                {
                    MensagemParaOFront = $"email não cadastrado";
                    return;
                }
                if (userId == "senha_incorreta")
                {
                    MensagemParaOFront = $"senha incorreta";
                    return;
                }

                // Salvar o token de autenticação
                
                Preferences.Set("auth_token", userId);
                string authToken = Preferences.Get("auth_token", null);


                MensagemParaOFront = $"tudo certo com seu login";

                Application.Current.MainPage.Navigation.InsertPageBefore(new DesabafoPage(authToken), Application.Current.MainPage.Navigation.NavigationStack.First());
                await Application.Current.MainPage.Navigation.PopToRootAsync();

            }
            catch (ArgumentException e)
            {
                if (e.Message == "O endereço de e-mail fornecido é inválido.")
                {
                    // Tratar o erro de e-mail inválido aqu'Postgrest.Responses.ModeledResponsei
                    MensagemParaOFront = "O email fornecido é inválido.";
                }

            }
            catch (Exception e)
            {
                // Lidar com outras exceções
                MensagemParaOFront = $"Aconteceu algum erro inesperado{e.Message}";
            }

        }

       
    }
}

