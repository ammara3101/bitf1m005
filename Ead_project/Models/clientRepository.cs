using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ead_project.Models
{
    public class clientRepository:IDataSource
    {
        public void save(Contact c)
        {
            using(WeddingEntities14 db = new WeddingEntities14())
            {
                db.Contacts.Add(c);
                db.SaveChanges();
            }
        }
        public void save_signup(Signup s)
        {
            using (WeddingEntities14 db = new WeddingEntities14())
            {
                db.Signups.Add(s);
                db.SaveChanges();
            }
        }
        //public Signup login_check(Signup s)
        //{
        //    Signup d;
        //    using (WeddingEntities10 db = new WeddingEntities10())
        //    {
        //        try
        //        {
        //            d = db.Signups.First(x => x.email == s.email && x.password == s.password);

        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //        return d;
        //    }
        //}
        public void register_client(Registeration r)
        {
            using (WeddingEntities14 db = new WeddingEntities14())
            {
                db.Registerations.Add(r);
                db.SaveChanges();
            }
        }
    }
}