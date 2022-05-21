using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dhub3.DataServices;

namespace KOC.DHUB3.DataServices.CRUDModels
{
    public class LibraryDocument : ILibraryDocument
    {
        private readonly DataRepo _db;
        
        public LibraryDocument(DataRepo db)
        {
            _db = db;
        }
        public Task DeletDoc(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LibraryDocument> GetDoc(int id)
        {
            var results = await _db.LoadData<LibraryDocument, dynamic>($"select * from"  ,  new { Id = id });
            return results.FirstOrDefault();
        }

        public Task<IEnumerable<LibraryDocument>> GetDoc()
        {
            throw new NotImplementedException();
        }

        public Task InsertDoc(LibraryDocument doc)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoc(LibraryDocument doc)
        {
            throw new NotImplementedException();
        }
    }
    public interface ILibraryDocument
    {
        Task DeletDoc(int id);
        Task<LibraryDocument> GetDoc(int id);
        Task<IEnumerable<LibraryDocument>> GetDoc();
        Task InsertDoc(LibraryDocument doc);
        Task UpdateDoc(LibraryDocument doc);
    }
 
}
