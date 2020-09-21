using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _3080ReleaseTool
{
    public class CartAlert
    {
        string ukUrl = "https://www.nvidia.com/en-gb/geforce/graphics-cards/30-series/rtx-3080/";

        public Boolean checkForCartButton(string region)
        {
            try
            {
                if (region != "UK")
                {
                    throw new Exception("Region is incorrect");
                }
                string responseString = getWebsiteData(ukUrl);
                return responseString.IndexOf("add to cart", StringComparison.InvariantCultureIgnoreCase) >= 0;
            }
            catch
            {
                MessageBox.Show("Region Invalid");
                return false;
            }
        }

        public string getWebsiteData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            reader.Close();
            
            if(responseString != "")
            {
                return responseString;
            }
            else
            {
                return "ERROR";
            }
        }
    }
}
