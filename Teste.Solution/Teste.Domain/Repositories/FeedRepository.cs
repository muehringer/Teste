using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Teste.Domain.Entities;
using Teste.Domain.Interfaces;
using Teste.Infrastructure.Services;

namespace Teste.Domain.Repositories
{
    public class FeedRepository : IRepository
    {
        private MinutoSegurosRSS MinutoSegurosRSS;

        public FeedRepository() {
            MinutoSegurosRSS = new MinutoSegurosRSS();
        }

        public List<Feed> Get()
        {
            XDocument doc = XDocument.Parse(MinutoSegurosRSS.GetFeed());
            
            var feedItems = (from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
                             select item).ToList();

            List<Feed> feeds = new List<Feed>();

            feedItems.ForEach(item => {
                Feed feed = new Feed();

                feed.Title = Regex.Replace(item.Elements().First(i => i.Name.LocalName == "title").Value, "<[^>]*>", string.Empty);
                feed.Description = Regex.Replace(item.Elements().First(i => i.Name.LocalName == "description").Value, "<[^>]*>", string.Empty);

                feeds.Add(feed);
            });

            return feeds;
        }
    }
}
