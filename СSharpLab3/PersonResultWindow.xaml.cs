using System;
using System.Windows;

namespace СSharpLab3
{
    /// <summary>
    /// Логика взаимодействия для PersonResultWindow.xaml
    /// </summary>
    public partial class PersonResultWindow : Window
    {
        public PersonResultWindow(Person person)
        {
            InitializeComponent();
            DataContext = new PersonViewModel(person);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
