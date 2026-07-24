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
            int playerHp = 100;
            int battery = 100;
            int energy = 100;
            int playerHunger = 0;
            int playerThirst = 0;
            int food = 5;
            int water = 5;
            int medkit = 0;
            string state = "khỏe mạnh";
            int day = 1;
            Random random = new Random();

            while (state != "Dead")
            {
                Console.WriteLine();
                Console.WriteLine($"Ngày {day}");
                Console.WriteLine();
                Console.WriteLine($"=========Thông Tin=========");
                Console.WriteLine($" Tên: {name}               ");
                Console.WriteLine($" HP: {playerHp}            ");
                Console.WriteLine($" Pin: {battery}            ");
                Console.WriteLine($" Năng lượng: {energy}      ");
                Console.WriteLine($" Đói: {playerHunger}       ");
                Console.WriteLine($" Khát: {playerThirst}      ");
                Console.WriteLine($" Thức ăn: {food}           ");
                Console.WriteLine($" Nước uống: {water}        ");
                Console.WriteLine($" Bộ sơ cứu: {medkit}       ");
                Console.WriteLine($" Trạng thái: {state}       ");
                Console.WriteLine($"===========================");

                bool canNextDay = false;
                bool isSuccess = true;
                int playerChoose = 0;

                do
                {
                    Console.WriteLine("Mời lựa chọn việc cần làm");
                    Console.WriteLine("1. Đánh nhau với zombie");
                    Console.WriteLine("2. Sử dụng đèn");
                    Console.WriteLine("3. Ăn thức ăn");
                    Console.WriteLine("4. Uống nước");
                    Console.WriteLine("5. Băng bó vết thương");
                    Console.WriteLine("6. Nghỉ ngơi");

                    isSuccess = int.TryParse(Console.ReadLine(), out playerChoose);

                    if (!isSuccess || playerChoose < 1 || playerChoose > 6)
                    {
                        Console.WriteLine("Chỉ có thể chọn 1, 2, 3, 4, 5 hoặc 6!");
                    }
                } while (!isSuccess || playerChoose < 1 || playerChoose > 6);

                switch (playerChoose)
                {
                    case 1:
                        if (energy < 20)
                        {
                            Console.WriteLine("Không còn đủ năng lượng để thực hiện hành động");
                            break;
                        }
                        else if (playerHunger > 80)
                        {
                            Console.WriteLine("Bạn quá đói để thực hiện hành động");
                            break;
                        }
                        else if (playerThirst > 80)
                        {
                            Console.WriteLine("Bạn quá khát để thực hiện hành động");
                            break;
                        }

                        int zombieDamage = random.Next(1, 16);
                        int criticalChance = random.Next(1, 101);
                        int foodDrop = 0;
                        int foodDropChance = random.Next(1, 101);
                        int waterDrop = 0;
                        int waterDropChance = random.Next(1, 101);
                        int medkitDrop = 0;
                        int medkitDropChance = random.Next(1, 101);
                        if (criticalChance <= 5)
                        {
                            zombieDamage = zombieDamage * 2;
                            Console.WriteLine("Zombie đã tung đòn chí mạng");
                        }
                        if (foodDropChance <= 10)
                        {
                            foodDrop = 3;
                            Console.WriteLine($"Bạn đã tìm được {foodDrop} thức ăn trên xác zombie");
                        }
                        else if (foodDropChance <= 30)
                        {
                            foodDrop = 2;
                            Console.WriteLine($"Bạn đã tìm được {foodDrop} thức ăn trên xác zombie");
                        }
                        else if (foodDropChance <= 60)
                        {
                            foodDrop = 1;
                            Console.WriteLine($"Bạn đã tìm được {foodDrop} thức ăn trên xác zombie");
                        }
                        else
                        {
                            foodDrop = 0;
                        }
                        if (waterDropChance <= 10)
                        {
                            waterDrop = 3;
                            Console.WriteLine($"Bạn đã tìm được {waterDrop} nước uống trên xác zombie");
                        }
                        else if (waterDropChance <= 30)
                        {
                            waterDrop = 2;
                            Console.WriteLine($"Bạn đã tìm được {waterDrop} nước uống trên xác zombie");
                        }
                        else if (waterDropChance <= 60)
                        {
                            waterDrop = 1;
                            Console.WriteLine($"Bạn đã tìm được {waterDrop} nước uống trên xác zombie");
                        }
                        else
                        {
                            waterDrop = 0;
                        }
                        if (medkitDropChance <= 5)
                        {
                            medkitDrop = 2;
                            Console.WriteLine($"Bạn vừa nhặt được {medkitDrop} bộ sơ cứu");
                        }
                        else if (medkitDropChance <= 15)
                        {
                            medkitDrop = 1;
                            Console.WriteLine($"Bạn vừa nhặt được {medkitDrop} bộ sơ cứu");
                        }
                        else
                        {
                            medkitDrop = 0;
                        }
                        if (foodDrop == 0 && waterDrop == 0 && medkitDrop == 0)
                        {
                            Console.WriteLine("Bạn không tìm thấy gì");
                        }

                        playerHp = playerHp - zombieDamage;
                        energy = energy - 20;
                        playerHunger = playerHunger + 20;
                        playerThirst = playerThirst + 20;
                        food = food + foodDrop;
                        water = water + waterDrop;
                        medkit = medkit + medkitDrop;

                        canNextDay = false;

                        if (playerHp <= 0)
                        {
                            playerHp = 0;
                            Console.WriteLine($"Bạn vừa nhận {zombieDamage} sát thương");
                            Console.WriteLine("You Die");
                            Console.WriteLine($"Bạn đã sinh tồn được {day} ngày");
                            state = "Dead";
                        }
                        else if (playerHp >= 70)
                        {
                            Console.WriteLine($"Đã nhận {zombieDamage} sát thương");
                            Console.WriteLine($"Còn lại {playerHp} máu");
                            state = "Bị thương nhẹ";
                        }
                        else if (playerHp >= 50)
                        {
                            Console.WriteLine($"Đã nhận {zombieDamage} sát thương");
                            Console.WriteLine($"Còn lại {playerHp} máu");
                            state = "Vết thương sâu";
                        }
                        else if (playerHp >= 30)
                        {
                            Console.WriteLine($"Đã nhận {zombieDamage} sát thương");
                            Console.WriteLine($"Còn lại {playerHp} máu");
                            state = "Vết thương nghiêm trọng";
                        }
                        else if (playerHp < 30)
                        {
                            Console.WriteLine($"Đã nhận {zombieDamage} sát thương");
                            Console.WriteLine($"Còn lại {playerHp} máu");
                            state = "Ngưỡng máu nguy hiểm";
                        }

                        break;


                    case 2:
                        int batteryConsume = 0;
                        if (battery <= 0)
                        {
                            Console.WriteLine("Bạn không có đủ pin");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.Write("Mời nhập số pin cần dùng: ");
                                isSuccess = int.TryParse(Console.ReadLine(), out batteryConsume);

                                if (!isSuccess || batteryConsume <= 0)
                                {
                                    Console.WriteLine("Số pin sử dụng phải là số và không âm!");
                                }
                                else if (batteryConsume > battery)
                                {
                                    Console.WriteLine("Vượt quá số pin hiện có");
                                }
                            } while (!isSuccess || batteryConsume <= 0 || batteryConsume > battery);
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
                        if (food <= 0)
                        {
                            Console.WriteLine("Bạn không có đủ thức ăn");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.Write("Mời nhập số thức ăn cần dùng: ");
                                isSuccess = int.TryParse(Console.ReadLine(), out foodConsume);

                                if (!isSuccess || foodConsume <= 0)
                                {
                                    Console.WriteLine("Số thức ăn sử dụng phải là số và không âm!");
                                }
                                else if (foodConsume > food)
                                {
                                    Console.WriteLine("Vượt quá số thức ăn hiện có");
                                }
                            } while (!isSuccess || foodConsume <= 0 || foodConsume > food);
                        }

                        food = food - foodConsume;
                        playerHunger = playerHunger - (20 * foodConsume);

                        canNextDay = false;

                        if (playerHunger <= 0)
                        {
                            playerHunger = 0;
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

                        break;


                    case 4:
                        int waterConsume = 0;
                        if (water <= 0)
                        {
                            Console.WriteLine("Bạn không có đủ nước");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.Write("Mời nhập số nước cần dùng: ");
                                isSuccess = int.TryParse(Console.ReadLine(), out waterConsume);

                                if (!isSuccess || waterConsume <= 0)
                                {
                                    Console.WriteLine("Số nước sử dụng phải là số!");
                                }
                                else if (waterConsume > water)
                                {
                                    Console.WriteLine("Vượt quá số nước hiện có");
                                }
                            } while (!isSuccess || waterConsume <= 0 || waterConsume > water);
                        }

                        water = water - waterConsume;
                        playerThirst = playerThirst - (20 * waterConsume);

                        canNextDay = false;

                        if (playerThirst <= 0)
                        {
                            playerThirst = 0;
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

                        break;

                    case 5:
                        int medkitConsume;
                        int healedHp = 0;
                        int oldPlayerHp = playerHp;
                        if (medkit <= 0)
                        {
                            Console.WriteLine("Bạn không có đủ bộ sơ cứu");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.Write("Mời nhập số bộ sơ cứu cần dùng: ");
                                isSuccess = int.TryParse(Console.ReadLine(), out medkitConsume);

                                if (!isSuccess || medkitConsume <= 0)
                                {
                                    Console.WriteLine("Số bộ sơ cứu cần dùng phải là số!");
                                }
                                else if (medkitConsume > medkit)
                                {
                                    Console.WriteLine("Bạn không có đủ bộ sơ cứu");
                                }
                            } while (!isSuccess || medkitConsume <= 0 || medkitConsume > medkit);
                        }

                        medkit = medkit - medkitConsume;
                        playerHp = playerHp + (30 * medkitConsume);
                        canNextDay = false;

                        if (playerHp > 100)
                        {
                            playerHp = 100;
                            healedHp = playerHp - oldPlayerHp;
                        }
                        else
                        {
                            healedHp = playerHp - oldPlayerHp;
                        }

                        if (healedHp == 0)
                        {
                            Console.WriteLine("Bạn đang đầy máu, bộ sơ cứu không có tác dụng");
                            Console.WriteLine($"Bạn đã mất {medkitConsume} bộ sơ cứu");
                        }
                        else
                        {
                            Console.WriteLine($"Bạn vừa dùng {medkitConsume} bộ sơ cứu");
                            Console.WriteLine($"Bạn đã được hồi {healedHp} máu");
                        }

                        break;

                    case 6:
                        if (playerHunger > 50)
                        {
                            Console.WriteLine("Bạn không thể nghỉ ngơi do quá đói");
                            canNextDay = false;
                            break;
                        }
                        else if (playerThirst > 50)
                        {
                            Console.WriteLine("Bạn không thể nghỉ ngơi do quá khát!");
                            canNextDay = false;
                            break;
                        }

                        playerHunger = playerHunger + 50;
                        playerThirst = playerThirst + 50;
                        energy = 100;
                        playerHp = playerHp + 10;

                        if (playerHp > 100)
                        {
                            playerHp = 100;
                        }

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