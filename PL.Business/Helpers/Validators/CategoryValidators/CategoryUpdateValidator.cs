using FluentValidation;
using PL.Business.Concrete.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Helpers.Validators.CategoryValidators
{
    public class CategoryUpdateValidator:AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Please add id.");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please add name.");
        }
    }
}
