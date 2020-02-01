using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroIncripciones.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using RegistroIncripciones.Entidades;
using RegistroIncripciones.DAL;

namespace RegistroIncripciones.BLL.Tests
{
    [TestClass()]
    public class InscripcionesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Inscripciones inscripciones = new Inscripciones();
            inscripciones.InscripcionId = 0;
            inscripciones.PersonaId = 1;
            inscripciones.Monto = 500;
            inscripciones.Comentario = " Abonando 500";
            inscripciones.Fecha = Convert.ToDateTime(value: "12-10-2018");
            paso = BLL.InscripcionesBLL.Guardar(inscripciones);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Inscripciones articulo = new Inscripciones();
            articulo.InscripcionId = 5;
            articulo.PersonaId = 1;
            articulo.Monto = 70000;
            articulo.Comentario = "Primer Pago";
            paso = BLL.InscripcionesBLL.Modificar(articulo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = BLL.InscripcionesBLL.Eliminar(4);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscripciones = new Inscripciones();

            inscripciones = BLL.InscripcionesBLL.Buscar(5);
            Assert.IsNotNull(inscripciones);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = BLL.InscripcionesBLL.GetList(x => true);

            Assert.IsNotNull(lista);
        }
    }
}