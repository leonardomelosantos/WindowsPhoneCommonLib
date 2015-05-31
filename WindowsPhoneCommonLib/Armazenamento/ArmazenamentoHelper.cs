using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneCommonLib.Armazenamento
{
    public class ArmazenamentoHelper
    {
        public void ArmazenarDataHora(string tag, DateTime dataHora)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings[tag] = dataHora;
            settings.Save();
        }

        public DateTime? ConsultarDataHora(string tag)
        {
            DateTime? retorno = null;
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(tag))
            {
                retorno = (DateTime)settings[tag];
            }
            return retorno;
        }
    }
}
