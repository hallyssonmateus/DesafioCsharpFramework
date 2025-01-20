using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Sistema_peças.Model;

namespace Sistema_peças.Controller
{
    internal class PeçaController
    {
        // Método para cadastrar uma nova peça
        public bool CadastrarPeça(Peça peça)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession()) // Alteração aqui
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(peça); // Salva a peça no banco de dados
                        transaction.Commit(); // Confirma a transação
                    }
                }
                return true; // Indica sucesso
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar peça: {ex.Message}");
                return false; // Indica falha
            }
        }

        public List<Peça> PesquisarPeça(int? id = null, string nome = null)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession()) // Alteração aqui
                {
                    // Inicia a query base
                    var query = session.Query<Peça>().AsQueryable();

                    // Aplica os filtros
                    if (id.HasValue)
                        query = query.Where(p => p.Id == id.Value);

                    if (!string.IsNullOrWhiteSpace(nome))
                        query = query.Where(p => p.Nome.Contains(nome));

                    // Retorna os resultados como uma lista
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao pesquisar peça: {ex.Message}");
                return new List<Peça>(); // Retorna uma lista vazia em caso de erro
            }
        }

    }
}
