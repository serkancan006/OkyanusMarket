﻿using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace OkyanusWebUI.Service
{
    public class CustomHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly TokenService _tokenService;

        public CustomHttpClient(HttpClient httpClient, IConfiguration configuration, TokenService tokenService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        private string Url(RequestParameters requestParameters)
        {
            return $"{requestParameters.BaseUrl ?? _configuration["BaseApiUrls:ApiUrl"]}/{requestParameters.Controller}{(requestParameters.Action != null ? $"/{requestParameters.Action}" : "")}";
        }

        public async Task<HttpResponseMessage> Get(RequestParameters requestParameters, int? id = null)
        {
            string url;
            if (requestParameters.FullEndPoint != null)
            {
                url = requestParameters.FullEndPoint;
            }
            else
            {
                url = $"{Url(requestParameters)}{(id != null ? $"/{id}" : "")}{(requestParameters.QueryString != null ? $"?{requestParameters.QueryString}" : "")}";
            }

            var token = _tokenService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                var responseMessage = await _httpClient.GetAsync(url);
                return responseMessage;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"Get işlemi sırasında bir hata oluştu: {ex.Message}")
                };
            }
        }

        public async Task<HttpResponseMessage> Get(RequestParameters requestParameters, string id)
        {
            string url;
            if (requestParameters.FullEndPoint != null)
            {
                url = requestParameters.FullEndPoint;
            }
            else
            {
                url = $"{Url(requestParameters)}{(id != null ? $"/{id}" : "")}{(requestParameters.QueryString != null ? $"?{requestParameters.QueryString}" : "")}";
            }

            var token = _tokenService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                var responseMessage = await _httpClient.GetAsync(url);
                return responseMessage;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"Get işlemi sırasında bir hata oluştu: {ex.Message}")
                };
            }
        }
        //queryString: `imageId=${imageId}`
        public async Task<HttpResponseMessage> Post<T>(RequestParameters requestParameters, T content, int? id = null)
        {
            //var url = requestParameters.FullEndPoint ?? Url(requestParameters);
            string url;
            if (requestParameters.FullEndPoint != null)
            {
                url = requestParameters.FullEndPoint;
            }
            else
            {
                url = $"{Url(requestParameters)}{(id != null ? $"/{id}" : "")}{(requestParameters.QueryString != null ? $"?{requestParameters.QueryString}" : "")}";
            }

            var jsonData = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var token = _tokenService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await _httpClient.PostAsync(url, stringContent);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> PostFile(RequestParameters requestParameters, IFormFile file, int? id = null)
        {
            try
            {
                string url;
                if (requestParameters.FullEndPoint != null)
                {
                    url = requestParameters.FullEndPoint;
                }
                else
                {
                    url = $"{Url(requestParameters)}{(id != null ? $"/{id}" : "")}{(requestParameters.QueryString != null ? $"?{requestParameters.QueryString}" : "")}";
                }

                var multipartContent = new MultipartFormDataContent();
                var fileContent = new StreamContent(file.OpenReadStream())
                {
                    Headers =
            {
                ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    FileName = file.FileName
                }
            }
                };

                multipartContent.Add(fileContent);

                var token = _tokenService.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await _httpClient.PostAsync(url, multipartContent);
                return responseMessage;
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir HTTP yanıtı döndürün
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"Dosya yükleme hatası: {ex.Message}")
                };
            }
        }

        public async Task<HttpResponseMessage> PostMultipartFormData<T>(RequestParameters requestParameters, T content, int? id = null)
        {
            // URL oluşturma
            string url;
            if (requestParameters.FullEndPoint != null)
            {
                url = requestParameters.FullEndPoint;
            }
            else
            {
                url = $"{Url(requestParameters)}{(id != null ? $"/{id}" : "")}{(requestParameters.QueryString != null ? $"?{requestParameters.QueryString}" : "")}";
            }

            // Form verilerini oluşturma
            using (var formData = new MultipartFormDataContent())
            {
                // İçerik değerlerini kontrol etme ve form-data olarak eklemeyi işleme
                if (content != null)
                {
                    var properties = content.GetType().GetProperties();

                    foreach (var prop in properties)
                    {
                        var propValue = prop.GetValue(content);

                        if (propValue != null)
                        {
                            // Eğer özellik dosya ise, dosyayı form-data olarak ekler
                            if (prop.PropertyType == typeof(IFormFile))
                            {
                                var file = (IFormFile)propValue;
                                var fileContent = new StreamContent(file.OpenReadStream());
                                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                                {
                                    Name = prop.Name,
                                    FileName = file.FileName
                                };
                                formData.Add(fileContent);
                            }
                            // Eğer özellik int veya string ise, veriyi text/plain formatında form-data olarak ekler
                            else
                            {
                                var stringValue = propValue.ToString();
                                var stringContent = new StringContent(stringValue, Encoding.UTF8, "text/plain");
                                formData.Add(stringContent, prop.Name);
                            }
                        }
                    }
                }

                // Kimlik doğrulama ve istek gönderme
                var token = _tokenService.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await _httpClient.PostAsync(url, formData);
                return responseMessage;
            }
        }

        public async Task<HttpResponseMessage> PutMultipartFormData<T>(RequestParameters requestParameters, T content, int? id = null)
        {
            // URL oluşturma
            string url;
            if (requestParameters.FullEndPoint != null)
            {
                url = requestParameters.FullEndPoint;
            }
            else
            {
                url = $"{Url(requestParameters)}{(id != null ? $"/{id}" : "")}{(requestParameters.QueryString != null ? $"?{requestParameters.QueryString}" : "")}";
            }

            // Form verilerini oluşturma
            using (var formData = new MultipartFormDataContent())
            {
                // İçerik değerlerini kontrol etme ve form-data olarak eklemeyi işleme
                if (content != null)
                {
                    var properties = content.GetType().GetProperties();

                    foreach (var prop in properties)
                    {
                        var propValue = prop.GetValue(content);

                        if (propValue != null)
                        {
                            // Eğer özellik dosya ise, dosyayı form-data olarak ekler
                            if (prop.PropertyType == typeof(IFormFile))
                            {
                                var file = (IFormFile)propValue;
                                var fileContent = new StreamContent(file.OpenReadStream());
                                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                                {
                                    Name = prop.Name,
                                    FileName = file.FileName
                                };
                                formData.Add(fileContent);
                            }
                            // Eğer özellik int veya string ise, veriyi text/plain formatında form-data olarak ekler
                            else
                            {
                                var stringValue = propValue.ToString();
                                var stringContent = new StringContent(stringValue, Encoding.UTF8, "text/plain");
                                formData.Add(stringContent, prop.Name);
                            }
                        }
                    }
                }

                // Kimlik doğrulama ve istek gönderme
                var token = _tokenService.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await _httpClient.PutAsync(url, formData);
                return responseMessage;
            }
        }

        public async Task<HttpResponseMessage> Put<T>(RequestParameters requestParameters, T content)
        {
            var url = requestParameters.FullEndPoint ?? Url(requestParameters);

            var jsonData = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var token = _tokenService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await _httpClient.PutAsync(url, stringContent);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> Delete(RequestParameters requestParameters, int id)
        {
            var url = requestParameters.FullEndPoint ?? $"{Url(requestParameters)}/{id}";
            var token = _tokenService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await _httpClient.DeleteAsync(url);
            return responseMessage;
            //response.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Delete(RequestParameters requestParameters, string id)
        {
            var url = requestParameters.FullEndPoint ?? $"{Url(requestParameters)}/{id}";
            var token = _tokenService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await _httpClient.DeleteAsync(url);
            return responseMessage;
            //response.EnsureSuccessStatusCode();
        }

    }

    public partial class RequestParameters
    {
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? QueryString { get; set; }
        public string? BaseUrl { get; set; }
        public string? FullEndPoint { get; set; }
    }
}
