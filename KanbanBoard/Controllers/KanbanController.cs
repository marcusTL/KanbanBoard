using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanBoard.Data;
using KanbanBoard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Controllers
{
    public class KanbanController : Controller
    {

        private readonly ApplicationDbContext _dbContext;


        public KanbanController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Authorize("readonlypolicy")]
        public IActionResult Index()
        {

            var appDbContext = _dbContext.Item.Include(u => u.User)
                .Where(i => i.UserId == User.Identity.Name);

            return View(appDbContext.ToList());
        }
        [Authorize("writepolicy")]
        public IActionResult IndexCreate()
        {
            return View(nameof(CreateItem));
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([Bind("ItemId,Title,Description,ResponsibleUser,BoardState")]Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.UserId = User.Identity.Name;
                    _dbContext.Item.Add(item);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Create", "Unable to Create new Item: " + ex);
            }

            return View();
        }

        //[HttpPut]
        public IActionResult EditItem(Item item)
        {
            try
            {     

                if (ModelState.IsValid)
                {
                    _dbContext.Item.Update(item);
                    _dbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            
            catch (Exception ex)
            {
                ModelState.AddModelError("Create", "Unable to edit the item: " + ex);
            }

            return View();
        }
        
        public IActionResult IndexEdit(int? id)
        {
            Item item = null;
  
            if (id == null)
            {
                return NotFound();
            }

            item = _dbContext.Item.Find(id);

            return View(nameof(EditItem), item);
        }
        //[HttpDelete]
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _dbContext.Item.Find(id);
            _dbContext.Item.Remove(item);
            _dbContext.SaveChanges();

            return View();
        }

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Item = await _db.Item
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (Item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(Item);
        //}
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var Item = await _db.Item.FindAsync(id);
        //    _db.Item.Remove(Item);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
