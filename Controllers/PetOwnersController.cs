using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners()
        {
            return _context.PetOwners;
        }

        // GET by id
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
            PetOwner petOwner = _context.PetOwners
                .SingleOrDefault(petOwner => petOwner.id == id);

            // Return a `404 Not Found` if the baker doesn't exist
            if (petOwner is null)
            {
                return NotFound();
            }

            return petOwner;
        }

        // POST
        [HttpPost]
        public IActionResult Post(PetOwner petOwner)
        {
            _context.Add(petOwner);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = petOwner.id },
                petOwner
            );
        }

        // DELETE by id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PetOwner petOwner = _context.PetOwners.Find(id);

            _context.PetOwners.Remove(petOwner);

            _context.SaveChanges();
            return NoContent();

        }

        // PUT by id
        [HttpPut("{id}")]
        public PetOwner Put(int id, PetOwner petOwner)
        {
            petOwner.id = id;
            _context.Update(petOwner);
            _context.SaveChanges();

            return petOwner;
        }


    }
}
