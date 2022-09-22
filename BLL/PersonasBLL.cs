using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class PersonasBLL{
    private Contexto _contexto;

    public PersonasBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int personaId){
        return _contexto.Personas.Any(o => o.PersonaId == personaId);
    }

    private bool Insertar(Personas persona){
        _contexto.Personas.Add(persona);
        return _contexto.SaveChanges()> 0;
    }

    private bool Modificar(Personas persona){
        _contexto.Entry(persona).State = EntityState.Modified;
        return _contexto.SaveChanges()> 0;
    }

    public bool Guardar(Personas persona){
        if (!Existe(persona.PersonaId))
            return this.Insertar(persona);
        else
            return this.Modificar(persona);
    }

    public bool Eliminar(Personas persona){
        _contexto.Entry(persona).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public List<Personas> GetList(Expression<Func<Personas, bool>> Criterio){
            return _contexto.Personas
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
}