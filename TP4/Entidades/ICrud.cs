using System.Collections.Generic;

namespace Entidades
{
    public interface ICrud
    {
        List<Socio> ListarSocios();
        Socio BuscarPorID(int id);
        bool EliminarSocio(int id);
        bool EditarSocio(Socio socio);
        bool GuardarSocio(Socio socio);
    }
}
