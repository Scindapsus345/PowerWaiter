using System;
using PowerWaiters.Models;
using PowerWaiters.Services;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class PurposesViewModel : BindableObject
    {
        private IEnumerable<PurposeModel> purposeModels;
        public IEnumerable<PurposeModel> PurposeModels
        {
            get => purposeModels;
            set
            {
                if (value == purposeModels)
                    return;
                purposeModels = value;
                PurposeDisplayModels = value.Select(pm => pm.ConvertToDisplayModel());
                OnPropertyChanged();
            }
        }

        private IEnumerable<PurposeDisplayModel> purposeDisplayModels;
        public IEnumerable<PurposeDisplayModel> PurposeDisplayModels
        {
            get => purposeDisplayModels;
            set
            {
                if (value == purposeDisplayModels)
                    return;
                purposeDisplayModels = value;
                UpdatePurposesHeight();
                OnPropertyChanged();
            }
        }

        private int purposesHeight;
        public int PurposesHeight
        {
            get => purposesHeight;
            set
            {
                if (value == purposesHeight)
                    return;
                purposesHeight = value;
                OnPropertyChanged();
            }
        }

        private int purposeBlockHeight = 150;
        public int PurposeBlockHeight
        {
            get => purposeBlockHeight;
            set
            {
                if (value == purposeBlockHeight)
                    return;
                purposeBlockHeight = value;
                OnPropertyChanged();
            }
        }

        private string timerString;
        public string TimerString
        {
            get => timerString;
            set
            {
                if (value == timerString)
                    return;
                timerString = value;
                OnPropertyChanged();
            }
        }

        private DateTime endOfDay;


        public PurposesViewModel()
        {
            DataRefresher.MissionsDataChanged += () => PurposeModels = DataRefresher.PurposeModels;
            endOfDay = DateTime.Today.AddDays(1);
            StartTimer();
        }

        private void StartTimer()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                var time = endOfDay - DateTime.Now;
                TimerString = $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}";
                return true;
            });
        }

        private void UpdatePurposesHeight() => PurposesHeight = PurposeModels.Count() * PurposeBlockHeight;
    }
}
