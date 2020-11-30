using Dierentuin.Classes;
using DierenTuin.Core.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Zoo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DierentuinApi.InitAnimals();
            DierentuinApi.AddAnimal(new Elephant { Name = "Barbera", energy = 100 });
            DierentuinApi.AddAnimal(new Elephant { Name = "Bob", energy = 100 });
            DierentuinApi.AddAnimal(new Elephant { Name = "Samatha", energy = 100 });
            DierentuinApi.AddAnimal(new Monkey { Name = "Sjonnie", energy = 60 });
            DierentuinApi.AddAnimal(new Monkey { Name = "Sjakie", energy = 60 });
            DierentuinApi.AddAnimal(new Monkey { Name = "Bonnie", energy = 60 });
            DierentuinApi.AddAnimal(new Monkey { Name = "Jessie", energy = 60 });
            DierentuinApi.AddAnimal(new Lion { Name = "Lazy", energy = 60 });
            DierentuinApi.AddAnimal(new Lion { Name = "Crazy", energy = 60 });
            DierentuinApi.AddAnimal(new Lion { Name = "Hazy", energy = 60 });
            List<Animal> animals = DierentuinApi.GetAnimals();

            base.OnStartup(e); MainWindow window = new MainWindow();

            string path = "/MainWindow.xaml.cs";
            var viewmodel = new MainWindow();

        }
    }
}
