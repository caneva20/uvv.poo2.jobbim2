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
    /// Interação lógica para Inscricao_Page.xam
    /// </summary>
    public partial class Inscricao_Page : Page
    {
        public Inscricao_Page()
        {
            InitializeComponent();
        }

        private void criarInscricao(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItemCurso = (ComboBoxItem)lista_cursos.SelectedItem;
            ComboBoxItem typeItemFuncionario = (ComboBoxItem)lista_funcionarios.SelectedItem;
            string curso = typeItemCurso.Content.ToString();
            string funcionario = typeItemFuncionario.Content.ToString();
        }

        private void cancelarInscricao(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)lista_inscricao.SelectedItem;
            string value = typeItem.Content.ToString();
        }
    }
}
