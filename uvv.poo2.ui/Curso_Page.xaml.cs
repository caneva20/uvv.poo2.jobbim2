using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using ajj;

namespace WPF_Trabalho {
    /// <summary>
    /// Interação lógica para Curso_Page.xam
    /// </summary>
    public partial class Curso_Page : Page {
        private readonly CourseClient _client;

        public Curso_Page() {
            InitializeComponent();

            _client = new CourseClient(new HttpClient());

            LoadCourses();
        }

        private async void LoadCourses() {
            lista_cursos_update.Items.Clear();
            lista_cursos_delete.Items.Clear();

            foreach (var course in await _client.GetAllAsync()) {
                lista_cursos_update.Items.Add(course);
                lista_cursos_delete.Items.Add(course);
            }
        }

        private async void CreateCourse(object sender, RoutedEventArgs e) {
            var name = input_Nome_Curso.Text;
            var program = input_Ementa_Curso.Text;
            
            if (!int.TryParse(input_CargaHor_Curso_update.Text, out var workload)) {
                workload = 0;
            }

            await _client.CreateAsync(new CourseDto {
                Name = name,
                Program = program,
                Workload = workload
            });

            LoadCourses();
        }

        private async void UpdateCourse(object sender, RoutedEventArgs e) {
            var course = (Course) lista_cursos_update.SelectedItem;

            var name = input_Nome_Curso_update.Text;
            var program = input_Ementa_Curso_update.Text;
            
            if (!int.TryParse(input_CargaHor_Curso_update.Text, out var workload)) {
                workload = 0;
            }

            await _client.UpdateAsync(course.Id, new CourseDto {
                Name = name,
                Program = program,
                Workload = workload
            });

            LoadCourses();
        }

        private void DeleteCourse(object sender, RoutedEventArgs e) {
            var course = (Course) lista_cursos_delete.SelectedItem;

            _client.DeleteAsync(course.Id);

            lista_cursos_update.Items.Remove(course);
            lista_cursos_delete.Items.Remove(course);
        }
    }
}
