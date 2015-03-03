using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleApplication
{

   public class Downloads
   {
      public Downloads(string aURL)
      {
         PercentComplete = 0;
         Filename = "";
         Resolution = "";
         Length = "";
         URL = aURL;
         ResolutionInt = 1080;
      }
      public int PercentComplete { get; set; }
      public string Filename { get; set; }
      public string Resolution { get; set; }
      public int ResolutionInt;
      public string Length { get; set; }
      public string URL { get; set; }
   }
}
