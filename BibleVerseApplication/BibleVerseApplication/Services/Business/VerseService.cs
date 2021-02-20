/**
 *        file: Services/Business/VerseService.cs
 * description: Data service for BibleVerse
 *      author: Richard Williamson
 *       notes: none
 */

using BibleVerseApplication.Models;
using BibleVerseApplication.Services.Data;
using BibleVerseApplication.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Services.Business
{
    public class VerseService
    {
        ILogger Logger = Util.GetLogger();
        BibleVerseDAO service = new BibleVerseDAO();

        [Obsolete]
        public void AddVerse(BibleVerse verse)
        {
            Logger.Info("VerseService AddVerse() started");

            // first check that the verse does not already exist
            try
            {
                Logger.Info("VerseService AddVerse() Verifying the verse does not already exist");
                List<BibleVerse> versesCheck = service.Search(verse.Testament, verse.Book, int.Parse(verse.Chapter), int.Parse(verse.Verse));

                if (versesCheck == null || versesCheck.Count == 0)
                {
                    Logger.Info("VerseService AddVerse() verse is not in database");
                    service.AddVerse(verse);
                } else
                {
                    Logger.Info("VerseService AddVerse() verse was already in database");
                }
            } catch (Exception e)
            {
                Logger.Error("VerseService AddVerse() error => " + e.Message);
            }
            Logger.Info("VerseService AddVerse() stopped");
        }

        [Obsolete]
        public List<BibleVerse> SearchVerse(Search verse)
        {
            Logger.Info("VerseService SearchVerse() started");
            List<BibleVerse> verses = new List<BibleVerse>();

            // first check that the verse does not already exist
            try
            {
                Logger.Info("VerseService SearchVerse() Performing lookup");

                int verseNo = verse.Verse != null ? int.Parse(verse.Verse) : 0;
                verses = service.Search(verse.Testament, verse.Book, int.Parse(verse.Chapter), verseNo);

                if (verses == null || verses.Count == 0)
                {
                    Logger.Info("VerseService SearchVerse() no verses is not in database");

                }
                else
                {
                    Logger.Info("VerseService SearchVerse() " + verses.Count + " verses found");
                }
            }
            catch (Exception e)
            {
                Logger.Error("VerseService SearchVerse() error => " + e.Message);
            }
            Logger.Info("VerseService SearchVerse() stopped");

            return verses;
        }
    }
}