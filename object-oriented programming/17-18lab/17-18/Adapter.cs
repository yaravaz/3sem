using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab17_18
{
    public interface IGenre
    {
        void Read();
    }
    public class Genre : IGenre
    {
        public void Read()
        {
            WriteLine("Вы читаете книгу");
        }
    }
    public class AReader
    {
        public void Reading(IGenre genre)
        {
            genre.Read();
        }
    }
    interface IArticle
    {
        void Learn();
    }
    public class Article : IArticle
    {
        public void Learn()
        {
            WriteLine("Изучение статьи");
        }
    }
    public class ArticleAdapter : IGenre
    {
        private Article article;
        public ArticleAdapter(Article article)
        {
            this.article = article;
        }

        public void Read()
        {
            WriteLine("Вы изучаете статью");
        }
    }
}
