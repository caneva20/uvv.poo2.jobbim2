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
    /// Interação lógica para Funcionario_Page.xam
    /// </summary>
    public partial class Funcionario_Page : Page
    {
        string strNomeFuncionario;
        string strCargo;
        string strSetor;
        string strDataRecisao;
        public Funcionario_Page()
        {
            InitializeComponent();
        }

        private void criarFuncionario(object sender, RoutedEventArgs e)
        {
            strNomeFuncionario = input_Nome_Funcionario.Text;
            strCargo = input_Cargo.Text;
            strSetor = input_Setor.Text;
            strDataRecisao = input_Data_Recisao.Text;
        }

        private void listarCursos(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)lista_funcionarios_cursos.SelectedItem;
            string value = typeItem.Content.ToString();
        }

        private void listarDados(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)lista_funcionarios_buscar.SelectedItem;
            string value = typeItem.Content.ToString();
        }

        private void encerrarContrato(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)lista_funcionarios_encerrar.SelectedItem;
            string value = typeItem.Content.ToString();
        }
    }
}
