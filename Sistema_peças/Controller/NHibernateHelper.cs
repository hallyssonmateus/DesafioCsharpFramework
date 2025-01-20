using System;
using System.IO;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace Sistema_peças.Controller
{
    internal class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        // Propriedade para obter a fábrica de sessões
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    string connectionStr = "Server=localhost\\SQLEXPRESS;Database=SimuladorTelosN8;Trusted_Connection=True;";

                    // Configurar o NHibernate
                    var config = new Configuration();
                    config.DataBaseIntegration(x =>
                    {
                        x.ConnectionString = connectionStr;
                        x.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                        x.Driver<NHibernate.Driver.SqlClientDriver>();
                    });

                    // Definir o caminho dos arquivos de mapeamento
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string pecaMappingPath = Path.Combine(baseDirectory, "Mapping", "Peca.hbm.xml");
                    string vendasMappingPath = Path.Combine(baseDirectory, "Mapping", "Vendas.hbm.xml");

                    // Adicionar os arquivos de mapeamento
                    config.AddFile(pecaMappingPath);
                    config.AddFile(vendasMappingPath);

                    // Criar a fábrica de sessões
                    _sessionFactory = config.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        // Método para abrir uma nova sessão
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
