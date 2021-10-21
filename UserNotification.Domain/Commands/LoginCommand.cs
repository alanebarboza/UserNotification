using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Domain.Commands
{
    public sealed class LoginCommand : ICommand
    {
        public LoginCommand(string nick, string passWord)
        {
            Nick = nick;
            PassWord = passWord;
        }

        public string Nick { get; set; }
        public string PassWord { get; set; }
    }
}
