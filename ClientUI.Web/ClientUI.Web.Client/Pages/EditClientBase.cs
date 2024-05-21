using Client.Model.DatabaseViews;
using Client.Model.Entities;
using ClientUI.Web.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ClientUI.Web.Client.Pages
{
    public class EditClientBase: ComponentBase
    {
        public ClientDetailsViewItem EditModel = new ClientDetailsViewItem();
        public string responseMessage = string.Empty;
        public string SelectedGender = "1";
        [Inject] public ClientService clientService {  get; set; }
        [Parameter]
        public string ClientId { get; set; }
        [Inject] public NavigationManager NavManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if(long.TryParse(ClientId, out var clientId))
            {
                if(clientId > 0)
                {
                    var result = await this.clientService.GetClient(clientId);
                    this.EditModel = result ?? new ClientDetailsViewItem();
                    this.SelectedGender = ((int)this.EditModel.Gender).ToString();
                }
            }
        }
        public async Task OnSubmitClick() {
            _ = int.TryParse(this.SelectedGender, out var genderInt);
            this.EditModel.Gender = (Gender)genderInt;
;            var result = await this.clientService.AddClient(this.EditModel);
            if (result.IsSuccessStatusCode)
            {
                responseMessage = "Submit Successful!";
            }
            else
            {
                responseMessage = "";
            }
        }

        public void OnBackClick()
        {
            this.NavManager.NavigateTo("/");
        }
    }
}
