using CalendarProjectV1.Data;
using CalendarProjectV1.Models.Domain;
using CalendarProjectV1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;

namespace CalendarProjectV1.Controllers
{
    public class ItemsController : Controller
    {
        private readonly CalendarProjectDbContext calendarProjectDbContext;

        public ItemsController(CalendarProjectDbContext calendarProjectDbContext)
        {
            this.calendarProjectDbContext = calendarProjectDbContext;
        }
        [HttpGet]
        public async Task<IActionResult>Index(string SearchString, string SortStyle) 
        {
            ViewData["CurrentStringFilter"] = SearchString;
            ViewData["SortByTitle"] = String.IsNullOrEmpty(SortStyle) ? "TitleDesc" : "";
            ViewData["SortByDate"] = SortStyle == "Date" ? "DateDesc" : "Date";
            //         {             This is the condition           }      {this is the true prt}      {This is the false prt}


            var calendarItemm = from c in calendarProjectDbContext.CalendarItems
                                select c;

            if (!String.IsNullOrEmpty(SearchString))
            {
                calendarItemm = calendarItemm.Where(c => c.Title.Contains(SearchString));
            }
            switch (SortStyle)
            {
                case "TitleDesc":
                    calendarItemm = calendarItemm.OrderByDescending(c => c.Title);
                    break;
                case "Date":
                    calendarItemm = calendarItemm.OrderBy(c => c.AssignedDate);
                    break;
                case "DateDesc":
                    calendarItemm.OrderByDescending(c => c.AssignedDate);
                    break;
            }
            return View(await calendarItemm.AsNoTracking().ToListAsync());
            //                                 {"makes app run fasters as its a read oppperation"?}

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel addItemRequest) 
        {

            var CalendarItem = new CalendarItem()
            {
                Id = Guid.NewGuid(),
                AssignedDate = addItemRequest.AssignedDate,
                NameOfAssignedDate = addItemRequest.NameOfAssignedDate,
                Title = addItemRequest.Title,
                Location = addItemRequest.Location,
                AssignedPriority = addItemRequest.AssignedPriority,
                Note = addItemRequest.Note
                
            };

            await calendarProjectDbContext.CalendarItems.AddAsync(CalendarItem);
            await calendarProjectDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id) 
        {
            var calendaritem =  await calendarProjectDbContext.CalendarItems.FirstOrDefaultAsync(x => x.Id == id);

            if (calendaritem != null)
            {

                var viewModel = new UpdateCalendarItemViewModel()
                {
                    Id = calendaritem.Id,
                    AssignedDate = calendaritem.AssignedDate,
                    NameOfAssignedDate = calendaritem.NameOfAssignedDate,
                    Title = calendaritem.Title,
                    Location = calendaritem.Location,
                    AssignedPriority = calendaritem.AssignedPriority,
                    Note = calendaritem.Note
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateCalendarItemViewModel model)
        {
            var calendaritem = await calendarProjectDbContext.CalendarItems.FindAsync(model.Id);

            if (calendaritem != null) 
            {
                calendaritem.AssignedDate = model.AssignedDate;
                calendaritem.NameOfAssignedDate = model.NameOfAssignedDate;
                calendaritem.Title = model.Title;
                calendaritem.Location = model.Location;
                calendaritem.AssignedPriority = model.AssignedPriority;
                calendaritem.Note = model.Note;

                await calendarProjectDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateCalendarItemViewModel viewModel)
        {
            var calendarItem = await calendarProjectDbContext.CalendarItems.FindAsync(viewModel.Id);

            if(calendarItem != null) 
            {
                calendarProjectDbContext.CalendarItems.Remove(calendarItem);
                await calendarProjectDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

       
    }
}
