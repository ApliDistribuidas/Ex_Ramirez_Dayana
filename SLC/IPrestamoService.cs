using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace SLC
{
    public interface IPrestamosService
    {
        PrestamosLibros CreateAsistentes(PrestamosLibros prestamoslibros);
        bool Delete(int id);
        List<PrestamosLibros> GetAll();
        PrestamosLibros GetById(int id);
        bool UpdateProduct(PrestamosLibros prestamoslibros);
    }
}
