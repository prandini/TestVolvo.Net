using App.Volvo.Business.Interfaces;
using App.Volvo.Business.Models;
using App.Volvo.Site.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Volvo.Site.Controllers
{
    public class CaminhaoController : BaseController
    {
        //Camada de serviço para modificar dados de banco
        private readonly ICaminhaoService _caminhaoService;

        //Camada de repositorio para fazer leituras simples e trazer dados para a apresentação
        private readonly ICaminhaoRepository _caminhaoRepository;
        private readonly IModeloService _modeloService;
        private readonly IMapper _mapper;

        public CaminhaoController(ICaminhaoService caminhaoService, 
                                  ICaminhaoRepository caminhaoRepository, 
                                  IModeloService modeloService, 
                                  IMapper mapper, 
                                  INotifier notifier) : base(notifier)
        {
            _caminhaoService = caminhaoService;
            _caminhaoRepository = caminhaoRepository;
            _modeloService = modeloService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var caminhoes = await _caminhaoRepository.GetCaminhoesModelo();
            var caminhoesViewModel = _mapper.Map<IEnumerable<CaminhaoViewModel>>(caminhoes);

            return View(caminhoesViewModel);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            var caminhaoViewModel = GetCaminhao(id);
            return View(caminhaoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var caminhaoViewModel = await PopularModelos(new CaminhaoViewModel());

            caminhaoViewModel.AnoFabricacao = (short)DateTime.Now.Year;
            caminhaoViewModel.AnoModelo = (short)DateTime.Now.Year;

            return View(caminhaoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CaminhaoViewModel caminhaoViewModel)
        {
            if (ModelState.IsValid == false)
            {
                caminhaoViewModel = await PopularModelos(caminhaoViewModel);

                return View(caminhaoViewModel);
            }

            var caminhao = _mapper.Map<Caminhao>(caminhaoViewModel);
            await _caminhaoService.Insert(caminhao);

            if (OperacaoValida() == false)
            {
                caminhaoViewModel = await PopularModelos(caminhaoViewModel);
                return View(caminhaoViewModel);
            }
            
            return RedirectToAction("Index");            
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var caminhaoViewModel = _mapper.Map<CaminhaoViewModel>(await _caminhaoRepository.GetCaminhaoModelo(id));
            if (caminhaoViewModel == null)
            {
                return NotFound();
            }

            caminhaoViewModel = await PopularModelos(caminhaoViewModel);

            return View(caminhaoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CaminhaoViewModel caminhaoViewModel)
        {
            if (id != caminhaoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid == false)
            {
                caminhaoViewModel = await PopularModelos(caminhaoViewModel);
                return View(caminhaoViewModel);
            }

            var caminhao = _mapper.Map<Caminhao>(caminhaoViewModel);
            await _caminhaoService.Update(caminhao);

            if (OperacaoValida() == false)
            {
                caminhaoViewModel = await PopularModelos(caminhaoViewModel);
                return View(caminhaoViewModel);
            }

            return RedirectToAction("Index");            
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var caminhaoViewModel = _mapper.Map<CaminhaoViewModel>(await _caminhaoRepository.GetCaminhaoModelo(id));

            if (caminhaoViewModel == null)
            {
                return NotFound();
            }

            return View(caminhaoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var caminhaoViewModel = _mapper.Map<CaminhaoViewModel>(await _caminhaoRepository.GetCaminhaoModelo(id));
            if (caminhaoViewModel == null)
            {
                return NotFound();
            }

            await _caminhaoService.Delete(id);

            if (OperacaoValida() == false)
                return View(caminhaoViewModel);

            return RedirectToAction(nameof(Index));
        }

        private async Task<CaminhaoViewModel> PopularModelos(CaminhaoViewModel caminhaoViewModel)
        {
            var modelos = await _modeloService.GetModelosPermitidoCadastro();
            caminhaoViewModel.Modelos = _mapper.Map<IEnumerable<ModeloViewModel>>(modelos);
            return caminhaoViewModel;
        }

        private async Task<CaminhaoViewModel> GetCaminhao(Guid? id)
        {
            var caminhao = await _caminhaoRepository.GetById(id.Value);
            return _mapper.Map<CaminhaoViewModel>(caminhao);
        }

    }
}
