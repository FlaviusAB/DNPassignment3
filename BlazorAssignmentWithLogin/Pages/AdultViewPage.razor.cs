
using System.Threading.Tasks;
using LoginExample.Data.HttpServices;
using LoginExample.Data.Model;
using Microsoft.AspNetCore.Components;

namespace LoginExample.Pages
{
    public partial class AdultViewPage
    {
        [Inject] private IAdultsHttpServices AdultsHttpServices { get; set; }

        public Adult _adultModel= new Adult();
        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {

            _adultModel =await AdultsHttpServices.GetAdult(Id);


        }
    }
}