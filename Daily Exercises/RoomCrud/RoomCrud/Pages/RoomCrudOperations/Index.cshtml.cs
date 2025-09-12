using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoomCrudTestDemo.Models;

namespace RoomCrudTestDemo.Pages.RoomCrudOperations
{
    public class IndexModel : PageModel
    {
        private readonly RoomCrudTestDemo.Models.RFCoreDbContext _context;

        public IndexModel(RoomCrudTestDemo.Models.RFCoreDbContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Room = await _context.roomates.ToListAsync();
        }
    }
}
