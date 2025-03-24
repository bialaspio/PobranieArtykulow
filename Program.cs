using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglyToad.PdfPig.Content;
using System.Collections.Generic;
using System;

class Program
{
    static async Task Main(string[] args)
    {
        string outputDirectory = "PDFs";
        Directory.CreateDirectory(outputDirectory);

        string[] tmp_url = {
            "http://old.mbc.malopolska.pl/dlibra/publication/127787?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127788?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127789?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127790?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127791?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127792?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127793?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127794?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127795?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127796?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127797?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127798?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/126490?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/126503?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/126585?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/126643?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/126743?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/126793?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127068?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127099?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127163?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127186?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127270?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127271?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127470?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127471?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127594?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127677?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127718?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127947?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127948?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/127991?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128037?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128301?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128368?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128390?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128619?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128669?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128844?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128872?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128949?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128950?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129146?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129172?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129227?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129284?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129481?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129507?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128087?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128088?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128089?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128090?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128091?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128092?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128093?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128094?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128095?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128096?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128097?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128098?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128733?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128735?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128736?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128738?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128739?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128740?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128741?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128742?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128743?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128745?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128746?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128748?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129859?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129860?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129861?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129862?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129863?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129864?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129865?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129866?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129867?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129868?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129869?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129870?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128671?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128672?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128673?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128674?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128676?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128679?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128681?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128683?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128686?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128688?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128690?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/128692?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129536?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129537?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129587?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129615?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129666?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129695?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129745?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129794?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129897?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/129940?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130002?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130028?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130056?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130091?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130116?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130146?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130231?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130262?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130293?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130294?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130344?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130371?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130400?tab=3",
            "http://old.mbc.malopolska.pl/dlibra/publication/130427?tab=3"
};



        HttpClient client = new HttpClient();

        foreach (var url in tmp_url)
        {
            try
            {
                string pageContent = await client.GetStringAsync(url);
                List<string> contentLinks = ExtractContentLinks(pageContent);

                foreach (var contentLink in contentLinks)
                {
                    try
                    {
                        string pdfUrlPattern = @"http?://[^""]+\.pdf";
                        string pageContentPDF = await client.GetStringAsync(contentLink);

                        Match match = Regex.Match(pageContentPDF, pdfUrlPattern);
                        if (match.Success)
                        {
                            string pdfUrl = match.Value;
                            Uri uri = new Uri(pdfUrl);
                            string contentUrl = GetContentUrlFromQuery(uri.Query);

                            if (contentUrl != null)
                            {
                                string pdfNewUrl = $"{uri.Scheme}://{uri.Host}{contentUrl}";
                                Console.WriteLine(pdfNewUrl);
                                byte[] pdfBytes = await client.GetByteArrayAsync(pdfNewUrl);

                                using (MemoryStream stream = new MemoryStream(pdfBytes))
                                using (UglyToad.PdfPig.PdfDocument document = UglyToad.PdfPig.PdfDocument.Open(stream))
                                {
                                    bool found = false;

                                    foreach (Page page in document.GetPages())
                                    {
                                        string text = page.Text;

                                        if (Regex.IsMatch(text, "MAGDALENALINK", RegexOptions.IgnoreCase) ||
                                            Regex.IsMatch(text, "MAGDALENA LINK", RegexOptions.IgnoreCase))
                                        {
                                            found = true;
                                            break;
                                        }
                                    }

                                    if (found)
                                    {
                                        string fileName = Path.Combine(outputDirectory, $"{Path.GetFileNameWithoutExtension(pdfNewUrl)}.pdf");
                                        await File.WriteAllBytesAsync(fileName, pdfBytes);
                                        Console.WriteLine($"Saved: {fileName}");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{pdfUrl},No,content_url parameter not found");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{contentLink},No,PDF URL not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{contentLink},Error,{ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{url},Error,{ex.Message}");
            }
        }
    }

    static List<string> ExtractContentLinks(string htmlContent)
    {
        List<string> contentLinks = new List<string>();
        Regex regex = new Regex(@"<a[^>]*href=""(.*?)""[^>]*class=""contentTriggerStruct""", RegexOptions.IgnoreCase);

        MatchCollection matches = regex.Matches(htmlContent);

        foreach (Match match in matches)
        {
            contentLinks.Add(match.Groups[1].Value);
        }

        return contentLinks;
    }

    static string GetContentUrlFromQuery(string query)
    {
        var queryParams = query.TrimStart('?').Split('&');
        foreach (var param in queryParams)
        {
            var keyValue = param.Split('=');
            if (keyValue[0] == "content_url")
            {
                return keyValue[1];
            }
        }
        return null;
    }
}