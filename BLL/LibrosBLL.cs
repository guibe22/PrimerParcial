using Microsoft.EntityFrameworkCore;
public class LibrosBLL
{
    Contexto _Contexto;
    public LibrosBLL(Contexto Contexto) 
    {
        this._Contexto= Contexto;
    }

    public bool Existe(int LibroId){
         return _Contexto.Libros.Any(o=> o.LibroId==LibroId);
    }

    private bool Insertar (Libros libro){
         _Contexto.Libros.Add(libro);
         return _Contexto.SaveChanges() >0;
    }

    private bool Modificar (Libros libro){
         _Contexto.Entry(libro).State = EntityState.Modified;
         return  _Contexto.SaveChanges() >0;
    }

    public bool Guardar( Libros libro){
         if(!Existe(libro.LibroId)){
             return this.Insertar(libro);
         }
         else{
             return this.Modificar(libro);
         }
    }

    public Libros? Buscar(int LibroId){
         return _Contexto.Libros.Where(o => o.LibroId== LibroId).AsTracking().SingleOrDefault();
    }



}