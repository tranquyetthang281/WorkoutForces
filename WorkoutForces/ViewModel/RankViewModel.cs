﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkoutForces.Model;

namespace WorkoutForces.ViewModel
{
    class RankViewModel : BaseViewModel
    {
        private List<User> _listRank;
        public RelayCommand<object> RankCommand { get; set; }
        public List<User> ListRank
        {
            get
            {         
                return _listRank;
            }

            set
            {
                _listRank = value;
                OnPropertyChanged("ListRank");
            }
        }

        public RankViewModel()
        {
            _listRank = new List<User>();
            RankCommand = new RelayCommand<object>(canExecuteRank, RankExecute);
           
        }

        public bool canExecuteRank(object x)
        {
            return true;
        }
        public void RankExecute(object p)
        {
            MessageBox.Show("Executed!");
            int count = 0;
                count = DataProvider.Ins.DB.Users.Count();
            if (count > 0)
            {
                MessageBox.Show("DB is exist");
            }
            else
            {
                MessageBox.Show("DB isn't exist");
            }
            //  ListRank = DataProvider.Ins.DB.Users.OrderByDescending(x => x.score).Take(3).ToList();               
        }
    }
}
