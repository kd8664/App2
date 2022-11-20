using System;
using System.Collections.Generic;
using System.Text;

namespace App2
{
    public class SomeValute
    {
        public string ID { get; set; }
        public string NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Previous { get; set; }
    }
    public class Valute
    {
        public SomeValute AUD { get; set; }
        public SomeValute AZN { get; set; }
        public SomeValute GBP { get; set; }
        public SomeValute AMD { get; set; }
        public SomeValute BYN { get; set; }
        public SomeValute BGN { get; set; }
        public SomeValute BRL { get; set; }
        public SomeValute HUF { get; set; }
        public SomeValute HKD { get; set; }
        public SomeValute DKK { get; set; }
        public SomeValute USD { get; set; }
        public SomeValute EUR { get; set; }
        public SomeValute INR { get; set; }
        public SomeValute KZT { get; set; }
        public SomeValute CAD { get; set; }
        public SomeValute KGS { get; set; }
        public SomeValute CNY { get; set; }
        public SomeValute MDL { get; set; }
        public SomeValute NOK { get; set; }
        public SomeValute PLN { get; set; }
        public SomeValute RON { get; set; }
        public SomeValute XDR { get; set; }
        public SomeValute SGD { get; set; }
        public SomeValute TJS { get; set; }
        public SomeValute TRY { get; set; }
        public SomeValute TMT { get; set; }
        public SomeValute UZS { get; set; }
        public SomeValute UAH { get; set; }
        public SomeValute CZK { get; set; }
        public SomeValute SEK { get; set; }
        public SomeValute CHF { get; set; }
        public SomeValute ZAR { get; set; }
        public SomeValute KRW { get; set; }
        public SomeValute JPY { get; set; }
        public IEnumerable<SomeValute> All
        {
            get
			{
                yield return AUD;
                yield return AZN;
                yield return GBP;
                yield return AMD;
                yield return BYN;
                yield return BGN;
                yield return BRL;
                yield return HUF;
                yield return HKD;
                yield return DKK;
                yield return USD;
                yield return EUR;
                yield return INR;
                yield return KZT;
                yield return CAD;
                yield return KGS;
                yield return CNY;
                yield return MDL;
                yield return NOK;
                yield return PLN;
                yield return RON;
                yield return XDR;
                yield return SGD;
                yield return TJS;
                yield return TRY;
                yield return TMT;
                yield return UZS;
                yield return UAH;
                yield return CZK;
                yield return SEK;
                yield return CHF;
                yield return ZAR;
                yield return KRW;
                yield return JPY;
            }
        }
    }

    public class Root
    {
        public DateTime Date { get; set; }
        public DateTime PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public DateTime Timestamp { get; set; }
        public Valute Valute { get; set; }
    }
}