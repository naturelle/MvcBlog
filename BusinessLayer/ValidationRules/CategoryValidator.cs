using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CatName).NotEmpty().WithMessage("Blog title cannot be null");
            RuleFor(x => x.CatDescription).NotEmpty().WithMessage("Blog content cannot be null");
 
            RuleFor(x => x.CatName).MaximumLength(150).WithMessage("Blog titl should be at most 150");
            RuleFor(x => x.CatName).MinimumLength(2).WithMessage("Blog titl should be at least 150");
        }
    }
}
