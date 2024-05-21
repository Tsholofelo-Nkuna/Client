using Client.Model.DatabaseViews;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using ClientUI.Web.Shared.Services;
using System.Net.Http.Headers;
namespace ClientUI.Web.Client.Pages
{
    public class ClientDetailsBase : ComponentBase
    {
       private readonly HttpClient _httpClient = new HttpClient();
       [Inject]
       private ClientService _clientService { get; set; }
       [Inject]
       private NavigationManager NavManger {  get; set; }
        public IEnumerable<ClientDetailsViewItem> ClientDetails { get; set; } = Enumerable.Empty<ClientDetailsViewItem>();

        protected override async Task OnInitializedAsync()
        {
            await this.GetData();
        }

        public async Task GetData()
        {
            this.ClientDetails = await this._clientService.GetClients() ?? Enumerable.Empty<ClientDetailsViewItem>();
        }

        public async Task OnDeleteClick(ClientDetailsViewItem payload)
        {
            var result = await this._clientService.DeleteClient(payload.ClientUniqueId);
            if (result > 0)
            {
                await this.GetData();
            }
        }

        public async Task OnEditClick(ClientDetailsViewItem payload)
        {
            this.NavManger.NavigateTo($"/Edit/{payload.ClientUniqueId}");
        }

        public void OnAddClick()
        {
            this.NavManger.NavigateTo($"/Edit/{0}");
        }
    }
}
