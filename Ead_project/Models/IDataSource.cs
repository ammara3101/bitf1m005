using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ead_project.Models
{
    public interface IDataSource
    {
       void save(Contact c);
       void save_signup(Signup s);
       //Signup login_check(Signup s);
       void register_client(Registeration r);
    }
}
