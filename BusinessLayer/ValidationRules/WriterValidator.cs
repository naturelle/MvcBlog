using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator :AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Writer name cannot be null");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Writer surname cannot be null");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Writer mail cannot be null");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Writer password cannot be null");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Writer name should be at least two");
        }
    }
}
