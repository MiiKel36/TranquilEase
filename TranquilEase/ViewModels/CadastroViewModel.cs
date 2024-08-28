using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranquilEase.Models;

namespace TranquilEase.ViewModels
{
    internal class CadastroViewModel : INotifyPropertyChanged
    {
        Usuario _Usuario = new Usuario();
        DataBase _DataBase = new DataBase();

        //Mensagens para a view
        string _mensagemParafront = "";

        public string MensagemParaOFront
        {
            get { return _mensagemParafront; }
            set { _mensagemParafront = value;
                OnPropertyChanged(nameof(MensagemParaOFront));}
        }

        //Mundança de valores para UI
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        //Informações/variaveis do usuario
        public string User { get; set; }
        public string Senha { get; set; }
        public string SenhaConfirm { get; set; }      
        public string Email { get; set; }
        
        
        //Utilizar os dados do usuario
        public ICommand SalvarCommand => new Command(efetuarCadastro);
        public async void efetuarCadastro()
        {
            //caso os campos de senhas nao sejam iguais
            if(Senha != SenhaConfirm)
            {
                MensagemParaOFront = "As senhas não sao iguais";
                return;
            }

            //associa as informações da view com o obj _Usuario
            try
            {
                //insere as informações do usuario
                _Usuario.nome = User;
                _Usuario.senha = Senha;
                _Usuario.email = Email;
                
                //reotorna e existe um email igual true/false
                bool existeEmailIgual =  await _DataBase.ReturnIfExistUserEmailOnBD(Email);


                //se existe email igual, nao insere a conta no banco de dados
                if (!existeEmailIgual)
                {
                    MensagemParaOFront = "Este email ja etá sendo uilizado";
                    return;
                }

                //insere a conta no banco de dados
                _DataBase.InsertUserOnBD(_Usuario);

           
            } catch (ArgumentException e)
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
