using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using DietApp.Models;
using DietApp.Services;

namespace DietApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string sexValue = string.Empty;
        public string SexValue
        {
            get { return sexValue; }
            set { SetProperty(ref sexValue, value); }
        }

        string planValue = string.Empty;
        public string PlanValue
        {
            get { return planValue; }
            set { SetProperty(ref planValue, value); }
        }

        string activityValue = string.Empty;
        public string ActivityValue
        {
            get { return activityValue; }
            set { SetProperty(ref activityValue, value); }
        }

        string ageValue = "0";
        public string AgeValue
        {
            get { return ageValue; }
            set { SetProperty(ref ageValue, value); }
        }

        string weightValue = "0";
        public string WeightValue
        {
            get { return weightValue; }
            set { SetProperty(ref weightValue, value); }
        }

        string heightValue = "0";
        public string HeightValue
        {
            get { return heightValue; }
            set { SetProperty(ref heightValue, value); }
        }

        string bmi = "0";
        public string BMI
        {
            get { return bmi; }
            set { SetProperty(ref bmi, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
