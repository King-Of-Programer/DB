using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DbApp
{
    public partial class MainPage : ContentPage
    {
        private DataContext _dataContext;
        public MainPage()
        {
            InitializeComponent();
            _dataContext = new DataContext("https://xamapp-af217-default-rtdb.europe-west1.firebasedatabase.app/");
        }
        private Label CreateLabel(string text)
        {
            var label = new Label();
            label.FontSize = 15;
            label.Text = text;
            label.TextColor = Color.Black;
            return label;

        }
        private async void addWorker_Click(object sender, EventArgs e)
        {
            workersStack.Children.Clear();
            Worker worker = new Worker()
            {
                FirstName = fNameEntry.Text,
                LastName = lNameEntry.Text,
            };
            await _dataContext.AddPerson(worker);
            var students = await _dataContext.GetAllWorkers();
            foreach (var student in students)
            {
                var label = CreateLabel($"Id: {student.Id},First name: {student.FirstName}, Last name: {student.LastName}");
                workersStack.Children.Add(label);
            }
        }
    }
}
