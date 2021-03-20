using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkoutForces.Model;

namespace WorkoutForces.ViewModel
{
    class ProfileViewModel : BaseViewModel
    {
        private List<Challenge> _listChallenge;
        private User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
        public List<Challenge> ListChallenge
        {
            get
            {
                return _listChallenge;
            }
            set
            {
                _listChallenge = value;
                OnPropertyChanged("ListChallenge");
            }
        }
        public RelayCommand<object> profileCommand { get; set; }
        public ProfileViewModel()
        {
            profileCommand = new RelayCommand<object>(canExecuteProfile, ProfileExecute);
            //User = new User();
            ListChallenge = new List<Challenge>();
        }
        public ProfileViewModel(User theUser)
        {
            profileCommand = new RelayCommand<object>(canExecuteProfile, ProfileExecute);
            User = theUser;
            ListChallenge = new List<Challenge>();
        }
        private bool canExecuteProfile(object x)
        {
            return true;
        }
        private void ProfileExecute(object parameter)
        {
            MessageBox.Show("ProfileExecute");
            {
                string challenge = User.IdChallengeJoin;
                var array = challenge.Split(',');
                //var arrayId = Convert.ToInt32(array);
                //string[] array = { "1", "2", "3", "4" };
                int size = array.Length;
                for (int i = 0; i < size; i++)
                {
                    string temp = array[i];
                    var ch = (DataProvider.Ins.DB.Challenges.Where(x => x.Id == temp).Single());
                    ch = ch as Challenge;
                    MessageBox.Show(ch.Content);
                    ListChallenge.Add(ch);
                    //MessageBox.Show("LC " + ListChallenge[i].Content);
                }
                ListChallenge = ListChallenge.ToList();
                //ListChallenge = DataProvider.Ins.DB.Challenges.ToList();
            }


        }
    }
}
