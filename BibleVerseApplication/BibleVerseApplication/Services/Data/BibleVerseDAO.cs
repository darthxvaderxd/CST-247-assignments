/**
 *        file: Services/Data/BibleVerseDAO.cs
 * description: Data service for BibleVerse
 *      author: Richard Williamson
 *       notes: none
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BibleVerseApplication.Models;
using BibleVerseApplication.Utility;

namespace BibleVerseApplication.Services.Data
{
    public class BibleVerseDAO
    {
        ILogger Logger = Util.GetLogger();

        [Obsolete]
        public List<BibleVerse> Search(string Testament, string Book, int Chapter, int Verse)
        {
            Logger.Info("BibleVerseDAO Search() started");

            List<BibleVerse> verses = new List<BibleVerse>();
            string sql = "SELECT * FROM dbo.verse WHERE testament like @Testament AND book like @Book AND chapter = @Chapter ";

            // verse is not required so if is zero we do not search on it
            if (Verse > 0)
            {
                sql = sql + " AND verse = @Verse";
            }

            using (SqlConnection conn = new SqlConnection(Utility.Util.DB_CONN))
            {
                // paramatize our statement
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add("@Testament", Testament);
                command.Parameters.Add("@Book", Book);
                command.Parameters.Add("@Chapter", Chapter);

                // verse is not required so if is zero we do not search on it
                if (Verse > 0) 
                { 
                    command.Parameters.Add("@Verse", Verse);
                }

                // Try to access database and retrieve results
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results. If results add to highScoreList
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Create BibleVerse instance and populate
                            BibleVerse verse = new BibleVerse
                            {
                                Testament = reader["testament"].ToString(),
                                Book = reader["book"].ToString(),
                                Verse = reader["verse"].ToString(),
                                Chapter = reader["chapter"].ToString(),
                                Text = reader["text"].ToString(),
                            };

                            // Add verse to verses
                            verses.Add(verse);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Logger.Error("BibleVerseDAO Search() ERROR => " + e.Message);
                }
            }
            Logger.Info("BibleVerseDAO Search() complete");
            return verses;
        }

        [Obsolete]
        public void AddVerse(BibleVerse verse)
        {
            Logger.Info("BibleVerseDAO AddVerse() started");

            string sql = "INSERT INTO dbo.verse (testament, book, chapter, verse, text) VALUES (@Testament, @Book, @Chapter, @Verse, @Text)";

            using (SqlConnection conn = new SqlConnection(Utility.Util.DB_CONN))
            {
                // paramatize our statement
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add("@Testament", verse.Testament);
                command.Parameters.Add("@Book", verse.Book);
                command.Parameters.Add("@Chapter", verse.Chapter);
                command.Parameters.Add("@Verse", verse.Verse);
                command.Parameters.Add("@Text", verse.Text);

                // try to save...
                try
                {
                    conn.Open();
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Logger.Error("BibleVerseDAO AddVerse() ERROR => " + e.Message);
                }
            }
            Logger.Info("BibleVerseDAO AddVerse() complete");
        }
    }
}