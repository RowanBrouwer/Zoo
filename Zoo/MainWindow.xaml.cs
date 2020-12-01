using Dierentuin.Classes;
using DierenTuin.Core.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Threading;

namespace Zoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Animal> _animals = new List<Animal>();
        int deaths = 0;
        double ms = 0; double sec = 0; int min = 0;
        string spacer = "-------------------------------------------------------------------";
        string log = "log.txt";

        public MainWindow()
        {
            InitializeComponent();
            CreateList();

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            timer.Tick += Tick;
            timer.Start();

            using (StreamWriter outFile = new StreamWriter("log.txt", true))
            {
                outFile.WriteLine($"{spacer}");
                outFile.WriteLine($"Stared new session on {getTime()}");
            }

            Loaded += MainWindow_Loaded;
        }
        
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    

        public Task Update()
        {
            List<Monkey> monkeys = _animals.OfType<Monkey>().ToList();
            List<Lion> lions = _animals.OfType<Lion>().ToList();
            List<Elephant> elephants = _animals.OfType<Elephant>().ToList();
            _animals = DierentuinApi.UpdateAnimals(monkeys, lions, elephants);
            List<Monkey> _backMonkeys;
            List<Lion> _backLions;
            List<Elephant> _backElephants;

            if (Check_Monkey.IsChecked.Value)
            {;
            }
            if (Check_Lion.IsChecked.Value)
            {
            }
            if (Check_Elephant.IsChecked.Value)
            {
            }
            
            return Task.CompletedTask;
        }

        void Tick(object sender, EventArgs e)
        {
            ms += 250;
            if (ms >= 1000)
            {
                sec++;
                ms -= 1000;
                if (sec >= 60)
                {
                    min++;
                    sec -= 60;
                }
            }
            for (int i = _animals.Count - 1; i >= 0; i--)
            {
                _animals[i].energy = Task.Run(_animals[i].UseEnergy).Result;
                if (_animals[i].energy <= 0)
                {
                    if (min >= 1)
                    {
                        deaths++;
                        using (StreamWriter outFile = new StreamWriter("log.txt", true))
                        {
                            outFile.WriteLine(min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("000") + ":" + _animals[i].GetType().Name + " " + _animals[i].Name + $"Has died, there have been {deaths} deaths.");
                        }
                        _animals.Remove(_animals[i]);
                    }
                    else
                    {
                        using (StreamWriter outFile = new StreamWriter("log.txt", true))
                        {
                            outFile.WriteLine(min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("000") + ":" + _animals[i].GetType().Name + " " + _animals[i].Name + $"Has been auto fed");
                        }
                        _animals[i].Feed();
                    }
                }

                Update();
            }
        }

        public void OnExit()
        {
            using StreamWriter outFile = new StreamWriter("", true);
            outFile.WriteLine("");
            outFile.Write($"Ended session on {getTime()}.");
        }

        public void ViewLog(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "log.txt");
        }

        public void DeleteLog(object sender, EventArgs e)
        {
            File.WriteAllText(@"log.txt", string.Empty);
            using StreamWriter outFile = new StreamWriter("log.txt", true);
            outFile.WriteLine($"{spacer}");
            outFile.WriteLine($"Deleted Logs and Started new session on {getTime()}.");
            outFile.WriteLine("");
        }

        void Add_Animal(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Animal_Name.Text))
            {
                if (Animal_Kind.Text == "Monkey")
                {
                    Animal monkey = new Monkey
                    { Name = Animal_Name.Text, energy = 60 };
                    Add_Logger(monkey);
                    _animals.Add(monkey);
                }
                if (Animal_Kind.Text == "Lion")
                {
                    Animal lion = new Lion
                    { Name = Animal_Name.Text, energy = 60 };
                    Add_Logger(lion);
                    _animals.Add(lion);
                }
                if (Animal_Kind.Text == "Elephant")
                {
                    Animal elephant = new Elephant
                    { Name = Animal_Name.Text, energy = 60 };
                    Add_Logger(elephant);
                    _animals.Add(elephant);
                }
            }
        }

        void Feed(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            foreach (var animal in _animals)
            {
                if (btn.Name == "Monkeybtn" && animal is Monkey)
                {
                    Task.Run(animal.Feed);
                }
                else if (btn.Name == "Lionbtn")
                {
                    Task.Run(animal.Feed);
                }
                else if (btn.Name == "Elephantbtn")
                {
                    Task.Run(animal.Feed);
                }
                else if (btn.Name == "Allbtn")
                {
                    Task.Run(animal.Feed);
                }
            }  
        }

        public void CreateList()
        {
            DierentuinApi.InitAnimals();
            DierentuinApi.AddAnimal(new Elephant { Name = "Barbera", energy = 100 });
            DierentuinApi.AddAnimal(new Elephant { Name = "Bob", energy = 100 });
            DierentuinApi.AddAnimal(new Elephant { Name = "Samatha", energy = 100 });
            DierentuinApi.AddAnimal(new Monkey { Name = "Sjonnie", energy = 60 });
            DierentuinApi.AddAnimal(new Monkey { Name = "Sjakie", energy = 60 });
            DierentuinApi.AddAnimal(new Monkey { Name = "Bonnie", energy = 60 });
            DierentuinApi.AddAnimal(new Monkey { Name = "Jessie", energy = 60 });
            DierentuinApi.AddAnimal(new Lion { Name = "Lazy", energy = 100 });
            DierentuinApi.AddAnimal(new Lion { Name = "Crazy", energy = 100 });
            DierentuinApi.AddAnimal(new Lion { Name = "Hazy", energy = 100 });
            List<Animal> animals = DierentuinApi.GetAnimals();
            _animals = animals;
        }

        public Task Add_Logger(Animal animal)
        {
            using (StreamWriter outFile = new StreamWriter($"{log}", true))
            {
                if (animal is Monkey)
                {
                    outFile.WriteLine(min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("000") + ":" + $"Monkey {animal.Name} has been added.");
                }
                if (animal is Lion)
                {
                    outFile.WriteLine(min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("000") + ":" + $"Monkey {animal.Name} has been added.");
                }
                if (animal is Elephant)
                {
                    outFile.WriteLine(min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("000") + ":" + $"Monkey {animal.Name} has been added.");
                }
            }
            return Task.Delay(50);
        }

        public DateTime getTime()
        {
            return DateTime.Now;
        }
    }
}
