using System;
using BotecoDoGallao.Enumerations;

namespace BotecoDoGallao.Util
{
    public static class Conversions
    {
        public static string ToString(Taste taste)
        {
            switch (taste)
            {
                case Taste.Undefined:
                    return "";
                case Taste.Weak:
                    return "Fraco";
                case Taste.Soft:
                    return "Suave";
                case Taste.Strong:
                    return "Forte";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string ToPrice(Taste taste)
        {
            switch (taste)
            {
                case Taste.Undefined:
                    return "";
                case Taste.Weak:
                    return "R$ 15,00";
                case Taste.Soft:
                    return "R$ 20,00";
                case Taste.Strong:
                    return "R$ 25,00";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
