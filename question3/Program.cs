using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question3
{
    class Program
    {
        //Sayfadaki kaymalardan dolayi 1 satir icin tolere edilen deger.
        static int LINE_TOLERANCE = 10;
        static int FIRST_INDEX = 1;

        static void Main(string[] args)
        {
            List<Receipt> receiptList = new List<Receipt>();
            string json = Encoding.Default.GetString(Properties.Resources.json1);
            receiptList = JsonConvert.DeserializeObject<List<Receipt>>(json);

            string result = Parse(receiptList);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static string Parse(List<Receipt> receiptList)
        {
            int lineCounter = 1;
            string result = "";
            for (int i = FIRST_INDEX; i < receiptList.Count; i++)
            {
                if (receiptList[i].added != true)
                {
                    if (i != FIRST_INDEX)
                        result += System.Environment.NewLine;

                    result += $"{lineCounter} |" + receiptList[i].description;
                    lineCounter++;
                    receiptList[i].added = true;
                    var textIsInSameLine = receiptList.FindAll(receipt =>
                            (receipt.boundingPoly.vertices[(int)EnumVertices.TopLeft].x - receiptList[i].boundingPoly.vertices[(int)EnumVertices.TopLeft].x >= LINE_TOLERANCE)
                            && (receipt.boundingPoly.vertices[(int)EnumVertices.TopRight].y - receiptList[i].boundingPoly.vertices[(int)EnumVertices.TopRight].y <= LINE_TOLERANCE)
                            && (receipt.boundingPoly.vertices[(int)EnumVertices.BottomLeft].y - receiptList[i].boundingPoly.vertices[(int)EnumVertices.BottomLeft].y <= LINE_TOLERANCE)
                            && (receipt.boundingPoly.vertices[(int)EnumVertices.BottomRight].y - receiptList[i].boundingPoly.vertices[(int)EnumVertices.BottomRight].y <= LINE_TOLERANCE)
                            && receipt.added != true);

                    foreach (var receipt in textIsInSameLine)
                    {
                        result += " " + receipt.description;
                        receipt.added = true;
                    }
                }
            }
            return result;
        }
    }
}
