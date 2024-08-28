using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranquilEase.Models;

namespace TranquilEase.ViewModels
{
    internal class ComoSeSenteViewModel : INotifyPropertyChanged
    {
        DataBase dataBase = new DataBase();
        ComoSeSente sentimento = new ComoSeSente();
        DateTime dateWithTime = DateTime.Now;

        string _emocaoSelecionada = "";
        string _emocaoText = "";
        string _felizText = "";
        string _tristeText = "";

        public string EmocaoSelecionada
        {
            get { return _emocaoSelecionada; }
            set
            {
                _emocaoSelecionada = value;
                OnPropertyChanged(nameof(EmocaoSelecionada));
            }
        }
        public string EmocaoText
        {
            get { return _emocaoText; }
            set
            {
                _emocaoText = value;
                OnPropertyChanged(nameof(EmocaoText));
            }
        }
        public string FelizText
        {
            get { return _felizText; }
            set
            {
                _felizText = value;
                OnPropertyChanged(nameof(FelizText));
            }
        }
        public string TristeText
        {
            get { return _tristeText; }
            set
            {
                _tristeText = value;
                OnPropertyChanged(nameof(TristeText));
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
        public ICommand SalvarCommand => new Command(CadastrarSentimento);

        public void CadastrarSentimento()
        {
            // Recuperar o token de autenticação
            string authToken = Preferences.Get("auth_token", null);

            sentimento.user_id_emoçao = Convert.ToInt32(authToken);
            sentimento.emoçao_selecionada = EmocaoSelecionada;
            sentimento.emoçao_txt = EmocaoText;
            sentimento.feliz_txt = FelizText;
            sentimento.triste_txt = TristeText;
            sentimento.emocao_data_hora = dateWithTime.ToString();

            dataBase.InsertSentimentoOnBD(sentimento);

        }

        //Transaforma a função efetuar login compativel a se colocar em um botão (por agora feito na gambiarra)
        //Feliz maxmio
        public ICommand PegarSentimento1 => new Command(Sentimento_1);
        //Feliz normal
        public ICommand PegarSentimento2 => new Command(Sentimento_2);
        //Medio
        public ICommand PegarSentimento3 => new Command(Sentimento_3);
        //levemete triste
        public ICommand PegarSentimento4 => new Command(Sentimento_4);
        //Muito triste
        public ICommand PegarSentimento5 => new Command(Sentimento_5);
        //Bravo 
        public ICommand PegarSentimento6 => new Command(Sentimento_6);
        //Muito bravo
        public ICommand PegarSentimento7 => new Command(Sentimento_7);

        //Muito feliz
        public void Sentimento_1()
        {
            EmocaoSelecionada = "muit_feliz";
        }
        //Feliz
        public void Sentimento_2()
        {
            EmocaoSelecionada = "feliz";
        }
        //Medio
        public void Sentimento_3()
        {
            EmocaoSelecionada = "medio";
        }
        //Triste
        public void Sentimento_4()
        {
            EmocaoSelecionada = "triste";
        }
        //Muito triste
        public void Sentimento_5()
        {
            EmocaoSelecionada = "muito_triste";
        }
        //Bravo 
        public void Sentimento_6()
        {
            EmocaoSelecionada = "bravo";
        }
        //Muito bravo
        public void Sentimento_7()
        {
            EmocaoSelecionada = "muito_bravo";
        }

    }

}
