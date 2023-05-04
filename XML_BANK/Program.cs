using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_B_acc
{
    internal class Program
    {
        static int id;
        static void Main(string[] args) 
        {
            id = 0;

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine("Напишіть банк:");
            string bank = Console.ReadLine();
            Console.WriteLine("Напишіть тип рахунку");
            string type = Console.ReadLine();
            Console.WriteLine("Напишіть залишок на рахунку");
            decimal money = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Напишіть валюту(enter для пропуску)");
            string currency = Console.ReadLine();
            Console.WriteLine("Напишіть відсоткову ставку, якщо потрібно(enter для пропуску)");
            string perc = Console.ReadLine();
            Console.WriteLine("Напишіть термін, якщо потрібно(enter для пропуску)");
            string termin = Console.ReadLine();
            Console.OutputEncoding = Encoding.Default;
            Console.InputEncoding = Encoding.Default;
            XmlTextWriter wr = new XmlTextWriter("..\\..\\counts.xml", System.Text.Encoding.UTF8);
            wr.Formatting = Formatting.Indented;
            wr.WriteStartDocument();
            wr.WriteStartElement("cards");
            wr.WriteStartElement(bank);
            wr.WriteAttributeString("id", Convert.ToString(id));
            wr.WriteStartElement(type);
            wr.WriteAttributeString("Balance", Convert.ToString(money));
            if (currency != "" && currency != " ")
            {
                wr.WriteAttributeString("Currency", currency);
            }
            else
            {
                wr.WriteAttributeString("Currency", "Гривня");
            }
            if (perc != "" && perc != " ")
            {
                wr.WriteElementString("Percantage", perc);
            }
            if (termin != "" && termin != " ")
            {
                wr.WriteElementString("Termin", termin);
            }
            wr.WriteEndElement();
            wr.WriteEndElement();
            wr.WriteEndElement();
            id++;
            wr.Close();

        }
    }
}