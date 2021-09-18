using System;

namespace lab_one
{
    class Students_goup
    {
        // Переменные класса (приватные).
        int group_length;
        string[] first_name;
        string[] midle_name;
        string[] last_name;
        string[] birthday;

        // Конструктор класса (без параметров).
        public Students_goup()
        {
            Console.Write("Введите кол-во студентов: ");
            group_length = Convert.ToInt32(Console.ReadLine());
            if (group_length < 1)
            {
                Console.WriteLine("Кол-во студентов не может быть меньше одного.");
                Environment.Exit(0);
            }

            first_name = new string[group_length];
            midle_name = new string[group_length];
            last_name = new string[group_length];
            birthday = new string[group_length];

            int iter = 0;
            while (iter < group_length)
            {
                Console.WriteLine("\nСтудент № " + (iter + 1));
                Console.Write("Фамилия: ");
                first_name[iter] = Console.ReadLine();
                Console.Write("Имя: ");
                midle_name[iter] = Console.ReadLine();
                Console.Write("Отчество: ");
                last_name[iter] = Console.ReadLine();
                Console.Write("Дата рождения: ");
                birthday[iter] = Console.ReadLine();
                ++iter;
                Console.WriteLine();
            }
        }

        // Конструктор класса (с параметрами).
        public Students_goup(string f_name, string m_name, string l_name, string b_day)
        {
            first_name = new string[1];
            midle_name = new string[1];
            last_name = new string[1];
            birthday = new string[1];

            first_name[0] = f_name;
            midle_name[0] = m_name;
            last_name[0] = l_name;
            birthday[0] = b_day;
        }

        // Вывод всех студентов. Метод публичный без атрибутов.
        public void Print_group()
        {
            int j = 1;
            for (int iter = 0; iter < group_length; iter++)
            {
                if (!(first_name[iter] == null) && !(midle_name[iter] == null) && !(last_name[iter] == null) &&!(birthday[iter] == null))
                    Console.WriteLine("№"+(j++)+": " + first_name[iter] + "\t" + midle_name[iter] + "\t" + last_name[iter] + "\t" + birthday[iter]);
            }
        }
        // Запись нового студента.
        public void add_student()
        {
            string[] f = new string[group_length+1];
            string[] m = new string[group_length+1];
            string[] l = new string[group_length+1];
            string[] b = new string[group_length+1];

            Array.Copy(first_name, f, group_length);
            Array.Copy(midle_name, m, group_length);
            Array.Copy(last_name, l, group_length);
            Array.Copy(birthday, b, group_length);

            Console.Clear();

            Console.WriteLine("Введите информацию о студенте:");
            Console.Write("Фамилия: ");
            f[group_length] = Console.ReadLine();
            Console.Write("Имя: ");
            m[group_length] = Console.ReadLine();
            Console.Write("Отчество: ");
            l[group_length] = Console.ReadLine();
            Console.Write("Дата рождения: ");
            b[group_length] = Console.ReadLine();

            first_name = f;
            midle_name = m;
            last_name  = l;
            birthday   = b;
            ++group_length;
        }
        // Удаление записи о студенте.
        public void del_student()
        {
            int index;
            Console.Clear();
            Console.Write("Введите Номер студента: ");

            index = Convert.ToInt32(Console.ReadLine());

            if (index <= 0)
            {
                Console.WriteLine("Значение не может быть меньше единицы.");
                Environment.Exit(0);
            }

            --index;

            for (int iter = 0; iter < group_length; iter++)
            {
                if (iter == index)
                {
                    first_name[iter] = null;
                    midle_name[iter] = null;
                    last_name[iter] = null;
                    birthday[iter] = null;
                    break;
                }
            }
        }

        // Сортировка по критериям.
        public void sort_by()
        {
            int index;

            Console.Clear();
            Console.WriteLine("Выберети парамерт по которому будет выполнена сортировка:");

            Console.WriteLine(
                "1. По фамилии\n" +
                "2. По имени\n" +
                "3. По отчеству\n" +
                "4. По дате рождения\n"
                );

            Console.Write("Ввод: ");
            index = Convert.ToInt32(Console.ReadLine());

            switch(index)
            {
                case 1:
                    for (int i = 0; i < group_length; i++)
                    {
                        for (int j = 0; j < group_length - 1; j++)
                        {
                            if (needToReOrder(first_name[j], first_name[j + 1]))
                            {
                                string tmp = first_name[j];
                                first_name[j] = first_name[j + 1];
                                first_name[j + 1] = tmp;

                                tmp = last_name[j];
                                last_name[j] = last_name[j + 1];
                                last_name[j + 1] = tmp;

                                tmp = midle_name[j];
                                midle_name[j] = midle_name[j + 1];
                                midle_name[j + 1] = tmp;

                                tmp = birthday[j];
                                birthday[j] = birthday[j + 1];
                                birthday[j + 1] = tmp;
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < group_length; i++)
                    {
                        for (int j = 0; j < group_length - 1; j++)
                        {
                            if (needToReOrder(midle_name[j], midle_name[j + 1]))
                            {
                                string tmp = first_name[j];
                                first_name[j] = first_name[j + 1];
                                first_name[j + 1] = tmp;

                                tmp = last_name[j];
                                last_name[j] = last_name[j + 1];
                                last_name[j + 1] = tmp;

                                tmp = midle_name[j];
                                midle_name[j] = midle_name[j + 1];
                                midle_name[j + 1] = tmp;

                                tmp = birthday[j];
                                birthday[j] = birthday[j + 1];
                                birthday[j + 1] = tmp;
                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < group_length; i++)
                    {
                        for (int j = 0; j < group_length - 1; j++)
                        {
                            if (needToReOrder(last_name[j], last_name[j + 1]))
                            {
                                string tmp = first_name[j];
                                first_name[j] = first_name[j + 1];
                                first_name[j + 1] = tmp;

                                tmp = last_name[j];
                                last_name[j] = last_name[j + 1];
                                last_name[j + 1] = tmp;

                                tmp = midle_name[j];
                                midle_name[j] = midle_name[j + 1];
                                midle_name[j + 1] = tmp;

                                tmp = birthday[j];
                                birthday[j] = birthday[j + 1];
                                birthday[j + 1] = tmp;
                            }
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < group_length; i++)
                    {
                        for (int j = 0; j < group_length - 1; j++)
                        {
                            if (needToReOrder(birthday[j], birthday[j + 1]))
                            {
                                string tmp = first_name[j];
                                first_name[j] = first_name[j + 1];
                                first_name[j + 1] = tmp;

                                tmp = last_name[j];
                                last_name[j] = last_name[j + 1];
                                last_name[j + 1] = tmp;

                                tmp = midle_name[j];
                                midle_name[j] = midle_name[j + 1];
                                midle_name[j + 1] = tmp;

                                tmp = birthday[j];
                                birthday[j] = birthday[j + 1];
                                birthday[j + 1] = tmp;
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестный символ.");
                    break;
            }
        }
        // Метод сравнения строк, что-то на подобие "Да" > "да" (Да, да говнокод...)
        static bool needToReOrder(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }

        public void in_arr()
        {
            Console.Clear();
            Console.WriteLine("Запись по определенному индексу.");
            Console.Write("Введите номер записи: ");

            int index = Convert.ToInt32(Console.ReadLine());

            if (index <= 0)
            {
                Console.WriteLine("Значение не может быть меньше единицы.");
                Environment.Exit(0);
            }

            while(true)
            {
                if (index <= group_length)
                {
                    Console.Clear();

                    Console.WriteLine("Введите информацию о студенте:");
                    Console.Write("Фамилия: ");
                    first_name[index] = Console.ReadLine();
                    Console.Write("Имя: ");
                    midle_name[index] = Console.ReadLine();
                    Console.Write("Отчество: ");
                    last_name[index] = Console.ReadLine();
                    Console.Write("Дата рождения: ");
                    birthday[index] = Console.ReadLine();

                    break;
                }
                else
                {
                    Console.WriteLine("Значение не может быть больше кол-ва студентов.");
                    Environment.Exit(0);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number;
            bool exit = true;
            Students_goup st;

            st = new Students_goup();

            while (exit)
            {
                Console.Clear();
                Console.Write(
                    "1. Добавить студента\n" +
                    "2. Удалить студента\n" +
                    "3. Сортировка\n" +
                    "4. Запись по определенному номеру\n" +
                    "5. Выход" +
                    "\n\n"
                    );
                st.Print_group();

                Console.Write("\nВвод: ");
                number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    // Добавление студента.
                    case 1:
                        st.add_student();
                        break;
                    // Удаление информации о студенте.
                    case 2:
                        st.del_student();
                        break;
                    // Сортировка.
                    case 3:
                        st.sort_by();
                        break;
                    // Запись информации о студенте на определенную позицию.
                    case 4:
                        st.in_arr();
                        break;
                    // Выход из цикла.
                    case 5:
                        exit = false;
                        break;
                    // Защита от дурака.
                    default:
                        Console.WriteLine("Неизвестный символ.");
                        break;
                }
            }
        }
    }
}
