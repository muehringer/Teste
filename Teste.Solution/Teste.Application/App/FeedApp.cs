using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Application.Interfaces;
using Teste.Application.ViewModels;
using Teste.Domain.Entities;

namespace Teste.Application.App
{
    public class FeedApp : IFeedApp
    {
        private readonly IMapper Mapper;

        public FeedApp(IMapper mapper)
        {
            Mapper = mapper;
        }

        public ResultVM GetInfoGeneral()
        {
            ResultVM resultVM = new ResultVM();
            Feed feed = new Feed();

            var dezTopicos = feed.GetDezTopicos();
            var totalPalavras = feed.GetTotalPalavras(dezTopicos);
            var palavras = feed.DeleteArtigosPreposicoes(totalPalavras);
            var dezPalavrasAbordadasQtdeVezes = feed.GetDezPalavrasAbordadasQtdeVezes(palavras);
            var qtdePalavrasPorTopico = feed.GetQtdePalavrasPorTopico(dezTopicos);

            resultVM.FeedsDezTopicos = Mapper.Map<List<FeedVM>>(dezTopicos);
            resultVM.DezPalavrasAbordadasQtdeVezes = Mapper.Map<List<WordVM>>(dezPalavrasAbordadasQtdeVezes);
            resultVM.QtdePalavrasPorTopico = qtdePalavrasPorTopico;

            return resultVM;
        }
    }
}
