using FluentValidation;
using OkyanusWebUI.Models.ProductVM;

namespace OkyanusWebUI.Validations.Admin.Product
{
    public class UpdateProductVMValidator : AbstractValidator<UpdateProductVM>
    {
        public UpdateProductVMValidator()
        {
            RuleFor(x => x.ProductName).NotNull().WithMessage("Ürün Adı Boş geçilemez");
            RuleFor(x => x.Price).NotNull().WithMessage("Ürün Fiyatı Boş geçilemez")
                .GreaterThan(0).WithMessage("Ürün fiyatı 0 dan büyük olmalıdır");
            RuleFor(x => x.DiscountedPrice).LessThan(x => x.Price).WithMessage("İndirim fiyatı ana fiyattan az olmalıdır.");
            //RuleFor(x => x.DiscountedPrice).NotNull().WithMessage("Ürün Fiyatı Boş geçilemez"); 
            //RuleFor(x => x.ImageUrl).NotNull().WithMessage("Ürün Fiyatı Boş geçilemez"); 
            RuleFor(x => x.Description).NotNull().WithMessage("Ürün Açıklaması Boş geçilemez");
            RuleFor(x => x.ProductTypeID).NotNull().WithMessage("Ürün Tipi Boş geçilemez");
            RuleFor(x => x.Stock).NotNull().WithMessage("Ürün Stok Boş geçilemez");
            //RuleFor(x => x.ANAGRUP).NotNull().WithMessage("Ürün Stok Boş geçilemez"); 
            //RuleFor(x => x.ALTGRUP1).NotNull().WithMessage("Ürün Stok Boş geçilemez"); 
            //RuleFor(x => x.ALTGRUP2).NotNull().WithMessage("Ürün Stok Boş geçilemez"); 
            //RuleFor(x => x.ALTGRUP3).NotNull().WithMessage("Ürün Stok Boş geçilemez"); 
            //RuleFor(x => x.MarkaID).NotNull().WithMessage("Ürün Markası Boş geçilemez");
            RuleFor(x => x.AnaBarcode).NotNull().WithMessage("Ürün Ana Barkodu Boş geçilemez");
        }
    }
}
