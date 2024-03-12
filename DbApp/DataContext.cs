using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbApp
{
    public class DataContext
    {
        private FirebaseClient firebase;
        public DataContext(string databaseUrl)
        {
            firebase = new FirebaseClient(databaseUrl);
        }
        public async Task<List<Worker>> GetAllWorkers()
        {
            var students = await firebase
            .Child("Workers")
            .OnceAsync<Worker>();

            return students.Select(item => new Worker
            {
                Id = item.Object.Id,
                FirstName = item.Object.FirstName,
                LastName = item.Object.LastName
            }).ToList();

        }

        public async Task AddPerson(Worker stud)
        {
            await firebase
                .Child("Workers")
                .PostAsync(new Worker()
                {
                    Id = Guid.NewGuid(),
                    FirstName = stud.FirstName,
                    LastName = stud.LastName,
                });
        }
    }
}
