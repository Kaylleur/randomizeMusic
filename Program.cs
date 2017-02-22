using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace randomizeMusic
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(folder);

            var rand = new Random();

            foreach(var file in files){
                var fileName = file.Substring(folder.Length + 1);
                var reg = new System.Text.RegularExpressions.Regex("[0-9]{3}_");
                var number = rand.Next(999);
                Console.WriteLine(number);
                if (reg.Match(fileName.Substring(0,4)).Length > 0)
                {
                    File.Move(file, folder + "/" + addZero(number) + "_" + fileName.Substring(4));
                }
                else
                {    
                    File.Move(file, folder + "/" + addZero(number) + "_" + fileName);
                }
            }
            Console.ReadKey();
        }

        

        static string addZero(int number){
            var strResult = number.ToString();
            var nbZero = 3 - strResult.Length;
            for(var i = 0; i < nbZero; i++){
                strResult = "0" + strResult;
            }
            return strResult;
        }

    }
}
