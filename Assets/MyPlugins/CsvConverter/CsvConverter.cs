using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CsvConverter
{
	public static string[] ToOneArray(TextAsset rawCsv)
	{
		StringReader reader = new StringReader(rawCsv.text);
		string str = "";

		while (reader.Peek() != -1) // reader.Peaekが-1になるまで
		{
			string line = reader.ReadLine(); // 一行ずつ読み込み
			str +=  line + ",";
		}

		string[] returnValue = str.Split(',');
		return returnValue;
	} 
    
}
