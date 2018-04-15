
using BotecoDoGallao.Enumerations;
using BotecoDoGallao.TransferObjects;
using UnityEngine;

namespace BotecoDoGallao
{
    public static class Fuzzy
    {
        private static float StrongCoke(float x)
        {
            if (50f <= x && x <= 52f)
                return 1f;
            if (52f <= x && x <= 54f)
                return (54f - x) / (54f - 52f);
            return 0f;
        }

        private static float SoftCoke(float x)
        {
            if (52f <= x && x <= 54f)
            {
                return (x - 52f) / (54f - 52f);
            }
            if (54f <= x && x <= 56f)
            {
                return 1f;
            }
            if (56f < x && x <= 58f)
            {
                return (58f - x) / (58f - 56f);
            }
            return 0f;
        }

        private static float WeakCoke(float x)
        {
            if (56f <= x && x <= 58f)
                return (x - 56f) / (58f - 56f);
            if (58f <= x && x <= 60f)
                return 1f;
            return 0f;
        }

        private static float StrongPepsi(float x)
        {
            if (60f <= x && x <= 62f)
                return 1f;
            if (62f <= x && x <= 64f)
                return (64f - x) / (64f - 62f);
            return 0f;
        }

        private static float SoftPepsi(float x)
        {
            if (62f <= x && x <= 64f)
                return (x - 62f) / (64f - 62f);
            if (64f <= x && x <= 66f)
                return 1f;
            if (66f <= x && x <= 68f)
                return (68f - x) / (68f - 66f);
            return 0f;
        }

        private static float WeakPepsi(float x)
        {
            if (66f <= x && x <= 68f)
                return (x - 66f) / (68f - 66f);
            if (68f <= x && x <= 70f)
                return 1f;
            return 0f;
        }

        private static float StrongRum(float x)
        {
            if (23f <= x && x <= 28f)
                return (x - 23f) / (28f - 23f);
            if (28f <= x && x <= 30f)
                return 1f;
            return 0f;
        }

        private static float SoftRum(float x)
        {
            if (15f <= x && x <= 20f)
                return (x - 15f) / (20f - 15f);
            if (20f <= x && x <= 25f)
                return 1f;
            if (25f <= x && x <= 27f)
                return (27f - x) / (27f - 25f);
            return 0f;
        }

        private static float WeakRum(float x)
        {
            if (10f <= x && x <= 15f)
                return 1f;
            if (15f <= x && x <= 20f)
                return (20f - x) / (20f - 15f);
            return 0f;
        }

        private static float IceCubes(float x)
        {
            return Mathf.CeilToInt(x) == 20 ? 1f : 0f;
        }

        public static FuzzyPropertiesTO Fill(DrinkTO drinkTo, FuzzyPropertiesTO fuzzyProperties)
        {
            if (drinkTo.Soda == Soda.Coke)
            {
                fuzzyProperties.StrongCoke = StrongCoke(drinkTo.Coke);
                fuzzyProperties.SoftCoke = SoftCoke(drinkTo.Coke);
                fuzzyProperties.WeakCoke = WeakCoke(drinkTo.Coke);
                fuzzyProperties.StrongPepsi = 0f;
                fuzzyProperties.SoftPepsi = 0f;
                fuzzyProperties.WeakPepsi = 0f;
            }
            else
            {
                fuzzyProperties.StrongPepsi = StrongPepsi(drinkTo.Pepsi);
                fuzzyProperties.SoftPepsi = SoftPepsi(drinkTo.Pepsi);
                fuzzyProperties.WeakPepsi = WeakPepsi(drinkTo.Pepsi);
                fuzzyProperties.StrongCoke = 0f;
                fuzzyProperties.SoftCoke = 0f;
                fuzzyProperties.WeakCoke = 0f;
            }
            fuzzyProperties.StrongRum = StrongRum(drinkTo.Rum);
            fuzzyProperties.SoftRum = SoftRum(drinkTo.Rum);
            fuzzyProperties.WeakRum = WeakRum(drinkTo.Rum);
            fuzzyProperties.IceCubes = IceCubes(drinkTo.IceCubes);
            return fuzzyProperties;
        }

        public static void PrintOnConsole(DrinkTO drinktTo, FuzzyPropertiesTO fuzzyProperties)
        {

            if (drinktTo.Soda == Soda.Coke)
            {
                Debug.Log("StrongCoke " + fuzzyProperties.StrongCoke);
                Debug.Log("SoftCoke " + fuzzyProperties.SoftCoke);
                Debug.Log(string.Format("WeakCoke {0}", fuzzyProperties.WeakCoke));
            }
            else
            {
                Debug.Log(string.Format("StrongPepsi {0}", fuzzyProperties.StrongPepsi));
                Debug.Log(string.Format("SoftPepsi {0}", fuzzyProperties.SoftPepsi));
                Debug.Log(string.Format("WeakPepsi {0}", fuzzyProperties.WeakPepsi));
            }
            Debug.Log("StrongRum " + fuzzyProperties.StrongRum);
            Debug.Log("SoftRum " + fuzzyProperties.SoftRum);
            Debug.Log(string.Format("WeakRum {0}", fuzzyProperties.WeakRum));
            Debug.Log("IceCubes : " + fuzzyProperties.IceCubes);
        }

    }
}



