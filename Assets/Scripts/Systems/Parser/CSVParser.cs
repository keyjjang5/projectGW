using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Util
{
    /*
     *  excel 첫 행은 각 카테고리의 이름, 이후에는 그것에 맞춰서 작성한다.
     *  사용 방법 : 
     *  Read("위치") 로 파일을 읽는다.
     *      위치는 Resource/ 이후로 작성
     *  List<Dictionary<string, object>> "name" = new List<Dictionary<string, object>>();
     *  으로 정의하고
     *  "name"[행 번호][카테고리의 이름]으로 원하는 데이터를 읽는다.
     */
    public class CSVParser
    {
        readonly static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        readonly static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
        readonly static char[] TRIM_CHARS = { '\"' };

        public static List<Dictionary<string, object>> Read(string file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            var list = new List<Dictionary<string, object>>();
            TextAsset data = Resources.Load(file) as TextAsset;

            var lines = Regex.Split(data.text, LINE_SPLIT_RE);

            if (lines.Length <= 1) return list;

            var header = Regex.Split(lines[0], SPLIT_RE);
            for (var i = 1; i < lines.Length; i++)
            {

                var values = Regex.Split(lines[i], SPLIT_RE);
                if (values.Length == 0 || values[0] == "") continue;

                var entry = new Dictionary<string, object>();
                for (var j = 0; j < header.Length && j < values.Length; j++)
                {
                    string value = values[j];

                    value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                    object finalvalue = value;

                    if (int.TryParse(value, out int n))
                    {
                        finalvalue = n;
                    }
                    else if (float.TryParse(value, out float f))
                    {
                        finalvalue = f;
                    }
                    entry[header[j]] = finalvalue;
                }
                list.Add(entry);
            }
            return list;
        }
    }
}