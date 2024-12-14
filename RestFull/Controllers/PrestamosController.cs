using System;
using System.Collections.Generic;
using System.Web.Http;
using Entities;
using BLL;

namespace APIRestFull.Controllers
{
    public class PrestamosController : ApiController
    {
        // Crear préstamo
        [HttpPost]
        [Route("api/Prestamos")]
        public IHttpActionResult CreatePrestamo(PrestamosLibros prestamo)
        {
            if (prestamo == null)
                return BadRequest("El préstamo no puede ser nulo.");

            var _prestamosLogic = new PrestamosLogic();

            try
            {
                var createdPrestamo = _prestamosLogic.Create(prestamo);
                return Created($"api/Prestamos/{createdPrestamo.PrestamoID}", createdPrestamo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el préstamo: {ex.Message}");
            }
        }

        // Eliminar préstamo
        [HttpDelete]
        [Route("api/Prestamos/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var _prestamosLogic = new PrestamosLogic();
            var result = _prestamosLogic.Delete(id);

            if (result)
                return Ok("Préstamo eliminado correctamente.");
            else
                return NotFound();
        }

        // Obtener todos los préstamos
        [HttpGet]
        [Route("api/Prestamos")]
        public IHttpActionResult GetAll()
        {
            var _prestamosLogic = new PrestamosLogic();
            try
            {
                var prestamos = _prestamosLogic.RetrieveAll();
                if (prestamos == null || prestamos.Count == 0)
                    return NotFound();

                return Ok(prestamos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Obtener préstamo por ID
        [HttpGet]
        [Route("api/Prestamos/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var _prestamosLogic = new PrestamosLogic();
            try
            {
                var prestamo = _prestamosLogic.RetrieveById(id);
                if (prestamo == null)
                    return NotFound();

                // Crear un objeto anónimo para devolver solo las propiedades necesarias
                var response = new
                {
                    prestamo.PrestamoID,
                    prestamo.LibroID,
                    prestamo.UsuarioID,
                    prestamo.FechaPrestamo,
                    prestamo.FechaDevolucion,
                    prestamo.Estado
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Actualizar préstamo
        [HttpPut]
        [Route("api/Prestamos/{id:int}")]
        public IHttpActionResult UpdatePrestamo(int id, PrestamosLibros prestamo)
        {
            if (prestamo == null)
                return BadRequest("El préstamo no puede ser nulo.");

            if (id != prestamo.PrestamoID)
                return BadRequest("El ID del préstamo no coincide con el ID de la URL.");

            var _prestamosLogic = new PrestamosLogic();

            try
            {
                var updated = _prestamosLogic.Update(prestamo);
                if (updated)
                    return Ok("Préstamo actualizado correctamente.");
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el préstamo: {ex.Message}");
            }
        }
    }
}
