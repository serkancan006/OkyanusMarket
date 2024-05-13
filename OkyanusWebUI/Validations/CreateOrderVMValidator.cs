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
            RuleFor(item => item.UserAdresID).NotNull().WithMessage("Lütfen Adres Seçiniz!")
                .GreaterThan(0).WithMessage("Geçersiz Adres Seçimi!");
            RuleFor(item => item.TelefonNo)
                .NotNull().WithMessage("Lütfen Telefon Numaranızı Giriniz!");
                //.Matches(@"^05[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}$")
                //.WithMessage("Geçersiz telefon numarası formatı (05xx-xxx-xx-xx) şeklinde yazınız");
            RuleFor(item => item.TeslimatYontemi).NotNull().WithMessage("Lütfen Teslimat Yöntemi Seçiniz!");
            RuleFor(item => item.TeslimatSaati).NotNull().WithMessage("Lütfen Teslimat Saati Seçiniz!");
            RuleFor(item => item.AlternatifUrun).NotNull().WithMessage("Lütfen Alternatif Ürün Seçiniz!");
            RuleFor(item => item.HasReadAndUnderstood).Must(x => x == true).WithMessage("Lütfen devam etmeden önce kullanım koşullarını ve şartlarını okuduğunuzu ve anladığınızı onaylayın!");
            RuleFor(item => item.TotalPrice).NotNull().WithMessage("Boş Fiyat verilemez!")
                .GreaterThanOrEqualTo(250).WithMessage("Minumum Sepet Tutarı 250 Tl olmalıdır")
                .LessThanOrEqualTo(6900).WithMessage("Tek seferde maximum verilebilen toplam tutar 6900 Tl'dir! daha fazla sipariş vermek için 2. kez sepet oluşturabilirsiniz!");

            RuleFor(item => item.OrderItems).NotNull().NotEmpty().WithMessage("Boş sipariş verilemez!");
            //RuleForEach(x => x.OrderItems).SetValidator(new CartItemValidator()).WithMessage("hayırdır!");
            RuleForEach(x => x.OrderItems).SetValidator(new CartItemValidator()).WithMessage("Sipariş ögeleri geçersiz!");


            //When(request => request.OrderItems != null , { 

            //} )
        }
    }
}
