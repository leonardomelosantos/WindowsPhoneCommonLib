using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneCommonLib
{
    public class UserInterfaceUtils
    {
        public static void MostrarToast(string titulo, string conteudo)
        {
            ShellToast toast = new ShellToast();
            toast.Title = titulo;
            toast.Content = conteudo;
            toast.Show();
        }
    }
}
