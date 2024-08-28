using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls; // Certifique-se de estar usando o namespace correto

namespace TranquilEase.ViewModels
{
    internal class ChatComAIViewModel : INotifyPropertyChanged
    {
        // Objeto que contém as mensagens do usuário e do chatbot
        private ObservableCollection<Label> _stackChatBallons;

        public ObservableCollection<Label> StackChatBallons
        {
            get { return _stackChatBallons; }
            set
            {
                if (_stackChatBallons != value)
                {
                    _stackChatBallons = value;
                    OnPropertyChanged(nameof(StackChatBallons));
                }
            }
        }

        public ChatComAIViewModel()
        {
            _stackChatBallons = new ObservableCollection<Label>();
        }

        public ICommand ExecuteCodeSendToApi => new Command(SendMessageToAi);

        private void SendMessageToAi()
        {
            Label bola = new Label
            {
                FontSize = 50,
                Text = "teste"
            };

            StackChatBallons.Add(bola);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
