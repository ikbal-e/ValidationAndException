using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.FluentValidation
{
    public class IzinTalepDtoValidator : AbstractValidator<IzinTalepDto>
    {
        public IzinTalepDtoValidator()
        {
            RuleFor(x => x.IzinBaslangic).LessThan(x => x.IzinBitis)
                .WithMessage("İzin başlangıcı, bitişten ileri bir tarihte olamaz");

            RuleFor(x => new { x.IzinBaslangic, x.IzinBitis }).Must(x => EnFazlaBirYillikMi(x.IzinBaslangic, x.IzinBitis))
                .WithMessage("En fazla bir yıllık izin planlanabilir");

            RuleFor(x => x.Aciklama).NotEmpty()
                .WithMessage("Açıklama girmek zorundasınız");
        }

        private bool EnFazlaBirYillikMi(DateTime baslangic, DateTime bitis)
        {
            return (bitis.Subtract(baslangic).TotalDays < 365) ? true : false;
        }
    }
}