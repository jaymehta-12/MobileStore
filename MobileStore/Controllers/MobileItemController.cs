using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileItemController : ControllerBase
    {
        private readonly MobileContext _context;

        public MobileItemController(MobileContext context)
        {
            _context = context;
        }



        [HttpGet]

        public List<MobileItems> GetMobileList()
        {
            return _context.MobileItems.Include(a=>a.AccessoryItems).ToList();
        }

        [HttpGet("{id}")]

        public IActionResult GetMobileList(int id)
        {
            var mobileitems = _context.MobileItems.Include(a=>a.AccessoryItems).SingleOrDefault(m=>m.MobileItemsId==id);

            if (mobileitems == null)
            {
                return NotFound();
            }

            return Ok(mobileitems);

        }

        [HttpPost]

        public IActionResult AddMobile([FromBody] MobileItems mobile)
        {
            try
            {
               
                
                    _context.MobileItems.Add(mobile);
                
                _context.SaveChanges();
                return CreatedAtAction("GetMobileList", mobile);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("{list}")]

        public IActionResult AddMobileList([FromBody] List<MobileItems> mobile)
        {
            try
            {
                for (var i = 0; i < mobile.ToArray().Length; i++)
                {
                    _context.MobileItems.Add(mobile[i]);
                }
                _context.SaveChanges();
                return CreatedAtAction("GetMobileList", mobile);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]

        public IActionResult DeleteMobile([FromQuery] int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                var mobileitems = _context.MobileItems.Find(ids[i]);
                if (mobileitems == null)
                {
                    return NotFound();
                }

                _context.MobileItems.Remove(mobileitems);

            }
            _context.SaveChanges();

            return Ok(ids);
        }

        

        //[HttpPut("{id}")]
        [HttpPut]
        public IActionResult  PutMobileDetail([FromBody] List<MobileItems> mobile)
         {
             try
             {
                
                for (var i=0;i<mobile.ToArray().Length;i++)
                {
                    if (!MobileItemsExists(mobile[i].MobileItemsId))
                    {
                        _context.MobileItems.Add(mobile[i]);
                    }
                    else
                    _context.Entry(mobile[i]).State = EntityState.Modified;
                }
                  _context.SaveChanges();
             }
             catch (DbUpdateConcurrencyException jj)
             {
                return BadRequest(jj);
             }

             return NoContent();
         }
         bool MobileItemsExists(int id)
        {
            return _context.MobileItems.Any(e => e.MobileItemsId == id);
        }

    }
}