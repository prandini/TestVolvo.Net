using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Volvo.Site;
using App.Volvo.Site.ViewModels;
using App.Volvo.Business.Interfaces;
using AutoMapper;
using App.Volvo.Business.Models;

namespace App.Volvo.Site.Controllers
{
    public class ModeloController : BaseController
    {
        private readonly IModeloService _modeloService;

        private readonly IModeloRepository _modeloRepository;

        private readonly IMapper _mapper;

        public ModeloController(IModeloService modeloService, 
                                IModeloRepository modeloRepository, 
                                IMapper mapper,
                                INotifier notifier) : base(notifier)
        {
            _modeloService = modeloService;
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var modelos = await _modeloRepository.GetAll();
            var modelosViewModel = _mapper.Map<IEnumerable<ModeloViewModel>>(modelos);

            return View(modelosViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModeloViewModel modeloViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(modeloViewModel);
            }

            var modelo = _mapper.Map<Modelo>(modeloViewModel);
            await _modeloService.Insert(modelo);

            if (OperacaoValida() == false)
            {
                return View(modeloViewModel);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloViewModel>(await _modeloRepository.GetById(id));
            if (modeloViewModel == null)
            {
                return NotFound();
            }
            return View(modeloViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ModeloViewModel modeloViewModel)
        {
            if (id != modeloViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid == false)
            {
                return View(modeloViewModel);
            }

            var modelo = _mapper.Map<Modelo>(modeloViewModel);
            await _modeloService.Update(modelo);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloViewModel>(await _modeloRepository.GetById(id));

            if (modeloViewModel == null)
            {
                return NotFound();
            }

            return View(modeloViewModel);
        }

        // POST: Modelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloViewModel>(await _modeloRepository.GetById(id));
            if (modeloViewModel == null)
            {
                return NotFound();
            }

            await _modeloService.Delete(id);

            if (OperacaoValida() == false)
                return View(modeloViewModel);

            return RedirectToAction(nameof(Index));
        }
    }
}
