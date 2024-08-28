using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranquilEase.Models
{
    internal class BalãoDeFalaUsuario
    {
        Label lblFalaDoUsuario = new Label();
        VerticalStackLayout stackUserBallon = new VerticalStackLayout();

        public VerticalStackLayout ReturnChatBallonAI(string txtFalaDaAI)
        {
            lblFalaDoUsuario.Text = txtFalaDaAI;
            stackUserBallon.Add(lblFalaDoUsuario);

            return stackUserBallon;
        }
    }
}
