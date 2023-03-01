using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataRoom.Models;
using Microsoft.AspNetCore.Identity;
using DataRoom.ViewModels;

namespace DataRoom.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectsController(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            this._userManager = userManager;
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Project.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FirstOrDefaultAsync(m => m.Id == id);
            
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public async Task<IActionResult> Create()
        {
            var usersWithPermission = await _userManager.GetUsersInRoleAsync("Owners");

            // Then get a list of the ids of these users
            var idsWithPermission = usersWithPermission.Select(u => u.Id);

            // Now get the users in our database with the same ids
            var users = _context.Users.Where(u => idsWithPermission.Contains(u.Id)).ToListAsync();

            ViewBag.owners = users.Result;
            
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,OwnerId")] Project project) // What this Bind("Name,OwnerId") do?
        {
            if (ModelState.IsValid)
            {
                Project newProject = new Project
                {
                    Name = project.Name,
                    OwnerId = project.OwnerId,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    IsActive = project.IsActive
                };
                
                _context.Add(newProject);
                
                await _context.SaveChangesAsync();
                
                System.IO.Directory.CreateDirectory("Upload/" + project.Name);

                return RedirectToAction(nameof(Index));
            }
                        
            return View(project);
        }

        // GET: Projects/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }


            var model = new EditProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                OwnerId = project.OwnerId,
                IsActive = project.IsActive,
                ProjectBidders = _context.BidderProjects.Where(b => b.ProjectId == id).Select(p => p.BidderId).ToList()
            };

            var owerns = await _userManager.GetUsersInRoleAsync("Owners");
            var bidders = await _userManager.GetUsersInRoleAsync("Bidders");

            ViewBag.owners = owerns;
            ViewBag.bidders = bidders;
            
            return View(model);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProjectViewModel model)
        {
            var project = _context.Project.Where(p => p.Id == model.Id).First();

            if (project == null)
            {
                ViewBag.ErrorMessage = $"Project with Id = {model.Id} cannot be found";
                
                return View("NotFound");
            }
            else
            {
                project.Name = model.Name;
                project.OwnerId = model.OwnerId;
                project.StartDate = model.StartDate;
                project.EndDate = model.EndDate;
                project.IsActive = model.IsActive;

                var oldbidders = _context.BidderProjects.Where(b => b.ProjectId == model.Id).ToList();

                foreach (var item in oldbidders)
                {
                    if (!model.ProjectBidders.Contains(item.BidderId))
                    {
                        _context.BidderProjects.Remove(item);
                        
                        var bidder = _userManager.FindByIdAsync(item.BidderId).Result.UserName;
                        
                        System.IO.Directory.Delete("Upload/" + project.Name + "/" + bidder, true);
                    }
                }

                foreach (var item in model.ProjectBidders)
                {
                    if (item == null) continue;
                    
                    var oldbidderIds = oldbidders.Select(b => b.BidderId).ToList();
                    
                    if (!oldbidderIds.Contains(item))
                    {
                        _context.BidderProjects.Add(new BidderProject
                        {
                            BidderId = item,
                            ProjectId = model.Id
                        });
                        
                        var bidder = _userManager.FindByIdAsync(item).Result.UserName;
                        
                        System.IO.Directory.CreateDirectory("Upload/" + project.Name + "/" + bidder);
                    }
                }

                var result = _context.SaveChanges();
            }

            return RedirectToAction("details", new { id = model.Id });
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FirstOrDefaultAsync(m => m.Id == id);
            
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bidderProjects = _context.BidderProjects.Where(b => b.ProjectId == id).ToList();
            
            foreach (var b in bidderProjects)
                _context.BidderProjects.Remove(b);

            var project = await _context.Project.FindAsync(id);

            if (System.IO.Directory.Exists("Upload/" + project.Name))
                System.IO.Directory.Delete("Upload/" + project.Name, true);
            
            _context.Project.Remove(project);
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(string id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
