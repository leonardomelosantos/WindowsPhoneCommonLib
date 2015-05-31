using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneCommonLib
{
    public class DateTimeUtils
    {
        public enum TipoRetornoDiferenca
        {
            Minutos,
            Horas,
            Dias,
            Meses,
            Anos
        }

        public static double QuantoPrimeiraDataExcedeSegundaData(DateTime data1, DateTime data2, TipoRetornoDiferenca tipoDataDiferenca)
        {
            double valorRetorno = 0;
            DateTime dataMaior = data1;
            DateTime dataMenor = data2;
            int compare = data2.CompareTo(data1);

            if (compare != 0)
            {
                TimeSpan tsData = dataMaior.Subtract(dataMenor);

                switch (tipoDataDiferenca)
                {
                    case TipoRetornoDiferenca.Minutos:
                        valorRetorno = tsData.TotalMinutes;
                        break;
                    case TipoRetornoDiferenca.Horas:
                        valorRetorno = tsData.TotalHours;
                        break;

                    case TipoRetornoDiferenca.Dias:
                        valorRetorno = tsData.TotalDays;
                        break;
                    case TipoRetornoDiferenca.Meses:
                        if (dataMaior.Year != dataMenor.Year || dataMaior.Month != dataMenor.Month)
                        {
                            int meses = dataMaior.Month - dataMenor.Month;
                            int dias = tsData.Days;

                            for (int i = dataMenor.Year; i < dataMaior.Year; i++)
                            {
                                meses += 12;
                                TimeSpan tsDataMes = (new DateTime(i, 12, 31)).Subtract(new DateTime(i, 1, 1));
                                dias -= tsDataMes.Days;
                            }

                            if (dataMaior.Month != dataMenor.Month && dias < DateTime.DaysInMonth(dataMenor.Year, dataMenor.Month))
                            {
                                meses--;
                            }

                            valorRetorno = meses;
                        }
                        break;
                    case TipoRetornoDiferenca.Anos:
                        valorRetorno = dataMaior.Year - dataMenor.Year;
                        if (dataMenor.Month > dataMaior.Month)
                        {
                            valorRetorno--;
                        }
                        else
                        {
                            if (dataMenor.Month == dataMaior.Month)
                            {
                                if (dataMenor.Day > dataMaior.Day)
                                {
                                    valorRetorno--;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return valorRetorno;
        }
    }
}
