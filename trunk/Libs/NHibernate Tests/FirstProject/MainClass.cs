using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace FirstProject
{
    class MainClass
    {
        public static void Main(String[] args)
        {
            //ISessionFactory sf = new Configuration().Configure().BuildSessionFactory();

            Configuration cfg = new Configuration();
            cfg.Configure("FirstProject", "Person.hbm.xml");
            SchemaExport s = new SchemaExport(cfg);
            s.SetOutputFile("c:/void/schema.sql");
            s.Create(true,false);
            Console.ReadLine();
        }
    }
}
