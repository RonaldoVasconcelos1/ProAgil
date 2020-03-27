using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Evento[]> GetAllEventosByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosByEvento(bool includePalestrantes);
        Task<Evento[]> GetAllEventosById(int EventoId, bool includePalestrantes);

        //Palestrantes
        Task<Evento[]> GetAllPalestranteByNome(bool includePalestrantes);
        Task<Evento[]> GetAllPalestranteByNome(int PalestranteId,bool includePalestrantes);

        
    }
}