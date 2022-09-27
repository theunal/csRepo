using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Kayıt();

            }

            catch (KayitBulunamadiException e)

            {
                
                Console.WriteLine("\n\t" + e.Message);

            }


            Console.ReadLine();

            HandleException(() =>
            {
                Kayıt();
            });

            


        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (KayitBulunamadiException e)
            {
                Console.WriteLine("\n\t" + e.Message);

            }
        }

        private static void Kayıt()
        {
            List<string> students = new List<string>
              {
                "yusuf","unal","sdü"
              };

            if (!students.Contains("ünal"))
            {
                throw new KayitBulunamadiException("BÖYLE BİR KAYIT YOK AMK");
            }
            else
            {
                Console.WriteLine("KAYIT BULUNDU");
            }
        }
    }
}
