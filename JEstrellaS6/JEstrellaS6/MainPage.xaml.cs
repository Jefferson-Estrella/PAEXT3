using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JEstrellaS6
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://192.168.56.1/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<estudiante> post;
        public MainPage()
        {
            InitializeComponent();
            ObtenerDatos();
        }

        public async void ObtenerDatos()
        {
            var conternido = await cliente.GetStringAsync(Url);
            List<estudiante> listaPost = JsonConvert.DeserializeObject<List<estudiante>>(conternido);
            post = new ObservableCollection<estudiante>(listaPost);
            ListaEstudiantes.ItemsSource = post;
        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new registrar());
        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objeto = (estudiante)e.SelectedItem;
            var codigoTem = objeto.codigo.ToString();
            var codigo = Convert.ToInt32(codigoTem);
            string nombre = objeto.nombre.ToString();
            string apellido = objeto.apellido.ToString();
            var edadtemp = objeto.edad.ToString();
            int edad = Convert.ToInt32(edadtemp);
            Navigation.PushAsync(new ActualizarEliminar(codigo, nombre, apellido, edad));
        }
    }
}
