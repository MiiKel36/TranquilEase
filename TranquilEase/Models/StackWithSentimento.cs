using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranquilEase.Models
{
    internal class StackWithSentimento
    {

        public StackLayout ReturnStackSentimento(ComoSeSente comoSeSente, Layout parentLayout)
        {
            StackLayout stack = new StackLayout();
            DataBase dataBase = new DataBase();

            Button button = new Button();
            button.Text = "Exlcuir sentimento";
            button.Clicked += (sender, e) =>
            {
                int ButtonId = comoSeSente.emoçao_id;

                dataBase.DeleteSentimentoOfUser(ButtonId);
                parentLayout.Children.Remove(stack);
            };

            stack.Add(new Label { Text = $"{comoSeSente.emoçao_txt}" });
            stack.Add(new Label { Text = $"{comoSeSente.feliz_txt}" });
            stack.Add(new Label { Text = $"{comoSeSente.triste_txt}" });
            stack.Add(button);

            return stack;

        }

    }
}
