using System.Collections.Generic;

namespace IBlog.Entities
{
    public class AppUserEntity:ITable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public List<BlogEntity> Blogs { get; set; }
    }
}
