using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EX2.BLL;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;

namespace EX2
{
    class Program
    {
        const string Filespath = @"C:\Users\Public\Downloads";
        const string jsonFileName = "currencies.json";
        const string csvFileName = "conversions.csv";

        static void Main(string[] args)
        {
            List<Currency> currencies = new Currency().GetMeli();
            currencies = new Currency().Conversions(currencies);

            #region JSON
            string jsonFilepath = Path.Combine(Filespath, jsonFileName);
            StreamWriter file = File.CreateText(jsonFilepath);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, currencies);
            file.Close();
            file.Dispose();
            #endregion


            #region CSV
            string csvFilePath = Path.Combine(Filespath, csvFileName);
            string data = "";
            foreach (Currency currency in currencies)
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";

                data += currency.todolar.ToString(nfi) + ",";
            }
            data = data.Remove(data.LastIndexOf(','));
            System.IO.File.WriteAllText(csvFilePath, data);
            #endregion
        }
    }
}
