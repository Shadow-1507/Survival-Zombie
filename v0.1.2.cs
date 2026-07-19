using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Zom
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

            bool isSuccess;
            Console.WriteLine("Mời lựa chọn việc cần làm");
            Console.WriteLine("1. Đánh nhau với zombie");
            Console.WriteLine("2. Sử dụng đèn");
            Console.WriteLine("3. Ăn thức ăn");
            Console.WriteLine("4. Uống nước");
            isSuccess = int.TryParse(Console.ReadLine(), out int playerChoose);
            if (!isSuccess)
            {
                Console.WriteLine("phải chọn số 1, 2, 3 hoặc 4");
            } 
            switch (playerChoose)
            {
                case 1:
                    Console.Write("Mời nhập dame zombie: ");
                    isSuccess = int.TryParse(Console.ReadLine(), out int dame);
                    if (!isSuccess)
                    {
                        Console.WriteLine("Lượng dame gây ra phải là số!");
                    }
                    if (dame <= 0)
                    {
                        dame = 0;
                    }

                    hp = hp - dame;

                    if (hp <= 0)
                    {
                        hp = 0;
                        Console.WriteLine("You Die");
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
                    break;

                case 2:
                    Console.Write("Mời nhập số pin đã sử dụng: ");
                    isSuccess = int.TryParse(Console.ReadLine(), out int batteryConsume);
                    if (!isSuccess)
                    {
                        Console.WriteLine("Số pin sử dụng phải là số!");
                    }
                    if (batteryConsume <= 0)
                    {
                        batteryConsume = 0;
                    }

                    battery = battery - batteryConsume;

                    if (battery <= 0)
                    {
                        Console.WriteLine("Bóng Tối Đã Nuốt Chửng Bạn!");
                        battery = 0;
                    }
                    else if (battery <= 30)
                    {
                        Console.WriteLine($"Sắp hết Pin! - Còn lại {battery} pin");
                    }
                    break;

                case 3:
                    Console.Write("Mời nhập số thức ăn cần dùng: ");
                    isSuccess = int.TryParse(Console.ReadLine(), out int foodConsume);
                    if (!isSuccess)
                    {
                        Console.WriteLine("Số thức ăn sử dụng phải là số!");
                    }
                    if (foodConsume <= 0)
                    {
                        foodConsume = 0;
                    }

                    food = food - foodConsume;

                    if (food <= 0)
                    {
                        Console.WriteLine("Đã hết thức ăn!");
                        food = 0;
                    }
                    else if (food <= 3)
                    {
                        Console.WriteLine($"Sắp hết Thức ăn! - Còn lại {food} Thức ăn");
                    }
                    break;

                case 4:
                    Console.Write("Mời nhập số nước cần dùng: ");
                    isSuccess = int.TryParse(Console.ReadLine(), out int waterConsume);
                    if (!isSuccess)
                    {
                        Console.WriteLine("Số nước uống sử dụng phải là số!");
                    }
                    if (waterConsume <= 0)
                    {
                        waterConsume = 0;
                    }

                    water = water - waterConsume;

                    if (water <= 0)
                    {
                        Console.WriteLine("Đã hết nước uống!");
                        water = 0;
                    }
                    else if (water <= 3)
                    {
                        Console.WriteLine($"Sắp hết Nước uống! - Còn lại {water} Nước uống");
                    }
                    break;
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
