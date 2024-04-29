using FluentValidation;
using OkyanusWebUI.Models.OrderVM;
using OkyanusWebUI.Service;
using static OkyanusWebUI.Models.OrderVM.CreateOrderVmApi;

namespace OkyanusWebUI.Validations
{
    public class CreateOrderVMValidator : AbstractValidator<CreateOrderVM>
    {
        public CreateOrderVMValidator()
        {
            RuleFor(item => item.UserAdresID).NotNull().WithMessage("Lütfen Adres Seçiniz!");
            RuleFor(item => item.UserAdresID).GreaterThan(0).WithMessage("Geçersiz Adres Seçimi!");
            RuleFor(item => item.TelefonNo).NotNull().WithMessage("Lütfen Telefon Numaranızı Giriniz!");
            RuleFor(item => item.TeslimatYontemi).NotNull().WithMessage("Lütfen Teslimat Yöntemi Seçiniz!");
            RuleFor(item => item.TeslimatSaati).NotNull().WithMessage("Lütfen Teslimat Saati Seçiniz!");
            RuleFor(item => item.AlternatifUrun).NotNull().WithMessage("Lütfen Alternatif Ürün Seçiniz!");
            RuleFor(item => item.OrderItems).NotNull().WithMessage("Boş sipariş verilemez!");
            RuleFor(item => item.TotalPrice).NotNull().WithMessage("Boş Fiyat verilemez!");
            RuleFor(item => item.TotalPrice).GreaterThan(250).WithMessage("Minumum Sepet Tutarı 250 Tl olmalıdır");

            //RuleForEach(x => x.OrderItems).SetValidator(new CartItemValidator()).WithMessage("hayırdır!");

        }


    }
}
