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
            int energy = 100;
            int hungry = 0;
            int thirsty = 0;
            int food = 10;
            int water = 5;
            string state = "khỏe mạnh";
            int day = 1;

            while (state != "Dead")
            {
                Console.WriteLine();
                Console.WriteLine($"Ngày {day}");
                Console.WriteLine();
                Console.WriteLine($"=========Thông Tin=========");
                Console.WriteLine($" Tên: {name}               ");
                Console.WriteLine($" HP: {hp}                  ");
                Console.WriteLine($" Pin: {battery}            ");
                Console.WriteLine($" Năng lượng: {energy}      ");
                Console.WriteLine($" Thức ăn: {food}           ");
                Console.WriteLine($" Nước uống: {water}        ");
                Console.WriteLine($" Trạng thái: {state}       ");
                Console.WriteLine($"===========================");

                bool canNextDay = false;
                bool isSuccess = true;
                int playerChoose = 0;

                while (!isSuccess || playerChoose < 1 || playerChoose > 5)
                {
                    Console.WriteLine("Mời lựa chọn việc cần làm");
                    Console.WriteLine("1. Đánh nhau với zombie");
                    Console.WriteLine("2. Sử dụng đèn");
                    Console.WriteLine("3. Ăn thức ăn");
                    Console.WriteLine("4. Uống nước");
                    Console.WriteLine("5. Nghỉ ngơi");

                    isSuccess = int.TryParse(Console.ReadLine(), out playerChoose);

                    if (!isSuccess || playerChoose < 1 || playerChoose > 5)
                    {
                        Console.WriteLine("Chỉ có thể chọn 1, 2, 3, 4 hoặc 5!");
                    }
                }

                switch (playerChoose)
                {
                    case 1:
                        int dame = 0;

                        while (!isSuccess || dame <= 0)
                        {
                            Console.Write("Mời nhập dame zombie: ");
                            isSuccess = int.TryParse(Console.ReadLine(), out dame);

                            if (!isSuccess || dame <= 0)
                            {
                                Console.WriteLine("Lượng dame gây ra phải là số và không âm!");
                            }
                        }

                        if (energy <= 20)
                        {
                            Console.WriteLine("Không còn đủ năng lượng để thực hiện hành động");
                            break;
                        }
                        else if (hungry >= 80)
                        {
                            Console.WriteLine("Bạn quá đói để thực hiện hành động");
                            break;
                        }
                        else if (thirsty >= 80)
                        {
                            Console.WriteLine("Bạn quá khát để thực hiện hành động");
                            break;
                        }

                        hp = hp - dame;
                        energy = energy - 20;
                        hungry = hungry + 20;
                        thirsty = thirsty + 20;

                        food = food + 1;
                        water = water + 1;

                        canNextDay = false;

                        if (hp <= 0)
                        {
                            hp = 0;
                            Console.WriteLine("You Die");
                            Console.WriteLine($"Bạn đã sinh tồn được {day} ngày");
                            state = "Dead";
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
                        int batteryConsume = 0;

                        while (!isSuccess || batteryConsume <= 0 || batteryConsume > battery)
                        {
                            Console.Write("Mời nhập số pin cần dùng: ");
                            isSuccess = int.TryParse(Console.ReadLine(), out batteryConsume);

                            if (!isSuccess || batteryConsume <= 0)
                            {
                                Console.WriteLine("Số pin sử dụng phải là số và không âm!");
                            }
                            else if (batteryConsume > battery)
                            {
                                Console.WriteLine("Vượt quá số pin hiện có!");
                            }
                        }

                        battery = battery - batteryConsume;

                        canNextDay = false;

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
                        int foodConsume = 0;

                        while (!isSuccess || foodConsume <= 0 || foodConsume > food)
                        {
                            Console.Write("Mời nhập số thức ăn cần dùng: ");
                            isSuccess = int.TryParse(Console.ReadLine(), out foodConsume);

                            if (!isSuccess || foodConsume <= 0)
                            {
                                Console.WriteLine("Số thức ăn sử dụng phải là số và không âm!");
                            }
                            else if (foodConsume > food)
                            {
                                Console.WriteLine("Vượt quá số thức ăn hiện có!");
                            }
                        }

                        food = food - foodConsume;
                        hungry = hungry - 20;

                        canNextDay = false;

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
                        int waterConsume = 0;

                        while (!isSuccess || waterConsume <= 0 || waterConsume > water)
                        {
                            Console.Write("Mời nhập số nước cần dùng: ");
                            isSuccess = int.TryParse(Console.ReadLine(), out waterConsume);

                            if (!isSuccess || waterConsume <= 0)
                            {
                                Console.WriteLine("Số nước sử dụng phải là số và không âm!");
                            }
                            else if (waterConsume > water)
                            {
                                Console.WriteLine("Vượt quá số nước hiện có!");
                            }
                        }

                        water = water - waterConsume;
                        thirsty = thirsty - 20;

                        canNextDay = false;

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


                    case 5:
                        if (hungry >= 50)
                        {
                            Console.WriteLine("Bạn không thể nghỉ ngơi do quá đói");
                            canNextDay = false;
                            break;
                        }
                        else if (thirsty >= 50)
                        {
                            Console.WriteLine("Bạn không thể nghỉ ngơi do quá khát!");
                            canNextDay = false;
                            break;
                        }

                        hungry = hungry + 50;
                        thirsty = thirsty + 50;
                        energy = 100;

                        Console.WriteLine("Bạn đi ngủ...");
                        Console.WriteLine("Cơ thể được nghỉ ngơi");

                        canNextDay = true;

                        break;
                }

                if (canNextDay == true)
                {
                    day++;
                }
            }
        }
    }
}