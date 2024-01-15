using System.Windows;
using Vote.Model;

namespace Vode.Desktop.DialogWindow
{
    /// <summary>
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        private readonly Person _person;

        public AddPerson(Person person)
        {
            InitializeComponent();
            _person = person;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            _person.FirstName = firstNameTb.Text;
            _person.LastName = lastNameTb.Text;
            this.DialogResult = true; 
            this.Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
