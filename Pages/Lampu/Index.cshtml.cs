using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quiz1_Elsya_A.T.Model;
using Quiz1_Elsya_A.T.Services;

namespace Quiz1_Elsya_A.T.Pages.Lampu
{
    public class IndexModel : PageModel
    {
        private readonly LampuService ServiceMan;

        public IndexModel(LampuService lampuService)
        {
            this.ServiceMan = lampuService;
        }

        public List<LampuModel> lamps { set; get; }

        // For filter 
        [Display(Name = "Search")]
        [BindProperty(SupportsGet = true)]
        public string FilterByName { get; set; }

        public int TotalPage { set; get; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { set; get; }
        public int ItemPerPage => 5;

        public async Task OnGetAsync()
        {
            if (PageIndex == 0)
            {
                PageIndex = 1;
            }

            // add param filterByName for filtering
            lamps = await ServiceMan.GetAsync(PageIndex, ItemPerPage, FilterByName);

            var totalLampu = ServiceMan.GetTotalData();

            TotalPage = (int)Math.Ceiling(totalLampu / (double)ItemPerPage);
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var isSuccess = await this.ServiceMan.DeleteLampAsync(id);

            if (isSuccess == false)
            {
                return Page();
            }
            return Redirect("/lampu");
        }
       
    }
}
