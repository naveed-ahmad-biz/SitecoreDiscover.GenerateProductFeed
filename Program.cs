using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using SitecoreDiscover.GenerateProductFeed.Models;

namespace SitecoreDiscover.GenerateProductFeed
{
    /// <summary>
    /// This sample code converts the /me/product call from Sitecore OrderCloud into a TAB file as per the specficiations given at
    /// https://doc.sitecore.com/discover/en/developers/discover-developer-guide/product-data-feed-specifications.html
    /// The TAB file can then be used to send data to Sitecore Discover for initial bulk upload
    /// 
    /// 
    /// The JSON file is generated from the PLAY!Shop demo instance by calling /me/product API call and copying the generated output.
    /// The /me/product call is used by the PLAY!Shop demo to display initial list of products for an anonymous user.
    /// 
    /// The code is provided as-is without any warranty. This is a starting point, you will have to adjust the code and data models as per the
    /// JSON output/response for your own shop.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //read from the local json file from data/product_data.json location and convert to internal objects
            var data = Read(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\product_data.json"));
            //convert the file to TAB format
            ConvertToTabFile(data);            
            
        }
        /// <summary>
        /// Reads the JSON file from specific path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ProductDataItems Read(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                try
                {
                    string json = file.ReadToEnd();

                    return JsonConvert.DeserializeObject<ProductDataItems>(json);
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem reading file");

                    return null;
                }
            }
        }
        /// <summary>
        /// Converts the product data object into TAB delimited file, ready to bulk upload into Sitecore Discover
        /// </summary>
        /// <param name="data"></param>
        public static void ConvertToTabFile(ProductDataItems data)
        {
            try
            {
                //delimiter character for tab
                string tab = "\t";
                //We are only adding required fields, you can additional optional values in the headers, for more details see https://doc.sitecore.com/discover/en/developers/discover-developer-guide/product-data-feed-specifications.html
                string[] headerList = { 
                                        ProductFeedHeaders.product_group.ToString(), 
                                        ProductFeedHeaders.name.ToString(),
                                        ProductFeedHeaders.product_url.ToString(),
                                        ProductFeedHeaders.image_url.ToString(),
                                        ProductFeedHeaders.description.ToString(),
                                        ProductFeedHeaders.sku.ToString(),
                                        ProductFeedHeaders.sku_name.ToString(),
                                        ProductFeedHeaders.sku_url.ToString(),
                                        ProductFeedHeaders.sku_image_url.ToString(),
                                        ProductFeedHeaders.sku_description.ToString(),
                                        ProductFeedHeaders.ccids.ToString(),
                                        ProductFeedHeaders.price.ToString(),
                                        ProductFeedHeaders.final_price.ToString(),
                                        ProductFeedHeaders.is_active.ToString(),
                                        ProductFeedHeaders.brand.ToString() 
                                    };
                string detail = "";                
                string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\product_data_tab_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
                using (var sw = new StreamWriter(fileName, false))
                {

                    string header = string.Join(tab, headerList);
                    foreach (var product in data.Items)
                    {
                        string cleanDescription = Regex.Replace(product.Description, "<.*?>", String.Empty);
                        string[] lineList =
                        {
                         product.ID,
                         product.Name,
                         product.XP?.ProductUrl,
                         product.XP?.Images?.FirstOrDefault()?.Url,
                         cleanDescription.Replace("\n",string.Empty),
                         product.ID,
                         product.Name,
                         product.XP?.ProductUrl,
                         product.XP?.Images?.FirstOrDefault()?.Url,
                         cleanDescription.Replace("\n",string.Empty),
                         product.XP?.CCID,                         
                         product.PriceSchedule?.PriceBreaks?.FirstOrDefault()?.Price.ToString(),
                         product.PriceSchedule?.PriceBreaks?.FirstOrDefault()?.Price.ToString(),
                         "1",
                         product.XP?.Brand
                    };

                        string line = string.Join(tab, lineList);

                        detail += Environment.NewLine + line;
                    }

                    sw.Write(header + detail);
                    sw.Close();
                    Console.WriteLine("File Created:" + fileName);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem converting file" + ex.Message);

            }
        }

       
    }
}
