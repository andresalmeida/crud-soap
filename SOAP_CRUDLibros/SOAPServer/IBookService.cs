using SOAPServer;
using System.Collections.Generic;
using System.ServiceModel;

namespace SOAPServer
{

    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        Libro CrearLibro(Libro libro);

        [OperationContract]
        Libro ObtenerLibro(int id);

        [OperationContract]
        List<Libro> ObtenerTodosLosLibros();

        [OperationContract]
        Libro ActualizarLibro(Libro libro);

        [OperationContract]
        bool EliminarLibro(int id);
    }
}