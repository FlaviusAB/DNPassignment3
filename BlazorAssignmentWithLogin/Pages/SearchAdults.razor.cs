using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginExample.Data.HttpServices;
using LoginExample.Data.Model;
using Microsoft.AspNetCore.Components;

namespace LoginExample.Pages
{
    public partial class SearchAdults
    {

        [Inject] private IAdultsHttpServices AdultsHttpServices { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private string _searchInputVal = "";
        private bool _val = true;
        private IList<Adult> _adultList = new List<Adult>();
        private IList<Adult> _adultListOriginal;
       

        protected override async Task OnInitializedAsync()
        {
            var adults = await AdultsHttpServices.GetAdults();

            _adultList = adults.ToList();
            _adultListOriginal = _adultList;
            Console.WriteLine(adults);
        }

        public void Edit(int id)
        {
            NavigationManager.NavigateTo($"adult/{id}");
        }
        public void View(int id)
        {
            NavigationManager.NavigateTo($"adultView/{id}");
        }

        public void Add() {
            NavigationManager.NavigateTo($"adult");
        }
        public async Task Delete(int id)
        {
            await AdultsHttpServices.DeleteAdult(id);
            var adult = _adultList.FirstOrDefault(x => x.Id == id);
            _adultList.Remove(adult);

        }
        private async Task Search()
        {
            var lowerCaseFieldValue = _searchInputVal.ToLower();
            _adultList = _adultListOriginal.Where(adult => adult.FirstName.ToLower().Contains(lowerCaseFieldValue)
                                                           || adult.LastName.ToLower().Contains(lowerCaseFieldValue)).ToList();
            await InvokeAsync(() => StateHasChanged())
                .ConfigureAwait(false);
        }
        

    }
}