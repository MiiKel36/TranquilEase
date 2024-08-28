using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranquilEase.Models
{
    internal class StackWithDesabafos
    {
        public StackLayout ReturnStackDesabafo(Desabafo desabafo, Layout parentLayout)
        {
            StackLayout stack = new StackLayout();
            DataBase dataBase = new DataBase();

            Button button = new Button();
            button.Text = "Exlcuir desabafo";
            button.Clicked += (sender, e) =>
            {
                int ButtonId = desabafo.desabafo_id;

                dataBase.DeleteDesabafosOfUser(ButtonId);
                parentLayout.Children.Remove(stack);
            };

            stack.Add(new Label { Text = $"{desabafo.desabafo_txt}" });
            stack.Add(new Label { Text = $"{desabafo.desabafo_date_time}" });
            stack.Add(button);

            return stack;

        }
    }
}
