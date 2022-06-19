﻿using Entidades;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo El Gimnasio con 15 de Capacidad Maxima.
            Gimnasio gimnasio = new Gimnasio(15);

            //Creo Los Socios.
            Socio socio1 = new Socio("Juan", "Perez", "MASCULINO", 32782935, Socio.EPase.Libre, Socio.EStatus.Activo, Socio.EPago.Debito);
            Socio socio2 = new Socio("Manuel", "Garcia", "MASCULINO", 53646775, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Efectivo);
            Socio socio3 = new Socio("Elias", "Gimenez", "MASCULINO", 32846478, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Credito);
            Socio socio4 = new Socio("Jalil", "Di Palma", "MASCULINO", 38748369, Socio.EPase.Gympass, Socio.EStatus.Inactivo, Socio.EPago.Credito);
            Socio socio5 = new Socio("Malena", "Da Silva", "FEMENINO", 11111, Socio.EPase.Libre, Socio.EStatus.Activo, Socio.EPago.Efectivo);
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
            Socio socio17 = new Socio("Aldana", "De Paul", "FEMENINO", 57731218, Socio.EPase.Gympass, Socio.EStatus.Activo, Socio.EPago.Efectivo);

            //TEST METODO AGREGAR
            gimnasio.Agregar(socio1);
            gimnasio.Agregar(socio2);
            gimnasio.Agregar(socio3);
            gimnasio.Agregar(socio4);

            if (gimnasio.Agregar(socio4))
            {
                Console.WriteLine("El Socio ya se Encuentra Ingresado!");
            }

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

            //TEST EXCEPTION
            try
            {
                gimnasio.Agregar(socio17);
            }
            catch (CapacidadMaximaException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(gimnasio.ToString());

            //TEST METODO ==
            Console.WriteLine("Test Metodo ==");
            Console.WriteLine(socio15 == socio14);//False
            Console.WriteLine(socio5 == socio6);//True
            Console.WriteLine(socio8 == socio10);//False

            //TEST METODO REMOVER
            Console.WriteLine("\nTest Metodo Remover");
            gimnasio.Remover(socio9);
            gimnasio.Remover(socio11);
            gimnasio.Remover(socio13);

            //TEST MOSTRAR GYM
            Console.WriteLine(gimnasio.ToString());
            Console.ReadKey();
        }
    }
}
