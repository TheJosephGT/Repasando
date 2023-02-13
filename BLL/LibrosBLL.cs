using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class LibrosBLL{
    private Contexto _contexto;

    public LibrosBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int libroId) {return _contexto.Libros.Any(o => o.LibroId == libroId);}

    private bool Insertar(Libros libro)
    {
        _contexto.Libros.Add(libro);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Libros libro)
    {
        _contexto.Entry(libro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Libros libro)
    {
        
        if (!Existe(libro.LibroId))
            return this.Insertar(libro);
        else
            return this.Modificar(libro);
    }

    private bool Eliminar(Libros libro)
    {
        _contexto.Entry(libro).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Libros? Buscar(int libroId)
    {
        return _contexto.Libros.Where(o => o.LibroId == libroId).AsNoTracking().SingleOrDefault();
    }

    public List<Libros> GetList(Expression<Func<Libros, bool>> criterio)
    {
        return _contexto.Libros.AsNoTracking().Where(criterio).ToList();
    }
}