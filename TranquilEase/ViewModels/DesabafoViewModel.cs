using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranquilEase.Models;
using TranquilEase.Views;

namespace TranquilEase.ViewModels
{
    class DesabafoViewModel : INotifyPropertyChanged
    {
        DataBase dataBase = new DataBase();
        Desabafo desabafo = new Desabafo();
        DateTime dateWithTime = DateTime.Now;

        string _desabafoText = "";

        public string DesabafoText
        {
            get { return _desabafoText; }
            set
            {
                _desabafoText = value;
                OnPropertyChanged(nameof(DesabafoText));
            }
        }

        //cria envento de identificador para ver se alguma prorpiedade foi modificada
        public event PropertyChangedEventHandler PropertyChanged;

        //Função que pega o nome da propertty que mudou e avisa para a viw modificar o valor
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Transaforma a função efetuar login compativel a se colocar em um botão
        public ICommand SalvarCommand => new Command(CadastrarDesabafo);

        public void CadastrarDesabafo()
        {
            // Recuperar o token de autenticação
            string authToken = Preferences.Get("auth_token", null);

            desabafo.user_id_desabafo = Convert.ToInt32(authToken);
            desabafo.desabafo_txt = DesabafoText;
            desabafo.desabafo_date_time = $"{dateWithTime}";

            dataBase.InsertDesabafoOnBD(desabafo);

        }

    }
}
