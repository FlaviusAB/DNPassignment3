using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginExample.Data.HttpServices;
using LoginExample.Data.Model;
using Microsoft.AspNetCore.Components;


namespace LoginExample.Pages
{
public partial class AdultPage
    {
        [Parameter]
        public int? Id { get; set; }
        private IList<Adult> _adultList;
        private Adult _adultModel;

        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IAdultsHttpServices AdultsHttpServices { get; set; }

        public void HandleValidSubmit()
        {
            Console.WriteLine(_adultModel.FirstName);
        }

        protected override async Task OnInitializedAsync()
        { 
            var response  = await AdultsHttpServices.GetAdults();
            _adultList = response.ToList();
            
            if (Id.HasValue)
            {
                _adultModel = await AdultsHttpServices.GetAdult(Id.Value);

            }
            else
            {
                _adultModel = new Adult();
                
                Adult targetAdult = null;
                foreach(var adult in _adultList)
                {
                    if(targetAdult == null)
                    {
                        targetAdult = adult;
                    }
                    else
                    {
                        if (adult.Id > targetAdult.Id)
                            targetAdult = adult;
                    }
                } 
                _adultModel.Id = targetAdult?.Id + 1 ?? 0;
            }
        }
        private void Save()
        {
            if (!Id.HasValue)
            {
                AdultsHttpServices.AddAdult(_adultModel);
            }
            else
            {
                AdultsHttpServices.GetAdult(Id.Value);
                AdultsHttpServices.EditAdult(_adultModel);
            }
            NavigationManager.NavigateTo($"/adults");
        }

        private void Cancel()
        {
            NavigationManager.NavigateTo($"/adults");
        }

    }


}