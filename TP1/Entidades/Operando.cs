using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Inicializa el Numero en 0.
        /// </summary>
        public Operando(): this(0)
        {
          
        }

        /// <summary>
        /// Asigna el Valor a Numero.
        /// </summary>
        /// <param name="numero">Valor a Asignar.
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Asigna el Numero en Formato String y Convertirlo.
        /// </summary>
        /// <param name="strNumero">Numero a Asginar y Convertir.
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Valida el Numero y lo Setea.
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Verifica el Numero Recibido y lo Convierte a un Double.
        /// </summary>
        /// <param name="numero">Numero en Formato String.
        /// <returns>El Numero en Formato Double.
        private double ValidarOperando(string strNumero)
        {
            if (Double.TryParse(strNumero, out double nuevoNumero))
            {
                return nuevoNumero;
            }

            return -1;
        }

        /// <summary>
        /// Convierte el Valor a un Numero Decimal.
        /// </summary>
        /// <param name="binario">Numero en Formato String a Convertir.
        /// <returns>Regresa el Numero Decimal Convertido.
        public string BinarioDecimal(string binario)
        {
            char[] cadenaBinaria = binario.ToCharArray();
            int decimalBinario = 0;
            string mensajeError = "Valor inválido.";
            int tam = cadenaBinaria.Length;

            Array.Reverse(cadenaBinaria);

            if (EsBinario(binario))
            {
                for (int i = 0; i < tam; i++)
                {
                    if (cadenaBinaria[i] == '1')
                    {
                        decimalBinario += (int)Math.Pow(2, i);
                    }
                }

                return decimalBinario.ToString();
            }

            return mensajeError;
        }

        /// <summary>
        /// Convierte el Numero de Tipo Double a un Binario en Formato String.
        /// </summary>
        /// <param name="numero">Numero a Convertir.
        /// <returns>Una Cadena Binaria Formato String.
        public string DecimalBinario(double numero)
        {
            string cadenaBinaria = string.Empty;
            int numeroEntero = (int)Math.Abs(numero);

            if (numeroEntero == 0)
            {
                cadenaBinaria = "0";
            }
            else
            {
                while (numeroEntero > 0)
                {
                    cadenaBinaria = (int)numeroEntero % 2 + cadenaBinaria;
                    numeroEntero = (int)numeroEntero / 2;
                }
            }

            return cadenaBinaria;
        }

        /// <summary>
        /// Convierte un Numero String a un Binario en Formato String.
        /// </summary>
        /// <param name="numero">Numero en Foramto String a Convertir.
        /// <returns>El Numero Convertido.
        public string DecimalBinario(string numero)
        {
            if (Double.TryParse(numero, out double nuevoNumero))
            {
                return DecimalBinario(nuevoNumero);
            }

            return "Valor inválido.";
        }

        /// <summary>
        /// Verifica si La Cadena Binaria en Formato String es Binaria.
        /// </summary>
        /// <param name="binario">Cadena Binaria a Validar.
        /// <returns>Regresa un Booleano True si es Binaria.
        private bool EsBinario(string binario)
        {
            int tam = binario.Length;
            for (int i = 0; i < tam - 1; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Realiza la Suma de Dos Numeros.
        /// </summary>
        /// <param name="n1">Primer Numero a Sumar.
        /// <param name="n2">Segundo Numero a Sumar.
        /// <returns>Regresa la Suma de los Numeros.
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza la Resta de Dos Numeros.
        /// </summary>
        /// <param name="n1">Primer Numero a Restar.
        /// <param name="n2">Segundo Numero a Restar.
        /// <returns>Regresa la Resta de los Numeros.
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la Multiplicacion de Dos Numeros.
        /// </summary>
        /// <param name="n1">Primer Numero a Multiplicar.
        /// <param name="n2">Segundo Numero a Multiplicar.
        /// <returns>Regresa la Multiplicacion de los Numeros.
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la Division de Dos Numeros.
        /// </summary>
        /// <param name="n1">Primer Numero a Dividir.
        /// <param name="n2">Segundo Numero a Dividir.
        /// <returns>Regresa la Division de los Numeros.
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }

            return n1.numero / n2.numero;
        }

    }





}

