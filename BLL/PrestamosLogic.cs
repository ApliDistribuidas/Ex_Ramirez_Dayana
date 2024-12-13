using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class PrestamosLogic
    {
        public PrestamosLibros Create(PrestamosLibros prestamo)
        {
            PrestamosLibros _prestamo = null;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                // Verifica si ya existe un préstamo con el mismo LibroID y UsuarioID
                PrestamosLibros _result = repository.Retrieve<PrestamosLibros>(p => p.LibroID == prestamo.LibroID && p.UsuarioID == prestamo.UsuarioID && p.Estado == "Pendiente");

                if (_result == null)
                {
                    _prestamo = repository.Create(prestamo);
                }
                else
                {
                    throw new Exception("Ya existe un préstamo pendiente para este libro y usuario.");
                }
            }

            return _prestamo; // Retorna el préstamo creado.
        }

        public PrestamosLibros RetrieveById(int id)
        {
            PrestamosLibros _prestamo = null;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                _prestamo = repository.Retrieve<PrestamosLibros>(p => p.PrestamoID == id);
            }
            return _prestamo;
        }

        public bool Update(PrestamosLibros prestamo)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                // Busca el préstamo original en la base de datos
                var existingPrestamo = repository.Retrieve<PrestamosLibros>(p => p.PrestamoID == prestamo.PrestamoID);

                if (existingPrestamo == null)
                {
                    throw new Exception("El préstamo no existe.");
                }

                // Actualiza manualmente las propiedades necesarias
                existingPrestamo.LibroID = prestamo.LibroID;
                existingPrestamo.UsuarioID = prestamo.UsuarioID;
                existingPrestamo.FechaPrestamo = prestamo.FechaPrestamo;
                existingPrestamo.FechaDevolucion = prestamo.FechaDevolucion;
                existingPrestamo.Estado = prestamo.Estado;

                // Guarda los cambios
                return repository.Update(existingPrestamo);
            }
        }

        public bool Delete(int id)
        {
            bool _delete = false;
            var _prestamo = RetrieveById(id);
            if (_prestamo != null)
            {
                using (var repository = RepositoryFactory.CreateRepository())
                {
                    _delete = repository.Delete(_prestamo);
                }
            }
            return _delete;
        }

        public List<PrestamosLibros> RetrieveAll()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                // Usar una expresión lambda para devolver una lista de préstamos
                var prestamos = repository.Filter<PrestamosLibros>(p => p.PrestamoID > 0).ToList();
                return prestamos;
            }
        }
    }
}