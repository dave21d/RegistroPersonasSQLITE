using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroPersonasT.MODELS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistroPersonasT.VIEWS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePersonas : ContentPage
    {
        public PagePersonas()
        {
            InitializeComponent();
            Datos();
        }

        private async void EnviarInfo_Clicked(object sender, EventArgs e)
        {
            if (validaciondatos())
            {
                PersonasModels personasModels = new PersonasModels
                {
                   nombres=txtnombre.Text,
                        apellidos=txtapellidos.Text,
                        edad=Convert.ToDouble( txtedad.Text),
                        correo=txtcorreo.Text,
                        direccion=txtdireccion.Text,

                       
                     
                };
                await App.sqlitedb.Saveperson(personasModels);
                txtnombre.Text = "";
                txtapellidos.Text = "";
                txtedad.Text = "";
                txtcorreo.Text = "";
                txtdireccion.Text = "";
                await DisplayAlert("Mensaje", "Su Registro se guardo correctamente", "De Acuerdo");
                Datos();
               
            }
            else
            {
                await DisplayAlert("Mensaje", "Ingrese todos los datos", "De Acuerdo");
            }
            
            
            //if (await App.dbpers.Saveperson(persona) > 0)
            //    await DisplayAlert("Mensaje", "El Registro de Persona Fue Ingresado Correctamente", "De Acuerdo");
            //var personalist = await App.sqlitedb.GetPersonasAsync();
            //else
            //    await DisplayAlert("Mensaje", "Error", "De acuerdo");

            //var page = new VIEWS.Pageresultado();
            //page.BindingContext = persona;
            //await Navigation.PushAsync(page);
        }
        public async void Datos()
        {
            var personalist = await App.sqlitedb.GetPersonasAsync();
            if (personalist != null)
            {
                listpersonas.ItemsSource = personalist;
            }
        }
        public bool validaciondatos()
        {
            bool res;
            if (string.IsNullOrEmpty(txtnombre.Text))
            {
                res = false;
            }
            else if (string.IsNullOrEmpty(txtapellidos.Text))
            {
                res = false;
            }
            else if (string.IsNullOrEmpty(txtedad.Text))
            {
                res = false;
            }
            else if (string.IsNullOrEmpty(txtcorreo.Text))
            {
                res = false;
            }
            else if (string.IsNullOrEmpty(txtdireccion.Text))
            {
                res = false;
            }
            else
            {
                res = true;
            }
            return res;
        } 

        private async void Actualizar_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txid.Text))
            {
                PersonasModels personas = new PersonasModels()
                {

                    nombres = txtnombre.Text,
                    apellidos = txtapellidos.Text,
                    edad = Convert.ToDouble(txtedad.Text),
                    correo = txtcorreo.Text,
                    direccion = txtdireccion.Text
                };
                await App.sqlitedb.Saveperson(personas);
                await DisplayAlert("Registro de Persona", "Sus datos se actualizaron Correctamente", "De Acuerdo");
                txid.Text = "";
                txtnombre.Text = "";
                txtapellidos.Text = "";
                txtedad.Text = "";
                txtcorreo.Text = "";
                txtdireccion.Text = "";

                txid.IsVisible = false;
                Actualizar.IsVisible = false;
                EnviarInfo.IsVisible = true;
                Datos();
            }
            
            


           

            

        }

        private async void listpersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var relist = (PersonasModels)e.SelectedItem;
            EnviarInfo.IsVisible = true;
            txid.IsVisible = true;
            Actualizar.IsVisible = true;
            Eliminar.IsVisible = true;
            //Eliminar.IsVisible = true;


            if (!string.IsNullOrEmpty(relist.id.ToString()))
            {
                var persona = await App.sqlitedb.GetPersonaByIdAsync(relist.id);
                if (persona != null)
                {
                    txid.Text =persona.id.ToString();
                    txtnombre.Text = persona.nombres;
                    txtapellidos.Text = persona.apellidos;
                    txtedad.Text = persona.edad.ToString();
                    txtcorreo.Text = persona.correo;
                    txtdireccion.Text = persona.direccion;

                }
            }
            
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var persona = await App.sqlitedb.GetPersonaByIdAsync(Convert.ToInt32(txid.Text));
            if (persona != null)
            {
                await App.sqlitedb.deletepersonasAsync(persona);
                await DisplayAlert("Mensaje", "El registro de alumno fue eliminado correctamente", "De acuerdo");
                Datos();
                txid.IsVisible = false;
                Actualizar.IsVisible = false;
                Eliminar.IsVisible = false;
                EnviarInfo.IsVisible = true;

            }
        }
    }
}