using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Application.ViewModels;
using Teste.Domain.Entities;

namespace Teste.Application.ObjectMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Entity para ViewModel

            CreateMap<Feed, FeedVM>();
            CreateMap<Word, WordVM>();

            #endregion

            #region ViewModel para Entity

            CreateMap<FeedVM, Feed>();
            CreateMap<WordVM, Word>();

            #endregion
        }
    }
}
