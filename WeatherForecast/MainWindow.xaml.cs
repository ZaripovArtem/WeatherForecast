using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows;

namespace WeatherForecast
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод, активирующийся при нажатии на кнопку
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string city = City.Text;
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&lang=ru&appid=ffc05b61c96f4a360f8244f609f2ad83";

            try
            {
                HttpClient httpClient = new();

                ModuleData? moduleData = await httpClient.GetFromJsonAsync<ModuleData>(url);

                double? celsius = (moduleData?.Main?.Temp) - 273.15;

                Temperature.Text = Math.Round((decimal)celsius, 2).ToString();
                Wind.Text = moduleData?.Wind?.Speed.ToString() + " м/с";
                Description.Text = moduleData?.Weather?[0].Description;
            }
            catch
            {
                Error.Text = "Город не найден";
            }
        }
    }
}
