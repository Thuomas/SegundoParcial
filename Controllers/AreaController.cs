using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SegundoParcial.Data;
using SegundoParcial.Models;
using SegundoParcial.Services;
using SegundoParcial.ViewModels;

namespace SegundoParcial.Controllers
{
    public class AreaController : Controller
    {
        private IAreaService _areaService;
        private IDepositoService _depositoService;

        public AreaController(IAreaService areaService, IDepositoService depositoService)
        {
            _areaService = areaService;
            _depositoService=depositoService;
        }

        // GET: Area
        public async Task<IActionResult> Index()
        {
              var list = _areaService.GetAll();
              var model = new AreaViewModel();
              model.Areas= list;
              return View(model);
        }

        // GET: Area/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = _areaService.GetById(id.Value);
            if (area == null)
            {
                return NotFound();
            }
            var model= new AreaViewModel();
            model.Depositos = area.Depositos;
            model.Nombre = area.Nombre;
            model.Id = area.Id;

            return View(model);
        }

        // GET: Area/Create
        public IActionResult Create()
        {
            var depositoList = _depositoService.GetAll();
            ViewData["Depositos"] = new SelectList(depositoList, "Id", "Name");
            return View();
        }

        // POST: Area/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] AreaViewModel areaView)
        {
            if (ModelState.IsValid)
            {
                
                var area = new Area{
                    Nombre = areaView.Nombre                    
                };
                AreaCreateViewModel nuevaArea = new AreaCreateViewModel();
                var depositos = _depositoService.GetAll().Where(x=> nuevaArea.DepositoIds.Contains(x.Id)).ToList();
                area.Depositos = depositos;
                _areaService.Create(area);

                return RedirectToAction(nameof(Index));
            }
            return View(areaView);
        }

        // GET: Area/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = _areaService.GetById(id.Value);
            if (area == null)
            {
                return NotFound();
            }
            AreaViewModel areaN = new AreaViewModel();
           areaN.Depositos = area.Depositos;
           areaN.Id = area.Id;
           areaN.Nombre = area.Nombre;

            return View(areaN);
        }

        // POST: Area/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] AreaViewModel area)
        {
            if (id != area.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var areaNueva = new Area();
                areaNueva.Id = area.Id;
                areaNueva.Nombre = area.Nombre;
                //areaNueva.Depositos = area.Depositos;//resolver que no tiene depositos
                _areaService.Update(areaNueva);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Area/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var area = _areaService.GetById(id.Value);
            if (area == null)
            {
                return NotFound();
            }
            AreaViewModel areaN = new AreaViewModel();
            areaN.Id = area.Id;

            return View(areaN);
        }

        // POST: Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var area = _areaService.GetById(id);
            
            if (area != null)
            {
                _areaService.Delete(area.Id);
            }
            
            
            return RedirectToAction(nameof(Index));
        }

        private bool AreaExists(int id)
        {
          return _areaService.GetById(id) !=null;
        }
    }
}
