﻿using PowerWaiters.Models;
using PowerWaiters.Services;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class PurposesViewModel : BindableObject
    {
        private IEnumerable<PurposeDisplayModel> purposeModels;
        public IEnumerable<PurposeDisplayModel> PurposeModels
        {
            get => purposeModels;
            set
            {
                if (value == purposeModels)
                    return;
                purposeModels = value;
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

        public PurposesViewModel()
        {
            PurposeModels = PurposesService.GetPurposes().Select(p => p.ConvertToDisplayModel());
        }

        private void UpdatePurposesHeight() => PurposesHeight = PurposeModels.Count() * PurposeBlockHeight;
    }
}
