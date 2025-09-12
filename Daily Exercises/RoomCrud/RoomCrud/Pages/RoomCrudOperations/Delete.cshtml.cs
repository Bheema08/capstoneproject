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
    public class DeleteModel : PageModel
    {
        private readonly RoomCrudTestDemo.Models.RFCoreDbContext _context;

        public DeleteModel(RoomCrudTestDemo.Models.RFCoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room Room { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.roomates.FirstOrDefaultAsync(m => m.Id == id);

            if (room == null)
            {
                return NotFound();
            }
            else
            {
                Room = room;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.roomates.FindAsync(id);
            if (room != null)
            {
                Room = room;
                _context.roomates.Remove(Room);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
