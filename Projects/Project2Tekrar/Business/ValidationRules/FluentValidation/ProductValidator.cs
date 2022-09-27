using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori seçilmedi");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Fiyat girilmedi");
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("Birim ürün miktarı girilmedi");
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0).NotEmpty().WithMessage("Stok miktarı girilmedi");

            RuleFor(p => p.UnitPrice).GreaterThan(0);
           
            RuleFor(p => p.ProductName).Must(startWithA).WithMessage("Ürün \"A\" ile başlamalı.");
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);
        }

        private bool startWithA(string arg)
        {
           return arg.StartsWith("A");
        }
    }
}
