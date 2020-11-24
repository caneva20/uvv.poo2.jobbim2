using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using ajj;

namespace WPF_Trabalho {
    /// <summary>
    /// Interação lógica para Oferta_Page.xam
    /// </summary>
    public partial class OfferPage : Page {
        private readonly OfferClient _offerClient;
        private readonly CourseClient _courseClient;
        
        public OfferPage() {
            InitializeComponent();

            _offerClient = new OfferClient(new HttpClient());
            _courseClient = new CourseClient(new HttpClient());

            Load();
        }

        private async void Load() {
            lista_cursos_abrir.Items.Clear();
            lista_cursos_buscar.Items.Clear();
            lista_oferta_suspender.Items.Clear();
            
            foreach (var course in await _courseClient.GetAllAsync()) {
                lista_cursos_abrir.Items.Add(course);
                lista_cursos_buscar.Items.Add(course);
            }
            
            foreach (var offer in await _offerClient.GetOffersAllAsync()) {
                lista_oferta_suspender.Items.Add(offer);
            }
        }

        private void CreateOffer(object sender, RoutedEventArgs e) {
            if (!DateTime.TryParse(input_DataInicial.Text, out var beginDate)) {
                beginDate = DateTime.Now;
            }

            if (!DateTime.TryParse(input_DataFinal.Text, out var endDate)) {
                endDate = DateTime.Now;
            }
            
            if (!int.TryParse(input_situacaoOferta.Text, out var status)) {
                status = 0;
            }
            
            var course= (Course) lista_cursos_abrir.SelectedItem;

            _offerClient.CreateOfferAsync(new OfferDTO() {
                StartDate = beginDate,
                EndDate = endDate,
                Status = (OfferStatus) status,
                CourseId = course.Id,
            });
        }

        private async void SearchOffer(object sender, RoutedEventArgs e) {
            var course = (Course) lista_cursos_buscar.SelectedItem;

            lista_Cursos_Oferta.Items.Clear();
            
            foreach (var offer in await _offerClient.GetOffersAsync(course.Id)) {
                lista_Cursos_Oferta.Items.Add($"Até: {offer.EndDate}\nStatus: {offer.Status:G}");
            }
        }

        private void CloseOffer(object sender, RoutedEventArgs e) {
            var offer = (Offer) lista_oferta_suspender.SelectedItem;

            _offerClient.UpdateStatusAsync(offer.Id, new OfferStatusDTO() {
                Status = OfferStatus.Suspended,
            });
        }

        private void DeleteOffer(object sender, RoutedEventArgs e) {
            var offer = (Offer) lista_oferta_suspender.SelectedItem;

            _offerClient.UpdateStatusAsync(offer.Id, new OfferStatusDTO() {
                Status = OfferStatus.Canceled,
            });
        }
    }
}
