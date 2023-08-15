﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SliderProofOfConcept
{
    public class SliderViewModel : ViewModelBase
    {
        #region Variables

        public Slide LowerBoundSlider;
        public Slide UpperBoundSlider;
        private int _minimum;
        private int _maximum;
        private string _upperTooltipValue;
        private string _lowerTooltipValue;
        private string _lowerSliderName;
        private string _upperSliderName;

        #endregion

        #region Constructors

        public SliderViewModel()
        {
            LowerBoundSlider = new Slide(0);
            UpperBoundSlider = new Slide(10);
            _lowerTooltipValue = "°C";
            _upperTooltipValue = "°C";
            Minimum = -50;
            Maximum = 105;
            LowerSliderName = "Limit Temperature";
            UpperSliderName = "Over Temperature";
        }

        public SliderViewModel(double lowerSliderValue, double upperSliderValue, int minimum, int maximum, string temperatureUnit, string lowerSliderName, string upperSliderName)
        {
            LowerBoundSlider = new Slide(lowerSliderValue);
            UpperBoundSlider = new Slide(upperSliderValue);
            Minimum = minimum;
            Maximum = maximum;
            _lowerTooltipValue = temperatureUnit;
            _upperTooltipValue = temperatureUnit;
            LowerSliderName = lowerSliderName;
            UpperSliderName = upperSliderName;
        }

        #endregion

        #region Properties

        public double UpperBoundSliderValue
        {
            get
            {
                return UpperBoundSlider.Val;
            }
            set
            {
                UpperBoundSlider.Val = value < LowerBoundSlider.Val ? LowerBoundSlider.Val : value;
                RaisePropertyChanged(nameof(UpperBoundSliderValue));
                RaisePropertyChanged(nameof(UpperBoundSliderUpdateValue));
                RaisePropertyChanged(nameof(UpperTooltipValue));
            }
        }

        public double LowerBoundSliderValue
        {
            get
            {
                return LowerBoundSlider.Val;
            }
            set
            {
                LowerBoundSlider.Val = value > UpperBoundSlider.Val ? UpperBoundSlider.Val : value;
                RaisePropertyChanged(nameof(LowerBoundSliderValue));
                RaisePropertyChanged(nameof(LowerBoundSliderUpdateValue));
                RaisePropertyChanged(nameof(LowerTooltipValue));
            }
        }

        public int Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                _minimum = value;
                RaisePropertyChanged(nameof(Minimum));
            }
        }

        public int Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
                RaisePropertyChanged(nameof(Maximum));
            }
        }

        public string UpperTooltipValue
        {
            get
            {
                return string.Format("{0}{1}", UpperBoundSlider.Val, _upperTooltipValue);
            }
            set
            {
                _upperTooltipValue = value;
                RaisePropertyChanged(nameof(UpperBoundSliderValue));
                RaisePropertyChanged(nameof(UpperBoundSliderUpdateValue));
                RaisePropertyChanged(nameof(UpperTooltipValue));
            }
        }

        public string LowerTooltipValue
        {
            get
            {
                return string.Format("{0}{1}", LowerBoundSlider.Val, _lowerTooltipValue);
            }
            set
            {
                _lowerTooltipValue = value;
                RaisePropertyChanged(nameof(LowerBoundSliderValue));
                RaisePropertyChanged(nameof(LowerBoundSliderUpdateValue));
                RaisePropertyChanged(nameof(LowerTooltipValue));
            }
        }

        public double UpperBoundSliderUpdateValue
        {
            get
            {
                return UpperBoundSlider.Val;
            }
            set
            {
                if (value <= Maximum && value >= Minimum)
                {
                    UpperBoundSlider.Val = value < LowerBoundSliderValue ? LowerBoundSliderValue : value;
                }
                else
                {
                    UpperBoundSlider.Val = value > Maximum ? Maximum : Minimum;
                }
                RaisePropertyChanged(nameof(UpperBoundSliderValue));
                RaisePropertyChanged(nameof(UpperBoundSliderUpdateValue));
                RaisePropertyChanged(nameof(UpperTooltipValue));
            }
        }

        public double LowerBoundSliderUpdateValue
        {
            get
            {
                return LowerBoundSlider.Val;
            }
            set
            {
                if (value <= Maximum && value >= Minimum)
                {
                    LowerBoundSlider.Val = value > UpperBoundSliderValue ? UpperBoundSliderValue : value;
                }
                else
                {
                    UpperBoundSlider.Val = value > Maximum ? Maximum : Minimum;
                }
                RaisePropertyChanged(nameof(LowerBoundSliderValue));
                RaisePropertyChanged(nameof(LowerBoundSliderUpdateValue));
                RaisePropertyChanged(nameof(LowerTooltipValue));
            }
        }

        public string LowerSliderName
        {
            get
            {
                return _lowerSliderName;
            }
            set
            {
                _lowerSliderName = value;
                RaisePropertyChanged(nameof(LowerSliderName));
            }
        }

        public string UpperSliderName
        {
            get
            {
                return _upperSliderName;
            }
            set
            {
                _upperSliderName = value;
                RaisePropertyChanged(nameof(UpperSliderName));
            }
        }

        #endregion
    }
}