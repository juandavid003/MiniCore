using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1;

namespace YourNamespace.Controllers
{
    public class GastosController : Controller
    {
        private readonly MiniCoreEntities _context;

        public GastosController()
        {
            _context = new MiniCoreEntities(); // Inicializa el contexto de la base de datos
        }

        // Método para filtrar y calcular gastos
        public ActionResult FiltrarGastos(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaInicio > fechaFin)
                {
                    return Json(new { error = "La fecha de inicio no puede ser mayor que la fecha de fin." }, JsonRequestBehavior.AllowGet);
                }

                var gastos = _context.Gastoes
                    .Where(g => g.fecha >= fechaInicio && g.fecha <= fechaFin)
                    .Select(g => new GastoModel
                    {
                        Id = g.id,
                        Fecha = g.fecha,
                        Descripcion = g.descripcion,
                        Monto = g.monto,
                        Empleado = g.Empleado.nombre,
                        Departamento = g.Departamento.nombre
                    })
                    .ToList();

                var montoTotal = gastos.Sum(g => g.Monto);

                // Asignar los resultados al ViewBag para la vista
                ViewBag.Gastos = gastos;
                ViewBag.MontoTotal = montoTotal;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // Crear un empleado
        [HttpPost]
        public ActionResult CrearEmpleado(string nombre, int id)
        {
            try
            {
                var empleado = new Empleado
                {
                    nombre = nombre,
                    id = id
                };
                _context.Empleadoes.Add(empleado);
                _context.SaveChanges();
                return Json(new { success = true, message = "Empleado creado con éxito." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        // Eliminar un empleado
        [HttpPost]
        public ActionResult EliminarEmpleado(int id)
        {
            try
            {
                var empleado = _context.Empleadoes.Find(id);
                if (empleado == null) return Json(new { success = false, error = "Empleado no encontrado." });

                _context.Empleadoes.Remove(empleado);
                _context.SaveChanges();
                return Json(new { success = true, message = "Empleado eliminado con éxito." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        // Crear un departamento
        [HttpPost]
        public ActionResult CrearDepartamento(string nombre, int id)
        {
            try
            {
                var departamento = new Departamento
                {
                    nombre = nombre,
                    id = id
                };
                _context.Departamentoes.Add(departamento);
                _context.SaveChanges();
                return Json(new { success = true, message = "Departamento creado con éxito." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        // Eliminar un departamento
        [HttpPost]
        public ActionResult EliminarDepartamento(int id)
        {
            try
            {
                var departamento = _context.Departamentoes.Find(id);
                if (departamento == null) return Json(new { success = false, error = "Departamento no encontrado." });

                _context.Departamentoes.Remove(departamento);
                _context.SaveChanges();
                return Json(new { success = true, message = "Departamento eliminado con éxito." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        // Crear un gasto
        [HttpPost]
        public ActionResult CrearGasto(DateTime fecha, string descripcion, decimal monto, int idEmpleado, int idDepartamento)
        {
            try
            {
                var gasto = new Gasto
                {
                    fecha = fecha,
                    descripcion = descripcion,
                    monto = monto,
                    id_empleado = idEmpleado,
                    id_departamento = idDepartamento
                };
                _context.Gastoes.Add(gasto);
                _context.SaveChanges();
                return Json(new { success = true, message = "Gasto creado con éxito." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        // Eliminar un gasto
        [HttpPost]
        public ActionResult EliminarGasto(int id)
        {
            try
            {
                var gasto = _context.Gastoes.Find(id);
                if (gasto == null) return Json(new { success = false, error = "Gasto no encontrado." });

                _context.Gastoes.Remove(gasto);
                _context.SaveChanges();
                return Json(new { success = true, message = "Gasto eliminado con éxito." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
