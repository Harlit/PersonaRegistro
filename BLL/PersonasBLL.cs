using Microsoft.EntityFrameworkCore;


public class PersonasBLL{
        private Contexto _contexto;
       public static bool Guardar(Personas persona)
        {
            if (!Existe(persona.PersonaId))//si no existe insertamos
                return Insertar(persona);
            else
                return Modificar(persona);
        }
        

         public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Personas.Any(o => o.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        private static bool Insertar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                
                contexto.Personas.Add(persona);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        
        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM NombreCompleto n Where PersonaId = {persona.PersonaId}");

                foreach (var item in persona.NombreCompleto)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(persona).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        
       public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var persona = contexto.Personas.Find(id);
                
                if (persona != null)
                {
                    contexto.Personas.Remove(persona);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

           

        

}
