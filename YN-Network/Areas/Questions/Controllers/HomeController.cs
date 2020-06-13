using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YN_Network.Areas.Questions.Models;
using YN_Network.Areas.Questions.Services;
using YN_Network.Areas.Questions.ViewModels;
using YN_Network.Data;
using YN_Network.Models;

// Todo: Fix date issue when updating a record! //

namespace YN_Network.Areas.Questions.Controllers
{
    [Area("Questions")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IQuestionService _questionService;
        public HomeController(ApplicationDbContext context,IQuestionService questionService)
        {
            _context = context;
            _questionService = questionService;
        }

        // GET: Questions/Questions
        public async Task<IActionResult> Index()
        {
            QuestionsHomeViewModel viewModel = new QuestionsHomeViewModel();
            viewModel.Questions = _questionService.GetQuestions();
            viewModel.MostPopularQuestions = _questionService.GetMostPopularQuestions();
            return View(viewModel);
        }

        // GET: Questions/Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            question.Views = question.Views + 1;
            await _context.SaveChangesAsync();
            return View(question);
        }

        // GET: Questions/Questions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questions/Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,User,OptionA,OptionB")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.CreatedAt = DateTime.Now;
                _context.Add(question);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,OptionA,OptionB")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
