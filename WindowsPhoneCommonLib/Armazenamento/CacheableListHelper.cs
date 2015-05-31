using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneCommonLib.Armazenamento
{
    public class CacheableListHelper
    {
        public static void StoreList<T>(string key, IList<T> listData, DateTime expirationDateTime) where T : class
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                IsolatedStorageSettings.ApplicationSettings.Remove(key);
            }

            CacheableList<T> dados = new CacheableList<T>();
            dados.ExpirationDateTime = expirationDateTime;
            dados.ListData = listData;

            IsolatedStorageSettings.ApplicationSettings.Add(key, JsonConvert.SerializeObject(dados));
        }

        #region Métodos estáticos

        public static CacheableList<T> GetListStored<T>(string key) where T : class
        {
            CacheableList<T> retorno = new CacheableList<T>();
            retorno.ExpirationDateTime = DateTime.MinValue;
            retorno.ListData = new List<T>();

            try
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
                {
                    string conteudo = IsolatedStorageSettings.ApplicationSettings[key].ToString();
                    if (conteudo != null)
                    {
                        retorno = JsonConvert.DeserializeObject<CacheableList<T>>(conteudo);
                    }
                }
            }
            catch (Exception ex) { }

            return retorno;
        }

        #endregion

    }
}
