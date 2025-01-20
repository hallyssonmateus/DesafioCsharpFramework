using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Sistema_peças.Model;

namespace Sistema_peças.Controller
{
    internal class PecaController
    {
        // Método para cadastrar uma nova peça
        public bool CadastrarPeca(Peca peca)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession()) // Alteração aqui
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(peca); // Salva a peça no banco de dados
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

        public List<Peca> PesquisarPeça(int? id = null, string nome = null)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession()) // Alteração aqui
                {
                    // Inicia a query base
                    var query = session.Query<Peca>().AsQueryable();

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
                return new List<Peca>(); // Retorna uma lista vazia em caso de erro
            }
        }

        // Método para atualizar os dados de uma peça
        public bool AtualizarPeca(Peca peca)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var pecaExistente = session.Get<Peca>(peca.Id);
                        if (pecaExistente != null)
                        {
                            pecaExistente.Nome = peca.Nome;
                            pecaExistente.PrecoCompra = peca.PrecoCompra;
                            pecaExistente.PrecoVenda = peca.PrecoVenda;

                            session.Update(pecaExistente); // Atualiza a peça no banco de dados
                            transaction.Commit(); // Confirma a transação
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Peça não encontrada.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar peça: {ex.Message}");
                return false;
            }
        }

        // Método para excluir uma peça
        public bool ExcluirPeca(int id)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var peca = session.Get<Peca>(id);
                        if (peca != null)
                        {
                            session.Delete(peca); // Exclui a peça do banco de dados
                            transaction.Commit(); // Confirma a transação
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Peça não encontrada.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir peça: {ex.Message}");
                return false;
            }
        }

        // Método para listar todas as peças
        public List<Peca> ListarPecas()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    return session.Query<Peca>().ToList(); // Retorna todas as peças do banco de dados
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar peças: {ex.Message}");
                return new List<Peca>(); // Retorna uma lista vazia em caso de erro
            }
        }

    }
}
