using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using static RegistroPersonasT.CONTROLLERS.Personas;
using RegistroPersonasT.CONTROLLERS;

namespace RegistroPersonasT
{
    public partial class App : Application
    {
        //static CONTROLLERS.Personas DBpersonas;
        public static SqliteHelper dbpers;

        public static SqliteHelper sqlitedb
        {
            get
            {
                if (dbpers == null)
                {
                    dbpers = new SqliteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Personasr.db3"));
                }
                return dbpers;
            }
        }

        //public static CONTROLLERS.Personas DBPERSON
        //{
        //    get
        //    {
        //        if (DBpersonas == null)
        //        {
        //            var dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //            var dbname = "Personas.db3";
        //            DBpersonas = new CONTROLLERS.Personas (Path.Combine(dbpath, dbname));
        //        }
        //        return DBpersonas;
        //    }
            
        //}
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new VIEWS.PagePersonas());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
