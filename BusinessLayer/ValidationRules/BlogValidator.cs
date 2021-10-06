using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog title cannot be null");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog content cannot be null");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog image cannot be null");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog titl should be at most 150");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog titl should be at least 150");
        }
    }
}
