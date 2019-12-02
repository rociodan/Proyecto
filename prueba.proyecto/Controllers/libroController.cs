
using prueba.proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba.proyecto.Controllers
{
    public class libroController : Controller
    {
        // GET: libro
        public ActionResult Agregar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Agregar(Book book, IEnumerable<int> autores, IEnumerable<int> generos, IEnumerable<int> publisher)
        {
            AccentureAcademyBookStoreEntities db = new AccentureAcademyBookStoreEntities();

            foreach (int autorActual in autores)
            {
                Author autor = db.Author.Find(autorActual);
                book.Author.Add(autor);
            }

            
            foreach (int generoActual in generos)
            {
                
                Gender genero = db.Gender.Find(generoActual);
                book.Gender.Add(genero);                
            }

            foreach (int publisherActual in publisher)
            {

                Publisher publishers = db.Publisher.Find(publisherActual);
                book.Publisher.Add(publishers);
            }


                        

            db.Book.Add(book);
            db.SaveChanges();
           

            return Content("Libro añadido satisfactoriamente");
        }

        public ActionResult Editar(int id)
        {
            AccentureAcademyBookStoreEntities db = new AccentureAcademyBookStoreEntities();
            Book libro = db.Book.Find(id);
            return View(libro);
        }

        [HttpPost]
        public ActionResult Editar(Book book, IEnumerable<int> autores)
        {
            AccentureAcademyBookStoreEntities db = new AccentureAcademyBookStoreEntities();

            Book libro = db.Book.Find(book.Id);
            libro.Title = book.Title;
            libro.Author.Clear();

            foreach (int autorActual in autores)
            {
                Author escritoPor = db.Author.Find(autorActual);
                libro.Author.Add(escritoPor);
            }

            db.SaveChanges();

            return Content("Libro editado satisfactoriamente");
        }


        public ActionResult Listar()
        {
            AccentureAcademyBookStoreEntities db = new AccentureAcademyBookStoreEntities();
            return View(db.Book.ToList());
        }


        [HttpPost]
        public ActionResult Listar(ListarViewModel filtros)
        {
            AccentureAcademyBookStoreEntities db = new AccentureAcademyBookStoreEntities();

            IQueryable<Book> qry = db.Book;

            if (filtros.FiltroTitulo != null)
            {
                qry = qry.Where(lib => lib.Title.Contains(filtros.FiltroTitulo));
            }

            if (filtros.FiltroGenero.HasValue)
            {
                qry = qry.Where(lib =>
                    lib.Gender.Any(
                           aut => aut.Id.Equals(filtros.FiltroGenero.Value)
                           )
                );
            }

            return View(qry.ToList());
        }

        public ActionResult Eliminar(int Id)
        {
            AccentureAcademyBookStoreEntities db = new AccentureAcademyBookStoreEntities();

            Book book = db.Book.Find(Id);
            db.Book.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Listar");

        }


        
        public ActionResult Author()
        {            
            return View();
        }

         

        [HttpPost]
        public ActionResult Author(Author autores)
        {
            AccentureAcademyBookStoreEntities db = new AccentureAcademyBookStoreEntities();

            db.Author.Add(autores);
            db.SaveChanges();
            return Content("Autor Agregado satisfactoriamente");
        }

        public ActionResult Publisher()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Publisher(Publisher publish)
        {
            AccentureAcademyBookStoreEntities db = new AccentureAcademyBookStoreEntities();

            db.Publisher.Add(publish);
            db.SaveChanges();
            return Content("Editorial Agregada satisfactoriamente");
        }

    }
}
