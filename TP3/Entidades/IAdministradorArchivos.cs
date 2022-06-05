namespace Entidades
{
    public interface IAdministradorFiles<T>
    {
        bool Exportar(T datos);
        bool Importar(string ruta, out T datos);
    }
}
