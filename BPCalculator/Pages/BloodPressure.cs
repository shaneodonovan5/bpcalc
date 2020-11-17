using System;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High,
        [Display(Name = "Invalid")] Invalid
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                if (((Diastolic >= DiastolicMin) && (Diastolic <= 60)) && ((Systolic >= SystolicMin) && (Systolic <= 90)))
                {
                    return BPCategory.Low;
                }
                if (((Diastolic >= 60) && (Diastolic <= 80)) && ((Systolic >= 90) && (Systolic <= 120)))
                {
                    return BPCategory.Ideal;
                }
                if (((Diastolic >= 80) && (Diastolic <= 90)) && ((Systolic >= 120) && (Systolic <= 140)))
                {
                    return BPCategory.PreHigh;
                }
                if (((Diastolic >= 90) && (Diastolic <= DiastolicMax)) && ((Systolic >= 140) && (Systolic <= SystolicMax)))
                {
                    return BPCategory.Ideal;
                }

                else return BPCategory.Invalid;
            }
        }
    }
} 
