﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Web.Models;
using X.PagedList;

namespace TallerMotos.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IServiceUsuarios _serviceUsuarios;
        private readonly IServiceRol _serviceRol;
        public UsuariosController(IServiceUsuarios serviceUsuarios, IServiceRol serviceRol)
        {
            _serviceUsuarios = serviceUsuarios;
            _serviceRol = serviceRol;
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index(int? page)
        {
            var collection = await _serviceUsuarios.ListAsync();
            ViewData["Title"] = "Index";
            return View(collection.ToPagedList(page ?? 1, 5));
        }

        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var @object = await _serviceUsuarios.FindByIdAsync(id.Value);
                if (@object == null)
                {
                    throw new Exception("Usuarios no existente");
                }
                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult> Create()
        {
            var ListaRol = await _serviceRol.ListAsync();
            if (ListaRol == null || !ListaRol.Any())
            {
                ModelState.AddModelError(string.Empty, "No hay roles disponibles.");
                ViewBag.ListaRol = new SelectList(new List<Rol>(), "ID", "Nombre");
            }
            else
            {
                ViewBag.ListaRol = new SelectList(ListaRol, "ID", "Nombre");
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuariosDTO dto)
        {
            var ListaRol = await _serviceRol.ListAsync();
            if (ListaRol == null || !ListaRol.Any())
            {
                ModelState.AddModelError(string.Empty, "No hay roles disponibles.");
                ViewBag.ListaRol = new SelectList(new List<Rol>(), "ID", "Nombre");
            }
            else
            {
                ViewBag.ListaRol = new SelectList(ListaRol, "ID", "Nombre");
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _serviceUsuarios.AddAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuariosDTO = await _serviceUsuarios.FindByIdAsync(id);
            if (usuariosDTO == null)
            {
                return NotFound();
            }

            // Convertir la lista de roles a SelectList
            var roles = await _serviceRol.ListAsync();
            ViewBag.ListaRol = new SelectList(roles, "ID", "Nombre");

            return View(usuariosDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UsuariosDTO dto)
        {
            if (!ModelState.IsValid)
            {
                //// En caso de error, volver a cargar la lista de roles
                //var roles = await _serviceRol.ListAsync();
                //ViewBag.ListaRol = new SelectList(roles, "ID", "Nombre");

                string errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View(dto);
            }

            // Verificar si se seleccionó un rol válido
            if (dto.IDRol == 0) // O verifica si es null
            {
                ModelState.AddModelError(string.Empty, "Debe seleccionar un rol.");

                // Volver a cargar la lista de roles
                var roles = await _serviceRol.ListAsync();
                ViewBag.ListaRol = new SelectList(roles, "ID", "Nombre");

                return View(dto);
            }

            await _serviceUsuarios.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public IActionResult GetUsuarioByID(int filtro)
        {

            var collections = _serviceUsuarios.FindByIdAsync(filtro).GetAwaiter().GetResult();

            return Json(collections);
        }

        public IActionResult ErrorHandler(string messageJson)
        {
            var errorMessages = JsonConvert.
                DeserializeObject<ErrorMiddlewareViewModel>(messageJson);
            ViewBag.ErrorMessages = errorMessages;
            return View("ErrorHandler");
        }
    }
}
