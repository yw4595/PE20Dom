using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PE20Dom
{
    // Author: Yanzhi Wang
    // Purpose: This class represents a form that allows users to report their UFO sightings and displays them on a web page.
    // Restrictions: None
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // add the delegate method to be called after the webpage loads, set this up before Navigate()
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.WebBrowser1__DocumentCompleted);

            // if you want to use example.html from a local folder (saved in c:\temp for example):
            //this.webBrowser1.Navigate("c:\\temp\\example.html");

            // or if you want to use the URL  (only use one of these Navigate() statements)
            this.webBrowser1.Navigate("http://people.rit.edu/dxsigm/example.html");
        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;
            HtmlElement htmlElement;

            // Change the .InnerText of the first <h1> to "My UFO Page"
            htmlElementCollection = webBrowser.Document.GetElementsByTagName("h1");
            if (htmlElementCollection.Count > 0)
            {
                htmlElement = htmlElementCollection[0];
                htmlElement.InnerText = "My UFO Page";
            }

            // Change the .InnerText of the first <h2> to "My UFO Info"
            htmlElementCollection = webBrowser.Document.GetElementsByTagName("h2");
            if (htmlElementCollection.Count > 0)
            {
                htmlElement = htmlElementCollection[0];
                htmlElement.InnerText = "My UFO Info";
            }

            // Change the .InnerText of the 2nd <h2> to "My UFO Pictures"
            if (htmlElementCollection.Count > 1)
            {
                htmlElement = htmlElementCollection[1];
                htmlElement.InnerText = "My UFO Pictures";
            }

            // Change the .InnerText of the 3rd <h2> to an empty string - ""
            if (htmlElementCollection.Count > 2)
            {
                htmlElement = htmlElementCollection[2];
                htmlElement.InnerText = "";
            }

            // Select the <body> element and make 2 style changes:
            // a. The font-family shall be "sans-serif"
            // b. The font color shall be "reddish" (specify a red shade in hexadecimal).
            htmlElementCollection = webBrowser.Document.GetElementsByTagName("body");
            if (htmlElementCollection.Count > 0)
            {
                htmlElement = htmlElementCollection[0];
                htmlElement.Style = "font-family:sans-serif;color:#c43c35";
            }

            // Select the first paragraph and make some changes:
            // a. The inner HTML will contain the text "Report your UFO sightings here:" and have a working link to http://www.nuforc.org
            // b. There will be .Style changes:
            //    i. the font color is "green"
            //    ii. the font-weight is "bold"
            //    iii. the font-size is "2em"
            //    iv. the text-transform is "uppercase"
            //    v. the text-shadow is "3px 2px #A44"
            htmlElementCollection = webBrowser.Document.GetElementsByTagName("p");
            if (htmlElementCollection.Count > 0)
            {
                htmlElement = htmlElementCollection[0];
                htmlElement.InnerHtml = "Report your UFO sightings here: <a href=\"http://www.nuforc.org\">http://www.nuforc.org</a>";
                htmlElement.Style = "color:green; font-weight:bold; font-size:2em; text-transform:uppercase; text-shadow:3px 2px #A44;";
                // 14. Change the .InnerText of the 2nd paragraph to an empty string - ""
                htmlElementCollection = webBrowser.Document.GetElementsByTagName("p");
                if (htmlElementCollection.Count > 1)
                {
                    htmlElement = htmlElementCollection[1];
                    htmlElement.InnerText = "";
                }

                // 15. Insert an <img> element in the beginning of the 3rd paragraph to show an image of a UFO that is out on the web
                htmlElementCollection = webBrowser.Document.GetElementsByTagName("p");
                if (htmlElementCollection.Count > 2)
                {
                    htmlElement = htmlElementCollection[2];
                    HtmlElement imgElement = webBrowser.Document.CreateElement("img");
                    imgElement.SetAttribute("src", "https://picsum.photos/200/300");
                    htmlElement.InsertAdjacentElement(HtmlElementInsertionOrientation.BeforeBegin, imgElement);
                }

                // 16. Add a footer element to the end of the page which has a copyright (&copy;) notice, the current year and your name.
                HtmlElement footerElement = webBrowser.Document.CreateElement("footer");
                footerElement.InnerHtml = "&copy; " + DateTime.Now.Year.ToString() + " Yanzhi Wang";
                webBrowser.Document.Body.AppendChild(footerElement);

            }
        }
    } }
