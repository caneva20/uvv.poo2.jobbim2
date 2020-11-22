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
    /// Interação lógica para Oferta_Page.xam
    /// </summary>
    public partial class Oferta_Page : Page
    {
        string strDataInicial;
        string strDataFinal;
        string strSituacaoOferta;
        public Oferta_Page()
        {
            InitializeComponent();
        }

        private void abrirOferta(object sender, RoutedEventArgs e)
        {
            strDataInicial = input_DataFinal.Text;
            strDataFinal = input_DataFinal.Text;
            strSituacaoOferta = input_situacaoOferta.Text;
            ComboBoxItem typeItem = (ComboBoxItem)lista_cursos_abrir.SelectedItem;
            string value = typeItem.Content.ToString();
        }

        private void buscarOferta(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)lista_cursos_buscar.SelectedItem;
            string value = typeItem.Content.ToString();
        }

        private void suspenderOferta(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)lista_oferta_suspender.SelectedItem;
            string value = typeItem.Content.ToString();
        }

        private void cancelarOferta(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)lista_oferta_suspender.SelectedItem;
            string value = typeItem.Content.ToString();
        }
    }
}
