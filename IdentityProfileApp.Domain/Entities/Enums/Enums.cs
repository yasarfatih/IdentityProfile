using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Enums
{
    public enum ProfileParts
    {
        [Display(Name = "Dışadönük")]
        E = 1,
        [Display(Name = "İçedönük")]
        I = 2,
        [Display(Name = "Duyusal")]
        T = 3,
        [Display(Name = "Sezgisel")]
        F = 4,
        [Display(Name = "Hissel")]
        S = 5,
        [Display(Name = "Düşünsel")]
        N = 6,
        [Display(Name = "Algılayan")]
        J = 7,
        [Display(Name = "Hükümsel")]
        P = 8
    }
    public enum TimeUnit
    {
        [Display(Name = "Dakika")]
        Minute = 1,
        [Display(Name = "Saat")]
        Hour = 2,
        [Display(Name = "Gün")]
        Day = 3,
        [Display(Name = "Hafta")]
        Week = 4,
        [Display(Name = "Ay")]
        Month = 5,
        [Display(Name = "Yıl")]
        Year = 6
    }

    public enum PaymentType
    {
        [Display(Name = "Haftalık")]
        Weekly = 1,
        [Display(Name = "Aylık")]
        Monthly = 2,
        [Display(Name = "Yıllık")]
        Yearly = 3
    }
    public enum CurrencyType
    {
        [Display(Name = "Türk Lirası")]
        TL = 1,
        [Display(Name = "Amerikan Doları")]
        Usd = 2,
        [Display(Name = "Euro")]
        Euro = 3
    }
    public enum DiscountType
    {
        [Display(Name = "Yüzde")]
        Percent = 1,
        [Display(Name = "Miktar")]
        Quantity = 2
    }

    public enum Gender
    {
        [Display(Name = "Erkek")]
        Male = 1,
        [Display(Name = "Kadın")]
        Female = 2
    }

    public enum Characteristics
    {
        [Display(Name = "Tanıtım", Order = 1)]
        Inroduction = 1,
        [Display(Name = "Güçlü Yanlar", Order = 5)]
        Strengts = 2,
        [Display(Name = "Zayıf Yanlar", Order = 6)]
        Weaknesses = 3,
        [Display(Name = "Romatik İlişki", Order = 3)]
        RomanticRelationships = 4,
        [Display(Name = "Arkadaşlık", Order = 2)]
        FriendShips = 5,
        [Display(Name = "Ebebeynlik", Order = 4)]
        Parenthood = 6,
        [Display(Name = "Kariyer", Order = 7)]
        CareerPahts = 7,
        [Display(Name = "İş Yeri", Order = 8)]
        WorkplaceHabits = 8
    }

    public enum Answers
    {
        Accept = 1,
        RarelyAccept = 2,
        NotSure = 3,
        RarelyReject = 4,
        Reject = 5
    }

    public enum MediaType
    {
        Image=1,
        Video=2
    }
}
