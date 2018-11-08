using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Domain.Interfaces;
using Teste.Domain.Repositories;
using Teste.Infrastructure.Utilities;

namespace Teste.Domain.Entities
{
    public class Feed
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Feed> GetDezTopicos()
        {
            IRepository repository = new FeedRepository();

            return repository.Get().Take(Constants.QUANTIDADE_TOPICOS).ToList();            
        }

        public List<string> GetTotalPalavras(List<Feed> dezTopicos)
        {
            List<string> palavras = new List<string>();
            List<string> totalPalavras = new List<string>();

            dezTopicos.ForEach(item => {
                palavras = item.Description.Split(' ').ToList();
                palavras.ForEach(palavra => { totalPalavras.Add(palavra); });
            });

            return totalPalavras;
        }

        public List<string> DeleteArtigosPreposicoes(List<string> totalPalavras)
        {
            List<string> palavras = new List<string>();

            totalPalavras.ForEach(item => {
                var contemArtigoOuPreposicao = Constants.ARTIGOS_PREPOSICOES.Contains(item.ToLower());

                if (!contemArtigoOuPreposicao)
                    palavras.Add(item);
            });

            return palavras;
        }

        public List<Word> GetDezPalavrasAbordadasQtdeVezes(List<string> palavras)
        {
            var palavrasAbordadas = palavras.GroupBy(g => g).ToList().OrderByDescending(o => o.Count()).Take(10).ToList();

            List<Word> words = new List<Word>();
            
            palavrasAbordadas.ForEach(item => {
                Word word = new Word();

                word.Palavra = item.Key;
                word.QuantidadeVezes = item.Count();

                words.Add(word);
            });

            return words;
        }

        public List<int> GetQtdePalavrasPorTopico(List<Feed> dezTopicos)
        {
            List<string> palavras = new List<string>();
            List<int> qtdePalavrasPorTopico = new List<int>();

            dezTopicos.ForEach(item => {
                palavras = item.Description.Split(' ').ToList();
                qtdePalavrasPorTopico.Add(palavras.Count());
            });

            return qtdePalavrasPorTopico;
        }
    }
}
