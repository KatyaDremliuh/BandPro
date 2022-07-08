using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wpf_CurrencyConverter
{
    /// <summary>
    /// Модель курс доллара
    /// </summary>
    public class RateModel : PropertyChangedBase
    {
        protected double Val;

        // Числовое значение
        public double Value
        {
            get
            {
                return Val;
            }
            set
            {
                Val = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        // Запрос курса доллара с сайта
        public async Task GetRate()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var xml = await client.DownloadStringTaskAsync(new Uri("https://www.cbr-xml-daily.ru/daily.xml"));
                    XDocument xdoc = XDocument.Parse(xml);
                    var el = xdoc.Element("ValCurs").Elements("Valute");
                    string dollar = el.Where(x => x.Attribute("ID").Value == "R01235").Select(x => x.Element("Value").Value).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(dollar))
                    {
                        Value = Convert.ToDouble(dollar);
                        return;
                    }
                }

                Value = 0;
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}