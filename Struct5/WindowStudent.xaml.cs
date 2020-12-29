using System;
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
using System.Windows.Shapes;

namespace Struct5
{
    /// <summary>
    /// Логика взаимодействия для WindowStudent.xaml
    /// </summary>
    public partial class WindowStudent : Window
    {
        public WindowStudent(Student d)
        {
            InitializeComponent();
            fio.Text = d.fio;
            gn.Text = d.group_number.ToString();
            ap.Text = d.academic_perfomance.ToString();
        }

        public WindowStudent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        //public string getFio()
        //{
        //    return fio.Text;
        //}

        //public int getGroupNumber()
        //{
        //    return int.Parse(gn.Text);
        //}

        public int[] Parse(string st)
        {
            return st.Split(' ').Select(x => int.Parse(x)).ToArray();
        }
        public int[] getAcademicPerfomance()
        {
            string str = ap.Text;
            int[] res = Parse(str);
            return res;
        }
    }
}
