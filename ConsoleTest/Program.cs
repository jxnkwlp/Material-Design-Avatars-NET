using MaterialDesignAvatars;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/test/"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/test/");

            var source = "China3809moiva王中国斌吴元";

            foreach (var item in source)
            {
                var avatar = new MdAvatar();

                var result = avatar.Build(item.ToString().ToUpperInvariant(), 256);

                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/test/" + item + ".png", result);

                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
