using System;
using BotecoDoGallao.Enumerations;
using BotecoDoGallao.TransferObjects;
using UnityEngine;

namespace BotecoDoGallao
{
    public class Defuzzy
    {

        private static float Soft(DrinkTO drink, FuzzyPropertiesTO fuzzyProperties)
        {
            if (drink.Soda == Soda.Coke)
                return Mathf.Max(
                    Mathf.Min(fuzzyProperties.StrongCoke, fuzzyProperties.WeakRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.SoftCoke, fuzzyProperties.SoftRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.WeakCoke, fuzzyProperties.StrongRum, fuzzyProperties.IceCubes));
            else
                return Mathf.Max(Mathf.Min(fuzzyProperties.StrongPepsi, fuzzyProperties.WeakRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.SoftPepsi, fuzzyProperties.SoftRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.WeakPepsi, fuzzyProperties.StrongRum, fuzzyProperties.IceCubes));
        }

        private static float Strong(DrinkTO drink, FuzzyPropertiesTO fuzzyProperties)
        {
            if (drink.Soda == Soda.Coke)
                return Mathf.Max(Mathf.Min(fuzzyProperties.StrongCoke, fuzzyProperties.SoftRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.StrongCoke, fuzzyProperties.StrongRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.SoftCoke, fuzzyProperties.StrongRum, fuzzyProperties.IceCubes));
            else
                return Mathf.Max(Mathf.Min(fuzzyProperties.StrongPepsi, fuzzyProperties.SoftRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.StrongPepsi, fuzzyProperties.StrongRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.SoftPepsi, fuzzyProperties.StrongRum, fuzzyProperties.IceCubes));
        }

        private static float Weak(DrinkTO drink, FuzzyPropertiesTO fuzzyProperties)
        {
            if (drink.Soda == Soda.Coke)
                return Mathf.Max(Mathf.Min(fuzzyProperties.WeakCoke, fuzzyProperties.WeakRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.WeakCoke, fuzzyProperties.SoftRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.SoftCoke, fuzzyProperties.WeakRum, fuzzyProperties.IceCubes));
            else
                return Mathf.Max(Mathf.Min(fuzzyProperties.WeakPepsi, fuzzyProperties.WeakRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.WeakPepsi, fuzzyProperties.SoftRum, fuzzyProperties.IceCubes),
                    Mathf.Min(fuzzyProperties.SoftPepsi, fuzzyProperties.WeakRum, fuzzyProperties.IceCubes));
        }

        private static Taste GetTaste(DefuzzyPropertiesTO defuzzyPropertiesTo)
        {
            if(Mathf.Max(defuzzyPropertiesTo.Strong, defuzzyPropertiesTo.Soft, defuzzyPropertiesTo.Weak) == 0f)
                return Taste.Undefined;
            if (Mathf.Max(defuzzyPropertiesTo.Strong, defuzzyPropertiesTo.Soft, defuzzyPropertiesTo.Weak) == defuzzyPropertiesTo.Strong)
                return Taste.Strong;
            if (Mathf.Max(defuzzyPropertiesTo.Strong, defuzzyPropertiesTo.Soft, defuzzyPropertiesTo.Weak) == defuzzyPropertiesTo.Soft)
                return Taste.Soft;
            if (Mathf.Max(defuzzyPropertiesTo.Strong, defuzzyPropertiesTo.Soft, defuzzyPropertiesTo.Weak) == defuzzyPropertiesTo.Weak)
                return Taste.Weak;
            throw new Exception("FATAL ERROR ON FLOAT COMPARE");
        }

        public static bool IsCubaLivre(DrinkTO drinkTo)
        {
            if (drinkTo.Soda == Soda.Coke)
                return 50f <= drinkTo.Coke && drinkTo.Coke <= 60f && 10f <= drinkTo.Rum &&  drinkTo.Rum <= 30f && drinkTo.IceCubes == 20f;
            else
                return 60f <= drinkTo.Pepsi && drinkTo.Pepsi <= 70f && 10f <= drinkTo.Rum && drinkTo.Rum <= 30f && drinkTo.IceCubes == 20f;

        }

        public static DefuzzyPropertiesTO Fill(DrinkTO drinkTo, FuzzyPropertiesTO fuzzyPropertiesTo, DefuzzyPropertiesTO defuzzyPropertiesTo)
        {
            defuzzyPropertiesTo.Soft = Soft(drinkTo, fuzzyPropertiesTo);
            defuzzyPropertiesTo.Strong = Strong(drinkTo, fuzzyPropertiesTo);
            defuzzyPropertiesTo.Weak = Weak(drinkTo, fuzzyPropertiesTo);
            defuzzyPropertiesTo.Taste = GetTaste(defuzzyPropertiesTo);
            defuzzyPropertiesTo.IsCubaLivre = IsCubaLivre(drinkTo);
            return defuzzyPropertiesTo;
        }
    }
}
