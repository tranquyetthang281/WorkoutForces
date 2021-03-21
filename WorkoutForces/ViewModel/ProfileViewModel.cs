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
        private int _rankUser;
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
        public int RankUser
        {
            get
            {
                return _rankUser;
            }
            set
            {
                _rankUser = value;
                OnPropertyChanged("RankUser");
            }
        }
        public RelayCommand<object> profileCommand { get; set; }
        public ProfileViewModel()
        {
            profileCommand = new RelayCommand<object>(canExecuteProfile, ProfileExecute);
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
            //debug, apply a specific User to test
            User = DataProvider.Ins.DB.Users.Where(x => x.Id == 1).Single();

            MessageBox.Show("Debug: ProfileExecute");
            string challenge = User.IdChallengeJoin;
            var array = challenge.Split(',');
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                string temp = array[i];
                var ch = (DataProvider.Ins.DB.Challenges.Where(x => x.Id == temp).Single());
                ch = ch as Challenge;
                ListChallenge.Add(ch);
            }
            ListChallenge = ListChallenge.ToList(); // apply to ListView

            var sortedUsers = DataProvider.Ins.DB.Users.OrderByDescending(x => x.score).ToList();
            int cnt = sortedUsers.Count();

            for (int i = 0; i<cnt;i++)
            {
                if(sortedUsers[i].UserName == User.UserName)
                {
                    RankUser = i + 1;
                    break;
                }
            }
            MessageBox.Show("RankUser: " + RankUser.ToString());
        }
    }
}
