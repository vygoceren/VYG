namespace VYG.Core.ExtensionMethods
{
    public static class NumberTotTextExtesions
    {
        private static readonly string[] Units = { "", "Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz", "Dokuz" };
        private static readonly string[] Tens = { "", "On", "Yirmi", "Otuz", "Kırk", "Elli", "Altmış", "Yetmiş", "Seksen", "Doksan" };
        private static readonly string[] Thousands = { "", "Bin", "Milyon", "Milyar", "Trilyon" };

        public static string ConvertToTurkishLira(decimal number)
        {
            if (number == 0)
                return "Sıfır TL";

            string liraPart = Convert((int)number);
            int kurusPart = (int)((number - (int)number) * 100);

            if (kurusPart > 0)
            {
                liraPart += " TL " + ConvertThreeDigits(kurusPart) + " Kr";
            }
            else
            {
                liraPart += " TL";
            }

            return liraPart.Trim();
        }

        public static string Convert(decimal number)
        {
            if (number == 0)
                return "Sıfır";

            if (number < 0)
                return "Eksi" + Convert(-number);

            string words = "";
            int thousandGroup = 0;

            while (number > 0)
            {
                int groupValue = (int)(number % 1000);
                if (groupValue != 0)
                {
                    string groupText = ConvertThreeDigits(groupValue);
                    if (thousandGroup > 0)
                    {
                        if (groupValue == 1 && thousandGroup == 1)
                        {
                            groupText = "Bin";
                        }
                        else
                        {
                            groupText += Thousands[thousandGroup];
                        }
                    }
                    words = groupText + words;
                }
                number /= 1000;
                thousandGroup++;
            }

            return words.Trim();
        }

        private static string ConvertThreeDigits(int number)
        {
            string result = "";

            int hundreds = number / 100;
            int remainder = number % 100;

            if (hundreds > 0)
            {
                if (hundreds == 1)
                    result += "Yüz";
                else
                    result += Units[hundreds] + "Yüz";
            }

            if (remainder > 0)
            {
                if (remainder < 10)
                {
                    result += Units[remainder];
                }
                else if (remainder < 100)
                {
                    result += Tens[remainder / 10];
                    if (remainder % 10 > 0)
                    {
                        result += Units[remainder % 10];
                    }
                }
            }

            return result.Trim();
        }
    }
}
