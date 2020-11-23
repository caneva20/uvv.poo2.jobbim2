using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using ajj;

namespace WPF_Trabalho {
    /// <summary>
    /// Interação lógica para Funcionario_Page.xam
    /// </summary>
    public partial class Funcionario_Page : Page {
        private readonly EmployeeClient _client;
        
        string strNomeFuncionario;
        string strCargo;
        string strSetor;
        string strDataRecisao;

        public Funcionario_Page() {
            InitializeComponent();

            _client = new EmployeeClient(new HttpClient());

            LoadEmployees();
        }

        private async void LoadEmployees() {
            var employees = await _client.GetEmployeesAsync();

            foreach (var employee in employees) {
                lista_funcionarios_cursos.Items.Add(employee);
                lista_funcionarios_buscar.Items.Add(employee);
                lista_funcionarios_encerrar.Items.Add(employee);
            }
        }

        private void CreateEmployee(object sender, RoutedEventArgs e) {
            var name = input_Nome_Funcionario.Text;
            
            if (!DateTime.TryParse(input_Data_Admissao.Text, out var admissionDate)) {
                admissionDate = DateTime.Now;
            }

            _client.CreateEmployeeAsync(new EmployeeDTO {
                Name = name,
                AdmissionDate = admissionDate
            });
        }

        private async void ListCourses(object sender, RoutedEventArgs e) {
            var employee = (Employee) lista_funcionarios_cursos.SelectedItem;

            var courses = await _client.GetEmployeesCoursesAsync(employee.Id);

            foreach (var course in courses) {
                lista_Cursos.Items.Add(course);
            }
        }

        private void ListInfo(object sender, RoutedEventArgs e) {
            var employee = (Employee) lista_funcionarios_buscar.SelectedItem;

            dados_Funcionario.Items.Clear();
            dados_Funcionario.Items.Add($"Nome: {employee.Name}");
            dados_Funcionario.Items.Add($"Data de admissão: {employee.AdmissionDate}");
        }

        private void Fire(object sender, RoutedEventArgs e) {
            var employee = (Employee) lista_funcionarios_encerrar.SelectedItem;

            _client.TerminateContractAsync(employee.Id);
        }
    }
}
