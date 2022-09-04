using FluentValidation;
using PL.Business.Concrete.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Helpers.Validators.ProductValidators
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Please add id.");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please add name.");
            RuleFor(x => x.Price).NotEmpty().NotNull().WithMessage("Please add price.");
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("Please add categoryid.");
        }
    }
}
