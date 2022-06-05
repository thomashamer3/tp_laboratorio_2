using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class TestGym
    {
        /// <summary>
        /// Valida que se puedan Agregar Socios Correctamente.
        /// </summary>
        [TestMethod]
        public void AgregarSocios_Ok()
        {
            //Arrange
            Gimnasio gimnasio = new Gimnasio(15);
            Socio socio1 = new Socio("Juan", "Perez", "MASCULINO", 32782935, Socio.EPase.Libre, Socio.EStatus.Activo, Socio.EPago.Debito);
            Socio socio2 = new Socio("Manuel", "Garcia", "MASCULINO", 53646775, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Efectivo);
            Socio socio3 = new Socio("Elias", "Gimenez", "MASCULINO", 32846478, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Credito);
            Socio socio4 = new Socio("Jalil", "Di Palma", "MASCULINO", 38748369, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Credito);
            Socio socio5 = new Socio("Malena", "Da Silva", "FEMENINO", 11111, Socio.EPase.Libre, Socio.EStatus.Activo, Socio.EPago.Efectivo);
            Socio socio6 = new Socio("Rocio", "Colerio", "FEMENINO", 11111023, Socio.EPase.Musculacion, Socio.EStatus.Activo, Socio.EPago.Debito);

            int espacioLibreEsperado = 9;
            int espacioLibre = 0;

            //Act
            gimnasio.Agregar(socio1);
            gimnasio.Agregar(socio2);
            gimnasio.Agregar(socio3);
            gimnasio.Agregar(socio4);
            gimnasio.Agregar(socio5);
            gimnasio.Agregar(socio6);

            espacioLibre = gimnasio.LugaresLibres;

            //Assert
            Assert.AreEqual(espacioLibre, espacioLibreEsperado);
        }

        /// <summary>
        /// Valida que se Puedan Eliminar Socios Correctamente.
        /// </summary>
        [TestMethod]
        public void EliminarSocios_Ok()
        {
            //Arrange
            Gimnasio gimnasio = new Gimnasio(15);
            Socio socio1 = new Socio("Juan", "Perez", "MASCULINO", 32782935, Socio.EPase.Libre, Socio.EStatus.Activo, Socio.EPago.Debito);
            Socio socio2 = new Socio("Manuel", "Garcia", "MASCULINO", 53646775, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Efectivo);
            Socio socio3 = new Socio("Elias", "Gimenez", "MASCULINO", 32846478, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Credito);
            Socio socio4 = new Socio("Jalil", "Di Palma", "MASCULINO", 38748369, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Credito);
            Socio socio5 = new Socio("Malena", "Da Silva", "FEMENINO", 11111, Socio.EPase.Libre, Socio.EStatus.Activo, Socio.EPago.Efectivo);
            Socio socio6 = new Socio("Rocio", "Colerio", "FEMENINO", 11111023, Socio.EPase.Musculacion, Socio.EStatus.Activo, Socio.EPago.Debito);

            int espacioLibreEsperado = 12;
            int espacioLibre = 0;

            //Act
            gimnasio.Agregar(socio1);
            gimnasio.Agregar(socio2);
            gimnasio.Agregar(socio3);
            gimnasio.Agregar(socio4);
            gimnasio.Agregar(socio5);
            gimnasio.Agregar(socio6);

            gimnasio.Remover(socio1);
            gimnasio.Remover(socio3);
            gimnasio.Remover(socio6);
            espacioLibre = gimnasio.LugaresLibres;

            //Assert
            Assert.AreEqual(espacioLibre, espacioLibreEsperado);
        }

        /// <summary>
        /// Valida que no se puedan Agregar Socios una vez Alcancazada La Capacidad Maxima.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CapacidadMaximaException))]
        public void AgregarSocios_Exception()
        {
            //Arrange
            Gimnasio gimnasio = new Gimnasio(15);
            Socio socio1 = new Socio("Juan", "Perez", "MASCULINO", 32782935, Socio.EPase.Libre, Socio.EStatus.Activo, Socio.EPago.Debito);
            Socio socio2 = new Socio("Manuel", "Garcia", "MASCULINO", 53646775, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Efectivo);
            Socio socio3 = new Socio("Elias", "Gimenez", "MASCULINO", 32846478, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Credito);
            Socio socio4 = new Socio("Jalil", "Di Palma", "MASCULINO", 38748369, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Credito);
            Socio socio5 = new Socio("Malena", "Da Silva", "FEMENINO", 111110, Socio.EPase.Libre, Socio.EStatus.Activo, Socio.EPago.Efectivo);
            Socio socio6 = new Socio("Rocio", "Colerio", "FEMENINO", 11111, Socio.EPase.Musculacion, Socio.EStatus.Activo, Socio.EPago.Debito);
            Socio socio7 = new Socio("Guadalupe", "Caneda", "FEMENINO", 18399660, Socio.EPase.Libre, Socio.EStatus.Inactivo, Socio.EPago.Credito);
            Socio socio8 = new Socio("Camila", "Jerez", "FEMENINO", 52816305, Socio.EPase.Musculacion, Socio.EStatus.Activo, Socio.EPago.Debito);
            Socio socio9 = new Socio("Camille", "Susama", "FEMENINO", 66922239, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Efectivo);
            Socio socio10 = new Socio("Diego", "Montoya", "MASCULINO", 62762834, Socio.EPase.Musculacion, Socio.EStatus.Activo, Socio.EPago.Credito);
            Socio socio11 = new Socio("Nicolas", "Rivero", "MASCULINO", 13215691, Socio.EPase.Libre, Socio.EStatus.Inactivo, Socio.EPago.Debito);
            Socio socio12 = new Socio("Lionel", "Santos", "MASCULINO", 53927654, Socio.EPase.Musculacion, Socio.EStatus.Activo, Socio.EPago.Credito);
            Socio socio13 = new Socio("Celeste", "Marinez", "FEMENINO", 38254118, Socio.EPase.Gympass, Socio.EStatus.Activo, Socio.EPago.Efectivo);
            Socio socio14 = new Socio("Martina", "Baez", "FEMENINO", 48980060, Socio.EPase.Musculacion, Socio.EStatus.Inactivo, Socio.EPago.Debito);
            Socio socio15 = new Socio("Patricia", "Castro", "FEMENINO", 69480043, Socio.EPase.Libre, Socio.EStatus.Inactivo, Socio.EPago.Efectivo);
            Socio socio16 = new Socio("Pia", "Gonzales", "FEMENINO", 63931059, Socio.EPase.Musculacion, Socio.EStatus.Activo, Socio.EPago.Debito);

            //Act
            gimnasio.Agregar(socio1);
            gimnasio.Agregar(socio2);
            gimnasio.Agregar(socio3);
            gimnasio.Agregar(socio4);
            gimnasio.Agregar(socio5);
            gimnasio.Agregar(socio6);
            gimnasio.Agregar(socio7);
            gimnasio.Agregar(socio8);
            gimnasio.Agregar(socio9);
            gimnasio.Agregar(socio10);
            gimnasio.Agregar(socio11);
            gimnasio.Agregar(socio12);
            gimnasio.Agregar(socio13);
            gimnasio.Agregar(socio14);
            gimnasio.Agregar(socio15);
            gimnasio.Agregar(socio16);
        }
    }
}
