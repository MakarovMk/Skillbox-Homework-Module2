using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace Notebook1
{
    class Program
    {
        /// <summary>
        /// Программа для вывода индивидуальных данных ученика и его
        /// средней оценки по трём предметам: истории, математике и русскому языку
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string name = "Мария";     //Имя ученика
            byte age = 15;             //Возраст ученика
            byte height = 160;         //Рост ученика
            double history_score = 4;  //Балл по истории
            double maths_score = 2;    //Балл по математике
            double rus_lang_score = 5; //Балл по русскому языку
                     
            double average = (history_score + maths_score + rus_lang_score) / 3; //Среднее значение баллов по всем предметам

            //Конвертированные в стринг данные для вывода по центру экрана. Не придумал как строку 29 сделать короче
            string personal_data = "Имя: " + Convert.ToString(name) + "\n" + "Возраст: " + Convert.ToString(age) + "\n" + "Рост: " + Convert.ToString(height) + "\n" + "Балл по истории: " + Convert.ToString(history_score) + "\n" + "Балл по математике: " + Convert.ToString(maths_score) + "\n" + "Балл по русскому языку: " + Convert.ToString(rus_lang_score) + "\n" + "Средний балл по трём предметам: " + average.ToString("#.#");

            //Код для вывода данных по центру консоли. Взят отюда и адаптирован https://skillbox.ru/media/code/praktikum_po_s_vyravnivaem_tekst_po_krayu_i_po_tsentru_konsoli/
            string[] lines = Regex.Split(personal_data, "\r\n|\r|\n");

            int left = 0;
            int top = (Console.WindowHeight / 2) - (lines.Length / 2) - 1;

            int center = Console.WindowWidth / 2;

            for (int i = 0; i < lines.Length; i++)
            {
                left = center - (lines[i].Length / 2);

                Console.SetCursorPosition(left, top);
                Console.WriteLine(lines[i]);

                top = Console.CursorTop;
            }

            // 1. Обычный вывод данных
            // Форма для вывода среднего балла с использованием маски
            // до одной десятой
            string average1 = "Средний балл по трём предметам: " + average.ToString("#.#");

            WriteLine(name + age + height + history_score + maths_score + rus_lang_score);
            WriteLine(average1);


            //2.Форматированный вывод данных
            string pattern = "Имя: {0} \nВозраст: {1} \nРост: {2} \nБалл по истории: {3} \nБалл по математике: {4} \nБалл по русскому языку: {5} \nСредний балл по трём предметам: {6}";
            // Форма для вывода среднего балла с использованием маски
            //string average1 = average.ToString("#.#");

            WriteLine(pattern,
                      name,
                      age,
                      height,
                      history_score,
                      maths_score,
                      rus_lang_score,
                      average1);

            //3.Вывод индивидуальных данных с использованием интерполяции строк. Сделал два WriteLine, чтобы не было горизонтального скролла
            // Форма для вывода среднего балла с использованием маски
            //string average1 = "Средний балл по трём предметам: " + average.ToString("#.#");
            WriteLine("{0}", $"Имя: {name} \nВозраст: {age} \nРост: {height} \nБалл по истории: {history_score}");
            WriteLine($"Балл по математике: {maths_score} \nБалл по русскому языку: {rus_lang_score}");
            WriteLine($"{average1}");

            ReadKey();
        }
    }
}
