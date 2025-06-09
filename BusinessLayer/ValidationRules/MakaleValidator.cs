using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MakaleValidator :AbstractValidator<Makale>
    {
        public MakaleValidator()
        {
            RuleFor(x => x.MakaleTitle).NotEmpty().WithMessage("Makale başlık alanı boş geçilemez");
            RuleFor(x => x.MakaleTitle).MinimumLength(5).WithMessage("En az 5 karakter girmelisin");
            RuleFor(x => x.MakaleContent).NotEmpty().WithMessage("Makale içerik alanı boş geçilemez");
            RuleFor(x => x.MakaleContent).MinimumLength(50).WithMessage("En az 50 karakter girmelisin");
            RuleFor(x => x.MakaleCreateDate).NotEmpty().WithMessage("Makale tarih alanı boş geçilemez");
           
        }
    }
}
