﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Struct5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public struct Student
    {
        public string fio;
        public int group_number;
        public int[] academic_perfomance;
        public int[] average_score;
    }
    public partial class MainWindow : Window
    {
        Student[] students;
        int i = 0;
        int count;
        public MainWindow()
        {
            InitializeComponent();
        }

        //Функция создания массива 7 записей
        public void create_array_7()
        {
            count = 7;
            students = new Student[count];
            AddStudent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (i == 0)
            {
                try
                {
                    create_array_7();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                AddStudent(); //Добавить студента
            }
            if (i == count) //Заблокировать кнопку, когда количество записей достигнет 7
            {
                Add.IsEnabled = false;
            }
        }

        public void AddStudent()
        {
            if (i < count)
            {
                WindowStudent window = new WindowStudent();
                if (window.ShowDialog() == true)
                {
                    Student d = new Student();
                    d.fio = window.fio.Text;
                    d.group_number = int.Parse(window.gn.Text);
                    d.academic_perfomance = window.getAcademicPerfomance();
                    students[i] = d;
                    Student.Items.Add(d.fio);
                }
                i++;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Add.IsEnabled = false;
        }
        private void Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            Add.IsEnabled = true;
        }

        //Вычисление среднего балла
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            int s = 0;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (int j in students[i].academic_perfomance)
                    {
                        s += j;
                    }
                    s = s / 4;
                    OUTPUT.Text += students[i].fio + Environment.NewLine + "Оценки: " + string.Join(" ", students[i].academic_perfomance) + Environment.NewLine + "Средний балл: " + s + Environment.NewLine + Environment.NewLine;
                    s = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Сортировка по убыванию среднего балла
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int s = 0;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (int j in students[i].academic_perfomance)
                    {
                        s += j;
                    }
                    s = s / 4;
                    students[i].average_score[i] = s;
                    s = 0;
                }
                    //Сортировка пузырьком
                    for (int i = 0; i < count - 1; i++)
                    {
                        for (int j = i + 1; j < count; j++)
                        {
                            if (students[i].average_score[i] < students[i].average_score[j])
                            {
                                Student p = new Student();
                                p = students[i];
                                students[i] = students[j];
                                students[j] = p;
                            }
                        }
                    }
          
                Student.Items.Clear();
                for (int i = 0; i < count; i++) Student.Items.Add(students[i].fio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Очистка поля
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OUTPUT.Text = String.Empty;
        }

        //Вывод сведений о студентах
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
        }

        //Удалить студента с самым низким баллом
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }
    }

}

