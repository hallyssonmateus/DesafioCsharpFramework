using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Sistema_peças
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Configuração da string de conexão
                string connectionStr = "Server=localhost\\SQLEXPRESS;Database=SimuladorTelosN8;Trusted_Connection=True;";

                // Configuração do NHibernate
                var config = new NHibernate.Cfg.Configuration();
                config.DataBaseIntegration(x =>
                {
                    x.ConnectionString = connectionStr;
                    x.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                    x.Driver<NHibernate.Driver.SqlClientDriver>();
                });

                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Caminho absoluto para os arquivos de mapeamento
                string pecasMappingPath = Path.Combine(baseDirectory, "Mapping", "Peca.hbm.xml");
                string vendasMappingPath = Path.Combine(baseDirectory, "Mapping", "Vendas.hbm.xml");

                // Adiciona os arquivos de mapeamento
                config.AddFile(pecasMappingPath);
                config.AddFile(vendasMappingPath);

                // Cria o SessionFactory
                var sessionFactory = config.BuildSessionFactory();

                // Testa a conexão com o banco
                using (var session = sessionFactory.OpenSession())
                {
                    Console.WriteLine("Conexão bem-sucedida com o banco de dados!");

                }

                // Inicia a interface gráfica após configurar o NHibernate
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Cadastro()); // Abre o formulário principal
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao configurar o sistema: {ex.Message}");
            }
        }
    }
}
