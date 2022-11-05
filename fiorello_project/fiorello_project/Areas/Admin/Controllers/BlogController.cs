﻿using fiorello_project.Areas.Admin.ViewModels.Blog;
using fiorello_project.DAL;
using fiorello_project.Helpers;
using fiorello_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiorello_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(AppDbContext appDbContext, IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var model = new BlogIndexViewModel
            {
                Blogs = await _appDbContext.Blogs.ToListAsync()
            };
            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(BlogCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            bool isExist = await _appDbContext.Blogs.AnyAsync(b => b.Title.ToLower().Trim() == model.Title.ToLower().Trim());
            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda blog movcuddur");
                return View(model);
            }
            if (!_fileService.IsImage(model.MainPhoto))
            {
                ModelState.AddModelError("MainPhoto", "File image formatinda deyil zehmet olmasa image formasinda secin!!");
                return View(model);
            }
            if (!_fileService.CheckSize(model.MainPhoto, 300))
            {
                ModelState.AddModelError("MainPhoto", "File olcusu 300 kbdan boyukdur");
                return View(model);
            }

            if (model.CreateDate == null)
            {
                model.CreateDate = DateTime.Today;
            }

            var blog = new Blog
            {
                Title = model.Title,
                Description = model.Description,
                CreateDate = model.CreateDate.Value,
                PhotoName = await _fileService.UploadAsync(model.MainPhoto, _webHostEnvironment.WebRootPath),
            };

            await _appDbContext.Blogs.AddAsync(blog);
            await _appDbContext.SaveChangesAsync();


            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _appDbContext.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            _appDbContext.Blogs.Remove(blog);

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var blog = await _appDbContext.Blogs.FindAsync(id);

            if (blog == null) return NotFound();

            var model = new BlogUpdateViewModel
            {

                Title = blog.Title,
                Description = blog.Description,
                CreateDate = blog.CreateDate,
                MainPhotoName = blog.PhotoName,


            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogUpdateViewModel model, int id)
        {
            var blog = await _appDbContext.Blogs.FindAsync(id);

            if (!ModelState.IsValid) return View(model);

            if (id != model.Id) return BadRequest();

            bool isExits = await _appDbContext.Blogs.AnyAsync(p => p.Title.ToLower().Trim() == model.Title.ToLower().Trim() && p.Id != blog.Id);

            if (isExits)
            {
                ModelState.AddModelError("Title", "Bu blog movcuddur");
                return View(model);
            }
            blog.Title = model.Title;
            blog.Description = model.Description;
            blog.CreateDate = model.CreateDate.Value;
            model.MainPhotoName = blog.PhotoName;


            if (model.MainPhoto != null)
            {

                if (!_fileService.IsImage(model.MainPhoto))
                {
                    ModelState.AddModelError("Photo", "Image formatinda secin");
                    return View(model);
                }
                if (!_fileService.CheckSize(model.MainPhoto, 300))
                {
                    ModelState.AddModelError("Photo", "Sekilin olcusu 300 kb dan boyukdur");
                    return View(model);
                }
            blog.PhotoName = await _fileService.UploadAsync(model.MainPhoto, _webHostEnvironment.WebRootPath);
            }
    

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var blog = await _appDbContext.Blogs.FindAsync(id);

            if (blog == null) return NotFound();

            var model = new BlogDetailsViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                CreateDate = blog.CreateDate,
                MainPhotoName = blog.PhotoName,


            };
            return View(model);

        }
    }
}
