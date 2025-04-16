namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
                string[] peoples = File.ReadAllLines(@".\peoples.txt");
                FileInfo file = new FileInfo(@".\peoples.txt");


                for (int i = 0; i < peoples.Length; i++)
                {
                    listBox1.Items.Add(peoples[i]); // Добавление записи
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Генерация новых пользователей и запись в базу
                string[] new_10_peoples = generate_arry_peoples();
                write_in_file(new_10_peoples);

                listBox1.Items.Clear(); // Полное отчищение поля

                string[] peoples = File.ReadAllLines(@".\peoples.txt");
                FileInfo file = new FileInfo(@".\peoples.txt");


                for (int i = 0; i < peoples.Length; i++)
                {
                    listBox1.Items.Add(peoples[i]); // Добавление записи
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int result = 0;
            int n = vScrollBar1.Value;
            for (int i = 1; i < (int)((Math.Pow(n, 1)) + 1); i++)
            {
                result += (int)(Math.Pow(-1, i) * Math.Pow(i, 4));
            }

            label2.Text = result.ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = vScrollBar1.Value;
            int result = (int)((Math.Pow(-1, n)) * (Math.Pow(n, 4) + 2 * Math.Pow(n, 3) - n) / 2);

            label2.Text = result.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = vScrollBar1.Value.ToString();
        }

        private string[] generate_arry_peoples()
        {
            string[] FirstNames =
            {
                "Хрюня", "Чпок", "Бублик", "Плюша", "Кекс",
                "Шпунтик", "Мямлик", "Зюзя", "Квазя", "Бздун",
                "Пыхтя", "Чмоник", "Жмыш", "Хахатун", "Плюх"
            };

            string[] LastNames =
            {
                "Обломовский", "Чайник-Громов", "Пузиков", "Дрыщ", "Пельмешкин",
                "Вопилкин", "Соплюн", "Жмыхов", "Тормозов", "Бурчало",
                "Чих-Пых", "Шмяк", "Дребезгов", "Плюхов", "Хрюндель"
            };

            try
            {
                Random rand = new Random();
                string[] arry_people = new string[10];

                for (int i = 0; i < 10; i++)
                {
                    int index_1 = rand.Next(15);
                    int index_2 = rand.Next(15);

                    // date
                    int day = rand.Next(1, 32);
                    int month = rand.Next(1, 13);
                    int year = rand.Next(1925, 2025);

                    // phone
                    string phone = "+79";
                    for (int j = 0; j < 9; j++)
                    {
                        phone += rand.Next(10).ToString();
                    }

                    arry_people[i] = $"{FirstNames[index_1]} {LastNames[index_2]} {phone} {day}.{month}.{year}";
                }

                return arry_people;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.ToString());
                return new string[] { "ошибка" };
            }

        }

        private void write_in_file(string[] new_peoples)
        {
            try
            {
                FileInfo file = new FileInfo(@".\peoples.txt");

                using (StreamWriter SW = file.AppendText())
                {
                    foreach (string s in new_peoples)
                    {
                        SW.WriteLine(s);
                    }
                }

                Console.WriteLine("Файл записан");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.ToString());
            }
        }

        private string[] search_in_file(string LastName)
        {
            try
            {
                string[] peoples = File.ReadAllLines(@".\peoples.txt");
                FileInfo file = new FileInfo(@".\peoples.txt");

                string[] text = File.ReadAllLines(file.FullName);

                List<string> result_list = new List<string>();
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Split(' ')[1] == LastName) { result_list.Add(text[i]); }
                }

                return result_list.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.ToString());
                return new string[] { "ошибка" };
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string text_search = textBox1.Text.Trim(); // Полуение текста с текстового поля без пробелов.
                string[] peoples = search_in_file(text_search);

                listBox2.Items.Clear();

                foreach (string s in peoples)
                {
                    listBox2.Items.Add(s);
                    listBox2.Items.Add("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.ToString());
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
