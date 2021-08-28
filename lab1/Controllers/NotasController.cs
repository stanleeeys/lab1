using lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Console;

namespace lab1.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas
        public ActionResult Index()
        {
            using (Tbl_NotasEntities Alum = new Tbl_NotasEntities())
            {
                var listadoNotas = Alum.TblNotasEstudiante.ToList();
                return View(listadoNotas);


            }

        }


            [HttpPost]
        public ActionResult Save(int id, String nombre, decimal labo1, decimal labo2, decimal labo3, decimal parc1, decimal parc2, decimal parc3, decimal tot)
        {

            using (Tbl_NotasEntities est = new Tbl_NotasEntities())
            {
                TblNotasEstudiante estudiante = new TblNotasEstudiante();

                if (id == 0)
                {

                    estudiante.Alumno = nombre;
                    estudiante.lab1 = labo1;
                    estudiante.lab2 = labo2;
                    estudiante.lab3 = labo3;
                    estudiante.par1 = parc1;
                    estudiante.par2 = parc2;
                    estudiante.par3 = parc3;
                    estudiante.total = tot;
                    est.TblNotasEstudiante.Add(estudiante);
                    est.SaveChanges(); ;
                }
                else
                {
                    int idupdate = id;
                    TblNotasEstudiante editar = est.TblNotasEstudiante.Where(x => x.iDAlumno == idupdate).FirstOrDefault();
                    editar.Alumno = nombre;
                    est.SaveChanges();
                }

            }


            return Redirect("/Index/Index");



        }

        



        public ActionResult Resultado()
        {
            using (Tbl_NotasEntities Alum = new Tbl_NotasEntities())
            {
                var listadoNotas = Alum.TblNotasEstudiante.ToList();
                return View(listadoNotas);
            }
        }

       

    }
   
       

}