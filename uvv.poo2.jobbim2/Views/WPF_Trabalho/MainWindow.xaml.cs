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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Trabalho
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClickInscricao(object sender, RoutedEventArgs e)
        {
            Main.Content = new Inscricao_Page();
        }

        private void BtnClickCurso(object sender, RoutedEventArgs e)
        {
            Main.Content = new Curso_Page();
        }

        private void BtnClickOferta(object sender, RoutedEventArgs e)
        {
            Main.Content = new Oferta_Page();
        }

        private void BtnClickFuncionario(object sender, RoutedEventArgs e)
        {
            Main.Content = new Funcionario_Page();
        }
    }
}
