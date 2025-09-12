using CanteenProject.Middleware;
using CanteenProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MasterDbContext _context;

        public CustomersController(MasterDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            // Decrypt passwords before returning
            foreach (var c in customers)
            {
                c.custPassword = DecryptionHelper.Decrypt(c.custPassword);
            }

            return customers;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            // Decrypt before returning
            customer.custPassword = DecryptionHelper.Decrypt(customer.custPassword);

            return customer;
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.custId)
            {
                return BadRequest();
            }

            // Encrypt password before saving
            customer.custPassword = EncryptionHelper.Encrypt(customer.custPassword);

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            // Encrypt password before saving
            customer.custPassword = EncryptionHelper.Encrypt(customer.custPassword);

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Decrypt before returning response (optional)
            customer.custPassword = DecryptionHelper.Decrypt(customer.custPassword);

            return CreatedAtAction("GetCustomer", new { id = customer.custId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Customers/search/{username}
        [HttpGet("search/{username}")]
        public async Task<ActionResult<Customer>> SearchByUserName(string username)
        {
            var customer = await _context.Customers
                                         .FirstOrDefaultAsync(c => c.custUserName == username);

            if (customer == null)
            {
                return NotFound();
            }

            // Decrypt password before returning
            customer.custPassword = DecryptionHelper.Decrypt(customer.custPassword);

            return customer;
        }

        [HttpGet("login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            var customer = _context.Customers
                .FirstOrDefault(c => c.custUserName == username);

            if (customer != null)
            {
                // Decrypt the password
                string decryptedPassword = DecryptionHelper.Decrypt(customer.custPassword);

                if (decryptedPassword == password)
                    return Ok(true);  // valid
            }

            return Ok(false); // invalid
        }



        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.custId == id);
        }
    }
}