

using BotecoDoGallao.Enumerations;

namespace BotecoDoGallao.TransferObjects
{
    public class DefuzzyPropertiesTO
    {
        public float Strong { get; set; }
        public float Soft { get; set; }
        public float Weak { get; set; }
        public Taste Taste { get; set; }
        public bool IsCubaLivre { get; set; }
    }
}
