using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ExtUsersLibrary.WebPagesPL.Common
{
    public static class PictureDefaulting
    {
        public static String DefPicPath { get; set; } = "/Content/UserPic/defPic.png";

        public static String GetDefPath(String curPath)
        {
            if (curPath!=null)
            {
                return curPath;
            }
            else
            {
                return DefPicPath;
            }
        }
        public static String GetBynaryImage(byte[] imBytes)
        {
            if (imBytes != null)
            {
                //return ImageToBinaryConverter.DeconvertToImage(imBytes);
                return "data:image/jpeg;base64,"+ImageToBinaryConverter.DeconvertToImage(imBytes);
            }
            else
            {
                return DefPicPath;
            }
        }
    }
}