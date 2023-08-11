using System;

namespace MVCClinicaMedica.Repository.Servicios.Contrato
{
    public interface IRoleService
    {
        bool EsPaciente(string usuario);
        bool EsMedico(string usuario);
        bool EsAdministrador(string usuario);
    }

}
