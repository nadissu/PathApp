namespace Entities.Enums
{
    public enum ShipmentStatus
    {
        KargoHazirlaniyor = 1,
        KargoYolda,
        KargoyaVerildi,
        KargoTeslimEdildi,
        KargoİptalEdildi,
        KargoTeslimEdilemedi,
        AdresteBulunamadı
    }

    public class CargoStatusEnumHelpers
    {
        public static string ToFiendlyName(int value)
        {
            switch (value)
            {
                case 1: return "Kargo Hazırlanıyor";
                case 2: return "Kargoya Yolda";
                case 3: return "Kargo Verildi";
                case 4: return "Kargo Teslim Edildi";
                case 5: return "Kargoya İptal Edildi";
                case 6: return "Kargo Teslim Edilemedi";
                case 7: return "Adreste Bulunamadı";
                default: return value.ToString();
            }
        }
    }
}
