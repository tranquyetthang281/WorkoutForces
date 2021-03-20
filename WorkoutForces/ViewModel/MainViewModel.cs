using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutForces.Model;

namespace WorkoutForces.ViewModel
{
    class MainViewModel
    {
        public RankViewModel rankViewModel;
        public ProfileViewModel profileViewModel;
        public User user;
        public MainViewModel()
        {
            rankViewModel = new RankViewModel();
            profileViewModel = new ProfileViewModel();
        }
        public MainViewModel(User theUser)
        {
            user = theUser;
            rankViewModel = new RankViewModel();
            profileViewModel = new ProfileViewModel(theUser);
        }
    }
}
