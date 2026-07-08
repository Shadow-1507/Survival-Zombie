using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Học
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Chào Mừng Đến Với Survival Zombie Hậu Tận Thế!");
            Console.Write("Mời bạn nhập tên nhân vật: ");
            string name = Console.ReadLine();
            int hp = 100;
            int battery = 100;
            int food = 10;
            int water = 5;
            string state = "khỏe mạnh";
            Console.WriteLine($"=========Thông Tin=========");
            Console.WriteLine($" Tên: {name}               ");
            Console.WriteLine($" HP: {hp}                  ");
            Console.WriteLine($" Pin: {battery}            ");
            Console.WriteLine($" Thức ăn: {food}           ");
            Console.WriteLine($" Nước uống: {water}        ");
            Console.WriteLine($" Trạng thái: {state}       ");
            Console.WriteLine($"===========================");

            Console.Write("Mời nhập dame zombie: ");
            int dame = int.Parse(Console.ReadLine());
            if (dame <= 0)
            {
                dame = 0;
            }
            Console.Write("Mời nhập số pin đã sử dụng: ");
            int batteryConsume = int.Parse(Console.ReadLine());
            if (batteryConsume <= 0)
            {
                batteryConsume = 0;
            }    
            Console.Write("Mời nhập số thức ăn cần dùng: ");
            int foodConsume = int.Parse(Console.ReadLine());
            if (foodConsume <= 0)
            {
                foodConsume = 0;
            }
            Console.Write("Mời nhập số nước cần dùng: ");
            int waterConsume = int.Parse(Console.ReadLine());
            if (waterConsume <= 0)
            {
                waterConsume = 0;
            }

            hp = hp - dame;
            battery = battery - batteryConsume;
            food = food - foodConsume;
            water = water - waterConsume;

            if (hp <= 0)
            {
                hp = 0;
                Console.WriteLine("You Die");
            }
            else if (hp >= 100)
            {
                hp = 100;
                state = "Khỏe mạnh";
            }
            else if (hp >= 70)
            {
                Console.WriteLine($"Đã nhận {dame} sát thương");
                Console.WriteLine($"Còn lại {hp} máu");
                state = "Bị thương nhẹ";
            }
            else if (hp >= 50)
            {
                Console.WriteLine($"Đã nhận {dame} sát thương");
                Console.WriteLine($"Còn lại {hp} máu");
                state = "Vết thương sâu";
            }
            else if (hp >= 30)
            {
                Console.WriteLine($"Đã nhận {dame} sát thương");
                Console.WriteLine($"Còn lại {hp} máu");
                state = "Vết thương nghiêm trọng";
            }
            else if (hp < 30)
            {
                Console.WriteLine($"Đã nhận {dame} sát thương");
                Console.WriteLine($"Còn lại {hp} máu");
                state = "Ngưỡng máu nguy hiểm";
            }

            if (battery <= 0)
            {
                Console.WriteLine("Bóng Tối Đã Nuốt Chửng Bạn!");
                battery = 0;
            }
            else if (battery <= 30)
            {
                Console.WriteLine($"Sắp hết Pin! - Còn lại {battery} pin");
            }

            if (food <= 0)
            {
                Console.WriteLine("Đã hết thức ăn!");
                food = 0;
            }
            else if (food <= 3)
            {
                Console.WriteLine($"Sắp hết Thức ăn! - Còn lại {food} Thức ăn");
            }

            if (water <= 0)
            {
                Console.WriteLine("Đã hết nước uống!");
                water = 0;
            }
            else if (water <= 3)
            {
                Console.WriteLine($"Sắp hết Nước uống! - Còn lại {water} Nước uống");
            }

            Console.ReadKey();

            Console.WriteLine($"=========Thông Tin=========");
            Console.WriteLine($" Tên: {name}               ");
            Console.WriteLine($" HP: {hp}                  ");
            Console.WriteLine($" Pin: {battery}            ");
            Console.WriteLine($" Thức ăn: {food}           ");
            Console.WriteLine($" Nước uống: {water}        ");
            Console.WriteLine($" Trạng thái: {state}       ");
            Console.WriteLine($"===========================");
        }
    }
}
