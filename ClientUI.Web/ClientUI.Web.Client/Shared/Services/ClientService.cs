using Client.Model.DatabaseViews;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ClientUI.Web.Shared.Services;

public class ClientService
{

    private readonly HttpClient _httpClient;
    public string ServiceUrl => "https://localhost:7294/api/Client";
    public ClientService(HttpClient httpClient) {
        this._httpClient = httpClient;
       
    }
    public Task<IEnumerable<ClientDetailsViewItem>?> GetClients() => 
        this._httpClient.GetFromJsonAsync<IEnumerable<ClientDetailsViewItem>>(this.ServiceUrl);

    public Task<int> DeleteClient(long clientId) =>
        this._httpClient.DeleteFromJsonAsync<int>($"{this.ServiceUrl}/{clientId}");
    public Task<ClientDetailsViewItem?> GetClient(long clientId) => this._httpClient.GetFromJsonAsync<ClientDetailsViewItem>($"{this.ServiceUrl}/{clientId}");

    public Task<HttpResponseMessage> AddClient(ClientDetailsViewItem clientData)
        => this._httpClient.PostAsJsonAsync(this.ServiceUrl, clientData);

    
}
