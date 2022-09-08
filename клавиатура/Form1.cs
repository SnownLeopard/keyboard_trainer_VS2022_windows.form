using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace клавиатура
{
    public partial class Form1 : Form
    {
        public double dKeyDounRight, dKeyDounErorr, dSecunds;




        public Form1()
        {
            InitializeComponent();

            dSecunds = 0;//обнуление счётчика
            dKeyDounRight = 0;
            dKeyDounErorr = 0;

            String temp = System.IO.File.ReadAllText("C:\\library\\training\\Test.txt", System.Text.Encoding.Default);
            //-------------МОДУЛЬ Сортировки----------
            
            string[] words = temp.Split();

            //-------блок ПРОВЕРКИ------------
            char[] chMid = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            //char[] chMid = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            foreach (var word in words)
            {
                char[] s4 = word.ToCharArray();//копирование из массива string в char
                //перебор по одному слову
                foreach (var c4 in s4)
                {
                    //перебор по одной букве
                    foreach (var chMids in chMid)
                    {
                        if (c4 == chMids)
                        {
                            label4.Text += c4; //составление в слово, букв прошедших проверку.
                        }
                    }
                }

                if (label4.Text == word)//составление в строку,слово целиком прошло проверку
                {
                    label1.Text += word + ' ';//вывод проверенного слова
                }
                    label4.Text = null;//обнуления поля для ввода нового слова
            }
            label1.Text += '\n';//ОГРАНИЧИТЕЛЬ (что бы не было ошибки)  
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //-------------выбор файла-------------
            dSecunds = 0;//обнуление счётчика
            dKeyDounRight = 0;
            dKeyDounErorr = 0;
            label2.Text = null;//очистка экрана

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "C:\\library";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try//проверка catch
                {
                    label1.Text = null;//обнуление предыдущего текста
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string Text = File.ReadAllText(openFileDialog1.FileName);
                            string[] words = Text.Split();
                            //-------блок ПРОВЕРКИ------------
                            char[] chMid = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l',
                                'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'z', 'x', 'c', 'v',
                                'b', 'n', 'm', '\'', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Q',
                                'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'Z', 'X', 'C', 'V', 'B',
                                'N', 'M' };
                            foreach (var word in words)
                            {
                                char[] s4 = word.ToCharArray();//копирование из массива string в char
                                //перебор по одному слову
                                foreach (var c4 in s4)
                                {
                                    //перебор по одной букве
                                    foreach (var chMids in chMid)
                                    {
                                        if (c4 == chMids)
                                        {
                                            label4.Text += c4; //составление в слово, букв прошедших проверку.
                                        }
                                    }
                                }

                                if (label4.Text == word)//составление в строку,слово целиком прошло проверку
                                {
                                    label1.Text += word + ' ';//вывод проверенного слова
                                }
                                label4.Text = null;//обнуления поля для ввода нового слова
                            }
                            label1.Text += '\n';//ОГРАНИЧИТЕЛЬ (что бы не было ошибки) 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }



        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label2.Text = null;//очистка экрана
        String temp = System.IO.File.ReadAllText("C:\\library\\training\\Midline.txt ", System.Text.Encoding.Default);
                    label1.Text = null;
                    string[] separators = { "‘", "’", ",", ".", "!", "?", ";", ":", " ", "    ", "`", "\"", "@", "#", "$", "%", "^", "&", "*", "[", "]", "\n", "\r", " ", "~", "_", "-", "(", ")", "-", "+", "=", "<", ">", "{", "}", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                    string[] words = temp.Split(separators, StringSplitOptions.RemoveEmptyEntries);

         //-------------МОДУЛЬ Сортировки----------
                    char[] chMid = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
                    //char[] chMid = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
                    foreach (var word in words)
                    {
                        //-------блок ПРОВЕРКИ------------
                        char[] s4 = word.ToCharArray();//копирование из массива string в char
                        //for (int i = 0; i < word.Length; i++)//перебор по одному слову
                        foreach (var c4 in s4)
                        {
                            //for (int j = 0; j < chMid.Length; j++)//перебор по одной букве
                            foreach (var chMids in chMid)
                            {
                                if (c4 == chMids)
                                {
                                    label4.Text += c4; //составление в слово, букв прошедших проверку.
                                }
                            }
                        }
                        if (label4.Text == word)
                        {
                            label1.Text += word + ' ';//вывод проверенного слова
                        }
                        label4.Text = null;//обнуления поля для ввода нового слова
                    }
                    label1.Text += '\n';//ОГРАНИЧИТЕЛЬ (что бы не было ошибки)
        }

        private void сохранитьТекстНаДанномМоментеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("C:\\library\\training\\Memory.txt", label1.Text);//запись в файл
            MessageBox.Show("Документ сохранён.", "Сохраненить текст на данном моменте");

            if (label2.Text.Length > 1)
            {
                //----------------МОДУЛЬ ОШИБОК И ВРЕМЕНИ
                labelTimer.Text = null;//очистка экран
                timer1.Enabled = false;//остановка таймера
                labelTimer.Text = "" + dSecunds;
                double iProcent = dKeyDounRight / ((dKeyDounErorr + dKeyDounRight) / 100);
                int Procent = Convert.ToInt32(iProcent);
                double dSimbMin = dKeyDounRight / (dSecunds / 60);
                int iSimbMin = Convert.ToInt32(dSimbMin);
                labelTimer.Text = "Скорость" + iSimbMin + " знаков/минуту," + " Tочность" + Procent + "%";
                label2.Text = null;//очистка экрана
            }

        }

        private void загрузитьСохранённыйТекстToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dSecunds = 0;//обнуление счётчика
            dKeyDounRight = 0;
            dKeyDounErorr = 0;
            String temp = System.IO.File.ReadAllText("C:\\library\\training\\Memory.txt", System.Text.Encoding.Default);
            label2.Text = null;//очистка экрана
            label1.Text = temp;//ВЫВОД НА ЭКРАН

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //label1.Text = "KeyCode: " + e.KeyData; //показывает значение нажатой клавиши
            //String s = "asdfbcdefghijklmnopq";//получение s
            //label1.Text = s;

            
            if (label1.Text == " \n")
            //----------------МОДУЛЬ ОШИБОК И ВРЕМЕНИ
            {
                labelTimer.Text = null;
                timer1.Enabled = false;//остановка таймера
                labelTimer.Text =""+dSecunds;
                double iProcent = dKeyDounRight / ((dKeyDounErorr + dKeyDounRight) / 100);
                int Procent = Convert.ToInt32(iProcent);
                double dSimbMin = dKeyDounRight / (dSecunds/60);
                int iSimbMin = Convert.ToInt32(dSimbMin);
                labelTimer.Text = "Скорость" + iSimbMin + " знаков/минуту," + " Tочность" + Procent + "%";
                label2.Text = null;
            }
            string s;
            s = label1.Text;

            string s2; //объявляем
            s2 = s; //копируем из s в s2

            int x1 = 1;
            x1 = s2.Length;
            if (x1 > 0)
            {
                s2 = s2.Substring(0, x1 - (x1 - 1));//System.ArgumentOutOfRangeException
                //Дополнительные сведения: Индекс и длина должны указывать на позицию в строке.

                //В скобках первое значение 
                //- это позиция знака, второе длинна строки
            }
            char str2 = Convert.ToChar(s2);

            label1.Text = s;

            //---------------------------------------
            const int iNumber = 28; //количество конопок
            int[] iKeyADDCI = new int[iNumber] { 65, 83, 68, 70, 71, 72, 74, 75, 76, 81,87,69,82,84,89,85,73,79,80 ,90,88,67,86,66,78,77, 32 ,222 };
            char[] chLetter = new char[iNumber] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'z', 'x', 'c', 'v', 'b', 'n', 'm', ' ', '\'' };
            char[] chCapsLetter = new char[iNumber] { 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' , ' ', '\'' };
            //--------------iСОВПАДЕНЕИ-------------
            for (int i = 0; i < iNumber; i++)
            {
                if (e.KeyValue == iKeyADDCI[i] && (str2 == chLetter[i] || str2 == chCapsLetter[i]))
                {
                    dKeyDounRight++;//клавиш нажато правильно 
                    timer1.Enabled = true;

                    int n;
                    n = s.Length;
                    s = s.Substring(1, n - 1);
                    //В скобках
                    //первое значение - это позиция знака, 
                    //второе длинна строки
                    label1.Text = s;  //вывод на экран
                    label2.Text += s2; //вывод на экран
                    if (label2.Text.Length > 10)
                    {
                        label2.Text = label2.Text.Substring(1, 10);
                    }

                    if (i == 0)
                    {
                        labelA.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 1)
                    {
                        labelS.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 2)
                    {
                        labelD.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 3)
                    {
                        labelF.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 4)
                    {
                        labelG.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 5)
                    {
                        labelH.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 6)
                    {
                        labelJ.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 7)
                    {
                        labelK.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 8)
                    {
                        labelL.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 9)
                    {
                        labelQ.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 10)
                    {
                        labelW.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 11)
                    {
                        labelE.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 12)
                    {
                        labelR.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 13)
                    {
                        labelT.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 14)
                    {
                        labelY.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 15)
                    {
                        labelU.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 16)
                    {
                        labelI.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 17)
                    {
                        labelO.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 18)
                    {
                        labelP.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 19)
                    {
                        labelZ.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 20)
                    {
                        labelX.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 21)
                    {
                        labelC.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 22)
                    {
                        labelV.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 23)
                    {
                        labelB.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 24)
                    {
                        labelN.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 25)
                    {
                        labelM.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 26)
                    {
                        labelSpace.BackColor = Color.Lime; //изменение цвета
                    }
                    if (i == 27)
                    {
                        labelApostrophe.BackColor = Color.Lime; //изменение цвета
                    }
                }

                //----------jОШИБКА----------------
                for (int j = 0; j < iNumber; j++)
                {
                    if (e.KeyValue == iKeyADDCI[i] && (str2 == chLetter[j] || str2 == chCapsLetter[j]))
                    {

                        if (i == 0 && j != 0)
                        {
                            labelA.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;//нажато клавиш не правильно
                        }
                        if (i == 1 && j != 1)
                        {
                            labelS.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 2 && j != 2)
                        {
                            labelD.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 3 && j != 3)
                        {
                            labelF.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 4 && j != 4)
                        {
                            labelG.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 5 && j != 5)
                        {
                            labelH.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 6 && j != 6)
                        {
                            labelJ.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 7 && j != 7)
                        {
                            labelK.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 8 && j != 8)
                        {
                            labelL.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 9 && j != 9)
                        {
                            labelQ.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 10 && j != 10)
                        {
                            labelW.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 11 && j != 11)
                        {
                            labelE.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 12 && j != 12)
                        {
                            labelR.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 13 && j != 13)
                        {
                            labelT.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 14 && j != 14)
                        {
                            labelY.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 15 && j != 15)
                        {
                            labelU.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }if (i == 16 && j != 16)
                        {
                            labelI.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 17 && j != 17)
                        {
                            labelO.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 18 && j != 18)
                        {
                            labelP.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 19 && j != 19)
                        {
                            labelZ.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 20 && j != 20)
                        {
                            labelX.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }if (i == 21 && j != 21)
                        {
                            labelC.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 22 && j != 22)
                        {
                            labelV.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 23 && j != 23)
                        {
                            labelB.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 24 && j != 24)
                        {
                            labelN.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 25 && j != 25)
                        {
                            labelM.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                        if (i == 26 && j != 26)
                        {
                            labelSpace.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }
                            if (i == 27 && j != 27)
                        {
                            labelApostrophe.BackColor = Color.Red; //изменение цвета
                            dKeyDounErorr++;
                        }

                    }
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            labelA.BackColor = Color.White; //изменение цвета
            labelS.BackColor = Color.White; //изменение цвета
            labelD.BackColor = Color.White; //изменение цвета
            labelF.BackColor = Color.White; //изменение цвета
            labelG.BackColor = Color.White; //изменение цвета
            labelH.BackColor = Color.White; //изменение цвета
            labelJ.BackColor = Color.White; //изменение цвета
            labelK.BackColor = Color.White; //изменение цвета
            labelL.BackColor = Color.White; //изменение цвета
            labelQ.BackColor = Color.White; //изменение цвета
            labelW.BackColor = Color.White; //изменение цвета
            labelE.BackColor = Color.White; //изменение цвета
            labelR.BackColor = Color.White; //изменение цвета
            labelT.BackColor = Color.White; //изменение цвета
            labelY.BackColor = Color.White; //изменение цвета
            labelU.BackColor = Color.White; //изменение цвета
            labelI.BackColor = Color.White; //изменение цвета
            labelO.BackColor = Color.White; //изменение цвета
            labelP.BackColor = Color.White; //изменение цвета
            labelZ.BackColor = Color.White; //изменение цвета
            labelX.BackColor = Color.White; //изменение цвета
            labelC.BackColor = Color.White; //изменение цвета
            labelV.BackColor = Color.White; //изменение цвета
            labelB.BackColor = Color.White; //изменение цвета
            labelN.BackColor = Color.White; //изменение цвета
            labelM.BackColor = Color.White; //изменение цвета
            labelSpace.BackColor = Color.White; //изменение цвета
            labelApostrophe.BackColor = Color.White; //изменение цвета
        }

        private void midLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dSecunds++;
        }

        private void midTopLinesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void показатьРезультатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label2.Text.Length > 1)
            {
                //----------------МОДУЛЬ ОШИБОК И ВРЕМЕНИ
                labelTimer.Text = null;
                timer1.Enabled = false;//остановка таймера
                labelTimer.Text = "" + dSecunds;
                double iProcent = dKeyDounRight / ((dKeyDounErorr + dKeyDounRight) / 100);
                int Procent = Convert.ToInt32(iProcent);
                double dSimbMin = dKeyDounRight / (dSecunds / 60);
                int iSimbMin = Convert.ToInt32(dSimbMin);
                labelTimer.Text = "Скорость" + iSimbMin + " знаков/минуту," + " Tочность" + Procent + "%";
            }
        }

        private void текстСодержитasdfghjklИqwertyuiopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = null;//очистка экрана
            String temp = System.IO.File.ReadAllText("C:\\library\\training\\Midline.txt ", System.Text.Encoding.Default);
            label1.Text = null;
            string[] separators = { "‘", "’", ",", ".", "!", "?", ";", ":", " ", "    ", "`", "\"", "@", "#", "$", "%", "^", "&", "*", "[", "]", "\n", "\r", " ", "~", "_", "-", "(", ")", "-", "+", "=", "<", ">", "{", "}", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] words = temp.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            //-------------МОДУЛЬ Сортировки----------
            //char[] chMid = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            char[] chMid = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            foreach (var word in words)
            {
                //-------блок ПРОВЕРКИ------------
                char[] s4 = word.ToCharArray();//копирование из массива string в char
                //for (int i = 0; i < word.Length; i++)//перебор по одному слову
                foreach (var c4 in s4)
                {
                    //for (int j = 0; j < chMid.Length; j++)//перебор по одной букве
                    foreach (var chMids in chMid)
                    {
                        if (c4 == chMids)
                        {
                            label4.Text += c4; //составление в слово, букв прошедших проверку.
                        }
                    }
                }
                if (label4.Text == word)
                {
                    label1.Text += word + ' ';//вывод проверенного слова
                }
                label4.Text = null;//обнуления поля для ввода нового слова
            }
            label1.Text += '\n';//ОГРАНИЧИТЕЛЬ (что бы не было ошибки)
        }

        private void поСтрокамasdfghjklИqwertyuiopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dSecunds = 0;//обнуление счётчика
            dKeyDounRight = 0;
            dKeyDounErorr = 0;
            label2.Text = null;//очистка экрана
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\library";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try//проверка catch
                {
                    label1.Text = null;//обнуление предыдущего текста
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            //label1.Text = File.ReadAllText(openFileDialog1.FileName);
                            //------БЛОК склеивания в одну строку------------
                            string Text = File.ReadAllText(openFileDialog1.FileName);
                            string[] separators = { "‘", "’", ",", ".", "!", "?", ";", ":", " ", "    ", "`", "\"", "@", "#", "$", "%", "^", "&", "*", "[", "]", "\n", "\r", " ", "~", "_", "-", "(", ")", "-", "+", "=", "<", ">", "{", "}", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                            string[] words = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            //-------------МОДУЛЬ Сортировки----------
                            //char[] chMid = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
                            char[] chMid = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
                            foreach (var word in words)
                            {
                                //-------блок ПРОВЕРКИ------------
                                char[] s4 = word.ToCharArray();//копирование из массива string в char
                                //for (int i = 0; i < word.Length; i++)//перебор по одному слову
                                foreach (var c4 in s4)
                                {
                                    //for (int j = 0; j < chMid.Length; j++)//перебор по одной букве
                                    foreach (var chMids in chMid)
                                    {
                                        if (c4 == chMids)
                                        {
                                            //label1.Text += c4;
                                            label4.Text += c4; //составление в слово, букв прошедших проверку.
                                        }

                                    }
                                }
                                if (label4.Text == word)
                                {
                                    label1.Text += word + ' ';
                                }
                                label4.Text = null;//обнуления поля для ввода нового слова 
                            }
                        }
                        label1.Text += '\n';//ОГРАНИЧИТЕЛЬ (что бы не было ошибки)
                        /*System.IO.File.AppendAllText("Test.txt", label1.Text);//запись в файл
                        MessageBox.Show("Документ изменён.\nИзменения сохранены", "Expand training text");
                    */
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: \n" + ex.Message);
                }
            }

        }   
    }
}

