using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranquilEase.Models
{
    internal class BalãoDeFalaChatGpt
    {
        Label lblFalaDaAi = new Label();
        VerticalStackLayout stackChatBallon = new VerticalStackLayout();

        public VerticalStackLayout ReturnChatBallonAI(string txtFalaDaAI)
        {
            lblFalaDaAi.Text = txtFalaDaAI;
            stackChatBallon.Add(lblFalaDaAi);

            return stackChatBallon;
        }
    }
}
