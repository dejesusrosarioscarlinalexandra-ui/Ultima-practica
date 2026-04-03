using Bookcase.Database;
using Bookcase.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookcase.Repository;

public class MiembroRepository
{
    private readonly AppDbContext _context;

    public MiembroRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<MiembroModel> SelectAll()
    {
        return _context.Miembros.ToList();
    }

    public MiembroModel? GetByCedula(string cedula)
    {
        return _context.Miembros
            .FirstOrDefault(m => m.Cedula == cedula);
    }

    public void Insert(string nombre, string cedula, string telefono)
    {
        var miembro = new MiembroModel
        {
            NombreCompleto = nombre,
            Cedula = cedula,
            Telefono = telefono
        };

        _context.Miembros.Add(miembro);
        _context.SaveChanges();
    }

    public void UpdateTelefono(string telefono, string cedula)
    {
        var miembro = _context.Miembros
            .FirstOrDefault(m => m.Cedula == cedula);

        if (miembro != null)
        {
            miembro.Telefono = telefono;
            _context.SaveChanges();
        }
    }

    public void Delete(string cedula)
    {
        var miembro = _context.Miembros
            .FirstOrDefault(m => m.Cedula == cedula);

        if (miembro != null)
        {
            _context.Miembros.Remove(miembro);
            _context.SaveChanges();
        }
    }
}