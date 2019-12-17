using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryItemController : ControllerBase
    {
        private readonly MobileContext _context;

        public AccessoryItemController(MobileContext context)
        {
            _context = context;
                
        }

        [HttpGet]
        public List<AccessoryItems> GetAccessoryItems()
        {
            return _context.AccessoryItems.ToList();



        }

        [HttpGet("{id}")]
        public IActionResult GetAccessoryItems(int id)
        {
            var accessoryitems = _context.AccessoryItems.Find(id);

            if (accessoryitems == null)
            {
                return NotFound();
            }

            return Ok(accessoryitems);
        }
        [HttpPost]
        public IActionResult AddAccessoryItem([FromBody] List<AccessoryItems> accessory)
        {
            try
            {
                for (var i = 0; i < accessory.ToArray().Length; i++)
                {
                    _context.AccessoryItems.Add(accessory[i]);
                }
                _context.SaveChanges();
                return CreatedAtAction("GetAccessoryItems", accessory);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]

        [HttpPut("{id}")]
        public IActionResult PutAccessoryDetail(int id, List<AccessoryItems> accessory)
        {
            try
            {

                for (var i = 0; i < accessory.ToArray().Length; i++)
                {
                    if (id != accessory[i].AccessoryItemsId)
                    {
                        _context.AccessoryItems.Add(accessory[i]);
                    }
                    else
                        _context.Entry(accessory[i]).State = EntityState.Modified;
                }
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessoryItemsExists(id))
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

        [HttpDelete("{id}")]

        public IActionResult DeleteAccessory(int id)
        {
            var accessoryitems = _context.AccessoryItems.Find(id);
            if (accessoryitems == null)
            {
                return NotFound();
            }

            _context.AccessoryItems.Remove(accessoryitems);
            _context.SaveChanges();

            return Ok(accessoryitems);
        }
        bool AccessoryItemsExists(int id)
        {
            return _context.AccessoryItems.Any(e => e.AccessoryItemsId == id);
        }


    }
}