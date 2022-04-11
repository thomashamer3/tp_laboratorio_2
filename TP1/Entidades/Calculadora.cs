using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza las Operaciones Basicas y Regresa el Resultado.
        /// </summary>
        /// <param name="num1">Primer Numero a Operar.
        /// <param name="num2">Segundo Numero a Operar.
        /// <param name="operador">Operador para Realizar el Calculo.
        /// <returns>Regresa el Resultado de la Operacion.
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            char nuevoOperador = ValidarOperador(operador);

            switch (nuevoOperador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;

                case '-':
                    resultado = num1 - num2;
                    break;

                case '*':
                    resultado = num1 * num2;
                    break;

                case '/':
                    resultado = num1 / num2;
                    break;

            }

            return resultado;
        }

        /// <summary>
        /// Valida si el Operador es Valido.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Regresa el Operador Verificado.
        private static char ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }
            return '+';
        }













    }


}


