using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.GameUI
{
    public class MessageContainer
    {
        public static string GetMessageById(eUIMessages i_MessageId)
        {
            string messageToUser = string.Empty;

            switch (i_MessageId)
            {
                case eUIMessages.PlayAgain:
                    messageToUser = "Would you like to play another round?";
                    break;
                case eUIMessages.Turns:
                    messageToUser = "{0}'s Turn!";
                    break;
                case eUIMessages.GameScore:
                    messageToUser = "{0}: {1}       {2}: {3}";
                    break;
                case eUIMessages.WinnerMessage:
                    messageToUser = "The winner is {0}!";
                    break;
                case eUIMessages.TieMessage:
                    messageToUser = "Tie!";
                    break;
            }

            return messageToUser;
        }
    }
}
