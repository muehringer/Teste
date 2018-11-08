using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Application.ViewModels
{
    public class ResultVM
    {
        public List<FeedVM> FeedsDezTopicos { get; set; }
        public List<WordVM> DezPalavrasAbordadasQtdeVezes { get; set; }
        public List<int> QtdePalavrasPorTopico { get; set; }
    }
}
