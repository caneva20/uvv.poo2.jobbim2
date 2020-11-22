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
    /// Interação lógica para Curso_Page.xam
    /// </summary>
    public partial class Curso_Page : Page
    {
        string strNomeCurso;
        string strEmentaCurso;
        string strCargaHoraria;
        public Curso_Page()
        {
            InitializeComponent();
        }

        private void criarCurso(object sender, RoutedEventArgs e)
        {
            strNomeCurso = input_Nome_Curso.Text;
            strEmentaCurso = input_Ementa_Curso.Text;
            strCargaHoraria = input_CargaHor_Curso.Text;
        }

        private void atualizarCurso(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)lista_cursos_update.SelectedItem;
            string value = typeItem.Content.ToString();
            strNomeCurso = input_Nome_Curso_update.Text;
            strEmentaCurso = input_Ementa_Curso_update.Text;
            strCargaHoraria = input_CargaHor_Curso_update.Text;
        }

        private void deletarCurso(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)lista_cursos_delete.SelectedItem;
            string value = typeItem.Content.ToString();
        }
    }
}
