namespace BookStore.Importer
{
    using System.Linq;
    using BookStore.Data;
    using System.Xml.Linq;
    using System;
    using BookStore.Models;

    public class Program
    {
        private static string xmlFilesLocation = @"..\..\..\";
        private static string xmlImportFileName = @"complex-books.xml";
        private static string xmlSearchFileName = @"reviews-queries.xml";
        private static string xmlsearchResultFileName = @"reviews-search-results.xml";
        private static BookStoreDbContext db;

        static void Main()
        {
            db = new BookStoreDbContext();

            Import();
            Search();
        }

        private static void Search()
        {
            var xmlQueries = XElement.Load(xmlFilesLocation + xmlSearchFileName).Elements();
            var result = new XElement("search-result");

            foreach (var xmlQuery in xmlQueries)
            {
                var queryInReviews = db.Reviews.AsQueryable();
                if (xmlQuery.Attribute("type").Value == "by-period")
                {
                    var startDate = DateTime.Parse(xmlQuery.Element("start-date").Value);
                    var endDate = DateTime.Parse(xmlQuery.Element("end-date").Value);
                    queryInReviews = queryInReviews.Where(r => startDate <= r.CreateedOn && r.CreateedOn >= endDate);
                }
                else if (xmlQuery.Attribute("type").Value == "by-author")
                {
                    var authorName = xmlQuery.Element("author-name").Value;
                    queryInReviews = queryInReviews.Where(r => r.Author.Name == authorName);
                }

                var resultSet = queryInReviews
                    .OrderBy(r => r.CreateedOn)
                    .ThenBy(r => r.Content)
                    .Select(r => new
                    {
                        Date = r.CreateedOn,
                        Content = r.Content,
                        Book = new
                        {
                            Title = r.Book.Titles,
                            Authors = r.Book.Authors
                                    .AsQueryable()
                                    .OrderBy(a => a.Name)
                                    .Select(a => a.Name),
                            ISBN = r.Book.ISBN,
                            URL = r.Book.WebSite,
                        }
                    }).ToList();

                var xmlResultSet = new XElement("result-set");
                foreach (var reviewItem in resultSet)
                {
                    var xmlReview = new XElement("review");
                    xmlReview.Add(new XElement("date", reviewItem.Date.ToString("d-MMM-yyyy")));
                    xmlReview.Add(new XElement("content"), reviewItem.Content);

                    xmlResultSet.Add(xmlReview);
                }
                result.Add(xmlResultSet);
            }

            result.Save(xmlFilesLocation + xmlsearchResultFileName);
        }

        private static void Import()
        {
            var xmlBooks = XElement.Load(xmlFilesLocation + xmlImportFileName).Elements();

            foreach (var xmlBook in xmlBooks)
            {
                var currentBook = new Book();
                currentBook.Titles = xmlBook.Element("title").Value;

                var isbn = xmlBook.Element("isbn");
                if (isbn != null)
                {
                    var bookExist = db.Books.Any(b => b.ISBN == isbn.Value);
                    if (bookExist)
                    {
                        throw new ArgumentException("ISBN already exists");
                    }

                    currentBook.ISBN = isbn.Value;
                }

                var price = xmlBook.Element("price");
                if (price != null)
                {
                    currentBook.Price = decimal.Parse(price.Value);
                }

                var webSite = xmlBook.Element("web-site");
                if (webSite != null)
                {
                    currentBook.WebSite = webSite.Value;
                }

                var xmlAuthors = xmlBook.Element("authors");
                if (xmlAuthors != null)
                {
                    foreach (var xmlAuthor in xmlAuthors.Elements("author"))
                    {
                        var authorName = xmlAuthor.Value;
                        var author = GetAuthor(authorName);
                        currentBook.Authors.Add(author);
                    }
                }

                var xmlReviews = xmlBook.Element("reviews");
                if (xmlReviews != null)
                {
                    foreach (var xmlReview in xmlReviews.Elements("review"))
                    {
                        var reviewDate = xmlReview.Attribute("date");

                        var review = new Review
                        {
                            Content = xmlReview.Value,
                            CreateedOn = reviewDate == null ? DateTime.Today : DateTime.Parse(reviewDate.Value),
                        };

                        var authorName = xmlReview.Attribute("author");
                        if (authorName != null)
                        {
                            review.Author = GetAuthor(authorName.Value);
                        }

                        currentBook.Reviews.Add(review);
                    }
                }

                db.Books.Add(currentBook);
                db.SaveChanges();
            }
        }

        public static Author GetAuthor(string authorName)
        {
            var author = db.Authors.FirstOrDefault(a => a.Name == authorName);
            if (author == null)
            {
                author = new Author
                {
                    Name = authorName
                };
            }

            return author;
        }
    }
}
