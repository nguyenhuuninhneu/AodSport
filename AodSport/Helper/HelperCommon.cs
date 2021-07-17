using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace AodSport
{
    public class HelperCommon
    {

        public static string GetPath(string path = "~/", string filename = "")
        {
            var p = HttpContext.Current.Server.MapPath(path);
            return Path.Combine(p, filename);
        }
        public static string RemoveMark(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Trim();
                var charsToRemove = new string[] { "@", ",", ";", "'", "/", "\\", "\"", "[", "]", ":", "?", "=" };
                foreach (var c in charsToRemove)
                {
                    str = str.Replace(c, string.Empty);
                }
                const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ ";
                const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY-";
                int index = -1;
                char[] arrChar = FindText.ToCharArray();
                while ((index = str.IndexOfAny(arrChar)) != -1)
                {
                    int index2 = FindText.IndexOf(str[index]);
                    str = str.Replace(str[index], ReplText[index2]);
                }

            }
            return str;
        }
        public static string GetThumbnail(string FileName)
        {
            var ext = Path.GetExtension(FileName).ToLower();
            string icon = "";
            switch (ext)
            {
                case ".doc":
                case ".docx":
                    icon = "/Images/IconFile/WordIcon.png";
                    break;
                case ".xls":
                case ".xlsx":
                    icon = "/Images/IconFile/ExcelIcon.png";
                    break;
                case ".zip":
                case ".rar":
                    icon = "/Images/IconFile/ZipIcon.png";
                    break;
                case ".pdf":
                    icon = "/Images/IconFile/PDFIcon.png";
                    break;
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                    icon = FileName;
                    break;
                default:
                    icon = "/Images/IconFile/unknown.png";
                    break;
            }
            return icon;
        }
        public static string GetNameFile(string LinkFile)
        {
            var arrs = LinkFile.Split('/');
            var name1 = arrs[arrs.Count() - 1];
            var arrv = name1.Split(']');
            var FileName = arrv[arrv.Count() - 1];
            return FileName;
        }
        public static string Md5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            //get hash result after compute it
            var result = md5.Hash;

            var strBuilder = new StringBuilder();
            foreach (var t in result)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(t.ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public static async Task insert_filetoDb(string namefile = "", string linkfile = "", string replaceName = "", int id = 0, string code = "", string size = "")
        {
            //if (string.IsNullOrEmpty(replaceName))
            //    replaceName = namefile;
            //var fobj = new vFiles();
            //fobj.NameFile = namefile;
            //fobj.LinkFile = linkfile;
            //fobj.ReplaceName = replaceName;
            //fobj.Size = size;
            //fobj.ForeignID = HoSoID;
            //fobj.Code = code;
            //fobj.Status = 1;
            //fobj.CreateDate = DateTime.Now;
            //db.vFiles.Add(fobj);
            //await db.SaveChangesAsync();
        }

        public static Tuple<DateTime?, string> DateAndString(string s)
        {
            DateTime? DateResult = null;
            var strDate = "";

            try
            {
                s = s.Replace("_", "");
                string[] strArray;
                if (!string.IsNullOrEmpty(s))
                {
                    char charSplit = '/';
                    if (s.Contains('-'))
                    {
                        charSplit = '-';
                    }

                    strArray = s.Split(charSplit);
                    if (strArray.Length == 3)
                    {
                        int day = 0;
                        if (!string.IsNullOrEmpty(strArray[0]))
                            day = Convert.ToInt32(strArray[0]);

                        int month = 0;
                        if (day == 0)
                        {
                            if (!string.IsNullOrEmpty(strArray[1]))
                                month = Convert.ToInt32(strArray[1]);

                            if (month == 0)
                            {
                                month = 1;
                                strDate = strArray[2];
                            }
                            else
                            {
                                strDate = strArray[1] + "/" + strArray[2];
                            }
                            day = 1;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(strArray[1]))
                                month = Convert.ToInt32(strArray[1]);
                            if (month == 0)
                            {
                                month = 1;
                            }
                        }

                        if (!string.IsNullOrEmpty(strArray[2]))
                        {
                            DateResult = new DateTime(Convert.ToInt32(strArray[2]), month, day);
                        }
                        strDate = s;
                    }

                    if (strArray.Length == 2)
                    {
                        int month = 0;

                        if (!string.IsNullOrEmpty(strArray[0]))
                            month = Convert.ToInt32(strArray[0]);

                        if (month == 0)
                        {
                            month = 1;
                        }

                        if (!string.IsNullOrEmpty(strArray[1]))
                        {
                            DateResult = new DateTime(Convert.ToInt32(strArray[1]), month, 1);
                        }
                        strDate = s;
                    }

                    if (strArray.Length == 1)
                    {
                        if (!string.IsNullOrEmpty(strArray[0]))
                        {
                            DateResult = new DateTime(Convert.ToInt32(strArray[0]), 1, 1);
                        }
                        strDate = s;
                    }


                }

                return Tuple.Create(DateResult, strDate);
            }
            catch (Exception)
            {
                strDate = "False";
                return Tuple.Create(DateResult, strDate);
            }
        }
        public static string ConvertDateToString(DateTime? date, string format = "dd/MM/yyyy")
        {
            if (date == null) return "";
            var result = Convert.ToDateTime(date).ToString(format);
            return result;
        }
        public static DateTime ConvertDate(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                string[] dateStr = new string[] { };
                if (s.Contains('-'))
                {
                    dateStr = s.Split('-');
                    var swap = dateStr[0];
                    dateStr[0] = dateStr[2];
                    dateStr[2] = swap;
                }
                else
                {
                    dateStr = s.Split('/');
                }
                string Date = dateStr[1] + "/" + dateStr[0] + "/" + dateStr[2];
                DateTime Ngay = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[1]), Convert.ToInt32(dateStr[0]));
                return Ngay;
            }
            else return new DateTime(0001, 1, 1);
        }
        /// <summary>
        /// Set Level cho danh mục
        /// </summary>
        private static readonly Dictionary<string, int> DicLevel = new Dictionary<string, int>();
        private static int _level;

        public static object GetValueByName<T>(T obj, string fieldName)
        {
            var t = obj.GetType();

            var prop = t.GetProperty(fieldName);

            return prop.GetValue(obj);
        }
        public static object GetValueByName(object obj, string fieldName)
        {
            var t = obj.GetType();

            var prop = t.GetProperty(fieldName);

            return prop.GetValue(obj);
        }

        public static List<T> CreateLevel<T>(List<T> listAllCategory, string ParentId = "ParentId")
        {
            /*var lstCategory = (from g in listAllCategory where(GetValueByName(g, "Name").ToString().Contains("--")) select g).ToList();
            if (lstCategory.Count()>0)
            {

                foreach (var item in listAllCategory)
                {
                    var property = item.GetType().GetProperty("Level");
                    property.SetValue(item, Convert.ChangeType(0, property.PropertyType),null);
                }
                return listAllCategory;
            }*/
            var lstParent = (from g in listAllCategory
                             where ((int)GetValueByName(g, ParentId)) == 0
                             orderby (int)GetValueByName(g, "Ordering")
                             select g).ToList<T>();
            var lstOrder = new List<T>();
            FindChild(listAllCategory, lstParent, ref lstOrder, ParentId);
            return lstOrder;
        }

        public static void FindChild<T>(List<T> listAllCategory, List<T> lstParent, ref List<T> lstOrder, string ParentId = "ParentId")
        {
            using (var enumerator = lstParent.OrderBy(g => (int)GetValueByName(g, "Ordering")).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    Func<KeyValuePair<string, int>, bool> predicate = g => g.Key == GetValueByName(item, ParentId).ToString();
                    var pair = DicLevel.FirstOrDefault(predicate);
                    if (((int)GetValueByName(item, ParentId)) == 0)
                    {
                        _level = 0;
                    }
                    if (string.IsNullOrEmpty(pair.Key))
                    {
                        DicLevel.Add(GetValueByName(item, ParentId).ToString(), _level);
                    }
                    else
                    {
                        _level = pair.Value;
                    }
                    if (item != null)
                    {
                        var property = item.GetType().GetProperty("Level");
                        try
                        {
                            property.SetValue(item, _level, null);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                    Func<T, bool> func2 = g => GetValueByName(g, "Id").ToString() == GetValueByName(item, "Id").ToString();
                    if (!lstOrder.Where(func2).Any())
                    {
                        lstOrder.Add(item);
                    }
                    Func<T, bool> func3 = g => GetValueByName(g, ParentId).ToString() == GetValueByName(item, "Id").ToString();
                    var list = listAllCategory.Where<T>(func3).ToList<T>();
                    if (list.Count <= 0) continue;
                    foreach (var info2 in list.Select(local => item != null ? item.GetType().GetProperty("Level") : null))
                    {
                        try
                        {
                            info2.SetValue(item, _level, null);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                    _level++;
                    FindChild(listAllCategory, list, ref lstOrder);
                }
            }
        }
    }
}