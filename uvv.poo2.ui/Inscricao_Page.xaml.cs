using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using ajj;

namespace WPF_Trabalho {
    /// <summary>
    /// Interação lógica para Inscricao_Page.xam
    /// </summary>
    public partial class Inscricao_Page : Page {
        private readonly CourseClient _courseClient;
        private readonly EmployeeClient _employeeClient;
        private readonly SubscriptionClient _subscriptionClient;
        
        public Inscricao_Page() {
            InitializeComponent();
            
            _courseClient = new CourseClient(new HttpClient());
            _employeeClient = new EmployeeClient(new HttpClient());
            _subscriptionClient = new SubscriptionClient(new HttpClient());

            Load();
        }

        private async void Load() {
            lista_cursos.Items.Clear();
            lista_funcionarios.Items.Clear();
            lista_inscricao.Items.Clear();

            foreach (var course in await _courseClient.GetAllAsync()) {
                lista_cursos.Items.Add(course);
            }
            
            foreach (var employee in await _employeeClient.GetEmployeesAsync()) {
                lista_funcionarios.Items.Add(employee);
            }

            foreach (var subscription in await _subscriptionClient.GetSubscriptionsAsync()) {
                lista_inscricao.Items.Add(subscription);
            }
        }

        private async void CreateSubscription(object sender, RoutedEventArgs e) {
            var course = (Course) lista_cursos.SelectedItem;
            var employee = (Employee) lista_funcionarios.SelectedItem;

            await _subscriptionClient.CreateSubscriptionAsync(new SubscriptionDTO() {
                CourseId = course.Id,
                EmployeeId = employee.Id,
                Date = DateTimeOffset.Now,
                Status = true,
            });
        }

        private void CancelSubscription(object sender, RoutedEventArgs e) {
            var subscription = (Subscription) lista_inscricao.SelectedItem;

            _subscriptionClient.UpdateStatusAsync(subscription.Id, new SubscriptionStatusDTO() {
                Status = false,
            });
        }
    }
}
