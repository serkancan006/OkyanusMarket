namespace OkyanusHangfire.Services.OlimposSoapService
{
    public interface IOlimposSoapService
    {
        Task<ProductAllListSoapResponse> GetProductAllListSoap(string dbUserName = "WEBCRMUSER", string dbPassword = "WEBCRMUSER", string birimNo = "101");
    }
}
