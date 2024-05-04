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
            RuleFor(item => item.TelefonNo).NotNull().WithMessage("Lütfen Telefon Numaranızı Giriniz!")
                .Matches(@"^\+[1-9]{1}[0-9]{3,14}$").WithMessage("Geçersiz telefon numarası formatı");
            RuleFor(item => item.TeslimatYontemi).NotNull().WithMessage("Lütfen Teslimat Yöntemi Seçiniz!");
            RuleFor(item => item.TeslimatSaati).NotNull().WithMessage("Lütfen Teslimat Saati Seçiniz!");
            RuleFor(item => item.AlternatifUrun).NotNull().WithMessage("Lütfen Alternatif Ürün Seçiniz!");
            RuleFor(item => item.HasReadAndUnderstood).Must(x => x == true).WithMessage("Lütfen devam etmeden önce kullanım koşullarını ve gizlilik politikasını okuduğunuzu ve anladığınızı onaylayın!");
            RuleFor(item => item.TotalPrice).NotNull().WithMessage("Boş Fiyat verilemez!")
                .GreaterThan(250).WithMessage("Minumum Sepet Tutarı 250 Tl olmalıdır");

            RuleFor(item => item.OrderItems).NotNull().NotEmpty().WithMessage("Boş sipariş verilemez!");
            RuleForEach(x => x.OrderItems).SetValidator(new CartItemValidator()).WithMessage("hayırdır!");
            //When(request => request.OrderItems != null , { 
            
            
            //} )

        }


    }
}
