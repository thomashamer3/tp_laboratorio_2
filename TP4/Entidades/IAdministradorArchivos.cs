namespace Entidades
{
    public interface IAdministradorFiles<T>
    {
        /// <summary>
        /// Exportar() toma un tipo genérico T como parámetro y devuelve un booleano.
        /// </summary>
        /// <param name="T">El tipo de datos que se exportarán.</param>
        bool Exportar(T datos);

        /// <summary>
        /// Importar(string ruta, out T datos)
        /// </summary>
        /// <param name="ruta">La ruta al archivo que se va a importar.</param>
        /// <param name="T">El tipo de datos a importar.</param>
        bool Importar(string ruta, out T datos);
    }
}
