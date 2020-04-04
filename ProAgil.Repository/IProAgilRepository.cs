using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        //Gerais Todas Entidades tem que ter esse Crud
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetEventosAsyncById(int EventoId, bool includePalestrantes);

        //Palestrantes
        Task<Palestrante[]> GetAllPalestranteAsyncByNome(string name,bool includeEventos);
        Task<Palestrante> GetAllPalestranteAsync(int PalestranteId,bool includeEventos);

        
    }
}