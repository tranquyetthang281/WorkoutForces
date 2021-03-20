using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutForces.Model;

namespace WorkoutForces.ViewModel
{
    class RankViewModel
    {
        public ObservableCollection<User> listRank;
        public RelayCommand<object> RankCommand;

        public RankViewModel()
        {
            listRank = new ObservableCollection<User>();
            RankCommand = new RelayCommand<object>(canExecuteRank, RankExecute);
        }

        public bool canExecuteRank(object x)
        {
            return true;
        }
        public void RankExecute(object p)
        {
            listRank = DataProvider.Ins.DB.Users.OrderByDescending(x => x.score).Take(10).ToList();               
        }

    }
}
