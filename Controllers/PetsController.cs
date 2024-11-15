using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Pet> GetPet()
        {
            return _context.Pets
                .Include(pet => pet.petOwner);
        }
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            Pet pet = _context.Pets
               .SingleOrDefault(pet => pet.id == id);

            if (pet is null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPost]
        public IActionResult Post(Pet pet)
        {
            if (pet == null)
            {
                return BadRequest();
            }

            _context.Add(pet);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = pet.id },
                pet
            );
        }

        [HttpPut("{id}")]
        public Pet Put(int id, Pet pet)
        {
            pet.id = id;
            _context.Update(pet);
            _context.SaveChanges();

            return pet;
        }

        [HttpPut("{id}/checkin")]
        public Pet Checkin(int id)
        {
            Pet pet = _context.Pets.Find(id);
            pet.checkedInAt = DateTime.Now.ToString();
            _context.Update(pet);
            _context.SaveChanges();

            return pet;
        }

        [HttpPut("{id}/checkout")]
        public Pet Checkout(int id)
        {
            Pet pet = _context.Pets.Find(id);
            pet.checkedInAt = null;
            _context.Update(pet);
            _context.SaveChanges();

            return pet;
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pet pet = _context.Pets.Find(id);

            _context.Pets.Remove(pet);

            _context.SaveChanges();

            return NoContent();
        }
    }
};




