using Microsoft.AspNetCore.Mvc;
using OkyanusWebUI.Areas.Admin.Models.AdminOrderVM;
using OkyanusWebUI.Service;
using Newtonsoft.Json;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace OkyanusWebUI.Controllers
{
    [Area("Admin")]
    public class PdfController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        public PdfController(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IActionResult> GenerateOrderPdf(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order" }, id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultAdminOrderVM>(jsonData);
            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, memoryStream);

            Font fontNormal = FontFactory.GetFont("Arial", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 12, Font.NORMAL);
            Font fontTitle = FontFactory.GetFont("Arial", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 18, Font.BOLD);


            document.Open();

            // Başlık
            Paragraph title = new Paragraph("Siparis Detaylari".TurkceyiIngilizceyeCevir(), fontTitle);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Boşluk ekle
            document.Add(new Paragraph(" "));

            // Sipariş bilgileri
            PdfPTable infoTable = new PdfPTable(2);
            infoTable.WidthPercentage = 100;
            infoTable.SpacingAfter = 20;
            infoTable.AddCell(new PdfPCell(new Phrase($"Sipariş Oluşturulma Tarihi: {values?.createdDate.ToString("dd-MMM-yyyy HH:mm")}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase($"Toplam Fiyat: {values?.totalPrice}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase($"Iletisim Bilgileri: ".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase($"Adres Bilgileri: ".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase($"Adı Soyadı: {values?.orderFirstName} {values?.orderSurname}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase($"Apartman No: {values?.orderApartman}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase($"Email: {values?.orderMail}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase($"Daire No: {values?.orderDaire}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase($"Kullanıcı Telefon: {values?.orderUserPhone}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase($"Kat: {values?.orderKat}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase()));
            infoTable.AddCell(new PdfPCell(new Phrase($"Şehir: {values?.orderSehir}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase()));
            infoTable.AddCell(new PdfPCell(new Phrase($"İlçe: {values?.orderIlce}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable.AddCell(new PdfPCell(new Phrase()));
            infoTable.AddCell(new PdfPCell(new Phrase($"Tam Adres: {values?.orderAdress}".TurkceyiIngilizceyeCevir(), fontNormal)));
            // Diğer bilgileri buraya ekleyin
            document.Add(infoTable);

            // Boşluk ekle
            document.Add(new Paragraph(" "));



            PdfPTable infoTable2 = new PdfPTable(1);
            infoTable2.WidthPercentage = 100;
            infoTable2.SpacingAfter = 10;
            infoTable2.AddCell(new PdfPCell(new Phrase($"Açıklama: ".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable2.AddCell(new PdfPCell(new Phrase($"{values?.description}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable2.AddCell(new PdfPCell(new Phrase($"Siparis Bilgileri".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable2.AddCell(new PdfPCell(new Phrase($"Altarnatif Urun: {values?.alternatifUrun}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable2.AddCell(new PdfPCell(new Phrase($"Teslimat Zamanı: {values?.teslimatSaati}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable2.AddCell(new PdfPCell(new Phrase($"Teslimat Yontemi: {values?.teslimatYontemi}".TurkceyiIngilizceyeCevir(), fontNormal)));
            infoTable2.AddCell(new PdfPCell(new Phrase($"Aranacak Telefon: {values?.orderPhone}".TurkceyiIngilizceyeCevir(), fontNormal)));
            document.Add(infoTable2);

            // Boşluk ekle
            document.Add(new Paragraph(" "));

            // Sipariş detayları
            PdfPTable orderDetailsTable = new PdfPTable(6);
            orderDetailsTable.WidthPercentage = 100;
            orderDetailsTable.SpacingAfter = 10;
            // Başlık hücreleri
            orderDetailsTable.AddCell(new PdfPCell(new Phrase("#".TurkceyiIngilizceyeCevir(), fontNormal)));
            //Resim Sütunu
            //orderDetailsTable.AddCell(new PdfPCell(new Phrase("Resim", fontNormal)));
            orderDetailsTable.AddCell(new PdfPCell(new Phrase("Ürün".TurkceyiIngilizceyeCevir(), fontNormal)));
            orderDetailsTable.AddCell(new PdfPCell(new Phrase("Marka".TurkceyiIngilizceyeCevir(), fontNormal)));
            orderDetailsTable.AddCell(new PdfPCell(new Phrase("Fiyatı".TurkceyiIngilizceyeCevir(), fontNormal)));
            orderDetailsTable.AddCell(new PdfPCell(new Phrase("Adet".TurkceyiIngilizceyeCevir(), fontNormal)));
            orderDetailsTable.AddCell(new PdfPCell(new Phrase("Toplam".TurkceyiIngilizceyeCevir(), fontNormal)));

            // Sipariş detayları döngüsü
            int count = 0;
            foreach (var item in values?.orderDetails)
            {
                count++;
                orderDetailsTable.AddCell(new PdfPCell(new Phrase(count.ToString(), fontNormal)));
                // Resim ekleme işlemi
                // Ürün adı
                orderDetailsTable.AddCell(new PdfPCell(new Phrase(item.product.productName.TurkceyiIngilizceyeCevir(), fontNormal)));
                // Marka
                orderDetailsTable.AddCell(new PdfPCell(new Phrase(item.product.marka.TurkceyiIngilizceyeCevir(), fontNormal)));
                // Fiyat
                orderDetailsTable.AddCell(new PdfPCell(new Phrase(item.unitPrice.ToString().TurkceyiIngilizceyeCevir(), fontNormal)));
                // Adet
                orderDetailsTable.AddCell(new PdfPCell(new Phrase(item.count.ToString().TurkceyiIngilizceyeCevir(), fontNormal)));
                // Toplam
                orderDetailsTable.AddCell(new PdfPCell(new Phrase(item.totalPrice.ToString().TurkceyiIngilizceyeCevir(), fontNormal)));
            }

            document.Add(orderDetailsTable);

            document.Close();

            return File(memoryStream.ToArray(), "application/pdf", "SiparisDetaylari.pdf");
        }


      


    }

    public static class StringExtensions
    {
        public static string TurkceyiIngilizceyeCevir(this string metin)
        {
            string[] turkceKarakterler = { "ğ", "Ğ", "ü", "Ü", "ş", "Ş", "ı", "İ", "ö", "Ö", "ç", "Ç" };
            string[] ingilizceKarakterler = { "g", "G", "u", "U", "s", "S", "i", "I", "o", "O", "c", "C" };

            for (int i = 0; i < turkceKarakterler.Length; i++)
            {
                metin = metin.Replace(turkceKarakterler[i], ingilizceKarakterler[i]);
            }

            return metin;
        }
    }

}
